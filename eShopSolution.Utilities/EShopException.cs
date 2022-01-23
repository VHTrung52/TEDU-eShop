using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Utilities
{
    public class EShopException : Exception
    {
        public EShopException()
        {
            
        }

        public EShopException(string message)
            : base(message)
        {

        }

        public EShopException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
