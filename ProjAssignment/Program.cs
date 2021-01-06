
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjSharedLib;

namespace ProjAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggingHelper logHelper = new LoggingHelper();
            OrderDetails orderDetails = null;
            string msg = string.Empty;

            try
            {
                orderDetails = new OrderDetails();
                PriceCalculator price = new PriceCalculator();

                orderDetails.orderItems.Add(new Item("A", 5));
                //orderDetails.orderItems.Add(new Item("Z", 5));
                orderDetails.orderItems.Add(new Item("B", 8));
                orderDetails.orderItems.Add(new Item("E", 2.5f));
              

                orderDetails.Amount = price.CalTotalPriceOfOrder(orderDetails);

                msg = string.Format(string.Format("Num of valid items: {0}", orderDetails.validItems.Count));
                Console.WriteLine(msg);            
                msg = string.Format("Num of In-valid items: {0}", orderDetails.inValidItems.Count);
                Console.WriteLine(msg);
            
                foreach (Item item in orderDetails.validItems)
                {
                    msg = string.Format("Item Name: {0}, Amount: {1}", item.Name, item.Amount);
                    Console.WriteLine(msg);
                }
                Console.WriteLine(string.Format("Total Amount {0}", orderDetails.Amount));
                
            }
            catch (Exception ex)
            {               
                logHelper.LogException(LogLevel.Error, ex, ex.Message.ToString());
                logHelper.LogInfo(msg);
            }
            Console.Read();
        }
    }
}
