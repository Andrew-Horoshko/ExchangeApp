using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exchange
{
    public class User
    {
        public int Id { get; set; }
        public string FromCurrency { get; set; }
        public double FromAmount { get; set; }
        public string ToCurrency { get; set; }
        public double ToAmount { get; set; }
        public string Date { get; set; }
    }
}