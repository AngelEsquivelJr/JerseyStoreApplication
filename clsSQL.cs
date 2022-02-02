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
//ToDo: clsSQL - Write to DataTable: Create a validation method
//ToDo: clsSQL - Update DataTable values: Create a validation method
//ToDo: clsSQL - Read from DataTable: Create a validation method
//ToDo: clsSQL - Handle Errors: Create a validation method
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
                _cntDatabase.Close();
                OpenDatabase();
            }
        }

        //method to close database
        internal static void CloseDatabase()
        {            
            //close connection
            _cntDatabase.Close();
        }

        //method to write new user info to datatable
        internal static void WriteLoginData(ComboBox cbxTitle, TextBox tbxFirstN, TextBox tbxMiddleN, TextBox tbxLastN, TextBox tbxSuffix,
            TextBox tbxAddress1, TextBox tbxAddress2, TextBox tbxAddress3, TextBox tbxCity, TextBox tbxZipcode, ComboBox cbxState,
            TextBox tbxEmail, TextBox tbxPhone1, TextBox tbxPhone2, ComboBox cbxSecQuest1, TextBox tbxAnswer1, ComboBox cbxSecQuest2,
            TextBox tbxAnswer2, ComboBox cbxSecQuest3, TextBox tbxAnswer3, TextBox tbxUsername, TextBox tbxPassword)
        {
            OpenDatabase();

            //string commands to create user
            string sqlquery = "INSERT INTO EsquivelA22Sp2332.Person (Title, NameFirst, NameMiddle, NameLast, Suffix, Address1, Address2," +
                " Address3, City, Zipcode, State, Email, PhonePrimary, PhoneSecondary) VALUES (@Title, @NameFirst, @NameMiddle, @NameLast, @Suffix," +
                " @Address1, @Address2, @Address3, @City, @Zipcode, @State, @Email, @PhonePrimary, @PhoneSecondary)";
            string sqlquery2 = "INSERT INTO EsquivelA22Sp2332.Logon (LogonName, Password, FirstChallengeQuestion, FirstChallengeAnswer," +
                " SecondChallengeQuestion, SecondChallengeAnswer, ThirdChallengeQuestion, ThirdChallengeAnswer, PositionTitle) VALUES (@LogonName," +
                " @Password, @FirstChallengeQuestion, @FirstChallengeAnswer, @SecondChallengeQuestion, @SecondChallengeAnswer, @ThirdChallengeQuestion," +
                " @ThirdChallengeAnswer, 'Customer')";

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

            SqlCommand cmd2 = new SqlCommand(sqlquery2, _cntDatabase);
            cmd2.Parameters.AddWithValue("@LogonName", tbxUsername.Text);
            cmd2.Parameters.AddWithValue("@Password", tbxPassword.Text);
            cmd2.Parameters.AddWithValue("@FirstChallengeQuestion", cbxSecQuest1.Text);
            cmd2.Parameters.AddWithValue("@FirstChallengeAnswer", tbxAnswer1.Text);
            cmd2.Parameters.AddWithValue("@SecondChallengeQuestion", cbxSecQuest2.Text);
            cmd2.Parameters.AddWithValue("@SecondChallengeAnswer", tbxAnswer2.Text);
            cmd2.Parameters.AddWithValue("@ThirdChallengeQuestion", cbxSecQuest3.Text);
            cmd2.Parameters.AddWithValue("@ThirdChallengeAnswer", tbxAnswer3.Text);

            //executes querys and closes reader
            SqlDataReader rd = cmd.ExecuteReader();
            SqlDataReader rd2 = cmd2.ExecuteReader();
            rd.Close();
            rd2.Close();

        }

        //method to update login data
        internal static void UpdateLoginData()
        {

        }

        //method to read login data
        //and check credentials
        internal static void ReadLoginData(TextBox tbxUsername, TextBox tbxPassword)
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
            if(rd.Read())
            {

            }

        }

    }
}
