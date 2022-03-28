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
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            css.Append("<style> ");
            css.Append("body {background-color: #ccc;font-family: Verdana;}");
            css.Append("header {margin-top: 40px;}");
            css.Append("footer {background-color: #ffffff;}");
            css.Append("div.invoice {background-color: #ffffff; border: 1px solid #ccc; height: 802pt; margin-left: auto; margin-right: auto; padding: 10px; width: 595pt;}");
            css.Append("div.company-address {border: 1px solid #ccc; float: left; width: 200pt;}");
            css.Append("div.invoice-details {border: 1px solid #ccc; float: right; width: 200pt;}");
            css.Append("div.customer-info {border: 1px solid #ccc; float: left; margin-bottom: 50px; margin-top: 100px; width: 200pt;}");
            css.Append("div.item-table-panel {height: 460pt;}");
            css.Append("div.clear-fix {clear: both; float: none;}");
            css.Append("table.item-table {border: 1px solid #ccc; width: 100%;}");
            css.Append("table.footer-table {border: 1px solid #ccc; margin-top: 20pt; bottom: 0; width: 100%;}");
            css.Append("th {border: 1px solid #ccc; text-align: left;}");
            css.Append("th.itemname {width: 380px;}");
            css.Append("th.price {text-align: center; width: 80px;}");
            css.Append("th.quantity {text-align: right; width: 100px;}");
            css.Append("th.total-price {text-align: right; width: 100px;}");
            css.Append("tr {} td {border-bottom: 1px solid #ccc;}");
            css.Append("td.totals {background-color: #ffffff; text-align: right; width: 110px;}");
            css.Append(".text-left {text-align: left;}");
            css.Append(".text-center {text-align: center;}");
            css.Append(".text-right {text-align: right;}");
            css.Append("</style>");


            html.Append("<html>");
            html.Append($"<head>{css}</head>");
            html.Append($"<body>");
            html.Append($"<div class='invoice'> <header> <div class='company-address'><b>AE Sporting Fits</b></div> ");
            html.Append("<div class='invoice-details'>Order #: " + strOrderID + "<br /> Date: " + DateTime.Now.ToString() + "</div>");
            html.Append("</header><section>");
            html.Append("<div class='customer-info'>Customer: "+ strName +"<br /> Phone #: " + strPhone + "<br /> </div> </section>");
            html.Append("<div class='clear-fix'> </div> <section>");
            html.Append("<div class='item-table-panel'> <table border = '0' " +
                "cellspacing='0' class='item-table'> <tr> <th class='itemname'> Item </th> <th class='price'> Item Price </th> <th class='quantity'> Quantity </th> " +
                "<th class='total-price'> Total Price </th> </tr> ");

            
            for (int i = 0; i < strItems.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>" + strItems[i] + "</td>");
                html.Append("<td class='text-center'>" + strPrice[i] + "</td>");
                html.Append("<td class='text-right'>x" + intQuantity[i].ToString() + "</td>");
                html.Append("<td class='text-right'>" + strItemTotal[i] + "</td>");
                html.Append("</tr>");
            }            

            html.Append(" </table> </div> </section> <footer> <table border = '0' cellspacing='0' class='footer-table'> ");
            html.Append("<tr>");
            html.Append("<td class='text-right'>Sub total</td>");
            html.Append("<td class='totals'>" + strSub + "</td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td class='text-right'>Tax</td>");
            html.Append("<td class='totals'>" + strTax +"</td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td class='text-right'><b>TOTAL</b></td>");
            html.Append("<td class='totals'><b>" + strTotalAmount + "</b></td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td class='text-center'><b>Thank you for Shopping with us!</b></td>");
            html.Append("</tr>");
            html.Append("</table> </footer> </div>");

            html.Append("</body></html>");

            return html;

        }

        public static StringBuilder GenerateReceiptDiscount(List<string> strItems, List<int> intQuantity, List<string> strItemTotal, List<string> strPrice, string strOrderID, string strName, string strPhone, string strGross, string strSub, string strDiscount, string strTax, string strTotalAmount)
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            css.Append("<style> ");
            css.Append("body {background-color: #ccc;font-family: Verdana;}");
            css.Append("header {margin-top: 40px;}");
            css.Append("footer {background-color: #ffffff;}");
            css.Append("div.invoice {background-color: #ffffff; border: 1px solid #ccc; height: 802pt; margin-left: auto; margin-right: auto; padding: 10px; width: 595pt;}");
            css.Append("div.company-address {border: 1px solid #ccc; float: left; width: 200pt;}");
            css.Append("div.invoice-details {border: 1px solid #ccc; float: right; width: 200pt;}");
            css.Append("div.customer-info {border: 1px solid #ccc; float: left; margin-bottom: 50px; margin-top: 100px; width: 200pt;}");
            css.Append("div.item-table-panel {height: 460pt;}");
            css.Append("div.clear-fix {clear: both; float: none;}");
            css.Append("table.item-table {border: 1px solid #ccc; width: 100%;}");
            css.Append("table.footer-table {border: 1px solid #ccc; margin-top: 20pt; bottom: 0; width: 100%;}");
            css.Append("th {border: 1px solid #ccc; text-align: left;}");
            css.Append("th.itemname {width: 380px;}");
            css.Append("th.price {text-align: center; width: 80px;}");
            css.Append("th.quantity {text-align: right; width: 100px;}");
            css.Append("th.total-price {text-align: right; width: 100px;}");
            css.Append("tr {} td {border-bottom: 1px solid #ccc;}");
            css.Append("td.totals {background-color: #ffffff; text-align: right; width: 110px;}");
            css.Append(".text-left {text-align: left;}");
            css.Append(".text-center {text-align: center;}");
            css.Append(".text-right {text-align: right;}");
            css.Append("</style>");


            html.Append("<html>");
            html.Append($"<head>{css}</head>");
            html.Append($"<body>");
            html.Append($"<div class='invoice'> <header> <div class='company-address'><b>AE Sporting Fits</b></div> ");
            html.Append("<div class='invoice-details'>Order #: " + strOrderID + "<br /> Date: " + DateTime.Now.ToString() + "</div>");
            html.Append("</header><section>");
            html.Append("<div class='customer-info'>Customer: " + strName + "<br /> Phone #: " + strPhone + "<br /> </div> </section>");
            html.Append("<div class='clear-fix'> </div> <section>");
            html.Append("<div class='item-table-panel'> <table border = '0' " +
                "cellspacing='0' class='item-table'> <tr> <th class='itemname'> Item </th> <th class='price'> Item Price </th> <th class='quantity'> Quantity </th> " +
                "<th class='total-price'> Total Price </th> </tr> ");

            
            for (int i = 0; i < strItems.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>" + strItems[i] + "</td>");
                html.Append("<td class='text-center'>" + strPrice[i] + "</td>");
                html.Append("<td class='text-right'>x" + intQuantity[i].ToString() + "</td>");
                html.Append("<td class='text-right'>" + strItemTotal[i] + "</td>");
                html.Append("</tr>");
            }
            

            html.Append(" </table> </div> </section> <footer> <table border = '0' cellspacing='0' class='footer-table'> ");
            html.Append("<tr>");
            html.Append("<td class='text-right'>Sub total</td>");
            html.Append("<td class='totals'>" + strGross + "</td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td class='text-right'>Discount</td>");
            html.Append("<td class='totals'>" + strDiscount + "</td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td class='text-right'>Discounted Sub total</td>");
            html.Append("<td class='totals'>" + strSub + "</td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td class='text-right'>Tax</td>");
            html.Append("<td class='totals'>" + strTax + "</td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td class='text-right'><b>TOTAL</b></td>");
            html.Append("<td class='totals'><b>" + strTotalAmount + "</b></td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td class='text-center'><b>Thank you for Shopping with us!</b></td>");
            html.Append("</tr>");
            html.Append("</table> </footer> </div>");

            html.Append("</body></html>");

            return html;

        }

        //method for receipt display
        public static void PrintReceipt(StringBuilder html)
        {
            try
            {
                using (StreamWriter wr = new StreamWriter("Receipt.html"))
                {
                    wr.WriteLine(html);
                }
                System.Diagnostics.Process.Start(@"Receipt.html");
                String strFile = string.Empty;
                strFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                strFile = Path.Combine(strFile, "Receipt.html");
                
            }
            catch (Exception)
            {
                MessageBox.Show("You don't have write permissions", "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            using (StreamWriter wr = new StreamWriter("Receipt.html"))
            {
                wr.WriteLine(html);
            }
            
        }
    }
}
