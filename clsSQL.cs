//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
// Application used to browse and buy jerseys.
//*******************************************
// Class Purpose:
/*      Handles connections, INSERT/UPDATE/DELETE, and SELECT
 *      
 *      - Schema names must be a class level constant.
 *      - No query strings will be passed to the clsSQL.cs
 *      - Efficient code that uses a minimal amount of methods/functions for
 *        connecting to the database. Connection strings exist
 *        in only one location (global variable or constant).
 *      - Efficient code that uses a minimal amount of methods/functions for
 *        handling data manipulation. Appropriate methods for each of the DML statements.
 *      - Efficient code that uses a minimal amount of methods/functions for 
 *        querying the database. Methods usage can include populating application controls.
 *      - Efficient code that uses a minimal amount of methods/functions for handling SQL
 *      - Exceptions. SQL specific exception handling is better than generic handling.
 *      - All SQL related strings (connections strings, query strings, etc) contained inside of the class. Pass parameters or references and use overloading
 */
//*******************************************
//*******************************************


using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalProject
{
    internal class clsSQL
    {
        //schema name
        private const string strSchema = "EsquivelA22Sp2332";
        //connection string
        private const string CONNECT_STRING = @"Server=cstnt.tstc.edu;Database=inew2332sp22;User Id=EsquivelA22Sp2332;password=Ae1758192";
        //build a connection to database
        private static SqlConnection _cntDatabase = new SqlConnection(CONNECT_STRING);

        //method to open database
        internal static void OpenDatabase()
        {
            //open connection
            try
            {
                _cntDatabase.Open();
            }
            catch (Exception ex)
            {
                //call connection error method
                ConnectionFail(ex);
                //close database
                _cntDatabase.Close();
            }
        }

        //method to close database
        internal static void CloseDatabase()
        {
            //close connection
            _cntDatabase.Close();
        }

        //method to fill comboboxes
        internal static void FillCombo(ComboBox cbxQuestion1, ComboBox cbxQuestion2, ComboBox cbxQuestion3)
        {
            OpenDatabase();
            //commands for data
            SqlCommand cmd1 = new SqlCommand("Select QuestionID, QuestionPrompt from " + strSchema + ".SecurityQuestions WHERE SetID = 1", _cntDatabase);
            SqlCommand cmd2 = new SqlCommand("Select QuestionID, QuestionPrompt from " + strSchema + ".SecurityQuestions WHERE SetID = 2", _cntDatabase);
            SqlCommand cmd3 = new SqlCommand("Select QuestionID, QuestionPrompt from " + strSchema + ".SecurityQuestions WHERE SetID = 3", _cntDatabase);

            //data adapters
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);


            //data table
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();

            //fill data set
            da1.Fill(dt);
            da2.Fill(dt2);
            da3.Fill(dt3);

            //insert to data table
            DataRow dRow = dt.NewRow();
            dRow[0] = 0;
            dRow[1] = "Please Select";
            dt.Rows.InsertAt(dRow, 0);

            DataRow dRow2 = dt2.NewRow();
            dRow2[0] = 0;
            dRow2[1] = "Please Select";
            dt2.Rows.InsertAt(dRow2, 0);

            DataRow dRow3 = dt3.NewRow();
            dRow3[0] = 0;
            dRow3[1] = "Please Select";
            dt3.Rows.InsertAt(dRow3, 0);

            //close connection
            CloseDatabase();

            //setup comboboxes
            cbxQuestion1.DataSource = dt;
            cbxQuestion1.DisplayMember = "QuestionPrompt";
            cbxQuestion1.ValueMember = "QuestionID";

            cbxQuestion2.DataSource = dt2;
            cbxQuestion2.DisplayMember = "QuestionPrompt";
            cbxQuestion2.ValueMember = "QuestionID";

            cbxQuestion3.DataSource = dt3;
            cbxQuestion3.DisplayMember = "QuestionPrompt";
            cbxQuestion3.ValueMember = "QuestionID";

        }

        //structure for holding textbox and combobox parameters
        public struct SQLBoxParams
        {
            public ComboBox cTitle, cState, cSecQuest1, cSecQuest2, cSecQuest3;

            public TextBox tFirstN, tMiddleN, tLastN, tSuffix, tAddress1, tAddress2, tAddress3, tCity, tZipcode, tEmail, tPhone1, tPhone2, tAnswer1, tAnswer2, tAnswer3, tUser, tPassword;
        }

        //method to write new user info to datatable
        internal static bool WriteLoginData(SQLBoxParams bxParams)
        {

            //var for question id and person id
            int intID1 = 0;
            int intID2 = 0;
            int intID3 = 0;
            int intPersonID = 0;

            bool bolID1;
            bool bolID2;
            bool bolID3;

            //string commands to create user
            string strSqlQuery = "INSERT INTO " + strSchema + ".Person (Title, NameFirst, NameMiddle, NameLast, Suffix, Address1, Address2," +
                " Address3, City, Zipcode, State, Email, PhonePrimary, PhoneSecondary) VALUES (@Title, @NameFirst, @NameMiddle, @NameLast, @Suffix," +
                " @Address1, @Address2, @Address3, @City, @Zipcode, @State, @Email, @PhonePrimary, @PhoneSecondary)";
            string strSqlQuery2 = "INSERT INTO " + strSchema + ".Logon (PersonID, LogonName, Password, FirstChallengeQuestion, FirstChallengeAnswer," +
                " SecondChallengeQuestion, SecondChallengeAnswer, ThirdChallengeQuestion, ThirdChallengeAnswer, PositionTitle) VALUES (@PersonID, @LogonName," +
                " @Password, @FirstChallengeQuestion, @FirstChallengeAnswer, @SecondChallengeQuestion, @SecondChallengeAnswer, @ThirdChallengeQuestion," +
                " @ThirdChallengeAnswer, 'Customer')";
            string strSqlQuery3 = "SELECT PersonID, NameFirst FROM " + strSchema + ".Person where NameFirst = @NameFirst;";
            string strSqlQuery4 = "SELECT LogonName FROM " + strSchema + ".Logon where LogonName = @LogonName;";

            //set proper set id to question id var
            bolID1 = int.TryParse(bxParams.cSecQuest1.SelectedValue.ToString(), out intID1);
            bolID2 = int.TryParse(bxParams.cSecQuest2.SelectedValue.ToString(), out intID2);
            bolID3 = int.TryParse(bxParams.cSecQuest3.SelectedValue.ToString(), out intID3);

            OpenDatabase();

            try
            {

                //command query for logon name
                SqlCommand cmd4 = new SqlCommand(strSqlQuery4, _cntDatabase);
                cmd4.Parameters.AddWithValue("@LogonName", bxParams.tUser.Text);
                SqlDataReader rd4 = cmd4.ExecuteReader();

                //if statement to check if username already exists
                if (rd4.Read())
                {
                    //string for returned value
                    string strUsername = rd4.GetValue(0).ToString();

                    //if returned username is the same send error
                    if (strUsername.ToUpper().Contains(bxParams.tUser.Text.ToUpper()))
                    {
                        MessageBox.Show("The username entered already exists. Please enter a new username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rd4.Close();
                        CloseDatabase();
                        return false;
                    }
                    else
                        rd4.Close();

                }
                else
                {
                    //close reader
                    rd4.Close();
                }

                //sets up querys to insert user data
                SqlCommand cmd = new SqlCommand(strSqlQuery, _cntDatabase);
                cmd.Parameters.AddWithValue("@Title", bxParams.cTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@NameFirst", bxParams.tFirstN.Text.Trim());
                cmd.Parameters.AddWithValue("@NameMiddle", bxParams.tMiddleN.Text.Trim());
                cmd.Parameters.AddWithValue("@NameLast", bxParams.tLastN.Text.Trim());
                cmd.Parameters.AddWithValue("@Suffix", bxParams.tSuffix.Text.Trim());
                cmd.Parameters.AddWithValue("@Address1", bxParams.tAddress1.Text.Trim());
                cmd.Parameters.AddWithValue("@Address2", bxParams.tAddress2.Text.Trim());
                cmd.Parameters.AddWithValue("@Address3", bxParams.tAddress3.Text.Trim());
                cmd.Parameters.AddWithValue("@City", bxParams.tCity.Text.Trim());
                cmd.Parameters.AddWithValue("@Zipcode", bxParams.tZipcode.Text.Trim());
                cmd.Parameters.AddWithValue("@State", bxParams.cState.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", bxParams.tEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@PhonePrimary", bxParams.tPhone1.Text.Trim());
                cmd.Parameters.AddWithValue("@PhoneSecondary", bxParams.tPhone2.Text.Trim());

                //executes querys and closes reader
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Close();

                //command query for personId
                SqlCommand cmd3 = new SqlCommand(strSqlQuery3, _cntDatabase);
                cmd3.Parameters.AddWithValue("@NameFirst", bxParams.tFirstN.Text);
                SqlDataReader rd3 = cmd3.ExecuteReader();

                //if statement to set person id
                if (rd3.Read())
                {
                    //string for returned values
                    string strPersonID = rd3.GetValue(0).ToString();
                    string strName = rd3.GetValue(1).ToString();
                    //set string to int var
                    intPersonID = int.Parse(strPersonID);
                    //close reader
                    rd3.Close();
                }
                else
                {
                    //error for not finding person id / username
                    MessageBox.Show("Could not find proper Username for PersonID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rd3.Close();
                    CloseDatabase();
                    return false;
                }


                //insert data to logon
                SqlCommand cmd2 = new SqlCommand(strSqlQuery2, _cntDatabase);
                cmd2.Parameters.AddWithValue("@PersonID", intPersonID);
                cmd2.Parameters.AddWithValue("@LogonName", bxParams.tUser.Text.Trim());
                cmd2.Parameters.AddWithValue("@Password", bxParams.tPassword.Text.Trim());
                cmd2.Parameters.AddWithValue("@FirstChallengeQuestion", intID1);
                cmd2.Parameters.AddWithValue("@FirstChallengeAnswer", bxParams.tAnswer1.Text.Trim());
                cmd2.Parameters.AddWithValue("@SecondChallengeQuestion", intID2);
                cmd2.Parameters.AddWithValue("@SecondChallengeAnswer", bxParams.tAnswer2.Text.Trim());
                cmd2.Parameters.AddWithValue("@ThirdChallengeQuestion", intID3);
                cmd2.Parameters.AddWithValue("@ThirdChallengeAnswer", bxParams.tAnswer3.Text.Trim());

                //executes querys and closes reader
                SqlDataReader rd2 = cmd2.ExecuteReader();
                rd2.Close();


                //closes database
                CloseDatabase();
                //return successful attempt
                return true;

            }
            catch (Exception ex)
            {
                InsertDataFail(ex);
                return false;
            }

        }

        //method to read logon data
        //and check credentials
        internal static bool ReadLoginData(TextBox tbxUsername, TextBox tbxPassword)
        {
            OpenDatabase();

            //string command for logon table
            string strSqlQuery = "SELECT LogonName, Password, PositionTitle FROM " + strSchema + ".Logon " +
                "WHERE LogonName = @LogonName";
            try
            {
                //command query
                SqlCommand cmd = new SqlCommand(strSqlQuery, _cntDatabase);
                cmd.Parameters.AddWithValue("@LogonName", tbxUsername.Text);
                SqlDataReader rd = cmd.ExecuteReader();

                //if username is found return true
                if (rd.Read())
                {
                    //string for returned values
                    string strUsername = rd.GetValue(0).ToString();
                    string strPassword = rd.GetValue(1).ToString();
                    string strTitle = rd.GetValue(2).ToString();

                    //if returned username is the same
                    //make sure its not case sensitive
                    if (strUsername.ToUpper().Contains(tbxUsername.Text.ToUpper()))
                    {
                        //check password
                        if (strPassword == tbxPassword.Text)
                        {
                            //debug messagebox to see position title
                            MessageBox.Show("You are logging in as a " + strTitle + ".", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //returns true and closes reader
                            rd.Close();
                            //close database
                            CloseDatabase();
                            return true;
                        }
                        else
                        {
                            //if password not the same error pops up and reader closes
                            MessageBox.Show("Password is Incorrect. Please Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            rd.Close();
                            CloseDatabase();
                            //returns false
                            return false;
                        }
                    }
                    else
                    {
                        //username not the same error and reader closes
                        MessageBox.Show("Username is Incorrect. Please Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rd.Close();
                        CloseDatabase();
                        //returns false
                        return false;
                    }
                }
                else
                {
                    //logon name not found in database error
                    MessageBox.Show("Username match not found. Please Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rd.Close();
                    CloseDatabase();
                    //return false
                    return false;
                }
            }
            catch (Exception ex)
            {
                ConnectionFail(ex);
                return false;
            }
        }

        //method to update Reset form with correct info
        internal static bool UpdateResetData(TextBox tbxUsername, TextBox tbxQuest1, TextBox tbxQuest2, TextBox tbxQuest3)
        {

            OpenDatabase();

            try
            {
                //string command for logon table
                string strSqlQuery = "SELECT LogonName, Q1.QuestionPrompt, Q2.QuestionPrompt, Q3.QuestionPrompt FROM " + strSchema +
                    ".Logon L FULL JOIN " + strSchema + ".SecurityQuestions Q1 ON L.FirstChallengeQuestion = Q1.QuestionID" +
                    " FULL JOIN " + strSchema + ".SecurityQuestions Q2 ON L.SecondChallengeQuestion = Q2.QuestionID" +
                    " FULL JOIN " + strSchema + ".SecurityQuestions Q3 ON L.ThirdChallengeQuestion = Q3.QuestionID" +
                    " WHERE LogonName = @LogonName";

                //command query
                SqlCommand cmd = new SqlCommand(strSqlQuery, _cntDatabase);
                cmd.Parameters.AddWithValue("@LogonName", tbxUsername.Text);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    //string for returned values
                    string strUsername = rd.GetValue(0).ToString();
                    string strQuestion1 = rd.GetValue(1).ToString();
                    string strQuestion2 = rd.GetValue(2).ToString();
                    string strQuestion3 = rd.GetValue(3).ToString();

                    //if username is the same
                    //make sure its not case sensitive
                    if (strUsername.ToUpper().Contains(tbxUsername.Text.ToUpper()))
                    {
                        //set up question textboxes
                        tbxQuest1.Text = strQuestion1;
                        tbxQuest2.Text = strQuestion2;
                        tbxQuest3.Text = strQuestion3;

                        //set textbox to readonly and add username to textbox                   
                        tbxUsername.ReadOnly = true;
                        tbxUsername.Text = strUsername;

                        //close database
                        CloseDatabase();

                        return true;
                    }
                    else
                    {
                        //error for not finding matching username
                        MessageBox.Show("Could not find matching Username. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }

                }
                else
                {
                    //error for not finding username
                    MessageBox.Show("Could not find matching Username. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rd.Close();
                    CloseDatabase();
                    return false;
                }

            }
            catch (Exception ex)
            {
                UpdateDataFail(ex);
                CloseDatabase();
                return false;
            }

        }

        //method to write new data from reset form
        internal static bool WriteResetData(TextBox tbxUser, TextBox tbxAns1, TextBox tbxAns2, TextBox tbxAns3, TextBox tbxPassOne, TextBox tbxPassTwo)
        {
            //string commands to create new password
            string strSqlQuery = "SELECT LogonName, Password, FirstChallengeAnswer, SecondChallengeAnswer, ThirdChallengeAnswer FROM " + strSchema + ".Logon" +
                " WHERE LogonName = @LogonName";

            OpenDatabase();
            try
            {
                //command query
                SqlCommand cmd = new SqlCommand(strSqlQuery, _cntDatabase);
                cmd.Parameters.AddWithValue("@LogonName", tbxUser.Text);
                SqlDataReader rd = cmd.ExecuteReader();

                //find username match
                if (rd.Read())
                {
                    //set values in a string
                    string strUsername = rd.GetValue(0).ToString();
                    string strPassword = rd.GetValue(1).ToString();
                    string strAnswer1 = rd.GetValue(2).ToString();
                    string strAnswer2 = rd.GetValue(3).ToString();
                    string strAnswer3 = rd.GetValue(4).ToString();

                    rd.Close();

                    //check that answers are correct
                    //make sure its not case sensitive
                    if (tbxAns1.Text.ToUpper().Contains(strAnswer1.ToUpper()) && tbxAns2.Text.ToUpper().Contains(strAnswer2.ToUpper()) && tbxAns3.Text.ToUpper().Contains(strAnswer3.ToUpper()))
                    {
                        //check to make sure the password is new
                        if (strPassword != tbxPassOne.Text)
                        {
                            //if new check requirements
                            if (clsValidation.PasswordValidation(tbxPassOne.Text))
                            {
                                //check that new password matches
                                if (tbxPassOne.Text == tbxPassTwo.Text)
                                {
                                    //if answers are correct update old password
                                    //string command to update password
                                    string sqlquery2 = "UPDATE " + strSchema + ".Logon SET Password = @Password" +
                                    " WHERE LogonName = @LogonName";

                                    //insert new password and return success
                                    //command query
                                    SqlCommand cmd2 = new SqlCommand(sqlquery2, _cntDatabase);
                                    cmd2.Parameters.AddWithValue("@LogonName", tbxUser.Text);
                                    cmd2.Parameters.AddWithValue("@Password", tbxPassTwo.Text.Trim());
                                    SqlDataReader rd2 = cmd2.ExecuteReader();

                                    rd2.Close();

                                    //close database
                                    CloseDatabase();
                                    return true;
                                }
                                else
                                {
                                    //error for passwords not matching
                                    MessageBox.Show("The new password entered does not match the confirmed password. Try Again.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    rd.Close();
                                    CloseDatabase();
                                    return false;
                                }
                            }
                            else
                            {
                                rd.Close();
                                CloseDatabase();
                                return false;
                            }
                        }
                        else
                        {
                            //error for password matching
                            MessageBox.Show("The new password is the same as your old password. Please enter a new password.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            rd.Close();
                            CloseDatabase();
                            return false;
                        }
                    }
                    else
                    {
                        //error for answers being wrong
                        MessageBox.Show("One or more Answers are incorrect.", "Answer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        rd.Close();
                        return false;
                    }

                }
                else
                {
                    //error for not finding username
                    MessageBox.Show("Could not find matching Username. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rd.Close();
                    CloseDatabase();
                    return false;
                }

            }
            catch (Exception ex)
            {
                InsertDataFail(ex);
                CloseDatabase();
                return false;
            }
        }

        //methods for handling database errors
        internal static void ConnectionFail(Exception ex)
        {
            MessageBox.Show("Unable to Connect to database. " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static void InsertDataFail(Exception ex)
        {
            MessageBox.Show("Unable to Insert data to database. " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static void UpdateDataFail(Exception ex)
        {
            MessageBox.Show("Unable to Update data from database. " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
