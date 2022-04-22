//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
// Application used to browse and buy jerseys.
// Form Purpose:
// This form is used to create an account for the application.
// 


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
            if (clsSQL.strPositionTitle != "Manager")
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
                    //return to login
                    frmLogin.Show();
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
            clsParameters.SignupParameters signupParameters = new clsParameters.SignupParameters
            {
                cbxTitleP = cbxTitle,
                tbxFirstNameP = tbxFirstName,
                tbxMiddleNameP = tbxMiddleName,
                tbxLastNameP = tbxLastName,
                tbxSuffixP = tbxSuffix,
                tbxCityP = tbxCity,
                tbxAddress1P = tbxAddress1,
                tbxAddress2P = tbxAddress2,
                tbxAddress3P = tbxAddress3,
                tbxPhone1P = tbxPhoneOne,
                tbxPhone2P = tbxPhoneTwo,
                cbxStateP = cbxState,
                tbxEmailP = tbxEmailInput,
                tbxZipcodeP = tbxZipcode,
                tbxUsernameP = tbxUsername,
                tbxPasswordP = tbxPassword,
                cbxSecQuestion1P = cbxSecurityOne,
                cbxSecQuestion2P = cbxSecurityTwo,
                cbxSecQuestion3P = cbxSecurityThree,
                tbxAnswer1P = tbxAnswerOne,
                tbxAnswer2P = tbxAnswerTwo,
                tbxAnswer3P = tbxAnswerThree
            };

            //clsLogon method for signing up
            clsLogon.SignUp(signupParameters, frmLogin, this);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //get path of images
            string strShow = Path.GetFullPath(@"Resources\showPassEye.png");
            string strUnShow = Path.GetFullPath(@"Resources\unshowPassEye.png");

            try
            {
                //if statement for showing password
                if (tbxPassword.PasswordChar == (char)0)
                {
                    tbxPassword.PasswordChar = '*';
                    btnShow.Image = Image.FromFile(strShow);

                }
                else
                {
                    tbxPassword.PasswordChar = (char)0;
                    btnShow.Image = Image.FromFile(strUnShow);
                }
            }
            catch (Exception)
            {
                //error for no image
                MessageBox.Show("Show password error. ", "Error",
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
            //sql method to fill combos
            clsSQL.FillQuestionCombo(cbxSecurityOne, cbxSecurityTwo, cbxSecurityThree);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //call clsHelp method to open help file
            clsHelp.OpenHelp("SignUpHelp.pdf");
        }
    }
}
