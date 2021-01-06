using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAssignment
{
    public class OrderDetails 
    {
        public long orderNo;
        public long Amount;
        public List<Item> orderItems;
        public List<Item> validItems;
        public List<Item> inValidItems;
        private bool isDisposed;

        public OrderDetails()
        {
            orderNo = GenerateOrderNo();
            Amount = 0;
            orderItems = new List<Item>();
            LoggingHelper logHelper = new LoggingHelper();
            string msg = string.Format("Order # {0} processing started", this.orderNo);
            logHelper.LogInfo(msg);
        }

        public long GenerateOrderNo()
        {
            Random _random = new Random();
            return _random.Next(1, 99999);
        }
    }

    public class Item
    {
        public long itemNo;
        public long ProdID;
        public string Name;
        public float Quantity;
        public double Amount;
        public string Comment;

        public Item(string itemName, float itemQuantity)
        {
            this.Name = itemName;
            this.Quantity = itemQuantity;
        }

        public Item(Item item)
        {
            this.Name = item.Name;
            this.Quantity = item.Quantity;
            this.Comment = item.Comment;
        }
    }
}

