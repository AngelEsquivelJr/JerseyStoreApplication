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
            //closes current form            
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void frmReset_FormClosing(object sender, FormClosingEventArgs e)
        {
            //asks user for confirmation of exit and returns to previous form
            DialogResult dr = MessageBox.Show("Are you sure you want to exit this form? ",
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

        private void tbxAnswerOne_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AnswerAllowed(e);
        }

        private void tbxAnswerTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AnswerAllowed(e);
        }

        private void tbxAnswerThree_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AnswerAllowed(e);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //if statement for showing password
            if (tbxPassword.PasswordChar == (char)0)
            {
                tbxPassword.PasswordChar = '*';
            }
            else
            {
                tbxPassword.PasswordChar = (char)0;
            }
        }

        private void btnShowTwo_Click(object sender, EventArgs e)
        {
            //if statement for showing password
            if (tbxPassTwo.PasswordChar == (char)0)
            {
                tbxPassTwo.PasswordChar = '*';
            }
            else
            {
                tbxPassTwo.PasswordChar = (char)0;
            }
        }
    }
}
