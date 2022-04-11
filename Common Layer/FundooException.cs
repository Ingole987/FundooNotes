using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Common_Layer
{
    public class FundooException : Exception
    {
        public FundooException() : base() { }

        public FundooException(string message) : base(message) { }

        public FundooException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
