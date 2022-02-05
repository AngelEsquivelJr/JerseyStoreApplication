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
    public partial class frmSignUp : Form
    {
        frmLogon frmLogin = new frmLogon();

        public frmSignUp()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //closes current form
            this.Close();
        }

        private void frmSignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            //asks user for confirmation of exit and returns to previous form
            DialogResult dr = MessageBox.Show("Are you sure you want to exit this form? ",
              "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch(dr)
            {
                case DialogResult.Yes:
                    frmLogin.Show();
                    break;
                case DialogResult.No:
                    e.Cancel = true;
                    break;
            }
            
        }

        private void tbxEmailInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.EmailAllowed(e);
        }

        private void tbxAddress1_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AddressAllowed(e);
        }

        private void tbxAddress2_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AddressAllowed(e);
        }

        private void tbxAddress3_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AddressAllowed(e);
        }

        private void tbxCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.CityAllowed(e);
        }

        private void tbxZipcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.ZipAllowed(e);
        }

        private void tbxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.NameAllowedKeys(e);
        }

        private void tbxMiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.NameAllowedKeys(e);
        }

        private void tbxLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.NameAllowedKeys(e);
        }

        private void tbxSuffix_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.NameAllowedKeys(e);
        }

        private void tbxPhoneOne_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.PhoneAllowed(e);
        }

        private void tbxPhoneTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.PhoneAllowed(e);
        }

        private void tbxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.UsernameAllowedKeys(e);
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.PasswordAllowedKeys(e);
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

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            clsLogon.SignUp(cbxTitle, tbxFirstName, tbxMiddleName, tbxLastName, tbxSuffix, tbxAddress1, tbxAddress2, tbxAddress3, tbxCity,
                tbxZipcode, cbxState, tbxEmailInput, tbxPhoneOne, tbxPhoneTwo, cbxSecurityOne, tbxAnswerOne, cbxSecurityTwo, tbxAnswerTwo,
                cbxSecurityThree, tbxAnswerThree, tbxUsername, tbxPassword, this, frmLogin);
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
    }
}
