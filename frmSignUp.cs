using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                  "Returning", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
            clsValidation.EmailAllowedKeys(e);
        }

        private void tbxAddress1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.AddressAllowedKeys(e);
        }

        private void tbxAddress2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.AddressAllowedKeys(e);
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
            clsValidation.AddressAllowedKeys(e);
        }

        private void tbxCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.CityAllowedKeys(e);
        }

        private void tbxZipcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.ZipAllowedKeys(e);
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
            clsValidation.PhoneAllowedKeys(e);
        }

        private void tbxPhoneTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.PhoneAllowedKeys(e);
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
            clsValidation.AnswerAllowedKeys(e);
        }

        private void tbxAnswerTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.AnswerAllowedKeys(e);
        }

        private void tbxAnswerThree_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys
            clsValidation.AnswerAllowedKeys(e);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            //set up parameters
            clsLogon.BoxParams bxParams = new clsLogon.BoxParams();

            bxParams.cTitle = cbxTitle;
            bxParams.tFirstN = tbxFirstName;
            bxParams.tMiddleN = tbxMiddleName;
            bxParams.tLastN = tbxLastName;
            bxParams.tSuffix = tbxSuffix;
            bxParams.tCity = tbxCity;
            bxParams.tAddress1 = tbxAddress1;
            bxParams.tAddress2 = tbxAddress2;
            bxParams.tAddress3 = tbxAddress3;
            bxParams.tPhone1 = tbxPhoneOne;
            bxParams.tPhone2 = tbxPhoneTwo;
            bxParams.cState = cbxState;
            bxParams.tEmail = tbxEmailInput;
            bxParams.tZipcode = tbxZipcode;
            bxParams.tUser = tbxUsername;
            bxParams.tPassword = tbxPassword;
            bxParams.cSecQuest1 = cbxSecurityOne;
            bxParams.cSecQuest2 = cbxSecurityTwo;
            bxParams.cSecQuest3 = cbxSecurityThree;
            bxParams.tAnswer1 = tbxAnswerOne;
            bxParams.tAnswer2 = tbxAnswerTwo;
            bxParams.tAnswer3 = tbxAnswerThree;

            //clsLogon method for signing up
            clsLogon.SignUp(bxParams, frmLogin, this);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //get path of images
            string pathShow = Path.GetFullPath(@"Resources\showPassEye.png");
            string pathUnShow = Path.GetFullPath(@"Resources\unshowPassEye.png");

            try
            {
                //if statement for showing password
                if (tbxPassword.PasswordChar == (char)0)
                {
                    tbxPassword.PasswordChar = '*';
                    btnShow.Image = Image.FromFile(pathShow);

                }
                else
                {
                    tbxPassword.PasswordChar = (char)0;
                    btnShow.Image = Image.FromFile(pathUnShow);
                }
            }
            catch (Exception ex)
            {
                //error for no image
                MessageBox.Show("Show password error. " + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            clsSQL.FillCombo(cbxSecurityOne, cbxSecurityTwo, cbxSecurityThree);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //get path of pdf
            string path = Path.GetFullPath(@"HelpFiles\LoginHelpFinals.pdf");

            try
            {
                //open with default process
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                //error for no file
                MessageBox.Show("Help file was not found. " + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxEmailInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
