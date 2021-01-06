using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjAssignment;
using ProjSharedLib;

namespace ProjUnitTest
{

    namespace TestProject
    {
        [TestClass]
        public class AllUnitTest
        {
            LoggingHelper logHelper;
            private bool _isInitialized;

            public AllUnitTest()
            {

                if (!_isInitialized)
                {
                    TestClassInitialize();
                    _isInitialized = true;
                }

            }

            public void TestClassInitialize()
            {
                logHelper = new LoggingHelper();
            }

            [TestMethod]
            public void TestItem_A_Qty1()
            {
                string msg = string.Empty;
                msg = string.Format("Start of Unit Test : {0} ", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);

                PriceCalculator price = new PriceCalculator();
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.orderItems.Add(new Item("A", 1));
                price.CalTotalPriceOfOrder(orderDetails);

                Assert.AreEqual(orderDetails.validItems[0].Amount, 59.90);
                Assert.AreEqual(orderDetails.Amount, 60);
                msg = string.Format("End of Unit Test : {0} \n--------------------", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
            }

            [TestMethod]
            public void TestItem_A_Qty10()
            {
                string msg = string.Empty;
                msg = string.Format("Start of Unit Test : {0} ", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
                PriceCalculator price = new PriceCalculator();
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.orderItems.Add(new Item("A", 10));
                price.CalTotalPriceOfOrder(orderDetails);

                Assert.AreEqual(orderDetails.validItems[0].Amount, 59.9 * 7);
                Assert.AreEqual(orderDetails.Amount, 419);
                msg = string.Format("End of Unit Test : {0} \n--------------------", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
            }

            [TestMethod]
            public void TestItem_B_Qty1()
            {
                string msg = string.Empty;
                msg = string.Format("Start of Unit Test : {0} ", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
                PriceCalculator price = new PriceCalculator();
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.orderItems.Add(new Item("B", 1));

                price.CalTotalPriceOfOrder(orderDetails);
                Assert.AreEqual(orderDetails.Amount, 399);
                msg = string.Format("End of Unit Test : {0} \n--------------------", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
            }

            [TestMethod]
            public void TestItem_B_Qty5()
            {
                string msg = string.Empty;
                msg = string.Format("Start of Unit Test : {0} ", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
                PriceCalculator price = new PriceCalculator();
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.orderItems.Add(new Item("B", 5));
                price.CalTotalPriceOfOrder(orderDetails);

                Assert.AreEqual(orderDetails.validItems[0].Amount, (999 + 399 * 2));
                Assert.AreEqual(orderDetails.Amount, (999 + 399 * 2));
                msg = string.Format("End of Unit Test : {0} \n--------------------", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
            }
            [TestMethod]
            public void TestItem_C_Qty1()
            {
                string msg = string.Empty;
                msg = string.Format("Start of Unit Test : {0} ", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
                PriceCalculator price = new PriceCalculator();
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.orderItems.Add(new Item("C", 1));

                price.CalTotalPriceOfOrder(orderDetails);
                Assert.AreEqual(orderDetails.validItems[0].Amount, 19.54);
                msg = string.Format("End of Unit Test : {0} \n--------------------", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);

            }

            [TestMethod]
            public void TestRoundOff_Ceiling()
            {
                string msg = string.Empty;
                msg = string.Format("Start of Unit Test : {0} ", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
                PriceCalculator price = new PriceCalculator();
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.orderItems.Add(new Item("C", 1));
                price.CalTotalPriceOfOrder(orderDetails);

                Assert.AreEqual(orderDetails.Amount, 20);
                msg = string.Format("End of Unit Test : {0} \n--------------------", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
            }
            [TestMethod]
            public void TestRoundOff_Floor()
            {
                string msg = string.Empty;
                msg = string.Format("Start of Unit Test : {0} ", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
                PriceCalculator price = new PriceCalculator();
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.orderItems.Add(new Item("C", 1.1f));
                price.CalTotalPriceOfOrder(orderDetails);

                Assert.AreEqual(orderDetails.Amount, 21);
                msg = string.Format("End of Unit Test : {0} \n--------------------", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
            }
            [TestMethod]
            public void TestItem_C_QtyFraction()
            {
                string msg = string.Empty;
                msg = string.Format("Start of Unit Test : {0} ", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
                PriceCalculator price = new PriceCalculator();
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.orderItems.Add(new Item("C", 1.5f));

                price.CalTotalPriceOfOrder(orderDetails);
                Assert.AreEqual(orderDetails.validItems[0].Amount, (19.54 * 1.5));
                Assert.AreEqual(orderDetails.Amount, Math.Round(19.54 * 1.5));
                msg = string.Format("End of Unit Test : {0} \n--------------------", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
            }



            [TestMethod]
            public void TestItem_ABC_Together()
            {
                string msg = string.Empty;
                msg = string.Format("Start of Unit Test : {0} ", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
                PriceCalculator price = new PriceCalculator();
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.orderItems.Add(new Item("A", 7));
                orderDetails.orderItems.Add(new Item("B", 7));
                orderDetails.orderItems.Add(new Item("C", 1));

                price.CalTotalPriceOfOrder(orderDetails);
                Assert.AreEqual(orderDetails.Amount, 2716);
                msg = string.Format("End of Unit Test : {0} \n--------------------", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
            }
            [TestMethod]
            public void TestInvalidItem()
            {
                string msg = string.Empty;
                msg = string.Format("Start of Unit Test : {0} ", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
                PriceCalculator price = new PriceCalculator();
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.orderItems.Add(new Item("A", 5));
                orderDetails.orderItems.Add(new Item("B", 8));
                orderDetails.orderItems.Add(new Item("Z", 2.5f));

                price.CalTotalPriceOfOrder(orderDetails);
                var abc = price.CalTotalPriceOfOrder(orderDetails);
                Assert.AreEqual(orderDetails.inValidItems.Count, 1);
                Assert.AreEqual(orderDetails.inValidItems[0].Comment, AllConstants.ItemNotFound);
                msg = string.Format("End of Unit Test : {0} \n--------------------", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
            }

            [TestMethod]
            public void TestAllInvalidItem()
            {
                string msg = string.Empty;
                msg = string.Format("Start of Unit Test : {0} ", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
                PriceCalculator price = new PriceCalculator();
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.orderItems.Add(new Item("AA", 5));
                orderDetails.orderItems.Add(new Item("BB", 8));
                orderDetails.orderItems.Add(new Item("Z", 2.5f));

                price.CalTotalPriceOfOrder(orderDetails);
                var abc = price.CalTotalPriceOfOrder(orderDetails);
                Assert.AreEqual(orderDetails.inValidItems.Count, 3);
                Assert.AreEqual(orderDetails.validItems.Count, 0);
                msg = string.Format("End of Unit Test : {0} \n--------------------", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
            }

            [TestMethod]
            public void TestInvalidItem2()
            {
                string msg = string.Empty;
                msg = string.Format("Start of Unit Test : {0} ", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
                PriceCalculator price = new PriceCalculator();
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.orderItems.Add(new Item("A", 1.5f));
                price.CalTotalPriceOfOrder(orderDetails);

                var abc = price.CalTotalPriceOfOrder(orderDetails);
                Assert.AreEqual(orderDetails.inValidItems.Count, 1);
                Assert.AreEqual(orderDetails.inValidItems[0].Comment, AllConstants.InvalidOrderQuantity);
                msg = string.Format("End of Unit Test : {0} \n--------------------", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
            }

            [TestMethod]
            public void TestQuantityNegative()
            {
                string msg = string.Empty;
                msg = string.Format("Start of Unit Test : {0} ", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
                PriceCalculator price = new PriceCalculator();
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.orderItems.Add(new Item("A", -1));
                price.CalTotalPriceOfOrder(orderDetails);
                Assert.AreEqual(orderDetails.inValidItems[0].Comment, AllConstants.QuantityNegative);
                msg = string.Format("End of Unit Test : {0} \n--------------------", MethodBase.GetCurrentMethod());
                logHelper.LogInfo(msg);
            }
        }

    }
}
