using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Exchange
{
    public class RequsetRate
    {
        public static string GetDataForRate(string currency )
        {
            string request = "https://api.exchangeratesapi.io/latest?base=" + currency; // api.exchangeratesapi.io/latest?symbols=USD,GBP
            WebRequest requestObjGet = WebRequest.Create(request);
            requestObjGet.Method = "GET";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();
            string resultResponse = "";
            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader key = new StreamReader(stream);
                resultResponse = key.ReadToEnd();
                key.Close();
            }
            return resultResponse;
        }
    }
}