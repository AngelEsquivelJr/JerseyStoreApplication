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
        public struct LogonParams
        {
            public ComboBox cbxTitle, cbxState, cbxSecQuest1, cbxSecQuest2, cbxSecQuest3;

            public TextBox tbxFirstName, tbxMiddleName, tbxLastName, tbxSuffix, tbxAddress1, tbxAddress2, tbxAddress3, tbxCity, tbxZipcode, tbxEmail, tbxPhone1, tbxPhone2, tbxAnswer1, tbxAnswer2, tbxAnswer3, tbxUser, tbxPassword;
        }

        //method for signing up
        internal static void SignUp(LogonParams logonParams, frmLogon frmLogon, frmSignUp frmSignup)
        {
            //set values from validation parameters
            clsValidation.StringParams strParams = new clsValidation.StringParams();
            clsSQL.ParametersSQL boxParams = new clsSQL.ParametersSQL();

            strParams.strNameFirst = logonParams.tbxFirstName.Text;
            strParams.strNameLast = logonParams.tbxLastName.Text;
            strParams.strCity = logonParams.tbxCity.Text;
            strParams.strAddress = logonParams.tbxAddress1.Text;
            strParams.strPhone = logonParams.tbxPhone1.Text;
            strParams.strPhone2 = logonParams.tbxPhone2.Text;
            strParams.strState = logonParams.cbxState.Text;
            strParams.strEmail = logonParams.tbxEmail.Text;
            strParams.strZipCode = logonParams.tbxZipcode.Text;
            strParams.strUsername = logonParams.tbxUser.Text;
            strParams.strPassword = logonParams.tbxPassword.Text;
            strParams.strQuestion1 = logonParams.cbxSecQuest1.Text;
            strParams.strQuestion2 = logonParams.cbxSecQuest2.Text;
            strParams.strQuestion3 = logonParams.cbxSecQuest3.Text;
            strParams.strAnswer1 = logonParams.tbxAnswer1.Text;
            strParams.strAnswer2 = logonParams.tbxAnswer2.Text;
            strParams.strAnswer3 = logonParams.tbxAnswer3.Text;

            boxParams.cbxTitle = logonParams.cbxTitle;
            boxParams.tbxFirstName = logonParams.tbxFirstName;
            boxParams.tbxMiddleName = logonParams.tbxMiddleName;
            boxParams.tbxLastName = logonParams.tbxLastName;
            boxParams.tbxSuffix = logonParams.tbxSuffix;
            boxParams.tbxCity = logonParams.tbxCity;
            boxParams.tbxAddress1 = logonParams.tbxAddress1;
            boxParams.tbxAddress2 = logonParams.tbxAddress2;
            boxParams.tbxAddress3 = logonParams.tbxAddress3;
            boxParams.tbxPhone1 = logonParams.tbxPhone1;
            boxParams.tbxPhone2 = logonParams.tbxPhone2;
            boxParams.cbxState = logonParams.cbxState;
            boxParams.tbxEmail = logonParams.tbxEmail;
            boxParams.tbxZipcode = logonParams.tbxZipcode;
            boxParams.tbxUser = logonParams.tbxUser;
            boxParams.tbxPassword = logonParams.tbxPassword;
            boxParams.cbxSecQuestion1 = logonParams.cbxSecQuest1;
            boxParams.cbxSecQuestion2 = logonParams.cbxSecQuest2;
            boxParams.cbxSecQuestion3 = logonParams.cbxSecQuest3;
            boxParams.tbxAnswer1 = logonParams.tbxAnswer1;
            boxParams.tbxAnswer2 = logonParams.tbxAnswer2;
            boxParams.tbxAnswer3 = logonParams.tbxAnswer3;

            //call proper clsValidation method for validation
            if (clsValidation.Validate(strParams))
            {
                //call clsSql method for logging in
                if(clsSQL.WriteLoginData(boxParams))
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
                        //if credentials are true successfully login
                        main.Show();
                        logon.Hide();
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
