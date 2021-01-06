using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProjAssignment;
using ProjSharedLib;

namespace ProjUnitTest
{

    namespace TestProject
    {
        [TestClass]
        public class AllTests
        {
            [TestClass]
            public class AllUnitTest
            {
                [TestMethod]
                public void TestItem_A_Qty1()
                {
                    PriceCalculator price = new PriceCalculator();
                    OrderDetails orderDetails = new OrderDetails();

                    orderDetails.orderItems.Add(new Item("A", 1));
                    price.CalTotalPriceOfOrder(orderDetails);

                    Assert.AreEqual(orderDetails.validItems[0].Amount, 59.90);
                    Assert.AreEqual(orderDetails.Amount, 60);
                }

                [TestMethod]
                public void TestItem_A_Qty10()
                {
                    PriceCalculator price = new PriceCalculator();
                    OrderDetails orderDetails = new OrderDetails();

                    orderDetails.orderItems.Add(new Item("A", 10));
                    price.CalTotalPriceOfOrder(orderDetails);

                    Assert.AreEqual(orderDetails.validItems[0].Amount, 59.9 * 7);
                    Assert.AreEqual(orderDetails.Amount, 419);
                }

                [TestMethod]
                public void TestItem_B_Qty1()
                {
                    PriceCalculator price = new PriceCalculator();
                    OrderDetails orderDetails = new OrderDetails();

                    orderDetails.orderItems.Add(new Item("B", 1));

                    price.CalTotalPriceOfOrder(orderDetails);
                    Assert.AreEqual(orderDetails.Amount, 399);
                }

                [TestMethod]
                public void TestItem_B_Qty5()
                {
                    PriceCalculator price = new PriceCalculator();
                    OrderDetails orderDetails = new OrderDetails();

                    orderDetails.orderItems.Add(new Item("B", 5));
                    price.CalTotalPriceOfOrder(orderDetails);

                    Assert.AreEqual(orderDetails.validItems[0].Amount, (999 + 399 * 2));
                    Assert.AreEqual(orderDetails.Amount, (999 + 399 * 2));
                }
                [TestMethod]
                public void TestItem_C_Qty1()
                {
                    PriceCalculator price = new PriceCalculator();
                    OrderDetails orderDetails = new OrderDetails();

                    orderDetails.orderItems.Add(new Item("C", 1));

                    price.CalTotalPriceOfOrder(orderDetails);
                    Assert.AreEqual(orderDetails.validItems[0].Amount, 19.54);

                }

                [TestMethod]
                public void TestRoundOff_Ceiling()
                {
                    PriceCalculator price = new PriceCalculator();
                    OrderDetails orderDetails = new OrderDetails();

                    orderDetails.orderItems.Add(new Item("C", 1));
                    price.CalTotalPriceOfOrder(orderDetails);

                    Assert.AreEqual(orderDetails.Amount, 20);
                }
                [TestMethod]
                public void TestRoundOff_Floor()
                {
                    PriceCalculator price = new PriceCalculator();
                    OrderDetails orderDetails = new OrderDetails();

                    orderDetails.orderItems.Add(new Item("C", 1.1f));
                    price.CalTotalPriceOfOrder(orderDetails);

                    Assert.AreEqual(orderDetails.Amount, 21);
                }
                [TestMethod]
                public void TestItem_C_QtyFraction()
                {
                    PriceCalculator price = new PriceCalculator();
                    OrderDetails orderDetails = new OrderDetails();

                    orderDetails.orderItems.Add(new Item("C", 1.5f));

                    price.CalTotalPriceOfOrder(orderDetails);
                    Assert.AreEqual(orderDetails.validItems[0].Amount, (19.54 * 1.5));
                    Assert.AreEqual(orderDetails.Amount, Math.Round(19.54 * 1.5));
                }



                [TestMethod]
                public void TestItem_ABC_Together()
                {
                    PriceCalculator price = new PriceCalculator();
                    OrderDetails orderDetails = new OrderDetails();

                    orderDetails.orderItems.Add(new Item("A", 7));
                    orderDetails.orderItems.Add(new Item("B", 7));
                    orderDetails.orderItems.Add(new Item("C", 1));

                    price.CalTotalPriceOfOrder(orderDetails);
                    Assert.AreEqual(orderDetails.Amount, 2716);
                }
                [TestMethod]
                public void TestInvalidItem()
                {
                    PriceCalculator price = new PriceCalculator();
                    OrderDetails orderDetails = new OrderDetails();

                    orderDetails.orderItems.Add(new Item("A", 5));
                    orderDetails.orderItems.Add(new Item("B", 8));
                    orderDetails.orderItems.Add(new Item("Z", 2.5f));

                    price.CalTotalPriceOfOrder(orderDetails);
                    var abc = price.CalTotalPriceOfOrder(orderDetails);
                    Assert.AreEqual(orderDetails.inValidItems.Count, 1);
                    Assert.AreEqual(orderDetails.inValidItems[0].Comment, AllConstants.ItemNotFound);
                }

                [TestMethod]
                public void TestAllInvalidItem()
                {
                    PriceCalculator price = new PriceCalculator();
                    OrderDetails orderDetails = new OrderDetails();

                    orderDetails.orderItems.Add(new Item("AA", 5));
                    orderDetails.orderItems.Add(new Item("BB", 8));
                    orderDetails.orderItems.Add(new Item("Z", 2.5f));

                    price.CalTotalPriceOfOrder(orderDetails);
                    var abc = price.CalTotalPriceOfOrder(orderDetails);
                    Assert.AreEqual(orderDetails.inValidItems.Count, 3);
                    Assert.AreEqual(orderDetails.validItems.Count, 0);
                }

                [TestMethod]
                public void TestInvalidItem2()
                {
                    PriceCalculator price = new PriceCalculator();
                    OrderDetails orderDetails = new OrderDetails();

                    orderDetails.orderItems.Add(new Item("A", 1.5f));
                    price.CalTotalPriceOfOrder(orderDetails);

                    var abc = price.CalTotalPriceOfOrder(orderDetails);
                    Assert.AreEqual(orderDetails.inValidItems.Count, 1);
                    Assert.AreEqual(orderDetails.inValidItems[0].Comment, AllConstants.InvalidOrderQuantity);
                }

                [TestMethod]
                public void TestQuantityNegative()
                {
                    PriceCalculator price = new PriceCalculator();
                    OrderDetails orderDetails = new OrderDetails();

                    orderDetails.orderItems.Add(new Item("A", -1));
                    price.CalTotalPriceOfOrder(orderDetails);
                    Assert.AreEqual(orderDetails.inValidItems[0].Comment, AllConstants.QuantityNegative);
                }



                //[TestMethod]
                //[ExpectedException(typeof(ItemNotFoundException))]
                //public void TestItemOutOfStock()
                //{
                //    PriceCalculator price = new PriceCalculator();
                //    Dictionary<string, float> keyVal = new Dictionary<string, float>();
                //    double totalAmount = 0;
                //    keyVal.Add("A", 100);

                //    var abc = price.CalTotalPriceOfOrder(keyVal, ref totalAmount);
                //}


            }
        }
    }
}
