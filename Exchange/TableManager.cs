using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exchange
{
    public class TableManager
    {
       static public void Initialize(Table ExchangeHistory ,Label error)
        {
            ClearTheData(ExchangeHistory);
            AddHeaders(ExchangeHistory);
            try
            {
                using (UserContext db = new UserContext())
                {
                    var users = db.Users;
                    foreach (User u in users)
                    {
                        AddUserToTable(u, ExchangeHistory);
                    }
                }
            }
            catch
            {
                error.BorderColor = System.Drawing.Color.Red;
                error.Text = "Error ,look's like something's wrong with database";
            }
        }
        static public void UpdateTable(Table ExchangeHistory, string FromCurrency , double FromAmount , string ToCurrency ,double ToAmount , string Date)
        {
            using (UserContext db = new UserContext())
            {
                User addedRow = new User { FromCurrency = FromCurrency , FromAmount  = FromAmount , ToCurrency = ToCurrency, ToAmount= ToAmount , Date = Date };
                db.Users.Add(addedRow);
                db.SaveChanges();
                AddUserToTable(addedRow, ExchangeHistory);
            }
        }
        private static void AddUserToTable(User u ,Table ExchangeHistory)
        {
           
            TableRow r = new TableRow();
            for (int i = 0; i < 6; i++)
            {
                TableCell c = new TableCell();
                switch (i)
                {                       
                    case 0:
                        c.Controls.Add(new LiteralControl(u.Id.ToString()));
                        break;
                    case 1:
                        c.Controls.Add(new LiteralControl(u.FromCurrency));
                        break;
                    case 2:
                        c.Controls.Add(new LiteralControl(u.FromAmount.ToString()));
                        break;
                    case 3:
                        c.Controls.Add(new LiteralControl(u.ToCurrency));
                        break;
                    case 4:
                        c.Controls.Add(new LiteralControl(u.ToAmount.ToString()));
                        break;
                    case 5:
                        c.Controls.Add(new LiteralControl(u.Date));
                        break;
                }
                r.Cells.Add(c);
            }
            ExchangeHistory.Rows.Add(r);
        }
        private static void ClearTheData(Table ExchangeHistory)
        {
            ExchangeHistory.Rows.Clear();
        }
        public static void Sort(Table ExchangeHistory , string field , CheckBoxList Order)
        {
            ClearTheData(ExchangeHistory);
            AddHeaders(ExchangeHistory);
            using (UserContext db = new UserContext())
            {
                var users = db.Users.OrderByDescending(x => x.Id);
                switch (field)
                {
                    case "Id": if(Order.SelectedValue == "Descending")users = db.Users.OrderByDescending(x => x.Id);
                    else users = db.Users.OrderBy(x => x.Id);
                        break;
                    case "FromCurrency":
                       if (Order.SelectedValue == "Descending")users = db.Users.OrderByDescending(x => x.FromCurrency);
                        else users = db.Users.OrderBy(x => x.FromCurrency);
                        break;
                    case "FromAmount":
                        if (Order.SelectedValue == "Descending") users = db.Users.OrderByDescending(x => x.FromAmount);
                       else users = db.Users.OrderBy(x => x.FromAmount);
                        break;
                    case "ToCurrency":
                        if (Order.SelectedValue == "Descending") users = db.Users.OrderByDescending(x => x.ToCurrency);
                        else users = db.Users.OrderBy(x => x.ToCurrency);
                        break;
                    case "ToAmount":
                        if (Order.SelectedValue == "Descending") users = db.Users.OrderByDescending(x => x.ToAmount);
                        else users = db.Users.OrderBy(x => x.ToAmount);
                        break;
                    case "Date":
                        if (Order.SelectedValue == "Descending") users = db.Users.OrderByDescending(x => x.Date);
                        else users = db.Users.OrderBy(x => x.Date);
                        break;
                }
                foreach (User u in users)
                {
                    AddUserToTable(u, ExchangeHistory);
                }
            }
        }
        public static void Filter(Table ExchangeHistory , string searchValue , string field , TextBox line)
        {
            try
            {
                ClearTheData(ExchangeHistory);
                AddHeaders(ExchangeHistory);
                using (UserContext db = new UserContext())
                {
                    int searchId = new int();
                    double searchDouble = new double();
                    if (field == "Id") searchId = Int32.Parse(searchValue);
                    if (field == "FromAmount" || field == "ToAmount") searchDouble = double.Parse(searchValue);
                    var users = db.Users.Where(x => x.Id == searchId);
                    switch (field)
                    {
                        case "Id":
                            users = db.Users.Where(x => x.Id == searchId);
                            break;
                        case "FromCurrency":
                            users = db.Users.Where(x => x.FromCurrency == searchValue);
                            break;
                        case "FromAmount":
                            users = db.Users.Where(x => x.FromAmount == searchDouble);
                            break;
                        case "ToCurrency":
                            users = db.Users.Where(x => x.ToCurrency == searchValue);
                            break;
                        case "ToAmount":
                            users = db.Users.Where(x => x.ToAmount == searchDouble);
                            break;
                        case "Date":
                            users = db.Users.Where(x => x.Date == searchValue);
                            break;
                    }
                    foreach (User u in users)
                    {
                        AddUserToTable(u, ExchangeHistory);
                    }
                }
            }
            catch
            {
                line.BorderColor = System.Drawing.Color.Red;
                line.Text = "Wrong Data Type";
            }
        }
        private static void AddHeaders(Table ExchangeHistory)
        {
            string[] fields = { "Id", "FromCurrency", "FromAmount", "ToCurrency", "ToAmount", "Date" };
            TableHeaderRow b = new TableHeaderRow();
            for (int i = 0; i < 6; i++)
            {
                TableHeaderCell bc = new TableHeaderCell();
                bc.Controls.Add(new LiteralControl(fields[i]));
                b.Cells.Add(bc);
            }
            ExchangeHistory.Rows.Add(b);
        }
    }
}