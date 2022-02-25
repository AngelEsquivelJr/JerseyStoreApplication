
//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
// Application used to browse and buy jerseys.
// Form Purpose:
// This form is used to login to the application.
// 


using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmLogon : Form
    {
        //main form
        frmMain frmMain = new frmMain();

        public frmLogon()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //exits application
            Application.Exit();
        }

        private void btnShow_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
        private void btnShow_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void tbxUsername_Click(object sender, EventArgs e)
        {
            //clears textbox text
            if (tbxUsername.Text == "Username")
            {
                tbxUsername.Clear();
                tbxUsername.ForeColor = Color.Black;
            }
            
        }

        private void tbxPassword_Click(object sender, EventArgs e)
        {
            //clears password text
            if (tbxPassword.Text == "Password")
            {
                tbxPassword.Clear();
                tbxPassword.ForeColor = Color.Black;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            //opens sign up form
            frmSignUp frmSign = new frmSignUp();
            frmSign.Show();
            this.Hide();
        }

        private void btnPasswordReset_Click(object sender, EventArgs e)
        {
            //opens reset form
            frmReset frmReset = new frmReset();
            frmReset.Show();
            this.Hide();
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

        private void frmLogon_FormClosing(object sender, FormClosingEventArgs e)
        {
            //allow exit through x button
            //close datatbase upon exit
            Application.Exit();
            clsSQL.CloseDatabase();
        }

        private void tbxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allowed keys
            clsValidation.UsernameAllowedKeys(e);
        }

        private void tbxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allowed keys
            clsValidation.PasswordAllowedKeys(e);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //clsLogon method for logging in
            clsLogon.Login(tbxPassword, tbxUsername, this, frmMain);
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
            catch(Exception ex)
            {
                //error for no file
                MessageBox.Show("Help file was not found. " + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxUsername_TextChanged(object sender, EventArgs e)
        {
            //make text proper color
            tbxUsername.ForeColor = Color.Black;
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            //make text proper color
            tbxPassword.ForeColor = Color.Black;
        }
    }
}