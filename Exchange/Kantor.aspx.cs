using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exchange
{
    public partial class Kantor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            TableManager.Initialize(ExchangeHistory ,error);
            
        }

        protected void Exchange(object sender, EventArgs e)
        {
            try
            {
                amountFrom.BorderColor = System.Drawing.Color.LimeGreen;
                string request = curFrom.Text;
                string resultResponse = RequsetRate.GetDataForRate(request);
                double curToRate = Rates.GetRate(resultResponse, curTo.Text);
                amountTo.Text = Rates.Exchange(double.Parse(amountFrom.Text), curToRate).ToString();
                TableManager.UpdateTable(ExchangeHistory, curFrom.Text, double.Parse(amountFrom.Text), curTo.Text, double.Parse(amountTo.Text), DateTime.Now.ToString());
            }
            catch
            {
                amountFrom.BorderColor = System.Drawing.Color.Red;
                amountFrom.Text = "Incorrect Format";
            }
        }

        protected void Sort(object sender, EventArgs e)
        {
            TableManager.Sort(ExchangeHistory, field.Text ,Order);
        }

        protected void Filter(object sender, EventArgs e)
        {
            if (search.Text != "")
            {
                search.BorderColor = System.Drawing.Color.LimeGreen;
                TableManager.Filter(ExchangeHistory, search.Text, field.Text, search);
            }
            else
            {
                search.Text = "Required field is empty!";
                search.BorderColor = System.Drawing.Color.Red;
            }
            
        }

        protected void All(object sender, EventArgs e)
        {
            TableManager.Initialize(ExchangeHistory,error);
        }

        protected void Switch(object sender, EventArgs e)
        {
            int buffer =curFrom.SelectedIndex;
            amountFrom.Text = amountTo.Text;
            amountTo.Text = "";
            curFrom.SelectedIndex = curTo.SelectedIndex;
            curTo.SelectedIndex = buffer;
        }
    }
}