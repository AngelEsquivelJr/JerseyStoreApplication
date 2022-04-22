//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
// Application used to browse and buy jerseys.
//*******************************************
// Class Purpose: 
/* This class calls other classes that handle validation, SQL queries, etc related to login:
 *      - Calls the appropriate clsValidation method to validate user ID and validate password
 *        according to the User/Logon ID requirements stated earlier, returning a boolean value to
 *        represent success(True) or failure(False).
 * 
 *      - Calls the appropriate clsSQL method after successful validation from clsValidation to
 *        query the database for an account. If a match is found, clsSQL calls an additional
 *        method to return the user’s type (typically an integer value).
*/
//*******************************************
//*******************************************

using System.Windows.Forms;

namespace FinalProject
{
    internal class clsLogon
    {
        //method for signing up
        internal static void SignUp(clsParameters.SignupParameters loginParameters, frmLogon frmLogon, frmSignUp frmSignup)
        {         
            //call proper clsValidation method for validation
            if (clsValidation.Validate(loginParameters))
            {
                //call clsSql method for logging in
                if(clsSQL.WriteLoginData(loginParameters))
                {
                    //message for success and returns to login form
                    MessageBox.Show("Account Created Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmSignup.Close();
                    if (clsSQL.strPositionTitle != "Manager")
                    {
                        frmLogon.Show();
                    }
                }
            }
        }

        //method for logging in
        internal static void Login(TextBox tbxPass, TextBox tbxUser, frmLogon frmLogon, frmMain frmMain, frmManager frmManager)
        {
            //call proper clsValidation methods for validation
            //check username validation
            if (clsValidation.UsernameValidation(tbxUser.Text))
            {
                //if username is valid, check password validation
                if (clsValidation.PasswordValidation(tbxPass.Text))
                {
                    //if both are valid call clsSql
                    //check credentials
                    if (clsSQL.ReadLoginData(tbxUser, tbxPass))
                    {
                        //check position to determine where to go
                        if (clsSQL.strPositionTitle == "Manager")
                        {
                            frmLogon.Hide();
                            frmManager.Show();
                        }
                        else
                        {
                            //if credentials are true successfully login
                            frmLogon.Hide();
                            frmMain.Show();
                        }
                    }
                }
            }

        }

        //method for updating reset form
        internal static void UpdateReset(TextBox tbxUser, TextBox tbxQ1, TextBox tbxQ2, TextBox tbxQ3, frmReset frmReset, Button btnReset, Button btnUpdate)
        {
            //call clsSql method for updating
            if(clsSQL.UpdateResetData(tbxUser, tbxQ1, tbxQ2, tbxQ3))
            {
                //refresh screen and enable reset button
                //disable update button
                frmReset.Refresh();
                btnReset.Enabled = true;
                btnUpdate.Enabled = false;
            }

        }

        //method for resetting password
        internal static void Reset(TextBox tbxUser, TextBox tbxA1, TextBox tbxA2, TextBox tbxA3, TextBox tbxNewP, TextBox tbxConfirmP, frmLogon frmLogon, frmReset frmReset)
        {
            //call proper clsValidation methods for validation
            //check answer fields first
            if(clsValidation.AnswerValidation(tbxA1.Text, tbxA2.Text, tbxA3.Text))
            {
                    //if valid password, call clsSql method for Resetting Password
                    if(clsSQL.WriteResetData(tbxUser, tbxA1, tbxA2, tbxA3, tbxNewP, tbxConfirmP))
                    {
                        //message for success and returns to login form
                        MessageBox.Show("Password Reset Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmReset.Close();
                        frmLogon.Show();                                          
                    }                
            }
        }
    }
}
