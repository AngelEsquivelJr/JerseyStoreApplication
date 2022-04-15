using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set selection range
            SelectionRange rangeWeek = new SelectionRange(calendarSalesReports.SelectionStart, calendarSalesReports.SelectionEnd.AddDays(6));
            int intDays = DateTime.DaysInMonth(calendarSalesReports.SelectionStart.Year, calendarSalesReports.SelectionStart.Month);
            DateTime dateFirst = new DateTime(calendarSalesReports.SelectionStart.Year, calendarSalesReports.SelectionStart.Month, 1);
            DateTime dateLast = dateFirst.AddMonths(1).AddDays(-1);
            SelectionRange rangeMonth = new SelectionRange(dateFirst, dateLast);

            if (cbxDays.SelectedIndex == 0)
            {
                calendarSalesReports.MaxSelectionCount = 1;
            }
            else if(cbxDays.SelectedIndex == 1)
            {
                calendarSalesReports.MaxSelectionCount = 7;
                calendarSalesReports.SelectionRange = rangeWeek;
            }
            else if (cbxDays.SelectedIndex == 2)
            {
                calendarSalesReports.MaxSelectionCount = intDays;
                calendarSalesReports.SelectionRange = rangeMonth;
            }
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
        }

        private void calendarSalesReports_DateSelected(object sender, DateRangeEventArgs e)
        {
            //set selection range
            SelectionRange rangeWeek = new SelectionRange(calendarSalesReports.SelectionStart, calendarSalesReports.SelectionEnd.AddDays(6));
            int intDays = DateTime.DaysInMonth(calendarSalesReports.SelectionStart.Year, calendarSalesReports.SelectionStart.Month);
            DateTime dateFirst = new DateTime(calendarSalesReports.SelectionStart.Year, calendarSalesReports.SelectionStart.Month, 1);
            SelectionRange rangeMonth = new SelectionRange(dateFirst, calendarSalesReports.SelectionEnd.AddDays(intDays));
            
            if(cbxDays.SelectedIndex == 0)
            {                
                calendarSalesReports.MaxSelectionCount = 1;
            }
            else if (cbxDays.SelectedIndex == 1)
            {
                calendarSalesReports.MaxSelectionCount = 7;
                calendarSalesReports.SelectionRange = rangeWeek;
            }
            else if (cbxDays.SelectedIndex == 2)
            {
                calendarSalesReports.MaxSelectionCount = intDays;
                calendarSalesReports.SelectionRange = rangeMonth;
            }
        }

        private void btnPrintSales_Click(object sender, EventArgs e)
        {
            DateTime dateSelectedDay = calendarSalesReports.SelectionStart;
            DateTime dateLastDayWeek = calendarSalesReports.SelectionStart.AddDays(6);
            if (cbxDays.SelectedIndex == 0)
            {                
                //print daily reports
                clsSQL.DatabaseCommandLoadDailySales(dateSelectedDay);
                clsHTML.PrintDailySales(clsHTML.GenerateDailySales(clsSQL._sqlDailySales), dateSelectedDay);
            }
            else if(cbxDays.SelectedIndex == 1)
            {
                //print weekly reports
                clsSQL.DatabaseCommandLoadWeeklySales(dateSelectedDay, dateLastDayWeek);
                clsHTML.PrintWeeklySales(clsHTML.GenerateWeeklySales(clsSQL._sqlWeeklySales), dateSelectedDay);
            }
            else if (cbxDays.SelectedIndex == 2)
            {
                //print monthly reports
                clsSQL.DatabaseCommandLoadMonthlySales(dateSelectedDay);
                clsHTML.PrintMonthlySales(clsHTML.GenerateMonthlySales(clsSQL._sqlMonthlySales), dateSelectedDay);
            }
            else
            {
                MessageBox.Show("Please select the type of sales report you would like to print.", "Sales Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
