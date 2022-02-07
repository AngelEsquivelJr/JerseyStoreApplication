//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
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

// To See the 'ToDo' tags, go to the 'View' Menu and then select 'Task List'
// You can then double click on a 'ToDo' to go to that specific one in the list

//ToDo: ------------ clsLogon - Remove Form ToDo List, once completed (Listed Below) ------------

//ToDo: ------------ clsLogon - Remove Form ToDo List, once completed (Listed Above) ------------

using System.Windows.Forms;

namespace FinalProject
{
    internal class clsLogon
    {
        //method for signing up
        internal static void SignUp(ComboBox cbxTitle, TextBox tbxFirstN, TextBox tbxMiddleN, TextBox tbxLastN, TextBox tbxSuffix,
            TextBox tbxAddress1, TextBox tbxAddress2, TextBox tbxAddress3, TextBox tbxCity, TextBox tbxZipcode, ComboBox cbxState,
            TextBox tbxEmail, TextBox tbxPhone1, TextBox tbxPhone2, ComboBox cbxSecQuest1, TextBox tbxAnswer1, ComboBox cbxSecQuest2,
            TextBox tbxAnswer2, ComboBox cbxSecQuest3, TextBox tbxAnswer3, TextBox tbxUsername, TextBox tbxPassword, frmSignUp signup, frmLogon logon)
        {
            //call proper clsValidation methods for validation
            //check email first
            if(clsValidation.EmailExist(tbxEmail.Text) == false)
            {
                if (clsValidation.RequiredFields(tbxFirstN.Text, tbxLastN.Text, tbxAddress1.Text, tbxCity.Text, cbxState.Text, cbxSecQuest1.Text, cbxSecQuest2.Text, cbxSecQuest3.Text, tbxAnswer1.Text, tbxAnswer2.Text, tbxAnswer3.Text))
                {
                    //check zipcode next
                    if (clsValidation.ZipCodeMatch(tbxZipcode.Text))
                    {
                        //check username
                        if (clsValidation.UsernameHasComplexity(tbxUsername.Text))
                        {
                            //check password
                            if (clsValidation.PasswordHasComplexity(tbxPassword.Text))
                            {
                                //calls proper clsSql method to insert data
                                if (clsSQL.WriteLoginData(cbxTitle, tbxFirstN, tbxMiddleN, tbxLastN, tbxSuffix, tbxAddress1, tbxAddress2, tbxAddress3, tbxCity, tbxZipcode,
                                    cbxState, tbxEmail, tbxPhone1, tbxPhone2, cbxSecQuest1, tbxAnswer1, cbxSecQuest2, tbxAnswer2, cbxSecQuest3, tbxAnswer3, tbxUsername, tbxPassword))
                                {
                                    //message for success and returns to login form
                                    MessageBox.Show("Account Created Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    logon.Show();
                                    signup.Hide();
                                }
                            }
                        }
                    }
                }
            } 
            else 
            {
                //if user enters email, check email validation
                if(clsValidation.EmailMatch(tbxEmail.Text))
                {
                    if (clsValidation.RequiredFields(tbxFirstN.Text, tbxLastN.Text, tbxAddress1.Text, tbxCity.Text, cbxState.Text, cbxSecQuest1.Text, cbxSecQuest2.Text, cbxSecQuest3.Text, tbxAnswer1.Text, tbxAnswer2.Text, tbxAnswer3.Text))
                    {
                        //check zipcode next
                        if (clsValidation.ZipCodeMatch(tbxZipcode.Text))
                        {
                            //check username
                            if (clsValidation.UsernameHasComplexity(tbxUsername.Text))
                            {
                                //check password
                                if (clsValidation.PasswordHasComplexity(tbxPassword.Text))
                                {
                                    //calls proper clsSql method to insert data
                                    if (clsSQL.WriteLoginData(cbxTitle, tbxFirstN, tbxMiddleN, tbxLastN, tbxSuffix, tbxAddress1, tbxAddress2, tbxAddress3, tbxCity, tbxZipcode,
                                        cbxState, tbxEmail, tbxPhone1, tbxPhone2, cbxSecQuest1, tbxAnswer1, cbxSecQuest2, tbxAnswer2, cbxSecQuest3, tbxAnswer3, tbxUsername, tbxPassword))
                                    {
                                        //message for success and returns to login form
                                        MessageBox.Show("Account Created Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        logon.Show();
                                        signup.Hide();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //method for logging in
        internal static void Login(TextBox tbxPass, TextBox tbxUser, frmLogon logon, frmMain main)
        {
            //call proper clsValidation methods for validation
            //check username validation
            if (clsValidation.UsernameHasComplexity(tbxUser.Text))
            {
                //if username is valid, check password validation
                if (clsValidation.PasswordHasComplexity(tbxPass.Text))
                {
                    //if both are valid call clsSql
                    //check credentials
                    if (clsSQL.ReadLoginData(tbxUser, tbxPass))
                    {
                        //if credentials are true succesfully login
                        main.Show();
                        logon.Hide();
                    }
                }
            }

        }

        //method for updating reset form
        internal static void UpdateReset(TextBox tbxUser, TextBox tbxQ1, TextBox tbxQ2, TextBox tbxQ3, frmReset reset, Button btnReset, Button btnUpdate)
        {
            //call clsSql method for updating
            if(clsSQL.UpdateResetData(tbxUser, tbxQ1, tbxQ2, tbxQ3))
            {
                //refresh screen and enable reser button
                //disable update button
                reset.Refresh();
                btnReset.Enabled = true;
                btnUpdate.Enabled = false;
            }

        }

        //method for resetting password
        internal static void Reset(TextBox tbxUser, TextBox tbxA1, TextBox tbxA2, TextBox tbxA3, TextBox tbxNewP, TextBox tbxConfirmP, frmLogon logon, frmReset reset)
        {
            //call proper clsValidation methods for validation
            //check answer fields first
            if(clsValidation.AnswerExist(tbxA1.Text, tbxA2.Text, tbxA3.Text))
            {
                //check password validation
                if(clsValidation.PasswordHasComplexity(tbxNewP.Text))
                {
                    //if valid password, call clsSql method for Resetting Password
                    if(clsSQL.WriteResetData(tbxUser, tbxA1, tbxA2, tbxA3, tbxNewP, tbxConfirmP))
                    {
                        //message for success and returns to login form
                        MessageBox.Show("Password Reset Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        logon.Show();
                        reset.Close();                        
                    }
                }
            }
        }
    }
}
