using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exchange
{
    public class Rates
    {
       public static double GetRate(string rates, string currency)
        {
            string resRate = "";
            for (int i = rates.IndexOf(currency) + 5; rates[i] != ','; i++)
            {
                if (rates[i] == '.') resRate +=  ',';
                else resRate += rates[i];
            }
            return double.Parse(resRate); 
        }
        public static double Exchange(double baseAmount, double rateTo)
        {
            return baseAmount * rateTo;
        }
    }
}