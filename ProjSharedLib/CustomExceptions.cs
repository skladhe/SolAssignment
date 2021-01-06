using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSharedLib
{
    public class PriceCalcExceptions : Exception
    {

    }

    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException()
        {
        }

        public ItemNotFoundException(string message)
            : base(message)
        {
        }

        public ItemNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class OrderQtyNotValidException : Exception
    {
        public OrderQtyNotValidException()
        {
        }

        public OrderQtyNotValidException(string message)
            : base(message)
        {
        }

        public OrderQtyNotValidException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}