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
    public partial class frmReset : Form
    {
        frmLogon frmLogin = new frmLogon();

        public frmReset()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //opens up login form and closes current form
            frmLogin.Show();
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}
