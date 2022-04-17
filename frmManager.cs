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
    public partial class frmManager : Form
    {
        public frmManager()
        {
            InitializeComponent();
        }

        private void frmManager_Load(object sender, EventArgs e)
        {
            //call method to show restock view
            clsSQL.InitializeRestockView(dgvRestock, lblRestock);
            //set label
            lblManager.Text = "Manager: " + clsSQL.strName;
        }

        private void frmManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            //login form
            frmLogon frmLogin = new frmLogon();

            //asks user for confirmation of exit and returns to previous form
            DialogResult drResult = MessageBox.Show("Are you sure you want to logout? ",
                  "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (drResult)
            {
                case DialogResult.Yes:
                    frmLogin.Show();
                    break;
                case DialogResult.No:
                    e.Cancel = true;
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //refresh restock view
            dgvRestock.DataSource = null;
            clsSQL.InitializeRestockView(dgvRestock, lblRestock);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            frmInventory frmInventory = new frmInventory();
            frmInventory.ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer frmCustomer = new frmCustomer();
            frmCustomer.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmReports frmReport = new frmReports();
            frmReport.ShowDialog();
        }

        private void btnDiscounts_Click(object sender, EventArgs e)
        {
            frmDiscount frmDiscount = new frmDiscount();
            frmDiscount.ShowDialog();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //help file
            clsHelp.OpenHelp("ManagerHelp.pdf");
        }
    }
}
