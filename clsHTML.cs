//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
// Application used to browse and buy jerseys.
// Class Purpose:
// This class is used to produce htmls for the application.
// 

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    class clsHTML
    {
        //method to generate receipt
        public static StringBuilder GenerateReceipt(List<string> strItems, List<int> intQuantity, List<string> strItemTotal, List<string> strPrice, string strOrderID, string strName, string strPhone, string strSub, string strTax, string strTotalAmount)
        {
            StringBuilder sbHtml = new StringBuilder();
            StringBuilder sbCss = new StringBuilder();

            sbCss.Append("<style> ");
            sbCss.Append("body {background-color: #ccc;font-family: Verdana;}");
            sbCss.Append("header {margin-top: 40px;}");
            sbCss.Append("footer {background-color: #ffffff;}");
            sbCss.Append("div.invoice {background-color: #ffffff; border: 1px solid #ccc; height: 802pt; margin-left: auto; margin-right: auto; padding: 10px; width: 595pt;}");
            sbCss.Append("div.company-address {border: 1px solid #ccc; float: left; width: 200pt;}");
            sbCss.Append("div.invoice-details {border: 1px solid #ccc; float: right; width: 200pt;}");
            sbCss.Append("div.customer-info {border: 1px solid #ccc; float: left; margin-bottom: 50px; margin-top: 100px; width: 200pt;}");
            sbCss.Append("div.item-table-panel {height: 460pt;}");
            sbCss.Append("div.clear-fix {clear: both; float: none;}");
            sbCss.Append("table.item-table {border: 1px solid #ccc; width: 100%;}");
            sbCss.Append("table.footer-table {border: 1px solid #ccc; margin-top: 20pt; bottom: 0; width: 100%;}");
            sbCss.Append("th {border: 1px solid #ccc; text-align: left;}");
            sbCss.Append("th.itemname {width: 380px;}");
            sbCss.Append("th.price {text-align: center; width: 80px;}");
            sbCss.Append("th.quantity {text-align: right; width: 100px;}");
            sbCss.Append("th.total-price {text-align: right; width: 100px;}");
            sbCss.Append("tr {} td {border-bottom: 1px solid #ccc;}");
            sbCss.Append("td.totals {background-color: #ffffff; text-align: right; width: 110px;}");
            sbCss.Append(".text-left {text-align: left;}");
            sbCss.Append(".text-center {text-align: center;}");
            sbCss.Append(".text-right {text-align: right;}");
            sbCss.Append("</style>");


            sbHtml.Append("<html>");
            sbHtml.Append($"<head>{sbCss}</head>");
            sbHtml.Append($"<body>");
            sbHtml.Append($"<div class='invoice'> <header> <div class='company-address'><b>AE Sporting Fits</b></div> ");
            sbHtml.Append("<div class='invoice-details'>Order #: " + strOrderID + "<br /> Date: " + DateTime.Now.ToString() + "</div>");
            sbHtml.Append("</header><section>");
            if (clsSQL.strPositionTitle != "Manager")
            {
                sbHtml.Append("<div class='customer-info'>Customer: " + strName + "<br /> Phone #: " + strPhone + "<br /> </div> </section>");
            }
            else
            {
                sbHtml.Append("<div class='customer-info'>Customer: " + strName + "<br /> Phone #: " + strPhone + "<br /> <br /> Manager: " + clsSQL.strName + "<br /> </div> </section>");
            }
            sbHtml.Append("<div class='clear-fix'> </div> <section>");
            sbHtml.Append("<div class='item-table-panel'> <table border = '0' " +
                "cellspacing='0' class='item-table'> <tr> <th class='itemname'> Item </th> <th class='price'> Item Price </th> <th class='quantity'> Quantity </th> " +
                "<th class='total-price'> Total Price </th> </tr> ");

            
            for (int i = 0; i < strItems.Count; i++)
            {
                sbHtml.Append("<tr>");
                sbHtml.Append("<td>" + strItems[i] + "</td>");
                sbHtml.Append("<td class='text-center'>" + strPrice[i] + "</td>");
                sbHtml.Append("<td class='text-right'>x" + intQuantity[i].ToString() + "</td>");
                sbHtml.Append("<td class='text-right'>" + strItemTotal[i] + "</td>");
                sbHtml.Append("</tr>");
            }            

            sbHtml.Append(" </table> </div> </section> <footer> <table border = '0' cellspacing='0' class='footer-table'> ");
            sbHtml.Append("<tr>");
            sbHtml.Append("<td class='text-right'>Sub total</td>");
            sbHtml.Append("<td class='totals'>" + strSub + "</td>");
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.Append("<td class='text-right'>Tax</td>");
            sbHtml.Append("<td class='totals'>" + strTax +"</td>");
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.Append("<td class='text-right'><b>TOTAL</b></td>");
            sbHtml.Append("<td class='totals'><b>" + strTotalAmount + "</b></td>");
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.Append("<td class='text-center'><b>Thank you for Shopping with us!</b></td>");
            sbHtml.Append("</tr>");
            sbHtml.Append("</table> </footer> </div>");

            sbHtml.Append("</body></html>");

            return sbHtml;

        }

        public static StringBuilder GenerateReceiptDiscount(List<string> strItems, List<int> intQuantity, List<string> strItemTotal, List<string> strPrice, string strOrderID, string strName, string strPhone, string strGross, string strSub, string strDiscount, string strTax, string strTotalAmount, string strDType)
        {
            StringBuilder sbHtml = new StringBuilder();
            StringBuilder sbCss = new StringBuilder();

            sbCss.Append("<style> ");
            sbCss.Append("body {background-color: #ccc;font-family: Verdana;}");
            sbCss.Append("header {margin-top: 40px;}");
            sbCss.Append("footer {background-color: #ffffff;}");
            sbCss.Append("div.invoice {background-color: #ffffff; border: 1px solid #ccc; height: 802pt; margin-left: auto; margin-right: auto; padding: 10px; width: 595pt;}");
            sbCss.Append("div.company-address {border: 1px solid #ccc; float: left; width: 200pt;}");
            sbCss.Append("div.invoice-details {border: 1px solid #ccc; float: right; width: 200pt;}");
            sbCss.Append("div.customer-info {border: 1px solid #ccc; float: left; margin-bottom: 50px; margin-top: 100px; width: 200pt;}");
            sbCss.Append("div.item-table-panel {height: 460pt;}");
            sbCss.Append("div.clear-fix {clear: both; float: none;}");
            sbCss.Append("table.item-table {border: 1px solid #ccc; width: 100%;}");
            sbCss.Append("table.footer-table {border: 1px solid #ccc; margin-top: 20pt; bottom: 0; width: 100%;}");
            sbCss.Append("th {border: 1px solid #ccc; text-align: left;}");
            sbCss.Append("th.itemname {width: 380px;}");
            sbCss.Append("th.price {text-align: center; width: 80px;}");
            sbCss.Append("th.quantity {text-align: right; width: 100px;}");
            sbCss.Append("th.total-price {text-align: right; width: 100px;}");
            sbCss.Append("tr {} td {border-bottom: 1px solid #ccc;}");
            sbCss.Append("td.totals {background-color: #ffffff; text-align: right; width: 110px;}");
            sbCss.Append(".text-left {text-align: left;}");
            sbCss.Append(".text-center {text-align: center;}");
            sbCss.Append(".text-right {text-align: right;}");
            sbCss.Append("</style>");


            sbHtml.Append("<html>");
            sbHtml.Append($"<head>{sbCss}</head>");
            sbHtml.Append($"<body>");
            sbHtml.Append($"<div class='invoice'> <header> <div class='company-address'><b>AE Sporting Fits</b></div> ");
            sbHtml.Append("<div class='invoice-details'>Order #: " + strOrderID + "<br /> Date: " + DateTime.Now.ToString() + "</div>");
            sbHtml.Append("</header><section>");
            if (clsSQL.strPositionTitle != "Manager")
            {
                sbHtml.Append("<div class='customer-info'>Customer: " + strName + "<br /> Phone #: " + strPhone + "<br /> </div> </section>");
            }
            else
            {
                sbHtml.Append("<div class='customer-info'>Customer: " + strName + "<br /> Phone #: " + strPhone + "<br /> <br /> Manager: " + clsSQL.strName + "<br /> </div> </section>");
            }
            sbHtml.Append("<div class='clear-fix'> </div> <section>");
            sbHtml.Append("<div class='item-table-panel'> <table border = '0' " +
                "cellspacing='0' class='item-table'> <tr> <th class='itemname'> Item </th> <th class='price'> Item Price </th> <th class='quantity'> Quantity </th> " +
                "<th class='total-price'> Total Price </th> </tr> ");

            
            for (int i = 0; i < strItems.Count; i++)
            {
                sbHtml.Append("<tr>");
                sbHtml.Append("<td>" + strItems[i] + "</td>");
                sbHtml.Append("<td class='text-center'>" + strPrice[i] + "</td>");
                sbHtml.Append("<td class='text-right'>x" + intQuantity[i].ToString() + "</td>");
                sbHtml.Append("<td class='text-right'>" + strItemTotal[i] + "</td>");
                sbHtml.Append("</tr>");
            }
            

            sbHtml.Append(" </table> </div> </section> <footer> <table border = '0' cellspacing='0' class='footer-table'> ");
            sbHtml.Append("<tr>");
            sbHtml.Append("<td class='text-right'>Sub total</td>");
            sbHtml.Append("<td class='totals'>" + strGross + "</td>");
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");            
            if(strDType.Contains("%"))
            {
                sbHtml.Append("<td class='text-right'>Discount -                 " + strDType + "</td>");
            }
            else
            {
                sbHtml.Append("<td class='text-right'>Discount</td>");
            }
            sbHtml.Append("<td class='totals'>-(" + strDiscount + ")</td>");
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.Append("<td class='text-right'>Discounted Sub total</td>");
            sbHtml.Append("<td class='totals'>" + strSub + "</td>");
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.Append("<td class='text-right'>Tax</td>");
            sbHtml.Append("<td class='totals'>" + strTax + "</td>");
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.Append("<td class='text-right'><b>TOTAL</b></td>");
            sbHtml.Append("<td class='totals'><b>" + strTotalAmount + "</b></td>");
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.Append("<td class='text-center'><b>Thank you for Shopping with us!</b></td>");
            sbHtml.Append("</tr>");
            sbHtml.Append("</table> </footer> </div>");

            sbHtml.Append("</body></html>");

            return sbHtml;

        }

        //method to generate sales reports
        public static StringBuilder GenerateDailySales(SqlCommand cmdDaily)
        {
            clsSQL.OpenDatabase();
            StringBuilder sbHtml = new StringBuilder();
            StringBuilder sbCss = new StringBuilder();
            string strInfo = "";
            SqlDataReader rdDaily;

            cmdDaily.ExecuteNonQuery();

            rdDaily = cmdDaily.ExecuteReader();

            sbCss.Append("<style>");
            sbCss.Append("td {padding:5px;text-align:center;font-weight:bold;text-align:center}");
            sbCss.Append("</style>");

            sbHtml.Append("<html>");
            sbHtml.Append($"<head>{sbCss}<title>{"Daily Sales"}</title></head>");
            sbHtml.Append($"<body>");
            sbHtml.Append($"<h1>{"Daily Sales"}</h1>");

            sbHtml.Append("<table>");
            sbHtml.Append("<tr><td colspan=6></td></tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td>OrderID</td>");
            sbHtml.Append("<td>Order Date</td>");
            sbHtml.Append("<td>Product Name</td>");
            sbHtml.Append("<td>Quantity Sold</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            while (rdDaily.Read())
            {
                strInfo = rdDaily.GetString(4);
                sbHtml.Append($"<td>{rdDaily.GetInt32(0)}</td>");
                sbHtml.Append($"<td>{Convert.ToDateTime(rdDaily.GetDateTime(1)).ToString("MM/dd/yyyy")}</td>");
                sbHtml.Append($"<td>{rdDaily.GetString(2)}</td>");
                sbHtml.Append($"<td>{rdDaily.GetInt32(3)}</td>");
                sbHtml.Append("</tr>");
            }


            sbHtml.Append("<tr><td colspan=7></td></tr>");
            sbHtml.Append("</table>");
            if (strInfo != "")
            {
                sbHtml.Append("<p>Total Daily Sales</p>");
                sbHtml.Append($"<p>{strInfo}</p>");
            }
            sbHtml.Append("</body></html>");

            rdDaily.Close();
            clsSQL.CloseDatabase();
            return sbHtml;
        }
        public static StringBuilder GenerateWeeklySales(SqlCommand cmdWeekly)
        {
            clsSQL.OpenDatabase();
            StringBuilder sbHtml = new StringBuilder();
            StringBuilder sbCss = new StringBuilder();
            string strInfo = "";
            SqlDataReader rdWeekly;

            cmdWeekly.ExecuteNonQuery();

            rdWeekly = cmdWeekly.ExecuteReader();

            sbCss.Append("<style>");
            sbCss.Append("td {padding:5px;text-align:center;font-weight:bold;text-align:center}");
            sbCss.Append("</style>");

            sbHtml.Append("<html>");
            sbHtml.Append($"<head>{sbCss}<title>{"Weekly Sales"}</title></head>");
            sbHtml.Append($"<body>");
            sbHtml.Append($"<h1>{"Weekly Sales"}</h1>");

            sbHtml.Append("<table>");
            sbHtml.Append("<tr><td colspan=6></td></tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td>OrderID</td>");
            sbHtml.Append("<td>Order Date</td>");
            sbHtml.Append("<td>Daily Sales Total</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            while (rdWeekly.Read())
            {
                strInfo = rdWeekly.GetString(3);
                sbHtml.Append($"<td>{rdWeekly.GetInt32(0)}</td>");
                sbHtml.Append($"<td>{Convert.ToDateTime(rdWeekly.GetDateTime(1)).ToString("MM/dd/yyyy")}</td>");
                sbHtml.Append($"<td>{rdWeekly.GetString(2)}</td>");
                sbHtml.Append("</tr>");
            }

            sbHtml.Append("<tr><td colspan=7></td></tr>");
            sbHtml.Append("</table>");
            if (strInfo != "")
            {
                sbHtml.Append("<p>Total Weekly Sales</p>");
                sbHtml.Append($"<p>{strInfo}</p>");
            }
            sbHtml.Append("</body></html>");

            rdWeekly.Close();
            clsSQL.CloseDatabase();
            return sbHtml;
        }
        public static StringBuilder GenerateMonthlySales(SqlCommand cmdMonthly)
        {
            clsSQL.OpenDatabase();
            StringBuilder sbHtml = new StringBuilder();
            StringBuilder sbCss = new StringBuilder();
            string strInfo = "";
            SqlDataReader rdMonthly;

            cmdMonthly.ExecuteNonQuery();

            rdMonthly = cmdMonthly.ExecuteReader();

            sbCss.Append("<style>");
            sbCss.Append("td {padding:5px;text-align:center;font-weight:bold;text-align:center}");
            sbCss.Append("</style>");

            sbHtml.Append("<html>");
            sbHtml.Append($"<head>{sbCss}<title>{"Monthly Sales"}</title></head>");
            sbHtml.Append($"<body>");
            sbHtml.Append($"<h1>{"Monthly Sales"}</h1>");

            sbHtml.Append("<table>");
            sbHtml.Append("<tr><td colspan=6></td></tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td>OrderID</td>");
            sbHtml.Append("<td>Order Date</td>");
            sbHtml.Append("<td>Weekly Sales Total</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            while (rdMonthly.Read())
            {
                strInfo = rdMonthly.GetString(3);
                sbHtml.Append($"<td>{rdMonthly.GetInt32(0)}</td>");
                sbHtml.Append($"<td>{Convert.ToDateTime(rdMonthly.GetDateTime(1)).ToString("MM/dd/yyyy")}</td>");
                sbHtml.Append($"<td>{rdMonthly.GetString(2)}</td>");
                sbHtml.Append("</tr>");
            }

            sbHtml.Append("<tr><td colspan=7></td></tr>");
            sbHtml.Append("</table>");
            if (strInfo != "")
            {
                sbHtml.Append("<p>Total Monthly Sales</p>");
                sbHtml.Append($"<p>{strInfo}</p>");
            }
            sbHtml.Append("</body></html>");

            rdMonthly.Close();
            clsSQL.CloseDatabase();
            return sbHtml;
        }

        //method to generate inventory reports
        public static StringBuilder GenerateInventoryAvailable(SqlCommand cmdAvailable)
        {
            clsSQL.OpenDatabase();
            StringBuilder sbHtml = new StringBuilder();
            StringBuilder sbCss = new StringBuilder();
            string strInfo = "";
            SqlDataReader rdAvailable;
            DateTime dateToday = DateTime.Now;

            cmdAvailable.ExecuteNonQuery();

            rdAvailable = cmdAvailable.ExecuteReader();

            sbCss.Append("<style>");
            sbCss.Append("td {padding:5px;text-align:center;font-weight:bold;text-align:center}");
            sbCss.Append("</style>");

            sbHtml.Append("<html>");
            sbHtml.Append($"<head>{sbCss}<title>{"Available Inventory Report"}</title></head>");
            sbHtml.Append($"<body>");
            sbHtml.Append($"<h1>{"Available Inventory Report"}</h1>");

            sbHtml.Append("<table>");
            sbHtml.Append("<tr><td colspan=6></td></tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td>InventoryID</td>");
            sbHtml.Append("<td>Item Name</td>");
            sbHtml.Append("<td>Cost</td>");
            sbHtml.Append("<td>Retail Price</td>");
            sbHtml.Append("<td>Quantity</td>");
            sbHtml.Append("<td>Restock Threshold</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            while (rdAvailable.Read())
            {
                strInfo = dateToday.ToString("MM/dd/yyyy");
                sbHtml.Append($"<td>{rdAvailable.GetInt32(0)}</td>");
                sbHtml.Append($"<td>{rdAvailable.GetString(1)}</td>");
                sbHtml.Append($"<td>{rdAvailable.GetString(2)}</td>");
                sbHtml.Append($"<td>{rdAvailable.GetString(3)}</td>");
                sbHtml.Append($"<td>{rdAvailable.GetInt32(4)}</td>");
                sbHtml.Append($"<td>{rdAvailable.GetInt32(5)}</td>");
                sbHtml.Append("</tr>");
            }

            sbHtml.Append("<tr><td colspan=7></td></tr>");
            sbHtml.Append("</table>");
            if (strInfo != "")
            {
                sbHtml.Append("<p>Date of Report</p>");
                sbHtml.Append($"<p>{strInfo}</p>");
            }
            sbHtml.Append("</body></html>");

            rdAvailable.Close();
            clsSQL.CloseDatabase();
            return sbHtml;
        }
        public static StringBuilder GenerateInventoryFull(SqlCommand cmdFull)
        {
            clsSQL.OpenDatabase();
            StringBuilder sbHtml = new StringBuilder();
            StringBuilder sbCss = new StringBuilder();
            string strInfo = "";
            SqlDataReader rdFull;
            DateTime dateToday = DateTime.Now;

            cmdFull.ExecuteNonQuery();

            rdFull = cmdFull.ExecuteReader();

            sbCss.Append("<style>");
            sbCss.Append("td {padding:5px;text-align:center;font-weight:bold;text-align:center}");
            sbCss.Append("</style>");

            sbHtml.Append("<html>");
            sbHtml.Append($"<head>{sbCss}<title>{"Full Inventory Report"}</title></head>");
            sbHtml.Append($"<body>");
            sbHtml.Append($"<h1>{"Full Inventory Report"}</h1>");

            sbHtml.Append("<table>");
            sbHtml.Append("<tr><td colspan=6></td></tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td>InventoryID</td>");
            sbHtml.Append("<td>Item Name</td>");
            sbHtml.Append("<td>Cost</td>");
            sbHtml.Append("<td>Retail Price</td>");
            sbHtml.Append("<td>Quantity</td>");
            sbHtml.Append("<td>Restock Threshold</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            while (rdFull.Read())
            {
                strInfo = dateToday.ToString("MM/dd/yyyy");
                sbHtml.Append($"<td>{rdFull.GetInt32(0)}</td>");
                sbHtml.Append($"<td>{rdFull.GetString(1)}</td>");
                sbHtml.Append($"<td>{rdFull.GetString(2)}</td>");
                sbHtml.Append($"<td>{rdFull.GetString(3)}</td>");
                sbHtml.Append($"<td>{rdFull.GetInt32(4)}</td>");
                sbHtml.Append($"<td>{rdFull.GetInt32(5)}</td>");
                sbHtml.Append("</tr>");
            }

            sbHtml.Append("<tr><td colspan=7></td></tr>");
            sbHtml.Append("</table>");
            if (strInfo != "")
            {
                sbHtml.Append("<p>Date of Report</p>");
                sbHtml.Append($"<p>{strInfo}</p>");
            }
            sbHtml.Append("</body></html>");

            rdFull.Close();
            clsSQL.CloseDatabase();
            return sbHtml;
        }
        public static StringBuilder GenerateInventoryRestock(SqlCommand cmdRestock)
        {
            clsSQL.OpenDatabase();
            StringBuilder sbHtml = new StringBuilder();
            StringBuilder sbCss = new StringBuilder();
            string strInfo = "";
            SqlDataReader rdRestock;
            DateTime dateToday = DateTime.Now;

            cmdRestock.ExecuteNonQuery();

            rdRestock = cmdRestock.ExecuteReader();

            sbCss.Append("<style>");
            sbCss.Append("td {padding:5px;text-align:center;font-weight:bold;text-align:center}");
            sbCss.Append("</style>");

            sbHtml.Append("<html>");
            sbHtml.Append($"<head>{sbCss}<title>{"Restock Inventory Report"}</title></head>");
            sbHtml.Append($"<body>");
            sbHtml.Append($"<h1>{"Restock Inventory Report"}</h1>");

            sbHtml.Append("<table>");
            sbHtml.Append("<tr><td colspan=6></td></tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td>InventoryID</td>");
            sbHtml.Append("<td>Item Name</td>");
            sbHtml.Append("<td>Cost</td>");
            sbHtml.Append("<td>Retail Price</td>");
            sbHtml.Append("<td>Quantity</td>");
            sbHtml.Append("<td>Restock Threshold</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            while (rdRestock.Read())
            {
                strInfo = dateToday.ToString("MM/dd/yyyy");
                sbHtml.Append($"<td>{rdRestock.GetInt32(0)}</td>");
                sbHtml.Append($"<td>{rdRestock.GetString(1)}</td>");
                sbHtml.Append($"<td>{rdRestock.GetString(2)}</td>");
                sbHtml.Append($"<td>{rdRestock.GetString(3)}</td>");
                sbHtml.Append($"<td>{rdRestock.GetInt32(4)}</td>");
                sbHtml.Append($"<td>{rdRestock.GetInt32(5)}</td>");
                sbHtml.Append("</tr>");
            }

            sbHtml.Append("<tr><td colspan=7></td></tr>");
            sbHtml.Append("</table>");
            if (strInfo != "")
            {
                sbHtml.Append("<p>Date of Report</p>");
                sbHtml.Append($"<p>{strInfo}</p>");
            }
            sbHtml.Append("</body></html>");

            rdRestock.Close();
            clsSQL.CloseDatabase();
            return sbHtml;
        }

        //method for receipt display
        public static void PrintReceipt(StringBuilder sbHtml, string strOrderID)
        {
            try
            {
                if (!Directory.Exists("AESportingFits"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AESportingFits"));
                }
                //get path of html
                string strFileName = string.Empty;
                strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string strSubFolder = Path.Combine(strFileName, "AESportingFits");
                if (!Directory.Exists("Receipts"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(strSubFolder, "Receipts"));
                }
                string strSubFile = Path.Combine(strSubFolder, "Receipts");
                string strFile = Path.Combine(strSubFile, "Receipt-Order-" + strOrderID + ".html");
                File.WriteAllText(strFile, sbHtml.ToString());
                System.Diagnostics.Process.Start(strFile);
            }
            catch (Exception)
            {
                MessageBox.Show("You don't have write permissions ", "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        //method for sales reports display
        public static void PrintDailySales(StringBuilder sbHtml, DateTime dateSelected)
        {
            try
            {
                if (!Directory.Exists("AESportingFits"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AESportingFits"));
                }
                //get path of folders
                string strFileName = string.Empty;
                strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string strSubFolder = Path.Combine(strFileName, "AESportingFits");                
                if (!Directory.Exists("DailySalesReports"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(strSubFolder, "DailySalesReports"));
                }
                //get path of html
                string strSubFile = Path.Combine(strSubFolder, "DailySalesReports");
                string strFile = Path.Combine(strSubFile, dateSelected.ToString("MM-dd-yyyy") + "-DailySales.html");
                File.WriteAllText(strFile, sbHtml.ToString());
                System.Diagnostics.Process.Start(strFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("You don't have write permissions " + ex, "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void PrintWeeklySales(StringBuilder sbHtml, DateTime dateSelected)
        {
            try
            {
                if (!Directory.Exists("AESportingFits"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AESportingFits"));
                }
                //get path of folders
                string strFileName = string.Empty;
                strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string strSubFolder = Path.Combine(strFileName, "AESportingFits");
                if (!Directory.Exists("WeeklySalesReports"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(strSubFolder, "WeeklySalesReports"));
                }
                //get path of html
                string strSubFile = Path.Combine(strSubFolder, "WeeklySalesReports");
                string strFile = Path.Combine(strSubFile, dateSelected.ToString("MM-dd-yyyy") + "-WeeklySales.html");
                File.WriteAllText(strFile, sbHtml.ToString());
                System.Diagnostics.Process.Start(strFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("You don't have write permissions " + ex, "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void PrintMonthlySales(StringBuilder sbHtml, DateTime dateSelected)
        {
            try
            {
                if (!Directory.Exists("AESportingFits"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AESportingFits"));
                }
                //get path of folders
                string strFileName = string.Empty;
                strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string strSubFolder = Path.Combine(strFileName, "AESportingFits");
                if (!Directory.Exists("MonthlySalesReports"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(strSubFolder, "MonthlySalesReports"));
                }
                //get path of html
                string strSubFile = Path.Combine(strSubFolder, "MonthlySalesReports");
                string strFile = Path.Combine(strSubFile, dateSelected.ToString("MM") + "-MonthlySales.html");
                File.WriteAllText(strFile, sbHtml.ToString());
                System.Diagnostics.Process.Start(strFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("You don't have write permissions " + ex, "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //methods for printing inventory reports
        public static void PrintInventoryAvailable(StringBuilder sbHtml)
        {
            try
            {
                if (!Directory.Exists("AESportingFits"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AESportingFits"));
                }
                DateTime dateToday = DateTime.Now;
                //get path of folders
                string strFileName = string.Empty;
                strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string strSubFolder = Path.Combine(strFileName, "AESportingFits");
                if (!Directory.Exists("InventoryReports"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(strSubFolder, "InventoryReports"));
                }
                //get path of html
                string strSubFile = Path.Combine(strSubFolder, "InventoryReports");
                string strFile = Path.Combine(strSubFile, "AvailableInventory-" + dateToday.ToString("MM-dd-yyyy") + ".html");
                File.WriteAllText(strFile, sbHtml.ToString());
                System.Diagnostics.Process.Start(strFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("You don't have write permissions " + ex, "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void PrintInventoryFull(StringBuilder sbHtml)
        {
            try
            {
                if (!Directory.Exists("AESportingFits"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AESportingFits"));
                }
                DateTime dateToday = DateTime.Now;
                //get path of folders
                string strFileName = string.Empty;
                strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string strSubFolder = Path.Combine(strFileName, "AESportingFits");
                if (!Directory.Exists("InventoryReports"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(strSubFolder, "InventoryReports"));
                }
                //get path of html
                string strSubFile = Path.Combine(strSubFolder, "InventoryReports");
                string strFile = Path.Combine(strSubFile, "FullInventory-" + dateToday.ToString("MM-dd-yyyy") + ".html");
                File.WriteAllText(strFile, sbHtml.ToString());
                System.Diagnostics.Process.Start(strFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("You don't have write permissions " + ex, "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void PrintInventoryRestock(StringBuilder sbHtml)
        {
            try
            {
                if (!Directory.Exists("AESportingFits"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AESportingFits"));
                }
                DateTime dateToday = DateTime.Now;
                //get path of folders
                string strFileName = string.Empty;
                strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string strSubFolder = Path.Combine(strFileName, "AESportingFits");
                if (!Directory.Exists("InventoryReports"))
                {
                    //create sub folder
                    Directory.CreateDirectory(Path.Combine(strSubFolder, "InventoryReports"));
                }
                //get path of html
                string strSubFile = Path.Combine(strSubFolder, "InventoryReports");
                string strFile = Path.Combine(strSubFile, "RestockInventory-" + dateToday.ToString("MM-dd-yyyy") + ".html");
                File.WriteAllText(strFile, sbHtml.ToString());
                System.Diagnostics.Process.Start(strFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("You don't have write permissions " + ex, "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
