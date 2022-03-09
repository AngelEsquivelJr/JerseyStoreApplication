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
            //call clsLogon method for resetting password
            clsLogon.Reset(tbxUsername, tbxAnswerOne, tbxAnswerTwo, tbxAnswerThree, tbxPassword, tbxPassTwo, frmLogin, this);
        }

        private void frmReset_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxPassTwo.Text) || string.IsNullOrEmpty(tbxQuestionOne.Text) || string.IsNullOrEmpty(tbxAnswerTwo.Text))
            {
                //asks user for confirmation of exit and returns to previous form
                DialogResult drResult = MessageBox.Show("Are you sure you want to exit the password reset? ",
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            //get path of images
            string strShow = Path.GetFullPath(@"Resources\showPassEye.png");
            string strUnshow = Path.GetFullPath(@"Resources\unshowPassEye.png");

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
                    btnShow.Image = Image.FromFile(strUnshow);
                }
            }
            catch (Exception ex)
            {
                //error for no image
                MessageBox.Show("Show password error. " + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowTwo_Click(object sender, EventArgs e)
        {
            //get path of images
            string strShow = Path.GetFullPath(@"Resources\showPassEye.png");
            string strUnshow = Path.GetFullPath(@"Resources\unshowPassEye.png");

            try
            {
                //if statement for showing password
                if (tbxPassTwo.PasswordChar == (char)0)
                {
                    tbxPassTwo.PasswordChar = '*';
                    btnShowTwo.Image = Image.FromFile(strShow);

                }
                else
                {
                    tbxPassTwo.PasswordChar = (char)0;
                    btnShowTwo.Image = Image.FromFile(strUnshow);
                }
            }
            catch (Exception)
            {
                //error for no image
                MessageBox.Show("Show password error. ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //call the clsLogon method for updating form
            clsLogon.UpdateReset(tbxUsername, tbxQuestionOne, tbxQuestionTwo, tbxQuestionThree, this, btnReset, btnUpdate);
            //clear text boxes          
            tbxAnswerOne.Clear();
            tbxAnswerTwo.Clear();
            tbxAnswerThree.Clear();
            //set focus to first text box
            //enable password fields
            if (tbxUsername.ReadOnly == true)
            {
                tbxAnswerOne.Focus();
                tbxPassword.ReadOnly = false;
                tbxPassTwo.ReadOnly = false;
            }
            else
            {
                tbxUsername.Focus();
            }

        }

        private void tbxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation method for allowed keys in username
            clsValidation.UsernameAllowedKeys(e);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //call clsHelp method to open help file
            clsHelp.OpenHelp("ResetHelp.pdf");
        }
    }
}
