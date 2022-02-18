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
            if (string.IsNullOrEmpty(tbxPassword.Text) || string.IsNullOrEmpty(tbxAnswerThree.Text))
            {
                //asks user for confirmation of exit and returns to previous form
                DialogResult drResult = MessageBox.Show("Are you sure you want to cancel sign up? ",
                  "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            else
            {
                //informs user of form exit
                DialogResult drResult = MessageBox.Show("Returning to login. ",
                  "Exit", MessageBoxButtons.OK, MessageBoxIcon.Question);
                switch (drResult)
                {
                    case DialogResult.OK:
                        frmLogin.Show();
                        break;
                }
            }
        }

        private void tbxEmailInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.EmailAllowed(e);
        }

        private void tbxAddress1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.AddressAllowed(e);
        }

        private void tbxAddress2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.AddressAllowed(e);
            //if statement to allow access to other textboxes
            if (string.IsNullOrEmpty(tbxAddress2.Text) == false)
            {
                tbxAddress3.ReadOnly = false;
            }
            else
            {
                tbxAddress3.ReadOnly = true;
                tbxAddress3.Clear();
            }
        }

        private void tbxAddress3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.AddressAllowed(e);
        }

        private void tbxCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.CityAllowed(e);
        }

        private void tbxZipcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.ZipAllowed(e);
        }

        private void tbxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.NameAllowedKeys(e);
        }

        private void tbxMiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.NameAllowedKeys(e);
        }

        private void tbxLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.NameAllowedKeys(e);
        }

        private void tbxSuffix_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.NameAllowedKeys(e);
        }

        private void tbxPhoneOne_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.PhoneAllowed(e);
        }

        private void tbxPhoneTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.PhoneAllowed(e);
        }

        private void tbxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.UsernameAllowedKeys(e);
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.PasswordAllowedKeys(e);
        }

        private void tbxAnswerOne_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.AnswerAllowed(e);
        }

        private void tbxAnswerTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.AnswerAllowed(e);
        }

        private void tbxAnswerThree_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.AnswerAllowed(e);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            //clsLogon method for signing up
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

        private void tbxAddress2_KeyUp(object sender, KeyEventArgs e)
        {
            //if statement to allow access to other textboxes
            if (string.IsNullOrEmpty(tbxAddress2.Text) == false)
            {
                tbxAddress3.ReadOnly = false;
            }
            else
            {
                tbxAddress3.ReadOnly = true;
                tbxAddress3.Clear();
            }
        }

        private void tbxAddress1_KeyUp(object sender, KeyEventArgs e)
        {
            //if statement to allow access to other textboxes
            if (string.IsNullOrEmpty(tbxAddress1.Text) == false)
            {
                tbxAddress2.ReadOnly = false;                
            }
            else
            {
                tbxAddress2.ReadOnly = true;
                tbxAddress3.ReadOnly = true;
                tbxAddress2.Clear();
                tbxAddress3.Clear();
            }
        }

        private void tbxPhoneOne_KeyUp(object sender, KeyEventArgs e)
        {
            //if statement to allow access to other textboxes
            if (string.IsNullOrEmpty(tbxPhoneOne.Text) == false)
            {
                tbxPhoneTwo.ReadOnly = false;
            }
            else
            {
                tbxPhoneTwo.ReadOnly = true;
                tbxPhoneTwo.Clear();
            }
        }

        private void frmSignUp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inew2332sp22TableDataSet.SecurityQuestions' table. You can move, or remove it, as needed.
            this.securityQuestionsTableAdapter1.Fill(this.inew2332sp22TableDataSet.SecurityQuestions);
            // TODO: This line of code loads data into the 'inew2332sp22DataSet.SecurityQuestions' table. You can move, or remove it, as needed.
            this.securityQuestionsTableAdapter.Fill(this.inew2332sp22DataSet.SecurityQuestions);

            clsSQL.FillCombo(cbxSecurityOne, cbxSecurityTwo, cbxSecurityThree);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //open help pdf
            System.Diagnostics.Process.Start(@"C:\Users\aesqu\Source\Repos\22SP-FinalProject-EsquivelAngel\HelpFiles\SignUpHelpFinal.pdf");
        }

        private void tbxEmailInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
