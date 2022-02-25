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

        //structure for holding textbox and combobox parameters
        public struct BoxParams
        {
            public ComboBox cTitle, cState, cSecQuest1, cSecQuest2, cSecQuest3;

            public TextBox tFirstN, tMiddleN, tLastN, tSuffix, tAddress1, tAddress2, tAddress3, tCity, tZipcode, tEmail, tPhone1, tPhone2, tAnswer1, tAnswer2, tAnswer3, tUser, tPassword;
        }

        //method for signing up
        internal static void SignUp(BoxParams bxParams, frmLogon frmLogon, frmSignUp frmSignup)
        {
            //set values from validation parameters
            clsValidation.StringParams stParams = new clsValidation.StringParams();
            clsSQL.SQLBoxParams sqlParams = new clsSQL.SQLBoxParams();

            stParams.strNameF = bxParams.tFirstN.Text;
            stParams.strNameL = bxParams.tLastN.Text;
            stParams.strCity = bxParams.tCity.Text;
            stParams.strAddress = bxParams.tAddress1.Text;
            stParams.strPhone = bxParams.tPhone1.Text;
            stParams.strPhone2 = bxParams.tPhone2.Text;
            stParams.strState = bxParams.cState.Text;
            stParams.strEmail = bxParams.tEmail.Text;
            stParams.strZipCode = bxParams.tZipcode.Text;
            stParams.strUsername = bxParams.tUser.Text;
            stParams.strPassword = bxParams.tPassword.Text;
            stParams.strQues1 = bxParams.cSecQuest1.Text;
            stParams.strQues2 = bxParams.cSecQuest2.Text;
            stParams.strQues3 = bxParams.cSecQuest3.Text;
            stParams.strAns1 = bxParams.tAnswer1.Text;
            stParams.strAns2 = bxParams.tAnswer2.Text;
            stParams.strAns3 = bxParams.tAnswer3.Text;

            sqlParams.cTitle = bxParams.cTitle;
            sqlParams.tFirstN = bxParams.tFirstN;
            sqlParams.tMiddleN = bxParams.tMiddleN;
            sqlParams.tLastN = bxParams.tLastN;
            sqlParams.tSuffix = bxParams.tSuffix;
            sqlParams.tCity = bxParams.tCity;
            sqlParams.tAddress1 = bxParams.tAddress1;
            sqlParams.tAddress2 = bxParams.tAddress2;
            sqlParams.tAddress3 = bxParams.tAddress3;
            sqlParams.tPhone1 = bxParams.tPhone1;
            sqlParams.tPhone2 = bxParams.tPhone2;
            sqlParams.cState = bxParams.cState;
            sqlParams.tEmail = bxParams.tEmail;
            sqlParams.tZipcode = bxParams.tZipcode;
            sqlParams.tUser = bxParams.tUser;
            sqlParams.tPassword = bxParams.tPassword;
            sqlParams.cSecQuest1 = bxParams.cSecQuest1;
            sqlParams.cSecQuest2 = bxParams.cSecQuest2;
            sqlParams.cSecQuest3 = bxParams.cSecQuest3;
            sqlParams.tAnswer1 = bxParams.tAnswer1;
            sqlParams.tAnswer2 = bxParams.tAnswer2;
            sqlParams.tAnswer3 = bxParams.tAnswer3;

            //call proper clsValidation method for validation
            if (clsValidation.Validate(stParams))
            {
                //call clsSql method for logging in
                if(clsSQL.WriteLoginData(sqlParams))
                {
                    //message for success and returns to login form
                    MessageBox.Show("Account Created Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmSignup.Close();
                    frmLogon.Show();
                }
            }

        }

        //method for logging in
        internal static void Login(TextBox tbxPass, TextBox tbxUser, frmLogon logon, frmMain main)
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
                        //if credentials are true succesfully login
                        //main.Show();
                        //logon.Hide();
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
