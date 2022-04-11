using Common_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Service
{
    public class ExampleErrorService
    {
        public ExampleErrorService()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="FundooException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public void ExampleErrors()
        {
            //// a custom app exception that will return a 400 response
            throw new FundooException("Email or password is incorrect");

            //// a key not found exception that will return a 404 response
            throw new KeyNotFoundException("Account not found");
        }
    }
}
