using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using ProjDAL;
using ProjSharedLib;

namespace ProjAssignment
{
    public class PriceCalculator
    {
        ECModel objEc;
        List<ProdDiscount> prodDiscounts;
        List<MastProduct> prodMast;
        List<ProdPricing> prodPricing;
        LoggingHelper logHelper;

        public PriceCalculator()
        {
            logHelper = new LoggingHelper();
            PopulateAllTables();
        }

        private void PopulateAllTables()
        {
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["ECModel"].ToString();
                objEc = new ECModel(connString);
                prodDiscounts = objEc.ProdDiscounts.ToList<ProdDiscount>();
                prodMast = objEc.MastProducts.ToList<MastProduct>();
                prodPricing = objEc.ProdPricings.ToList<ProdPricing>();
            }
            catch (Exception ex)
            {
                logHelper.LogException(LogLevel.Error, ex, ex.Message);
            }
        }

        public long CalAmountAllItems(OrderDetails orderDetails)
        {
            double orderAmount = 0;
            long roundOffAmount = 0;
            string msg = string.Format("Order # {0} Amount Calculation Started", orderDetails.orderNo);
            logHelper.LogInfo(msg);
            try
            {
                foreach (var item in orderDetails.validItems)
                {
                    string itemName = item.Name;
                    float itemQty = item.Quantity;
                    item.Amount = GetPriceOfEachItem(item.ProdID, itemQty);
                    msg = string.Format("Item Name: {0}, Amount: {1}", item.Name, item.Amount);
                    logHelper.LogInfo(msg);
                    orderAmount += item.Amount;
                }
            }
            catch (Exception ex)
            {
                logHelper.LogException(LogLevel.Error, ex, ex.Message);
                throw ex;
            }
            roundOffAmount = Convert.ToInt64(Math.Round(orderAmount));
            msg = string.Format("Order # {0}  Total Amount = {1}", orderDetails.orderNo, roundOffAmount);
            logHelper.LogInfo(msg);
            msg = string.Format("Order # {0} Ended", orderDetails.orderNo);
            logHelper.LogInfo(msg);
            return roundOffAmount;
        }


        internal OrderDetails GetAllValidItems(OrderDetails currentOrder)
        {
            string msg = string.Empty;
            int intProdId = -1;
            string UnitOfSales = string.Empty;
            currentOrder.validItems = new List<Item>();
            currentOrder.inValidItems = new List<Item>();

            msg = string.Format("Order # {0} Validation Started", currentOrder.orderNo);
            logHelper.LogInfo(msg);

            try
            {
                foreach (var item in currentOrder.orderItems)
                {
                    intProdId = -1;
                    float itemQty = item.Quantity;
                    var prodDetails = (from prod in
                              prodMast.Where(a => a.ProdName == item.Name)
                                       select (prod.ProdID, prod.UnitOfSales)).FirstOrDefault();


                    intProdId = prodDetails.ProdID;
                    UnitOfSales = prodDetails.UnitOfSales;
                    if (itemQty < 0)
                    {
                        item.Comment = AllConstants.QuantityNegative;
                        currentOrder.inValidItems.Add(item);
                        msg = string.Format("Invalid Item found: Name {0} , Reason {1}", item.Name, AllConstants.QuantityNegative);
                        logHelper.LogError(msg);
                        continue;
                        //throw new ItemNotFoundException();
                    }
                    if (intProdId <= 0)
                    {
                        item.Comment = AllConstants.ItemNotFound;
                        currentOrder.inValidItems.Add(item);
                        msg = string.Format("Invalid Item found: Name {0} , Reason {1}", item.Name, AllConstants.ItemNotFound);
                        logHelper.LogError(msg);
                        continue;
                        //throw new ItemNotFoundException();
                    }

                    if (UnitOfSales.Equals(AllConstants.INTEGER))
                    {
                        bool isInt = (itemQty == Math.Truncate(itemQty));
                        if (!isInt)
                        {
                            item.Comment = AllConstants.InvalidOrderQuantity;
                            currentOrder.inValidItems.Add(item);
                            msg = string.Format("Invalid Item found: Name {0} , Reason {1}", item.Name, AllConstants.InvalidOrderQuantity);
                            logHelper.LogError(msg);
                            continue;
                            //throw new OrderQtyNotValidException();
                        }
                    }
                    item.ProdID = intProdId;
                    currentOrder.validItems.Add(item);
                }

                msg = string.Format(string.Format("Num of valid items: {0}", currentOrder.validItems.Count));
                logHelper.LogInfo(msg);

                msg = string.Format("Num of In-valid items: {0}", currentOrder.inValidItems.Count);
                logHelper.LogInfo(msg);
                msg = string.Format("Order # {0} Validation Ended", currentOrder.orderNo);
                logHelper.LogInfo(msg);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                logHelper.LogException(LogLevel.Error, ex, msg);
            }
            return currentOrder;
        }


