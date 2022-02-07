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
    public partial class frmMain : Form
    {        
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //login form
            frmLogon frmLogin = new frmLogon();

            //asks user for confirmation of exit and returns to previous form
            DialogResult dr = MessageBox.Show("Are you sure you want to exit? ",
              "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (dr)
            {
                case DialogResult.Yes:
                    frmLogin.Show();
                    break;
                case DialogResult.No:
                    e.Cancel = true;
                    break;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //close current form
            this.Close();
        }
    }
}
