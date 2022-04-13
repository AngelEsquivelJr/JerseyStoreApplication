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
    public partial class frmPastTransactions : Form
    {
        public frmPastTransactions()
        {
            InitializeComponent();
        }

        private void frmPastTransactions_Load(object sender, EventArgs e)
        {
            //set name of customer
            lblName.Text = clsSQL.strLogonName;
            clsSQL.InitializeOrderView(dgvOrders);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //call method for order details
            clsSQL.InitializeOrderDetailsView(dgvOrderDetails, dgvOrders);
        }
    }
}