        private double GetPriceOfEachItem(long intProdId, float itemQty)
        {
            double itemTotalPrice = 0;

            var curProdDiscount = prodDiscounts.Where(a => a.ProdID == intProdId)
                                              .OrderBy(a => a.DiscPriority)
                                              .ToList<ProdDiscount>();

            float remQty = itemQty;
            int i = 0;
            int count = curProdDiscount.Count;

            try
            {
                while (remQty > 0)
                {
                    string discType = string.Empty;
                    float division = 0;
                    int minOrderQty = 1;
                    discType = "NOT_APPLY";
                    if (i < count)
                    {
                        minOrderQty = Convert.ToInt32(curProdDiscount[i].MinOrderQty);
                        discType = curProdDiscount[i].DiscType;
                        division = ((int)remQty) / minOrderQty;
                    }
                    else
                    {
                        division = remQty;
                    }
                    itemTotalPrice += CalculatePriceForDicType(discType, division, intProdId);
                    remQty = remQty - division * minOrderQty;
                    i++;
                };
                itemTotalPrice = Math.Round(itemTotalPrice, 2);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw ex;
            }
            return itemTotalPrice;
        }


        private double CalculatePriceForDicType(string discType, float division, long prodId)
        {
            double amount = 0;
            try
            {
                switch (discType)
                {
                    case "FIXEDPRICE":
                        amount = GetFixedPrice(division, prodId);
                        break;

                    case "FREE_ON_MIN_QTY":
                        amount = GetFreeOnMinQtyPrice(division, prodId);
                        break;

                    case "FLAT_PERCENT":
                        amount = GetFlatPercentPrice(division, prodId);
                        break;

                    default:
                        amount = GetPriceWithNoDicount(division, prodId);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return amount;
        }

        private double GetPriceWithNoDicount(float division, long prodId)
        {
            double price = 0;
            try
            {
                var prodPriceDetails = prodPricing.Where(a => a.ProdID == prodId).First();
                price = division * Convert.ToDouble(prodPriceDetails.BasePrice);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Convert.ToDouble(price);
        }

        private double GetFlatPercentPrice(float division, long prodId)
        {
            double price = 0;
            try
            {
                var prodDetails = prodDiscounts.Where(a => a.ProdID == prodId && a.DiscType == "FLAT_PERCENT").First();
                var prodPriceDetails = prodPricing.Where(a => a.ProdID == prodId).First();

                double perCent = prodDetails.DiscPercent is null ? 0 : (100 - Convert.ToDouble(prodDetails.DiscPercent)) / 100.0;

                price = division * Convert.ToDouble(prodPriceDetails.BasePrice) * perCent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Convert.ToDouble(price);
        }

        private double GetFreeOnMinQtyPrice(float division, long prodId)
        {
            double price = 0;
            try
            {
                var prodDetails = prodDiscounts.Where(a => a.ProdID == prodId && a.DiscType == "FREE_ON_MIN_QTY").First();
                var prodPriceDetails = prodPricing.Where(a => a.ProdID == prodId).First();
                price = division * Convert.ToDouble(prodDetails.ChargeForQty) * Convert.ToDouble(prodPriceDetails.BasePrice);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Convert.ToDouble(price);
        }

        private double GetFixedPrice(float division, long prodId)
        {
            double price = 0;
            try
            {
                var prodDetails = prodDiscounts.Where(a => a.ProdID == prodId && a.DiscType == "FIXEDPRICE").First();

                price = division * Convert.ToDouble(prodDetails.FixedPrice);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Convert.ToDouble(price);
        }

        public long CalTotalPriceOfOrder(OrderDetails orderDetails)
        {
            long totalAmount = 0;
            try
            {
                OrderDetails validOrer = this.GetAllValidItems(orderDetails);
                if (validOrer.validItems.Count > 0)
                {
                    totalAmount = this.CalAmountAllItems(orderDetails);
                }
                orderDetails.Amount = totalAmount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return totalAmount;
        }
    }
}