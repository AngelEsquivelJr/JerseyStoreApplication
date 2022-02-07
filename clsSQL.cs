//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: {Program Purpose Goes here}
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

// To See the 'ToDo' tags, go to the 'View' Menu and then select 'Task List'
// You can then double click on a 'ToDo' to go to that specific one in the list

//ToDo: ------------ clsSQL - Remove Form ToDo List, once completed (Listed Below) ------------
//ToDo: ------------ clsSQL - Remove Form ToDo List, once completed (Listed Above) ------------

using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalProject
{
    internal class clsSQL
    {
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

        //method to write new user info to datatable
        internal static bool WriteLoginData(ComboBox cbxTitle, TextBox tbxFirstN, TextBox tbxMiddleN, TextBox tbxLastN, TextBox tbxSuffix,
            TextBox tbxAddress1, TextBox tbxAddress2, TextBox tbxAddress3, TextBox tbxCity, TextBox tbxZipcode, ComboBox cbxState,
            TextBox tbxEmail, TextBox tbxPhone1, TextBox tbxPhone2, ComboBox cbxSecQuest1, TextBox tbxAnswer1, ComboBox cbxSecQuest2,
            TextBox tbxAnswer2, ComboBox cbxSecQuest3, TextBox tbxAnswer3, TextBox tbxUsername, TextBox tbxPassword)
        {

            //var for question id and person id
            int questID1 = 0;
            int questID2 = 0;
            int questID3 = 0;
            int personID = 0;

            //string commands to create user
            string sqlquery = "INSERT INTO EsquivelA22Sp2332.Person (Title, NameFirst, NameMiddle, NameLast, Suffix, Address1, Address2," +
                " Address3, City, Zipcode, State, Email, PhonePrimary, PhoneSecondary) VALUES (@Title, @NameFirst, @NameMiddle, @NameLast, @Suffix," +
                " @Address1, @Address2, @Address3, @City, @Zipcode, @State, @Email, @PhonePrimary, @PhoneSecondary)";
            string sqlquery2 = "INSERT INTO EsquivelA22Sp2332.Logon (PersonID, LogonName, Password, FirstChallengeQuestion, FirstChallengeAnswer," +
                " SecondChallengeQuestion, SecondChallengeAnswer, ThirdChallengeQuestion, ThirdChallengeAnswer, PositionTitle) VALUES (@PersonID, @LogonName," +
                " @Password, @FirstChallengeQuestion, @FirstChallengeAnswer, @SecondChallengeQuestion, @SecondChallengeAnswer, @ThirdChallengeQuestion," +
                " @ThirdChallengeAnswer, 'Customer')";
            string sqlquery3 = "SELECT PersonID, NameFirst FROM EsquivelA22Sp2332.Person where NameFirst = @NameFirst;";
            
            //if statements for setting questions into proper int id
            //setId 1
            if(cbxSecQuest1.Text == "What is your favorite Color?")
            {
                questID1 = 100;
            }
            else if (cbxSecQuest1.Text == "Your favorite Toy's name?")
            {
                questID1 = 101;
            }
            else if (cbxSecQuest1.Text == "Your Pet's name?")
            {
                questID1 = 102;
            }
            else
            {
                //error for question
                MessageBox.Show("Security Question One was not picked correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //setId 2
            if (cbxSecQuest2.Text == "Your Home Town name?")
            {
                questID2 = 103;
            }
            else if (cbxSecQuest2.Text == "Your mother's first name?")
            {
                questID2 = 104;
            }
            else if (cbxSecQuest2.Text == "Your favorite Football Team?")
            {
                questID2 = 105;
            }
            else
            {
                //error for question
                MessageBox.Show("Security Question Two was not picked correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //setId 3
            if (cbxSecQuest3.Text == "What is your favorite food?")
            {
                questID3 = 106;
            }
            else if (cbxSecQuest3.Text == "Favorite place to vacation?")
            {
                questID3 = 107;
            }
            else if (cbxSecQuest3.Text == "Name of your favorite book?")
            {
                questID3 = 108;
            }
            else
            {
                //error for question
                MessageBox.Show("Security Question Three was not picked correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            OpenDatabase();

            try
            {                
                //sets up querys to insert user data
                SqlCommand cmd = new SqlCommand(sqlquery, _cntDatabase);
                cmd.Parameters.AddWithValue("@Title", cbxTitle.Text);
                cmd.Parameters.AddWithValue("@NameFirst", tbxFirstN.Text);
                cmd.Parameters.AddWithValue("@NameMiddle", tbxMiddleN.Text);
                cmd.Parameters.AddWithValue("@NameLast", tbxLastN.Text);
                cmd.Parameters.AddWithValue("@Suffix", tbxSuffix.Text);
                cmd.Parameters.AddWithValue("@Address1", tbxAddress1.Text);
                cmd.Parameters.AddWithValue("@Address2", tbxAddress2.Text);
                cmd.Parameters.AddWithValue("@Address3", tbxAddress3.Text);
                cmd.Parameters.AddWithValue("@City", tbxCity.Text);
                cmd.Parameters.AddWithValue("@Zipcode", tbxZipcode.Text);
                cmd.Parameters.AddWithValue("@State", cbxState.Text);
                cmd.Parameters.AddWithValue("@Email", tbxEmail.Text);
                cmd.Parameters.AddWithValue("@PhonePrimary", tbxPhone1.Text);
                cmd.Parameters.AddWithValue("@PhoneSecondary", tbxPhone2.Text);

                //executes querys and closes reader
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Close();

                //command query for personId
                SqlCommand cmd3 = new SqlCommand(sqlquery3, _cntDatabase);
                cmd3.Parameters.AddWithValue("@NameFirst", tbxFirstN.Text);
                SqlDataReader rd3 = cmd3.ExecuteReader();

                //if statement to set person id
                if (rd3.Read())
                {
                    //string for returned values
                    string strPersonID = rd3.GetValue(0).ToString();
                    string strName = rd3.GetValue(1).ToString();
                    //set string to int var
                    personID = int.Parse(strPersonID);
                    //close reader
                    rd3.Close();
                }
                else
                {
                    //error for not finding person id / username
                    MessageBox.Show("Could not find proper Username for PersonID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rd3.Close();
                }

                //insert data to logon
                SqlCommand cmd2 = new SqlCommand(sqlquery2, _cntDatabase);
                cmd2.Parameters.AddWithValue("@PersonID", personID);
                cmd2.Parameters.AddWithValue("@LogonName", tbxUsername.Text);
                cmd2.Parameters.AddWithValue("@Password", tbxPassword.Text);
                cmd2.Parameters.AddWithValue("@FirstChallengeQuestion", questID1);
                cmd2.Parameters.AddWithValue("@FirstChallengeAnswer", tbxAnswer1.Text);
                cmd2.Parameters.AddWithValue("@SecondChallengeQuestion", questID2);
                cmd2.Parameters.AddWithValue("@SecondChallengeAnswer", tbxAnswer2.Text);
                cmd2.Parameters.AddWithValue("@ThirdChallengeQuestion", questID3);
                cmd2.Parameters.AddWithValue("@ThirdChallengeAnswer", tbxAnswer3.Text);

                //executes querys and closes reader
                SqlDataReader rd2 = cmd2.ExecuteReader();                
                rd2.Close();


                //closes database
                CloseDatabase();
                //return successfull attempt
                return true;

            } catch (Exception ex)
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
            string sqlquery = "SELECT LogonName, Password, PositionTitle FROM EsquivelA22Sp2332.Logon " +
                "WHERE LogonName = @LogonName";

            //command query
            SqlCommand cmd = new SqlCommand(sqlquery, _cntDatabase);
            cmd.Parameters.AddWithValue("@LogonName", tbxUsername.Text);
            SqlDataReader rd = cmd.ExecuteReader();

            //if username is found return true
            if (rd.Read())
            {
                //string for returned values
                string Username = rd.GetValue(0).ToString();
                string Password = rd.GetValue(1).ToString();
                string Title = rd.GetValue(2).ToString();

                //if returned username is the same
                if (Username == tbxUsername.Text)
                {
                    //check password
                    if (Password == tbxPassword.Text)
                    {
                        //debug messagebox to see position title
                        MessageBox.Show("You are logging in as a " + Title + ".", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //returns true and closes reader
                        rd.Close();
                        return true;
                    }
                    else
                    {
                        //if password not the same error pops up and reader closes
                        MessageBox.Show("Password is Incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rd.Close();
                        //returns false
                        return false;
                    }
                }
                else
                {
                    //username not the same error and reader closes
                    MessageBox.Show("Username is Incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rd.Close();
                    //returns false
                    return false;
                }
            }
            else
            {
                //logon name not found in database error
                MessageBox.Show("Username is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rd.Close();
                //return false
                return false;
            }
        }

        //method to update Reset form with correct info
        internal static bool UpdateResetData(TextBox tbxUsername, TextBox tbxQuest1, TextBox tbxQuest2, TextBox tbxQuest3)
        {
            //var for quest id
            int questID1 = 0;
            int questID2 = 0;
            int questID3 = 0;

            OpenDatabase();

            try
            {
                //string command for logon table
                string sqlquery = "SELECT LogonName, FirstChallengeQuestion, SecondChallengeQuestion, ThirdChallengeQuestion FROM EsquivelA22Sp2332.Logon " +
                    "WHERE LogonName = @LogonName";

                //command query
                SqlCommand cmd = new SqlCommand(sqlquery, _cntDatabase);
                cmd.Parameters.AddWithValue("@LogonName", tbxUsername.Text);
                SqlDataReader rd = cmd.ExecuteReader();

                //find username match
                if (rd.Read())
                {
                    //string for returned values
                    string Username = rd.GetValue(0).ToString();
                    string quest1 = rd.GetValue(1).ToString();
                    string quest2 = rd.GetValue(2).ToString();
                    string quest3 = rd.GetValue(3).ToString();

                    //set string to int var
                    questID1 = int.Parse(quest1);
                    questID2 = int.Parse(quest2);
                    questID3 = int.Parse(quest3);

                    //if username is the same
                    if (Username == tbxUsername.Text)
                    {
                        //if statements for setting textboxes
                        //setId 1
                        if (questID1 == 100)
                        {
                            tbxQuest1.Text = "What is your favorite Color?";
                        }
                        else if (questID1 == 101)
                        {
                            tbxQuest1.Text = "Your favorite Toy's name?";
                        }
                        else if (questID1 == 102)
                        {
                            tbxQuest1.Text = "Your Pet's name?";
                        }
                        else
                        {
                            //error for question
                            MessageBox.Show("Question id was not successfully found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //setId 2
                        if (questID2 == 103)
                        {
                            tbxQuest2.Text = "Your Home Town name?";
                        }
                        else if (questID2 == 104)
                        {
                            tbxQuest2.Text = "Your mother's first name?";
                        }
                        else if (questID2 == 105)
                        {
                            tbxQuest2.Text = "Your favorite Football Team?";
                        }
                        else
                        {
                            //error for question
                            MessageBox.Show("Question id was not successfully found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //setId 3
                        if (questID3 == 106)
                        {
                            tbxQuest3.Text = "What is your favorite food?";
                        }
                        else if (questID3 == 107)
                        {
                            tbxQuest3.Text = "Favorite place to vacation?";
                        }
                        else if (questID3 == 108)
                        {
                            tbxQuest3.Text = "Name of your favorite book?";
                        }
                        else
                        {
                            //error for question
                            MessageBox.Show("Question id was not successfully found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //set textbox to readonly and add username to textbox                   
                        tbxUsername.ReadOnly = true;
                        tbxUsername.Text = Username;

                        //close database
                        CloseDatabase();

                        return true;
                    }
                    else
                    {
                        //error for not finding matching username
                        MessageBox.Show("Could not find matching Username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                }
                else
                {
                    //error for not finding username
                    MessageBox.Show("Could not find proper Username match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rd.Close();
                    CloseDatabase();
                    return false;
                }
                
            } catch (Exception ex)
            {
                UpdateDataFail(ex);
                return false;
            }
            
        }

        //method to write new data from reset form
        internal static bool WriteResetData(TextBox tbxUser, TextBox tbxAns1, TextBox tbxAns2, TextBox tbxAns3, TextBox passOne, TextBox passTwo)
        {
            //string commands to create new password and delete old password
            string sqlquery = "SELECT LogonName, Password, FirstChallengeAnswer, SecondChallengeAnswer, ThirdChallengeAnswer FROM EsquivelA22Sp2332.Logon" +
                " WHERE LogonName = @LogonName";

            OpenDatabase();
            try
            {
                //command query
                SqlCommand cmd = new SqlCommand(sqlquery, _cntDatabase);
                cmd.Parameters.AddWithValue("@LogonName", tbxUser.Text);
                SqlDataReader rd = cmd.ExecuteReader();

                //find username match
                if (rd.Read())
                {
                    //set values in a string
                    string username = rd.GetValue(0).ToString();
                    string password = rd.GetValue(1).ToString();
                    string answer1 = rd.GetValue(2).ToString();
                    string answer2 = rd.GetValue(3).ToString();
                    string answer3 = rd.GetValue(4).ToString();

                    //check that answers are correct
                    if (answer1 == tbxAns1.Text && answer2 == tbxAns2.Text && answer3 == tbxAns3.Text)
                    {
                        //check to make sure the password is new
                        if (password != passOne.Text)
                        {
                            //check that new password matches
                            if (passOne.Text == passTwo.Text)
                            {
                                //if answers are correct remove old password                                
                                //insert new password and return success
                                //TODO - add new password, replace/remove old password

                                //close database
                                CloseDatabase();
                                return true;
                            }
                            else
                            {
                                //error for passwords not matching
                                MessageBox.Show("The new password is not the same as the confirm password field.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Could not find proper Username match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rd.Close();
                    return false;
                }

            }
            catch(Exception ex)
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
