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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

        //var for login name and ids
        public static string strLogonName = "Guest";
        public static string strName = "Guest";
        public static string strPositionTitle = "Empty";
        public static string strPID = "0";
        public static string strDID = "0";
        public static string strDiscountType = "0";
        public static int intItemDataQuantity = 0;

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

        //method to fill question combos
        internal static void FillQuestionCombo(ComboBox cbxQuestion1, ComboBox cbxQuestion2, ComboBox cbxQuestion3)
        {
            OpenDatabase();
            try
            {
                //commands for data
                SqlCommand cmdSet1 = new SqlCommand("Select QuestionID, QuestionPrompt from " + strSchema + ".SecurityQuestions WHERE SetID = 1", _cntDatabase);
                SqlCommand cmdSet2 = new SqlCommand("Select QuestionID, QuestionPrompt from " + strSchema + ".SecurityQuestions WHERE SetID = 2", _cntDatabase);
                SqlCommand cmdSet3 = new SqlCommand("Select QuestionID, QuestionPrompt from " + strSchema + ".SecurityQuestions WHERE SetID = 3", _cntDatabase);

                //data adapters
                SqlDataAdapter daSet1 = new SqlDataAdapter(cmdSet1);
                SqlDataAdapter daSet2 = new SqlDataAdapter(cmdSet2);
                SqlDataAdapter daSet3 = new SqlDataAdapter(cmdSet3);


                //data table
                DataTable dtSet1 = new DataTable();
                DataTable dtSet2 = new DataTable();
                DataTable dtSet3 = new DataTable();

                //fill data set
                daSet1.Fill(dtSet1);
                daSet2.Fill(dtSet2);
                daSet3.Fill(dtSet3);

                //insert to data table
                DataRow drSet1 = dtSet1.NewRow();
                drSet1[0] = 0;
                drSet1[1] = "Please Select";
                dtSet1.Rows.InsertAt(drSet1, 0);

                DataRow drSet2 = dtSet2.NewRow();
                drSet2[0] = 0;
                drSet2[1] = "Please Select";
                dtSet2.Rows.InsertAt(drSet2, 0);

                DataRow drSet3 = dtSet3.NewRow();
                drSet3[0] = 0;
                drSet3[1] = "Please Select";
                dtSet3.Rows.InsertAt(drSet3, 0);

                //close connection
                CloseDatabase();

                //setup comboboxes
                cbxQuestion1.DataSource = dtSet1;
                cbxQuestion1.DisplayMember = "QuestionPrompt";
                cbxQuestion1.ValueMember = "QuestionID";

                cbxQuestion2.DataSource = dtSet2;
                cbxQuestion2.DisplayMember = "QuestionPrompt";
                cbxQuestion2.ValueMember = "QuestionID";

                cbxQuestion3.DataSource = dtSet3;
                cbxQuestion3.DisplayMember = "QuestionPrompt";
                cbxQuestion3.ValueMember = "QuestionID";
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Could not fill security question combo boxes. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //method to write new user info to database
        internal static bool WriteLoginData(clsParameters.SignupParameters signupParameters)
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
            string strInsertQuery = "INSERT INTO " + strSchema + ".Person (Title, NameFirst, NameMiddle, NameLast, Suffix, Address1, Address2," +
                " Address3, City, Zipcode, State, Email, PhonePrimary, PhoneSecondary, PersonDeleted) VALUES (@Title, @NameFirst, @NameMiddle, @NameLast, @Suffix," +
                " @Address1, @Address2, @Address3, @City, @Zipcode, @State, @Email, @PhonePrimary, @PhoneSecondary, @PersonDeleted)";
            string strInsertQuery2 = "INSERT INTO " + strSchema + ".Logon (PersonID, LogonName, Password, FirstChallengeQuestion, FirstChallengeAnswer," +
                " SecondChallengeQuestion, SecondChallengeAnswer, ThirdChallengeQuestion, ThirdChallengeAnswer, PositionTitle) VALUES (@PersonID, @LogonName," +
                " @Password, @FirstChallengeQuestion, @FirstChallengeAnswer, @SecondChallengeQuestion, @SecondChallengeAnswer, @ThirdChallengeQuestion," +
                " @ThirdChallengeAnswer, 'Customer')";
            string strSelectQuery = "SELECT PersonID, NameFirst FROM " + strSchema + ".Person where NameFirst = @NameFirst;";
            string strSelectQuery2 = "SELECT LogonName FROM " + strSchema + ".Logon where LogonName = @LogonName;";

            //set proper set id to question id var
            bolID1 = int.TryParse(signupParameters.cbxSecQuestion1P.SelectedValue.ToString(), out intID1);
            bolID2 = int.TryParse(signupParameters.cbxSecQuestion2P.SelectedValue.ToString(), out intID2);
            bolID3 = int.TryParse(signupParameters.cbxSecQuestion3P.SelectedValue.ToString(), out intID3);

            OpenDatabase();

            try
            {
                //command query for logon name
                SqlCommand cmdSelectLogon = new SqlCommand(strSelectQuery2, _cntDatabase);
                cmdSelectLogon.Parameters.AddWithValue("@LogonName", signupParameters.tbxUsernameP.Text);
                SqlDataReader rdLogon = cmdSelectLogon.ExecuteReader();

                //if statement to check if username already exists
                if (rdLogon.Read())
                {
                    //string for returned value
                    string strUsername = rdLogon.GetValue(0).ToString();

                    //if returned username is the same send error
                    if (strUsername.ToUpper().Contains(signupParameters.tbxUsernameP.Text.ToUpper()))
                    {
                        MessageBox.Show("The username entered already exists. Please enter a new username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rdLogon.Close();
                        CloseDatabase();
                        return false;
                    }
                    else
                        rdLogon.Close();

                }
                else
                {
                    //close reader
                    rdLogon.Close();
                }

                //sets up querys to insert user data
                SqlCommand cmdInsert = new SqlCommand(strInsertQuery, _cntDatabase);
                cmdInsert.Parameters.AddWithValue("@Title", signupParameters.cbxTitleP.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@NameFirst", signupParameters.tbxFirstNameP.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@NameMiddle", signupParameters.tbxMiddleNameP.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@NameLast", signupParameters.tbxLastNameP.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@Suffix", signupParameters.tbxSuffixP.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@Address1", signupParameters.tbxAddress1P.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@Address2", signupParameters.tbxAddress2P.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@Address3", signupParameters.tbxAddress3P.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@City", signupParameters.tbxCityP.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@Zipcode", signupParameters.tbxZipcodeP.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@State", signupParameters.cbxStateP.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@Email", signupParameters.tbxEmailP.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@PhonePrimary", signupParameters.tbxPhone1P.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@PhoneSecondary", signupParameters.tbxPhone2P.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@PersonDeleted", "0");

                //executes querys and closes reader
                SqlDataReader rdInsert = cmdInsert.ExecuteReader();
                rdInsert.Close();

                //command query for personId
                SqlCommand cmdSelect = new SqlCommand(strSelectQuery, _cntDatabase);
                cmdSelect.Parameters.AddWithValue("@NameFirst", signupParameters.tbxFirstNameP.Text);
                SqlDataReader rdSelect = cmdSelect.ExecuteReader();

                //if statement to set person id
                if (rdSelect.Read())
                {
                    //string for returned values
                    string strPersonID = rdSelect.GetValue(0).ToString();
                    string strName = rdSelect.GetValue(1).ToString();
                    //set string to int var
                    intPersonID = int.Parse(strPersonID);
                    //close reader
                    rdSelect.Close();
                }
                else
                {
                    //error for not finding person id / username
                    MessageBox.Show("Could not find proper Username for PersonID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdSelect.Close();
                    CloseDatabase();
                    return false;
                }


                //insert data to logon
                SqlCommand cmdInsert2 = new SqlCommand(strInsertQuery2, _cntDatabase);
                cmdInsert2.Parameters.AddWithValue("@PersonID", intPersonID);
                cmdInsert2.Parameters.AddWithValue("@LogonName", signupParameters.tbxUsernameP.Text.Trim());
                cmdInsert2.Parameters.AddWithValue("@Password", signupParameters.tbxPasswordP.Text.Trim());
                cmdInsert2.Parameters.AddWithValue("@FirstChallengeQuestion", intID1);
                cmdInsert2.Parameters.AddWithValue("@FirstChallengeAnswer", signupParameters.tbxAnswer1P.Text.Trim());
                cmdInsert2.Parameters.AddWithValue("@SecondChallengeQuestion", intID2);
                cmdInsert2.Parameters.AddWithValue("@SecondChallengeAnswer", signupParameters.tbxAnswer2P.Text.Trim());
                cmdInsert2.Parameters.AddWithValue("@ThirdChallengeQuestion", intID3);
                cmdInsert2.Parameters.AddWithValue("@ThirdChallengeAnswer", signupParameters.tbxAnswer3P.Text.Trim());

                //executes querys and closes reader
                SqlDataReader rdInsert2 = cmdInsert2.ExecuteReader();
                rdInsert2.Close();

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
            string strSelectQuery = "SELECT L.LogonName, L.PersonID, L.Password, L.PositionTitle, P.NameFirst, P.NameLast, P.PersonDeleted FROM " + strSchema + ".Logon L " +
                "FULL JOIN "+ strSchema + ".Person P ON L.PersonID = P.PersonID WHERE L.LogonName = @LogonName";
            try
            {
                //command query
                SqlCommand cmd = new SqlCommand(strSelectQuery, _cntDatabase);
                cmd.Parameters.AddWithValue("@LogonName", tbxUsername.Text);
                SqlDataReader rd = cmd.ExecuteReader();

                //if username is found return true
                if (rd.Read())
                {
                    //string for returned values
                    string strUsername = rd.GetValue(0).ToString();
                    string strPersonID = rd.GetValue(1).ToString();
                    string strPassword = rd.GetValue(2).ToString();
                    string strTitle = rd.GetValue(3).ToString();
                    string strFirst = rd.GetValue(4).ToString();
                    string strLast = rd.GetValue(5).ToString();
                    string strDeleted = rd.GetValue(6).ToString();

                    //if returned username is the same
                    //make sure its not case sensitive
                    if (strUsername.ToUpper().Contains(tbxUsername.Text.ToUpper()))
                    {
                        //check password
                        if (strPassword == tbxPassword.Text)
                        {
                            if (strDeleted.Contains("True"))
                            {
                                //if account is deleted stop login
                                MessageBox.Show("I'm sorry this account has been disabled/deleted. Please Try Again with another account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                rd.Close();
                                CloseDatabase();
                                //returns false
                                return false;
                            }
                            else
                            {
                                //set logon name var
                                strLogonName = strUsername;
                                strPID = strPersonID;
                                strPositionTitle = strTitle;
                                strName = strFirst + " " + strLast;

                                //returns true and closes reader
                                rd.Close();
                                //close database
                                CloseDatabase();
                                return true;
                            }
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
                string strSelectQuery = "SELECT LogonName, Q1.QuestionPrompt, Q2.QuestionPrompt, Q3.QuestionPrompt FROM " + strSchema +
                    ".Logon L FULL JOIN " + strSchema + ".SecurityQuestions Q1 ON L.FirstChallengeQuestion = Q1.QuestionID" +
                    " FULL JOIN " + strSchema + ".SecurityQuestions Q2 ON L.SecondChallengeQuestion = Q2.QuestionID" +
                    " FULL JOIN " + strSchema + ".SecurityQuestions Q3 ON L.ThirdChallengeQuestion = Q3.QuestionID" +
                    " WHERE LogonName = @LogonName";

                //command query
                SqlCommand cmdUpdate = new SqlCommand(strSelectQuery, _cntDatabase);
                cmdUpdate.Parameters.AddWithValue("@LogonName", tbxUsername.Text);
                SqlDataReader rdUpdate = cmdUpdate.ExecuteReader();

                if (rdUpdate.Read())
                {
                    //string for returned values
                    string strUsername = rdUpdate.GetValue(0).ToString();
                    string strQuestion1 = rdUpdate.GetValue(1).ToString();
                    string strQuestion2 = rdUpdate.GetValue(2).ToString();
                    string strQuestion3 = rdUpdate.GetValue(3).ToString();

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
                    rdUpdate.Close();
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
            string strSelectQuery = "SELECT LogonName, Password, FirstChallengeAnswer, SecondChallengeAnswer, ThirdChallengeAnswer FROM " + strSchema + ".Logon" +
                " WHERE LogonName = @LogonName";

            OpenDatabase();
            try
            {
                //command query
                SqlCommand cmd = new SqlCommand(strSelectQuery, _cntDatabase);
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
                                    string strUpdateQuery = "UPDATE " + strSchema + ".Logon SET Password = @Password" +
                                    " WHERE LogonName = @LogonName";

                                    //insert new password and return success
                                    //command query
                                    SqlCommand cmdUpdate = new SqlCommand(strUpdateQuery, _cntDatabase);
                                    cmdUpdate.Parameters.AddWithValue("@LogonName", tbxUser.Text);
                                    cmdUpdate.Parameters.AddWithValue("@Password", tbxPassTwo.Text.Trim());
                                    SqlDataReader rd2 = cmdUpdate.ExecuteReader();

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

        //Main Form Information

        //data command
        public static SqlCommand _sqlInventoryCommand;
        //data adapter
        public static SqlDataAdapter _daInventory = new SqlDataAdapter();
        //data tables
        public static DataTable _dtInventoryTable = new DataTable();
        public static DataTable _dtProductDescriptionTable = new DataTable();

        //method to set images from database
        internal static void ImageInventory(DataGridView dgvInventory)
        {
            //make byte var
            byte[] imageData = null;
            Int32 intWidth = 140;

            try
            {
                
                for (int i = 0; i < dgvInventory.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(_dtInventoryTable.Rows[i]["Image"].ToString()))
                    {
                        //set image to byte and use temporary image
                        imageData = (byte[])_dtInventoryTable.Rows[i]["Image"];
                        Image tmpImage = Image.FromStream(new MemoryStream(imageData));
                        //scale image and set resized image
                        double dblScaleImg = (double)intWidth / (double)tmpImage.Width;
                        Graphics tmpGraphics = default(Graphics);
                        Bitmap tmpResizedImage = new Bitmap(Convert.ToInt32(dblScaleImg * tmpImage.Width), Convert.ToInt32(dblScaleImg * tmpImage.Height));
                        tmpGraphics = Graphics.FromImage(tmpResizedImage);
                        tmpGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                        tmpGraphics.DrawImage(tmpImage, 0, 0, tmpResizedImage.Width + 1, tmpResizedImage.Height + 1);
                        Image imgOut = tmpResizedImage;

                        //add image to data grid view
                        dgvInventory.Rows[i].Cells[0].Value = imgOut;
                    }
                }
                CloseDatabase();
            }
            catch(Exception)
            {
                //error message
                MessageBox.Show("Error gathering all Images.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        //method to format and bind data grid view
        internal static void BindInventoryView(DataGridView dgvInventory, string strSport, string strSize)
        {
            //set command object to null
            _sqlInventoryCommand = null;

            //reset data adapter and data table to new
            _daInventory = new SqlDataAdapter();
            _dtInventoryTable = new DataTable();
            string strDGVQuery;

            if (strSport == "null" && strSize == "null")
            {
                //string query
                strDGVQuery = "Select ItemImage as 'Image', ItemName as 'Name', RetailPrice as 'Price', Size, Quantity, ItemDescription as 'Description', Color, T.TeamSport as 'Sport' from " + strSchema + ".Inventory I INNER JOIN " +
                    strSchema + ".Teams T ON I.TeamID = T.TeamID Where Quantity > 0 AND Discontinued = 0";
            }
            else if(strSport == "null" && strSize != "null")
            {
                //string query
                strDGVQuery = "Select ItemImage as 'Image', ItemName as 'Name', RetailPrice as 'Price', Size, Quantity, ItemDescription as 'Description', Color, T.TeamSport as 'Sport' from " + strSchema + ".Inventory I INNER JOIN " +
                    strSchema + ".Teams T ON I.TeamID = T.TeamID Where Quantity > 0 AND Discontinued = 0 AND Size = '"+ strSize +"'";
            }
            else if(strSport != "null" && strSize == "null")
            {
                //string query
                strDGVQuery = "Select ItemImage as 'Image', ItemName as 'Name', RetailPrice as 'Price', Size, Quantity, ItemDescription as 'Description', Color, T.TeamSport as 'Sport' from " + strSchema + ".Inventory I INNER JOIN " +
                    strSchema + ".Teams T ON I.TeamID = T.TeamID Where Quantity > 0 AND Discontinued = 0 AND T.TeamSport = '" + strSport + "'";
            }
            else
            {
                //string query
                strDGVQuery = "Select ItemImage as 'Image', ItemName as 'Name', RetailPrice as 'Price', Size, Quantity, ItemDescription as 'Description', Color, T.TeamSport as 'Sport' from " + strSchema + ".Inventory I INNER JOIN " +
                    strSchema + ".Teams T ON I.TeamID = T.TeamID Where Quantity > 0 AND Discontinued = 0 AND T.TeamSport = '" + strSport +"' AND Size = '" + strSize +"'";
            }            

            //set command object to null
            _sqlInventoryCommand = null;

            //est command obj
            _sqlInventoryCommand = new SqlCommand(strDGVQuery, _cntDatabase);
            //establish data adapter
            _daInventory.SelectCommand = _sqlInventoryCommand;
            //fill data table
            _daInventory.Fill(_dtInventoryTable);
            //bind grid view to data table
            dgvInventory.DataSource = _dtInventoryTable;
            
        }

        //method to initialize data grid view
        internal static void InitializeInventoryView(DataGridView dgvInventory)
        {
            //open database
            OpenDatabase();

            //fill tables and objects
            try
            {
                string strFilter = "null", strSize = "null";
                //setup data
                BindInventoryView(dgvInventory, strFilter, strSize);

                if (dgvInventory.Columns.Count <= 8 && !dgvInventory.Columns.Contains("Item Image"))
                {
                    //setup image column
                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                    imageColumn.HeaderText = "Item Image";
                    dgvInventory.Columns.Insert(0, imageColumn);
                }

                //setup image
                ImageInventory(dgvInventory);
                dgvInventory.Columns.Remove("Image");

                //format view
                clsCart.FormatInventoryView(dgvInventory);

                //close database
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDatabase();
            }

            //dispose of command, adapter, and table 
            _sqlInventoryCommand.Dispose();
            _daInventory.Dispose();
            _dtInventoryTable.Dispose();
            //close database
            CloseDatabase();
        }

        //list vars for cart and checkout
        public static List<string> lstStrCart = new List<string>();
        public static List<string> lstStrNames = new List<string>();
        public static List<double> lstDblPrice = new List<double>();
        public static List<string> lstStrPrice = new List<string>();
        public static List<int> lstIntQuantity = new List<int>();
        public static List<int> lstIntItemQuantity = new List<int>();
        public static List<int> lstIntNewQuantity = new List<int>();
        public static List<int> lstIntInventoryID = new List<int>();
        public static List<string> lstStrTotal = new List<string>();
        public static List<double> lstDblCartPrice = new List<double>();
        public static List<int> lstIntProdCount = new List<int>();

        //method for applying discount
        internal static void ApplyDiscount(DataGridView dgvCart, TextBox tbxGross, TextBox tbxCode, TextBox tbxDiscount, TextBox tbxSub, TextBox tbxTax, TextBox tbxTotal)
        {
            //open database
            OpenDatabase();            

            try
            {                
                //string command for discounts table
                string strItemLevelQuery = "SELECT DiscountCode, Description, DiscountLevel, InventoryID, DiscountType, DiscountDollarAmount, DiscountPercentage," +
                    " ExpirationDate, DiscountID FROM " + strSchema + ".Discounts WHERE DiscountCode = @DiscountCode";
                //clear lists
                lstStrNames.Clear();
                lstIntInventoryID.Clear();
                //get names
                for (int i = 0; i < dgvCart.Rows.Count; i++)
                {
                    lstStrNames.Add((dgvCart.Rows[i].Cells[1].Value).ToString());
                }

                for (int i = 0; i < lstStrNames.Count; i++)
                {
                    //query for getting id
                    string strQuantityQuery = "SELECT InventoryID, RetailPrice  FROM " + strSchema + ".Inventory where ItemName = @ItemName;";
                    //command query for Quantity
                    SqlCommand cmdQuantity = new SqlCommand(strQuantityQuery, _cntDatabase);
                    cmdQuantity.Parameters.AddWithValue("@ItemName", lstStrNames[i]);
                    SqlDataReader rdQuantity = cmdQuantity.ExecuteReader();

                    //if statement to set id
                    if (rdQuantity.Read())
                    {
                        //string for returned values                            
                        string strInventoryId = rdQuantity.GetValue(0).ToString();
                        string strPrice = rdQuantity.GetValue(1).ToString();
                        //set string to int var
                        if (int.TryParse(strInventoryId, out int intID))
                        {
                            lstIntInventoryID.Add(intID);
                            //set price
                            if (double.TryParse(strPrice, out double dblSelectedCartPrice))
                            {
                                lstDblCartPrice.Add(dblSelectedCartPrice);
                                //close reader
                                rdQuantity.Close();
                            }
                        }
                    }
                    else
                    {
                        //error for not finding Quantity
                        MessageBox.Show("Could not find ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rdQuantity.Close();
                        CloseDatabase();
                    }
                }

                //command query
                SqlCommand cmdItemDiscount = new SqlCommand(strItemLevelQuery, _cntDatabase);
                cmdItemDiscount.Parameters.AddWithValue("@DiscountCode", tbxCode.Text);
                SqlDataReader rd = cmdItemDiscount.ExecuteReader();

                if (rd.Read())
                {
                    //vars for text boxes
                    if (!string.IsNullOrEmpty(tbxGross.Text) && tbxGross.Text != "$0")
                    {                        
                        string strDiscount = tbxDiscount.Text.Substring(1);
                        double dblSub, dblTax, dblNewTotal;
                        if (double.TryParse(tbxGross.Text.Substring(1), out double dblTotal))
                        {

                            //string for returned values
                            string strCode = rd.GetValue(0).ToString();
                            string strDescription = rd.GetValue(1).ToString();
                            string strLevel = rd.GetValue(2).ToString();
                            string strInventoryID = rd.GetValue(3).ToString();
                            string strType = rd.GetValue(4).ToString();
                            string strDollar = rd.GetValue(5).ToString();
                            string strPercentage = rd.GetValue(6).ToString();
                            string strExpiration = rd.GetValue(7).ToString();
                            string strDiscountID = rd.GetValue(8).ToString();
                            strDID = strDiscountID;

                            if(DateTime.TryParse(strExpiration, out DateTime expiryDate))
                            {
                                if(expiryDate == DateTime.Now)
                                {
                                    MessageBox.Show("Today is the last day to use this discount!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }                                                      
                            //get cart values
                            if (dgvCart.Rows.Count > 0)
                            {
                                //check expiration
                                if (expiryDate > DateTime.Now)
                                {
                                    if (double.TryParse(strDiscount, out double dblDiscount))
                                    {
                                        //check discount level
                                        if (strLevel == "1")
                                        {
                                            //item level
                                            //check if id is null
                                            if (string.IsNullOrEmpty(strInventoryID))
                                            {
                                                MessageBox.Show("Discount code is invalid. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else
                                            {
                                                //check type
                                                if (strType == "0")
                                                {
                                                    //percentage
                                                    if (double.TryParse(strPercentage, out double dblPercentage))
                                                    {
                                                        //discount, sub, tax, and total
                                                        for (int i = 0; i < lstDblCartPrice.Count; i++)
                                                        {
                                                            dblDiscount = lstDblCartPrice[i] * dblPercentage;
                                                        }

                                                        strDiscountType = dblPercentage.ToString("P");

                                                            dblSub = dblTotal - dblDiscount;
                                                            dblTax = dblSub * 0.0825;
                                                            dblNewTotal = dblSub + dblTax;

                                                            //add discount, sub, tax, and total
                                                            tbxDiscount.Text = dblDiscount.ToString("C");
                                                            tbxSub.Text = dblSub.ToString("C");
                                                            tbxTax.Text = dblTax.ToString("C");
                                                            tbxTotal.Text = dblNewTotal.ToString("C");
                                                    }
                                                }
                                                else
                                                {
                                                    //dollar
                                                    if (double.TryParse(strDollar, out double dblDollar))
                                                    {
                                                        //discount, sub, tax, and total
                                                        for (int i = 0; i < lstDblCartPrice.Count; i++)
                                                        {
                                                            strDiscountType = dblDollar.ToString("C");
                                                            dblDiscount = dblDollar;
                                                            dblSub = dblTotal - (lstDblCartPrice[i] - dblDiscount);
                                                            dblTax = dblSub * 0.0825;
                                                            dblNewTotal = dblSub + dblTax;

                                                            //add discount, sub, tax, and total
                                                            tbxDiscount.Text = dblDiscount.ToString("C");
                                                            tbxSub.Text = dblSub.ToString("C");
                                                            tbxTax.Text = dblTax.ToString("C");
                                                            tbxTotal.Text = dblNewTotal.ToString("C");
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                        else
                                        {
                                            //check type
                                            if (strType == "0")
                                            {
                                                //percentage
                                                if (double.TryParse(strPercentage, out double dblPercentage))
                                                {
                                                    //discount, sub, tax, and total
                                                    dblDiscount = dblTotal * dblPercentage;
                                                    dblSub = dblTotal - dblDiscount;
                                                    dblTax = dblSub * 0.0825;
                                                    dblNewTotal = dblSub + dblTax;
                                                    strDiscountType = dblPercentage.ToString("P");

                                                    //add discount, sub, tax, and total
                                                    tbxDiscount.Text = dblDiscount.ToString("C");
                                                    tbxSub.Text = dblSub.ToString("C");
                                                    tbxTax.Text = dblTax.ToString("C");
                                                    tbxTotal.Text = dblNewTotal.ToString("C");
                                                }
                                            }
                                            else
                                            {
                                                //dollar
                                                //dollar
                                                if (double.TryParse(strDollar, out double dblDollar))
                                                {
                                                    strDiscountType = dblDollar.ToString("C");
                                                    //discount, sub, tax, and total
                                                    dblDiscount = dblDollar;
                                                    dblSub = dblTotal - dblDiscount;
                                                    dblTax = dblSub * 0.0825;
                                                    dblNewTotal = dblSub + dblTax;

                                                    //add discount, sub, tax, and total
                                                    tbxDiscount.Text = dblDiscount.ToString("C");
                                                    tbxSub.Text = dblSub.ToString("C");
                                                    tbxTax.Text = dblTax.ToString("C");
                                                    tbxTotal.Text = dblNewTotal.ToString("C");
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Discount code is Expired. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    rd.Close();
                                    CloseDatabase();
                                }
                            }
                        }
                    }
                    rd.Close();
                    CloseDatabase();
                }
                else
                {
                    CloseDatabase();
                    rd.Close();
                    //error
                    MessageBox.Show("Discount code is invalid. Please Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception)
            {
                CloseDatabase();                
                //error message
                MessageBox.Show("Could not apply discount code. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //method for updating Orders table
        internal static void WriteOrders(int intDiscountID, int intPersonID, string strDate, string strCardNumber, string strExpiration, string strCCV)
        {
            try
            {                
                //check if discount is null
                if (intDiscountID == 0)
                {
                    //query to insert into orders table
                    string strInsertQuery = "INSERT INTO " + strSchema + ".Orders (PersonID, OrderDate, CC_Number, ExpDate, CCV)" +
                    "  VALUES (@PersonID, @OrderDate, @CC_Number, @ExpDate," +
                    " @CCV)";

                    //sets up querys to insert user data
                    SqlCommand cmdOrders = new SqlCommand(strInsertQuery, _cntDatabase);
                    cmdOrders.Parameters.AddWithValue("@PersonID", intPersonID);
                    cmdOrders.Parameters.AddWithValue("@OrderDate", strDate);
                    cmdOrders.Parameters.AddWithValue("@CC_Number", strCardNumber);
                    cmdOrders.Parameters.AddWithValue("@ExpDate", strExpiration);
                    cmdOrders.Parameters.AddWithValue("@CCV", strCCV);

                    //executes query and closes reader
                    SqlDataReader rdOrders = cmdOrders.ExecuteReader();
                    rdOrders.Close();

                }
                else
                {
                    //query to insert into orders table
                    string strInsertQuery = "INSERT INTO " + strSchema + ".Orders (DiscountID, PersonID, OrderDate, CC_Number, ExpDate, CCV)" +
                    "  VALUES (@DiscountID, @PersonID, @OrderDate, @CC_Number, @ExpDate," +
                    " @CCV)";

                    //sets up querys to insert user data
                    SqlCommand cmdOrders = new SqlCommand(strInsertQuery, _cntDatabase);
                    cmdOrders.Parameters.AddWithValue("@DiscountID", intDiscountID);
                    cmdOrders.Parameters.AddWithValue("@PersonID", intPersonID);
                    cmdOrders.Parameters.AddWithValue("@OrderDate", strDate);
                    cmdOrders.Parameters.AddWithValue("@CC_Number", strCardNumber);
                    cmdOrders.Parameters.AddWithValue("@ExpDate", strExpiration);
                    cmdOrders.Parameters.AddWithValue("@CCV", strCCV);

                    //executes query and closes reader
                    SqlDataReader rdOrders = cmdOrders.ExecuteReader();
                    rdOrders.Close();
                }

            } catch(Exception ex)
            {
                //close database and show error                
                CloseDatabase();
                InsertDataFail(ex);
            }
        }
        //method for updating Order Details Table
        internal static void WriteDetails(int intOrderID, int intInventoryID, int intDiscountID, int intQuantity)
        {
            try
            {
                if (intDiscountID == 0)
                {
                    //query to insert into order details table
                    string strInsertQuery = "INSERT INTO " + strSchema + ".OrderDetails (OrderID, InventoryID, Quantity)" +
                    "  VALUES (@OrderID, @InventoryID, @Quantity)";

                    //sets up querys to insert user data
                    SqlCommand cmdDetails = new SqlCommand(strInsertQuery, _cntDatabase);
                    cmdDetails.Parameters.AddWithValue("@OrderID", intOrderID);
                    cmdDetails.Parameters.AddWithValue("@InventoryID", intInventoryID);
                    cmdDetails.Parameters.AddWithValue("@Quantity", intQuantity);

                    //executes query and closes reader
                    SqlDataReader rdDetails = cmdDetails.ExecuteReader();
                    rdDetails.Close();
                }
                else
                {
                    //query to insert into order details table
                    string strInsertQuery = "INSERT INTO " + strSchema + ".OrderDetails (OrderID, InventoryID, DiscountID, Quantity)" +
                    "  VALUES (@OrderID, @InventoryID, @DiscountID, @Quantity)";

                    //sets up querys to insert user data
                    SqlCommand cmdDetails = new SqlCommand(strInsertQuery, _cntDatabase);
                    cmdDetails.Parameters.AddWithValue("@OrderID", intOrderID);
                    cmdDetails.Parameters.AddWithValue("@InventoryID", intInventoryID);
                    cmdDetails.Parameters.AddWithValue("@DiscountID", intDiscountID);
                    cmdDetails.Parameters.AddWithValue("@Quantity", intQuantity);

                    //executes query and closes reader
                    SqlDataReader rdDetails = cmdDetails.ExecuteReader();
                    rdDetails.Close();
                }

            }
            catch (Exception ex)
            {
                //close database and show error
                CloseDatabase();
                InsertDataFail(ex);
            }
        }
        //method for updating quantity in inventory
        internal static void UpdateQuantity(int intQuantity, int intInventoryID)
        {
            try
            {
                //string command to update password
                string strUpdateQuery = "UPDATE " + strSchema + ".Inventory SET Quantity = @Quantity" +
                " WHERE InventoryID = @InventoryID";

                //insert new password and return success
                //command query
                SqlCommand cmdUpdate = new SqlCommand(strUpdateQuery, _cntDatabase);
                cmdUpdate.Parameters.AddWithValue("@InventoryID", intInventoryID);
                cmdUpdate.Parameters.AddWithValue("@Quantity", intQuantity);
                SqlDataReader rdUpdate = cmdUpdate.ExecuteReader();

                rdUpdate.Close();
            }
            catch (Exception ex)
            {
                //close database and show error
                CloseDatabase();
                UpdateDataFail(ex);
            }
        }
        //method for checking out
        internal static void CheckOut(clsParameters.CheckoutParameters checkoutParameters)
        {            
            try
            {
                OpenDatabase();

                //check if cart is empty
                if (checkoutParameters.dgvCartP.Rows.Count > 0)
                {
                    //check card info
                    if (clsValidation.CardInfoValidation(checkoutParameters.tbxCardNumberP.Text, checkoutParameters.tbxExpiryP.Text, checkoutParameters.tbxCCVP.Text))
                    {
                        //get todays date
                        string strDate = DateTime.Now.ToString();

                        //setup ids
                        string strDiscountID, strPhone = "", strName = "";
                        int intOrderID = 0;
                        int intPersonID;
                        //check if discount is applied
                        if (checkoutParameters.tbxDiscountP.Text == "$0.00")
                        {
                            strDiscountID = "0";
                        }
                        else
                        {
                            strDiscountID = strDID;
                        }
                        if (int.TryParse(strDiscountID, out int intDiscountID))
                        {

                            //vars to hold text
                            string strSub, strItems, strDiscount, strTax, strTextboxTotal;
                            //clear lists
                            lstIntQuantity.Clear();
                            lstIntItemQuantity.Clear();
                            lstIntNewQuantity.Clear();
                            lstStrNames.Clear();
                            lstStrPrice.Clear();
                            lstStrTotal.Clear();
                            lstIntInventoryID.Clear();

                            //get person id
                            string strPersonID = strPID;
                            if (int.TryParse(strPersonID, out intPersonID))
                            {

                                //get cart values
                                for (int i = 0; i < checkoutParameters.dgvCartP.Rows.Count; i++)
                                {
                                    lstIntItemQuantity.Add((int)(checkoutParameters.dgvCartP.Rows[i].Cells[0].Value));
                                    lstStrNames.Add((checkoutParameters.dgvCartP.Rows[i].Cells[1].Value).ToString());
                                    lstStrPrice.Add((checkoutParameters.dgvCartP.Rows[i].Cells[3].Value).ToString());
                                    lstStrTotal.Add((checkoutParameters.dgvCartP.Rows[i].Cells[4].Value).ToString());
                                }

                                //get text box values
                                strSub = checkoutParameters.tbxSubP.Text;
                                strItems = checkoutParameters.tbxItemsP.Text;
                                strDiscount = checkoutParameters.tbxDiscountP.Text;
                                strTax = checkoutParameters.tbxTaxP.Text;
                                strTextboxTotal = checkoutParameters.tbxTotalP.Text;

                                //update tables
                                WriteOrders(intDiscountID, intPersonID, strDate, checkoutParameters.tbxCardNumberP.Text, checkoutParameters.tbxExpiryP.Text, checkoutParameters.tbxCCVP.Text);

                                //query for getting order id
                                string strSelectQuery = "SELECT max(OrderID), PersonID FROM " + strSchema + ".Orders where PersonID = @PersonID AND OrderDate = @OrderDate GROUP BY PersonID;";
                                //command query for order Id
                                SqlCommand cmdSelect = new SqlCommand(strSelectQuery, _cntDatabase);
                                cmdSelect.Parameters.AddWithValue("@PersonID", intPersonID);
                                cmdSelect.Parameters.AddWithValue("@OrderDate", strDate);
                                SqlDataReader rdSelect = cmdSelect.ExecuteReader();

                                //if statement to set order id
                                if (rdSelect.Read())
                                {
                                    //string for returned values                            
                                    string strOrderID = rdSelect.GetValue(0).ToString();
                                    //set string to int var
                                    if (int.TryParse(strOrderID, out intOrderID))
                                    {
                                        //close reader
                                        rdSelect.Close();
                                    }
                                }
                                else
                                {
                                    //error for not finding order id
                                    MessageBox.Show("Could not find OrderID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    rdSelect.Close();
                                    CloseDatabase();
                                }

                                for (int i = 0; i < lstStrNames.Count; i++)
                                {
                                    //query for getting quantity and id
                                    string strQuantityQuery = "SELECT Quantity, InventoryID FROM " + strSchema + ".Inventory where ItemName = @ItemName;";
                                    //command query for Quantity
                                    SqlCommand cmdQuantity = new SqlCommand(strQuantityQuery, _cntDatabase);
                                    cmdQuantity.Parameters.AddWithValue("@ItemName", lstStrNames[i]);
                                    SqlDataReader rdQuantity = cmdQuantity.ExecuteReader();

                                    //if statement to set Quantity
                                    if (rdQuantity.Read())
                                    {
                                        //string for returned values                            
                                        string strQuantity = rdQuantity.GetValue(0).ToString();
                                        string strInventoryId = rdQuantity.GetValue(1).ToString();
                                        //set string to int var
                                        if (int.TryParse(strQuantity, out int intItemQuantity) &&
                                        int.TryParse(strInventoryId, out int intID))
                                        {
                                            lstIntQuantity.Add(intItemQuantity);
                                            lstIntInventoryID.Add(intID);
                                            //close reader
                                            rdQuantity.Close();
                                        }
                                    }
                                    else
                                    {
                                        //error for not finding Quantity
                                        MessageBox.Show("Could not find Quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        rdQuantity.Close();
                                        CloseDatabase();
                                    }
                                }

                                for (int i = 0; i < lstIntInventoryID.Count; i++)
                                {
                                    lstIntNewQuantity.Add(lstIntQuantity[i] - lstIntItemQuantity[i]);
                                    //update details
                                    WriteDetails(intOrderID, lstIntInventoryID[i], intDiscountID, lstIntItemQuantity[i]);
                                    //update quantity
                                    UpdateQuantity(lstIntNewQuantity[i], lstIntInventoryID[i]);
                                }

                                //query for getting name and phone
                                string strSelectNameQuery = "SELECT PersonID, NameFirst, NameLast, PhonePrimary FROM " + strSchema + ".Person where PersonID = @PersonID;";
                                //command query for name and phone
                                SqlCommand cmdSelectName = new SqlCommand(strSelectNameQuery, _cntDatabase);
                                cmdSelectName.Parameters.AddWithValue("@PersonID", intPersonID);
                                SqlDataReader rdSelectName = cmdSelectName.ExecuteReader();

                                //if statement to set name and phone
                                if (rdSelectName.Read())
                                {
                                    //string for returned values                            
                                    string strFirst = rdSelectName.GetValue(1).ToString();
                                    string strLast = rdSelectName.GetValue(2).ToString();
                                    string strPhoneNumber = rdSelectName.GetValue(3).ToString();
                                    strName = strFirst + " " + strLast;
                                    strPhone = strPhoneNumber;
                                    //close reader
                                    rdSelectName.Close();
                                }
                                else
                                {
                                    //error for not finding order id
                                    MessageBox.Show("Could not find OrderID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    rdSelectName.Close();
                                    CloseDatabase();
                                }
                                //successful
                                MessageBox.Show("Purchase successful! Thank you for shopping with us! \nPlease shop with us again soon!", "AE Sporting Fits", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //show receipts
                                if (checkoutParameters.tbxDiscountP.Text == "$0.00")
                                {                                    
                                    clsHTML.PrintReceipt(clsHTML.GenerateReceipt(lstStrNames, lstIntItemQuantity, lstStrTotal, lstStrPrice, intOrderID.ToString(), strName, strPhone, strSub, strTax, strTextboxTotal), intOrderID.ToString());
                                }
                                else
                                {
                                    clsHTML.PrintReceipt(clsHTML.GenerateReceiptDiscount(lstStrNames, lstIntItemQuantity, lstStrTotal, lstStrPrice, intOrderID.ToString(), strName, strPhone, checkoutParameters.tbxGrossP.Text, strSub, strDiscount, strTax, strTextboxTotal, strDiscountType), intOrderID.ToString());
                                }

                                //reset lists
                                if (lstStrNames.Count > 0)
                                {
                                    lstIntQuantity.Clear();
                                    lstIntItemQuantity.Clear();
                                    lstIntNewQuantity.Clear();
                                    lstStrNames.Clear();
                                    lstStrPrice.Clear();
                                    lstStrTotal.Clear();
                                    lstIntInventoryID.Clear();
                                }

                                CloseDatabase();
                                //refresh inventory
                                checkoutParameters.dgvInventoryP.DataSource = null;
                                clsSQL.InitializeInventoryView(checkoutParameters.dgvInventoryP);

                                //clear cart
                                clsCart.ClearCart(checkoutParameters.dgvCartP);
                                //clear text boxes
                                checkoutParameters.tbxItemsP.Clear();
                                checkoutParameters.tbxDiscountP.Text = "$0.00";
                                checkoutParameters.tbxGrossP.Clear();
                                checkoutParameters.tbxCodeP.Clear();
                                checkoutParameters.tbxSubP.Clear();
                                checkoutParameters.tbxTaxP.Clear();
                                checkoutParameters.tbxTotalP.Clear();
                                checkoutParameters.dgvInventoryP.Refresh();
                            }
                        }
                    }                    
                }
                else
                {
                    CloseDatabase();
                    //empty cart message
                    MessageBox.Show("Cart is empty. Add an item to your cart to checkout!", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CloseDatabase();
            }
            catch (Exception ex)
            {
                CloseDatabase();
                //error message
                MessageBox.Show("Could not checkout. Please Try Again." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //method to fill category combos
        internal static void FillCategoryCombo(ComboBox cbxCategory)
        {
            try
            {
                //close previous connections and open new one
                CloseDatabase();
                OpenDatabase();                

                //commands for data
                SqlCommand cmdCategory = new SqlCommand("SELECT distinct T.TeamSport FROM " + strSchema +
                    ".Inventory I INNER JOIN " + strSchema + ".Teams T ON I.TeamID = T.TeamID ", _cntDatabase);

                  //data adapters
                SqlDataAdapter daCategory = new SqlDataAdapter(cmdCategory);

                 //data table
                 DataTable dtCategory = new DataTable();

                 //fill data set
                 daCategory.Fill(dtCategory);

                 //insert to data table
                 DataRow drCategory = dtCategory.NewRow();                       
                 dtCategory.Rows.InsertAt(drCategory, 0);

                 //setup combo boxes
                 cbxCategory.DataSource = dtCategory;
                 cbxCategory.DisplayMember = "TeamSport";
                 cbxCategory.ValueMember = "TeamSport";
                   
                //close connection
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Fill Category Combo Boxes. " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDatabase();                
            }
            //close connection
            CloseDatabase();
        }
        internal static void FillSizeCombo(ComboBox cbxSize)
        {
            try
            {
                //close previous connections and open new one
                CloseDatabase();
                OpenDatabase();

                //commands for data
                SqlCommand cmdSize = new SqlCommand("SELECT distinct I.Size FROM " + strSchema +
                    ".Inventory I INNER JOIN " + strSchema + ".Teams T ON I.TeamID = T.TeamID ", _cntDatabase);

                //data adapters
                SqlDataAdapter daSize = new SqlDataAdapter(cmdSize);

                //data table
                DataTable dtSize = new DataTable();

                //fill data set
                daSize.Fill(dtSize);

                //insert to data table
                DataRow drSize = dtSize.NewRow();
                dtSize.Rows.InsertAt(drSize, 0);

                //setup combo boxes
                cbxSize.DataSource = dtSize;
                cbxSize.DisplayMember = "Size";
                cbxSize.ValueMember = "Size";

                //close connection
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Fill Size Combo Boxes. " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDatabase();
            }
            //close connection
            CloseDatabase();
        }
        //method to fill quantity combos
        internal static void FillQuantityCombo(DataGridView dgvInventory, ComboBox cbxQuantity)
        {
            //var for inventory id, item name, and size
            string strInventoryID = "";
            string strItem = "";
            string strSize = "";
            string strQuantity = "";

            try
            {
                //close previous connections and open new one
                CloseDatabase();
                OpenDatabase();

                //if statement for setting item name and size
                if (dgvInventory.SelectedCells.Count > 0)
                {
                    int intSelectedRowIndex = dgvInventory.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvInventory.Rows[intSelectedRowIndex];
                    strItem = Convert.ToString(selectedRow.Cells["Name"].Value);
                    strSize = Convert.ToString(selectedRow.Cells["Size"].Value);
                    strQuantity = Convert.ToString(selectedRow.Cells["Quantity"].Value);
                    //set quantity to int
                    if (int.TryParse(strQuantity, out int intQuantity))
                    {

                        //query for getting inventory id
                        string strSelectID = "SELECT InventoryID, Quantity from " + strSchema + ".Inventory WHERE ItemName = '" + strItem + "' AND Size = '" + strSize + "'";
                        //command query for inventory id
                        SqlCommand cmdInventoryID = new SqlCommand(strSelectID, _cntDatabase);
                        SqlDataReader rdInventoryID = cmdInventoryID.ExecuteReader();

                        //if statement to set inventory id
                        if (rdInventoryID.Read())
                        {
                            //string for returned values
                            strInventoryID = rdInventoryID.GetValue(0).ToString();
                            string strDataQuantity = rdInventoryID.GetValue(1).ToString();
                            //close reader
                            rdInventoryID.Close();

                            //commands for data
                            SqlCommand cmdQuantity = new SqlCommand("SELECT Quantity from " + strSchema + ".Inventory WHERE InventoryID = " + strInventoryID, _cntDatabase);

                            //data adapters
                            SqlDataAdapter daQuantity = new SqlDataAdapter(cmdQuantity);

                            //data table
                            DataTable dtQuantity = new DataTable();

                            //fill data set
                            daQuantity.Fill(dtQuantity);

                            //insert to data table
                            DataRow drQuantity = dtQuantity.NewRow();

                            for (int i = 0; i < intQuantity + 1; i++)
                            {
                                dtQuantity.Rows.Add(i);
                            }

                            dtQuantity.Rows.InsertAt(drQuantity, 0);

                            if(int.TryParse(strDataQuantity, out int intDataQuantity))
                            {
                                intItemDataQuantity = intDataQuantity;
                                if(intDataQuantity > intQuantity)
                                {
                                    dtQuantity.Rows.RemoveAt(1);
                                }
                            }

                            //setup comboboxes
                            cbxQuantity.DataSource = dtQuantity;
                            cbxQuantity.DisplayMember = "Quantity";
                            cbxQuantity.ValueMember = "Quantity";

                        }
                        else
                        {
                            //error for not finding id
                            MessageBox.Show("Could not find Inventory ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            rdInventoryID.Close();
                            CloseDatabase();
                        }
                    }
                }
                //close connection
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Fill Quantity Combo Boxes. " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDatabase();
            }
            //close connection
            CloseDatabase();
        }

        //Manager Form Information
        //restock
        //data command
        public static SqlCommand _sqlRestockCommand;
        //data adapter
        public static SqlDataAdapter _daRestock = new SqlDataAdapter();
        //data tables
        public static DataTable _dtRestockTable = new DataTable();
        //method to show restock needed
        internal static void InitializeRestockView(DataGridView dgvRestock, Label lblRestock)
        {
            //open database
            OpenDatabase();

            //fill tables and objects
            try
            {
                //setup data
                //set command object to null
                _sqlRestockCommand = null;

                //reset data adapter and data table to new
                _daRestock = new SqlDataAdapter();
                _dtRestockTable = new DataTable();

                //string query
                string strDGVQuery = "Select InventoryID as 'Inventory ID', ItemName as 'Name', Quantity from " + strSchema + ".Inventory" +
                    " WHERE Quantity <= RestockThreshold AND Discontinued != 1 Order by Quantity ASC";

                //set command object to null
                _sqlRestockCommand = null;

                //est command obj
                _sqlRestockCommand = new SqlCommand(strDGVQuery, _cntDatabase);
                //establish data adapter
                _daRestock.SelectCommand = _sqlRestockCommand;
                //fill data table
                _daRestock.Fill(_dtRestockTable);
                //bind grid view to data table
                dgvRestock.DataSource = _dtRestockTable;

                //format data grid view

                for (int i = 0; i < dgvRestock.ColumnCount; i++)
                {
                    dgvRestock.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvRestock.AutoResizeColumns();
                    dgvRestock.AllowUserToAddRows = false;
                    dgvRestock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvRestock.Columns[i].DefaultCellStyle.Font = new Font("Rockwell", 9F, FontStyle.Bold);
                }

                if (dgvRestock.Rows.Count > 0)
                {
                    lblRestock.Visible = true;
                }
                else
                {
                    lblRestock.Visible = false;
                }

                //close database
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDatabase();
            }

            //dispose of command, adapter, and table 
            _sqlRestockCommand.Dispose();
            _daRestock.Dispose();
            _dtRestockTable.Dispose();
            //close database
            CloseDatabase();
        }
        
        //inventory
        //data command
        public static SqlCommand _sqlManagerICommand;
        //data adapter
        public static SqlDataAdapter _daManagerI = new SqlDataAdapter();
        //data tables
        public static DataTable _dtManagerITable = new DataTable();
        //method to set images from database
        internal static void ImageInventoryManager(DataGridView dgvInventory)
        {
            //make byte var
            byte[] imageData = null;
            Int32 intWidth = 140;

            try
            {

                for (int i = 0; i < dgvInventory.Rows.Count; i++)
                {
                    if (!String.IsNullOrEmpty(_dtManagerITable.Rows[i]["Image"].ToString()))
                    {
                        //set image to byte and use temporary image
                        imageData = (byte[])_dtManagerITable.Rows[i]["Image"];
                        Image tmpImage = Image.FromStream(new MemoryStream(imageData));
                        //scale image and set resized image
                        double dblScaleImg = (double)intWidth / (double)tmpImage.Width;
                        Graphics tmpGraphics = default(Graphics);
                        Bitmap tmpResizedImage = new Bitmap(Convert.ToInt32(dblScaleImg * tmpImage.Width), Convert.ToInt32(dblScaleImg * tmpImage.Height));
                        tmpGraphics = Graphics.FromImage(tmpResizedImage);
                        tmpGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                        tmpGraphics.DrawImage(tmpImage, 0, 0, tmpResizedImage.Width + 1, tmpResizedImage.Height + 1);
                        Image imgOut = tmpResizedImage;
                        //add image to data grid view
                        dgvInventory.Rows[i].Cells[0].Value = imgOut;
                    }
                }
                CloseDatabase();
            }
            catch (Exception ex)
            {
                //error message
                MessageBox.Show(ex.Message, "Error setting up images.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //method to show inventory
        internal static void InitializeManagerInventoryView(DataGridView dgvInventory)
        {
            //open database
            OpenDatabase();

            //fill tables and objects
            try
            {
                //setup data
                //set command object to null
                _sqlManagerICommand = null;

                //reset data adapter and data table to new
                _daManagerI = new SqlDataAdapter();
                _dtManagerITable = new DataTable();

                //string query
                string strDGVQuery = "Select ItemImage as 'Image', InventoryID as 'Inventory ID', ItemName as 'Name', ItemDescription as 'Description', format(RetailPrice, 'C') as 'Retail Price', format(Cost, 'C') as 'Cost', Quantity, " +
                    "Discontinued, Size, Color, TeamID as 'Team ID', RestockThreshold as 'Restock Threshold' from " + strSchema + ".Inventory Order by ItemName ASC";

                //set command object to null
                _sqlManagerICommand = null;

                //est command obj
                _sqlManagerICommand = new SqlCommand(strDGVQuery, _cntDatabase);
                //establish data adapter
                _daManagerI.SelectCommand = _sqlManagerICommand;
                //fill data table
                _daManagerI.Fill(_dtManagerITable);
                //bind grid view to data table
                dgvInventory.DataSource = _dtManagerITable;

                if (dgvInventory.Columns.Count <= 12 && !dgvInventory.Columns.Contains("Item Image"))
                {
                    //setup image column
                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                    imageColumn.Name = "Item Image";
                    imageColumn.HeaderText = "Item Image";
                    dgvInventory.Columns.Insert(0, imageColumn);
                }

                //setup image
                ImageInventoryManager(dgvInventory);
                dgvInventory.Columns.Remove("Image");

                //format data grid view
                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                    row.Height = 140;
                }

                for (int i = 0; i < dgvInventory.ColumnCount; i++)
                {
                    dgvInventory.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvInventory.AutoResizeColumns();
                    dgvInventory.AllowUserToAddRows = false;
                    dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvInventory.Columns[i].DefaultCellStyle.Font = new Font("Rockwell", 9F, FontStyle.Bold);
                    dgvInventory.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                //close database
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDatabase();
            }

            //dispose of command, adapter, and table 
            _sqlManagerICommand.Dispose();
            _daManagerI.Dispose();
            _dtManagerITable.Dispose();
            //close database
            CloseDatabase();
        }
        
        //customers
        //data command
        public static SqlCommand _sqlCustomersCommand;
        //data adapter
        public static SqlDataAdapter _daCustomers = new SqlDataAdapter();
        //data tables
        public static DataTable _dtCustomersTable = new DataTable();
        //method to show customers
        internal static void InitializeCustomerView(DataGridView dgvCustomers)
        {
            //open database
            OpenDatabase();

            //fill tables and objects
            try
            {
                //setup data
                //set command object to null
                _sqlCustomersCommand = null;

                //reset data adapter and data table to new
                _daCustomers = new SqlDataAdapter();
                _dtCustomersTable = new DataTable();

                //string query
                string strDGVQuery = "Select P.PersonID as 'Person ID', Title, NameFirst as 'First Name', NameMiddle as 'Middle Name', NameLast as 'Last Name', Suffix, Address1, Address2, Address3, " +
                    "City, Zipcode, State, Email, PhonePrimary as 'Primary Phone', PhoneSecondary as 'Secondary Phone', PersonDeleted as 'Deleted', L.PositionTitle as 'Position Title' from " + strSchema + ".Person P "+
                    "FULL JOIN " + strSchema + ".Logon L ON P.PersonID = L.PersonID";

                //set command object to null
                _sqlCustomersCommand = null;

                //est command obj
                _sqlCustomersCommand = new SqlCommand(strDGVQuery, _cntDatabase);
                //establish data adapter
                _daCustomers.SelectCommand = _sqlCustomersCommand;
                //fill data table
                _daCustomers.Fill(_dtCustomersTable);
                //bind grid view to data table
                dgvCustomers.DataSource = _dtCustomersTable;

                //format data grid view
                for (int i = 0; i < dgvCustomers.ColumnCount; i++)
                {
                    dgvCustomers.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvCustomers.AutoResizeColumns();
                    dgvCustomers.AllowUserToAddRows = false;
                    dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvCustomers.Columns[i].DefaultCellStyle.Font = new Font("Rockwell", 9F, FontStyle.Bold);
                }

                //close database
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDatabase();
            }

            //dispose of command, adapter, and table 
            _sqlCustomersCommand.Dispose();
            _daCustomers.Dispose();
            _dtCustomersTable.Dispose();
            //close database
            CloseDatabase();
        }
        
        //orders
        //data command
        public static SqlCommand _sqlOrdersCommand;
        //data adapter
        public static SqlDataAdapter _daOrders = new SqlDataAdapter();
        //data tables
        public static DataTable _dtOrdersTable = new DataTable();
        //method to show orders
        internal static void InitializeOrderView(DataGridView dgvOrders)
        {
            //open database
            OpenDatabase();

            //fill tables and objects
            try
            {
                //setup data
                //set command object to null
                _sqlOrdersCommand = null;

                //reset data adapter and data table to new
                _daOrders = new SqlDataAdapter();
                _dtOrdersTable = new DataTable();

                //string query
                string strDGVQuery = "Select O.PersonID as 'Person ID', P.NameFirst + ' ' + P.NameLast as 'Name', OrderID as 'Order ID', OrderDate " +
                    "from " + strSchema + ".Orders O FULL JOIN " + strSchema + ".Person P on O.PersonID = P.PersonID " +
                    "WHERE O.PersonID = " + clsSQL.strPID + " Order by OrderID DESC";

                //set command object to null
                _sqlOrdersCommand = null;
                //est command obj
                _sqlOrdersCommand = new SqlCommand(strDGVQuery, _cntDatabase);
                //establish data adapter
                _daOrders.SelectCommand = _sqlOrdersCommand;
                //fill data table
                _daOrders.Fill(_dtOrdersTable);
                //bind grid view to data table
                dgvOrders.DataSource = _dtOrdersTable;

                //format data grid view
                for (int i = 0; i < dgvOrders.ColumnCount; i++)
                {
                    dgvOrders.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvOrders.AutoResizeColumns();
                    dgvOrders.AllowUserToAddRows = false;
                    dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvOrders.Columns[i].DefaultCellStyle.Font = new Font("Rockwell", 9F, FontStyle.Bold);
                    dgvOrders.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                //close database
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDatabase();
            }

            //dispose of command, adapter, and table 
            _sqlOrdersCommand.Dispose();
            _daOrders.Dispose();
            _dtOrdersTable.Dispose();
            //close database
            CloseDatabase();
        }
        
        //order details
        //data command
        public static SqlCommand _sqlOrderDetailsCommand;
        //data adapter
        public static SqlDataAdapter _daOrderDetails = new SqlDataAdapter();
        //data tables
        public static DataTable _dtOrderDetailsTable = new DataTable();
        //method to show orders
        internal static void InitializeOrderDetailsView(DataGridView dgvOrderDetails, DataGridView dgvOrders)
        {
            //fill tables and objects
            try
            {
                //setup data
                //set command object to null
                _sqlOrderDetailsCommand = null;

                //reset data adapter and data table to new
                _daOrderDetails = new SqlDataAdapter();
                _dtOrderDetailsTable = new DataTable();

                //string query
                string strDGVQuery = "Select OrderDetailsID as 'Details ID', OrderID as 'Order ID', O.InventoryID as 'Inventory ID', I.ItemName as 'Item Name', " +
                    "O.Quantity as 'Quantity Sold', format(I.RetailPrice, 'C') as 'Retail Price', format(SUM(I.RetailPrice * O.Quantity), 'C') as 'Line Item Total', DiscountID as 'Discount ID' " +
                    "from " + strSchema + ".OrderDetails O FULL JOIN " + strSchema + ".Inventory I ON O.InventoryID = I.InventoryID " +
                    "WHERE O.OrderID = " + clsManager.GetOrderID(dgvOrders) + " group by OrderDetailsID, OrderID, O.InventoryID, I.ItemName, O.Quantity, DiscountID, RetailPrice";

                //set command object to null
                _sqlOrderDetailsCommand = null;
                //est command obj
                _sqlOrderDetailsCommand = new SqlCommand(strDGVQuery, _cntDatabase);
                //establish data adapter
                _daOrderDetails.SelectCommand = _sqlOrderDetailsCommand;
                //fill data table
                _daOrderDetails.Fill(_dtOrderDetailsTable);
                //bind grid view to data table
                dgvOrderDetails.DataSource = _dtOrderDetailsTable;

                //format data grid view
                for (int i = 0; i < dgvOrderDetails.ColumnCount; i++)
                {
                    dgvOrderDetails.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvOrderDetails.AutoResizeColumns();
                    dgvOrderDetails.AllowUserToAddRows = false;
                    dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvOrderDetails.Columns[i].DefaultCellStyle.Font = new Font("Rockwell", 9F, FontStyle.Bold);
                    dgvOrderDetails.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                //close database
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "Error in SQL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDatabase();
            }

            //dispose of command, adapter, and table 
            _sqlOrderDetailsCommand.Dispose();
            _daOrderDetails.Dispose();
            _dtOrderDetailsTable.Dispose();
            //close database
            CloseDatabase();
        }

        //discounts
        //data command
        public static SqlCommand _sqlDiscountsCommand;
        //data adapter
        public static SqlDataAdapter _daDiscounts = new SqlDataAdapter();
        //data tables
        public static DataTable _dtDiscountsTable = new DataTable();
        //method to show orders
        internal static void InitializeDiscountsView(DataGridView dgvDiscounts)
        {
            //open database
            OpenDatabase();

            //fill tables and objects
            try
            {
                //setup data
                //set command object to null
                _sqlDiscountsCommand = null;

                //reset data adapter and data table to new
                _daDiscounts = new SqlDataAdapter();
                _dtDiscountsTable = new DataTable();

                //string query
                string strDGVQuery = "Select DiscountID as 'Discount ID', DiscountCode as 'Discount Code', Description, DiscountLevel as 'Discount Level', " +
                    "InventoryID as 'Inventory ID', DiscountType as 'Discount Type', format(DiscountPercentage, 'P') as 'Discount Percentage', format(DiscountDollarAmount, 'C') as 'Discount Dollar Amount', " +
                    "StartDate as 'Start Date', ExpirationDate as 'Expiration Date' from " + strSchema + ".Discounts";

                //set command object to null
                _sqlDiscountsCommand = null;
                //est command obj
                _sqlDiscountsCommand = new SqlCommand(strDGVQuery, _cntDatabase);
                //establish data adapter
                _daDiscounts.SelectCommand = _sqlDiscountsCommand;
                //fill data table
                _daDiscounts.Fill(_dtDiscountsTable);
                //bind grid view to data table
                dgvDiscounts.DataSource = _dtDiscountsTable;

                //format data grid view
                for (int i = 0; i < dgvDiscounts.ColumnCount; i++)
                {
                    dgvDiscounts.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvDiscounts.AutoResizeColumns();
                    dgvDiscounts.AllowUserToAddRows = false;
                    dgvDiscounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvDiscounts.Columns[i].DefaultCellStyle.Font = new Font("Rockwell", 9F, FontStyle.Bold);
                }

                //close database
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "Error in SQL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDatabase();
            }

            //dispose of command, adapter, and table 
            _sqlDiscountsCommand.Dispose();
            _daDiscounts.Dispose();
            _dtDiscountsTable.Dispose();
            //close database
            CloseDatabase();
        }
        //method to fill combo for teamID
        internal static void FillTeamIDCombo(ComboBox cbxTeamID)
        {
            try
            {
                //close previous connections and open new one
                CloseDatabase();
                OpenDatabase();

                //commands for data
                SqlCommand cmdTeamID = new SqlCommand("SELECT distinct T.TeamName, T.TeamID FROM " + strSchema +
                    ".Inventory I INNER JOIN " + strSchema + ".Teams T ON I.TeamID = T.TeamID ", _cntDatabase);

                //data adapters
                SqlDataAdapter daTeamID = new SqlDataAdapter(cmdTeamID);

                //data table
                DataTable dtTeamID = new DataTable();

                //fill data set
                daTeamID.Fill(dtTeamID);

                //insert to data table
                DataRow drTeamID = dtTeamID.NewRow();
                dtTeamID.Rows.InsertAt(drTeamID, 0);

                //setup combo boxes
                cbxTeamID.DataSource = dtTeamID;
                cbxTeamID.DisplayMember = "TeamName";
                cbxTeamID.ValueMember = "TeamID";

                //close connection
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Fill TeamID Combo Box. " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDatabase();
            }
            //close connection
            CloseDatabase();
        }
        //method to fill combo for items
        internal static void FillItemsCombo(ComboBox cbxItemID)
        {
            try
            {
                //close previous connections and open new one
                CloseDatabase();
                OpenDatabase();

                //commands for data
                SqlCommand cmdInventoryID = new SqlCommand("SELECT distinct I.ItemName, I.InventoryID FROM " + strSchema +
                    ".Inventory I ", _cntDatabase);

                //data adapters
                SqlDataAdapter daInventoryID = new SqlDataAdapter(cmdInventoryID);

                //data table
                DataTable dtInventoryID = new DataTable();

                //fill data set
                daInventoryID.Fill(dtInventoryID);

                //insert to data table
                DataRow drInventoryID = dtInventoryID.NewRow();
                dtInventoryID.Rows.InsertAt(drInventoryID, 0);

                //setup combo boxes
                cbxItemID.DataSource = dtInventoryID;
                cbxItemID.DisplayMember = "ItemName";
                cbxItemID.ValueMember = "InventoryID";

                //close connection
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Fill Item name Combo Box. " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDatabase();
            }
            //close connection
            CloseDatabase();
        }
        //method to fill combo for title
        internal static void FillPositionTitleCombo(ComboBox cbxFilterTitle)
        {
            try
            {
                //close previous connections and open new one
                CloseDatabase();
                OpenDatabase();

                //commands for data
                SqlCommand cmdTitle = new SqlCommand("SELECT distinct PositionTitle FROM " + strSchema +
                    ".Logon", _cntDatabase);

                //data adapters
                SqlDataAdapter daTitle = new SqlDataAdapter(cmdTitle);

                //data table
                DataTable dtTitle = new DataTable();
                //fill data set
                daTitle.Fill(dtTitle);
                //insert to data table
                DataRow drTitle = dtTitle.NewRow();
                dtTitle.Rows.InsertAt(drTitle, 0);

                //setup combo boxes
                cbxFilterTitle.DataSource = dtTitle;
                cbxFilterTitle.DisplayMember = "PositionTitle";
                cbxFilterTitle.ValueMember = "PositionTitle";

                //close connection
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Fill Filter Title Combo Box. " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDatabase();
            }
            //close connection
            CloseDatabase();
        }
        //method for updating inventory
        internal static void UpdateInventory(clsParameters.InventoryParameters inventoryParameters, DataGridView dgvInventory)
        {
            try
            {
                OpenDatabase();
                //set up discontinued
                string strDiscontinued;
                if (inventoryParameters.cbxDiscontinuedP.SelectedIndex == 0)
                {
                    strDiscontinued = "0";
                }
                else if (inventoryParameters.cbxDiscontinuedP.SelectedIndex == 1)
                {
                    strDiscontinued = "1";
                }
                else
                {
                    strDiscontinued = "";
                }

                //change picture to byte
                Image imgItem = inventoryParameters.pbxItemImageP.Image;

                //string command to update inventory
                string strUpdateQuery = "UPDATE " + strSchema + ".Inventory SET ItemName = @ItemName, ItemDescription = @ItemDescription, RetailPrice = @RetailPrice, Cost = @Cost, Quantity = @Quantity," +
                " ItemImage = @ItemImage, Discontinued = @Discontinued, Size = @Size, Color = @Color, TeamID = @TeamID, RestockThreshold = @RestockThreshold WHERE InventoryID = @InventoryID";

                if (int.TryParse(inventoryParameters.tbxInventoryIDP.Text, out int intInventoryID) &&
                    int.TryParse(inventoryParameters.tbxQuantityP.Text.Trim(), out int intQuantity) &&
                    double.TryParse(inventoryParameters.tbxCostP.Text.Trim(), out double dblCost) &&
                    double.TryParse(inventoryParameters.tbxRetailPriceP.Text.Trim(), out double dblRetail) &&
                    int.TryParse(inventoryParameters.cbxTeamIDP.SelectedValue.ToString(), out int intTeamID) &&
                    int.TryParse(inventoryParameters.tbxRestockP.Text.Trim(), out int intRestock))
                {
                    //command query
                    SqlCommand cmdUpdate = new SqlCommand(strUpdateQuery, _cntDatabase);
                    cmdUpdate.Parameters.AddWithValue("@InventoryID", intInventoryID);
                    if(string.IsNullOrEmpty(inventoryParameters.tbxItemNameP.Text))
                    {
                        MessageBox.Show("The item name can not be blank. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return;
                    }
                    if (string.IsNullOrEmpty(inventoryParameters.tbxItemDescriptionP.Text))
                    {
                        MessageBox.Show("The item description can not be blank. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return;
                    }
                    cmdUpdate.Parameters.AddWithValue("@ItemName", inventoryParameters.tbxItemNameP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@ItemDescription", inventoryParameters.tbxItemDescriptionP.Text.Trim());
                    if (dblRetail > 0)
                    {
                        cmdUpdate.Parameters.AddWithValue("@RetailPrice", dblRetail);
                    }
                    else
                    {
                        MessageBox.Show("The retail price must be greater than 0. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return;
                    }
                    if (dblCost >= 0)
                    {
                        cmdUpdate.Parameters.AddWithValue("@Cost", dblCost);
                    }
                    else
                    {
                        MessageBox.Show("The cost must be greater than 0. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return;
                    }
                    cmdUpdate.Parameters.AddWithValue("@Quantity", intQuantity);
                    cmdUpdate.Parameters.AddWithValue("@ItemImage", clsManager.ImagetoByteArray(imgItem));
                    cmdUpdate.Parameters.AddWithValue("@Discontinued", strDiscontinued);
                    cmdUpdate.Parameters.AddWithValue("@Size", inventoryParameters.tbxSizeP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Color", inventoryParameters.tbxColorP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@TeamID", intTeamID);
                    cmdUpdate.Parameters.AddWithValue("@RestockThreshold", intRestock);
                    SqlDataReader rdUpdate = cmdUpdate.ExecuteReader();

                    rdUpdate.Close();
                }
                else
                {
                    MessageBox.Show("Unable to update item. Please ensure all fields are entered correctly. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseDatabase();
                    return;
                }
                CloseDatabase();
                dgvInventory.DataSource = null;
                InitializeManagerInventoryView(dgvInventory);
            }
            catch (Exception ex)
            {
                //close database and show error
                CloseDatabase();
                UpdateDataFail(ex);
            }
        }
        //method for updating customers
        internal static void UpdateCustomers(clsParameters.SignupParameters customerParameters)
        {
            try
            {
                OpenDatabase();

                //set up discontinued
                string strDeleted;
                if (customerParameters.cbxDeletedP.SelectedIndex == 0)
                {
                    strDeleted = "0";
                }
                else if (customerParameters.cbxDeletedP.SelectedIndex == 1)
                {
                    strDeleted = "1";
                }
                else
                {
                    strDeleted = "";
                }

                //string command to update inventory
                string strUpdateQuery = "UPDATE " + strSchema + ".Person SET Title = @Title, NameFirst = @NameFirst, NameMiddle = @NameMiddle, NameLast = @NameLast, Suffix = @Suffix," +
                " Address1 = @Address1, Address2 = @Address2, Address3 = @Address3, City = @city, Zipcode = @Zipcode, State = @State, Email = @Email," +
                " PhonePrimary = @PhonePrimary, PhoneSecondary = @PhoneSecondary, PersonDeleted = @PersonDeleted WHERE PersonID = @PersonID";

                if (int.TryParse(customerParameters.tbxPersonIDP.Text, out int intPersonID))
                {
                    //command query
                    SqlCommand cmdUpdate = new SqlCommand(strUpdateQuery, _cntDatabase);
                    cmdUpdate.Parameters.AddWithValue("@PersonID", intPersonID);
                    cmdUpdate.Parameters.AddWithValue("@Title", customerParameters.cbxTitleP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@NameFirst", customerParameters.tbxFirstNameP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@NameMiddle", customerParameters.tbxMiddleNameP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@NameLast", customerParameters.tbxLastNameP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Suffix", customerParameters.tbxSuffixP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Address1", customerParameters.tbxAddress1P.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Address2", customerParameters.tbxAddress2P.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Address3", customerParameters.tbxAddress3P.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@City", customerParameters.tbxCityP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Zipcode", customerParameters.tbxZipcodeP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@State", customerParameters.cbxStateP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Email", customerParameters.tbxEmailP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@PhonePrimary", customerParameters.tbxPhone1P.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@PhoneSecondary", customerParameters.tbxPhone2P.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@PersonDeleted", strDeleted);
                    SqlDataReader rdUpdate = cmdUpdate.ExecuteReader();

                    rdUpdate.Close();
                }
                CloseDatabase();
            }
            catch (Exception ex)
            {
                //close database and show error
                CloseDatabase();
                UpdateDataFail(ex);
            }
        }        
        //method for updating discounts
        internal static bool UpdateDiscounts(clsParameters.DiscountParameters discountParameters)
        {
            try
            {
                OpenDatabase();

                //set up type and level
                string strLevel, strType;
                if (discountParameters.cbxLevelP.SelectedIndex == 0)
                {
                    //item level
                    strLevel = "1";
                }
                else if (discountParameters.cbxLevelP.SelectedIndex == 1)
                {
                    strLevel = "0";
                }
                else
                {
                    strLevel = "";
                }

                if (discountParameters.cbxTypeP.SelectedIndex == 0)
                {
                    //percentage
                    strType = "0";
                }
                else if (discountParameters.cbxTypeP.SelectedIndex == 1)
                {
                    strType = "1";
                }
                else
                {
                    strType = "";
                }

                string strUpdateQuery;
                if (discountParameters.cbxLevelP.SelectedIndex == 0 && discountParameters.cbxTypeP.SelectedIndex == 0)
                {
                    //item level and percentage
                    strUpdateQuery = "UPDATE " + strSchema + ".Discounts SET DiscountCode = @DiscountCode, Description = @Description, DiscountLevel = @DiscountLevel, InventoryID = @InventoryID, DiscountType = @DiscountType," +
                    " DiscountPercentage = @DiscountPercentage, StartDate = @StartDate, ExpirationDate = @ExpirationDate" +
                    " WHERE DiscountID = @DiscountID";
                }
                else if(discountParameters.cbxLevelP.SelectedIndex == 0 && discountParameters.cbxTypeP.SelectedIndex == 1)
                {
                    //item level and dollar
                    strUpdateQuery = "UPDATE " + strSchema + ".Discounts SET DiscountCode = @DiscountCode, Description = @Description, DiscountLevel = @DiscountLevel, InventoryID = @InventoryID, DiscountType = @DiscountType," +
                    "  DiscountDollarAmount = @DiscountDollarAmount, StartDate = @StartDate, ExpirationDate = @ExpirationDate" +
                    " WHERE DiscountID = @DiscountID";
                }
                else if (discountParameters.cbxLevelP.SelectedIndex == 1 && discountParameters.cbxTypeP.SelectedIndex == 0)
                {
                    //cart and percentage
                    strUpdateQuery = "UPDATE " + strSchema + ".Discounts SET DiscountCode = @DiscountCode, Description = @Description, DiscountLevel = @DiscountLevel, DiscountType = @DiscountType," +
                    " DiscountPercentage = @DiscountPercentage, StartDate = @StartDate, ExpirationDate = @ExpirationDate" +
                    " WHERE DiscountID = @DiscountID";
                }
                else
                {
                    //cart and dollar
                    strUpdateQuery = "UPDATE " + strSchema + ".Discounts SET DiscountCode = @DiscountCode, Description = @Description, DiscountLevel = @DiscountLevel, DiscountType = @DiscountType," +
                    "  DiscountDollarAmount = @DiscountDollarAmount, StartDate = @StartDate, ExpirationDate = @ExpirationDate" +
                    " WHERE DiscountID = @DiscountID";
                }

                if (int.TryParse(discountParameters.tbxDiscountIDP.Text, out int intDiscountID))
                {
                    //command query
                    SqlCommand cmdUpdate = new SqlCommand(strUpdateQuery, _cntDatabase);
                    cmdUpdate.Parameters.AddWithValue("@DiscountID", intDiscountID);
                    if (string.IsNullOrEmpty(discountParameters.tbxDiscountCodeP.Text))
                    {
                        MessageBox.Show("The discount code can not be blank for the discount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                    if (string.IsNullOrEmpty(discountParameters.tbxDescriptionP.Text))
                    {
                        MessageBox.Show("The description can not be blank for the discount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                    cmdUpdate.Parameters.AddWithValue("@DiscountCode", discountParameters.tbxDiscountCodeP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Description", discountParameters.tbxDescriptionP.Text.Trim());
                    if (int.TryParse(discountParameters.tbxInventoryIDP.Text, out int intID))
                    {
                        cmdUpdate.Parameters.AddWithValue("@InventoryID", intID);
                    }
                    else if (!string.IsNullOrEmpty(discountParameters.tbxInventoryIDP.Text))
                    {
                        MessageBox.Show("Please enter a numeric value for inventory id. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(discountParameters.tbxInventoryIDP.Text) && discountParameters.cbxLevelP.SelectedIndex == 0)
                    {
                        MessageBox.Show("The inventory ID can not be blank if the level is set to item level. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                    string strDiscount;
                    if(!string.IsNullOrEmpty(discountParameters.tbxDollarP.Text))
                    {
                        if (discountParameters.tbxDollarP.Text.Contains("$"))
                        {
                            strDiscount = discountParameters.tbxDollarP.Text.Substring(1);
                        }
                        else
                        {
                            strDiscount = discountParameters.tbxDollarP.Text;
                        }
                    }
                    else
                    {
                        strDiscount = discountParameters.tbxDollarP.Text;
                    }

                    if (double.TryParse(strDiscount, out double dblDollar))
                    {
                        if (dblDollar > 0)
                        {
                            cmdUpdate.Parameters.AddWithValue("@DiscountDollarAmount", dblDollar);
                        }
                        else
                        {
                            MessageBox.Show("Please enter a numeric value that is not negative for dollar amount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            CloseDatabase();
                            return false;
                        }
                    }
                    else if(!string.IsNullOrEmpty(discountParameters.tbxDollarP.Text))
                    {
                        MessageBox.Show("Please enter a numeric value for dollar amount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                    else if(string.IsNullOrEmpty(discountParameters.tbxDollarP.Text) && discountParameters.cbxTypeP.SelectedIndex == 1)
                    {
                        MessageBox.Show("The dollar amount can not be blank if the type is set to dollar. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }

                    if(double.TryParse(discountParameters.tbxPercentageP.Text.Replace("%", ""), out double dblPercentage))
                    {
                        if (dblPercentage <= 100 && dblPercentage > 0)
                        {
                            cmdUpdate.Parameters.AddWithValue("@DiscountPercentage", dblPercentage / 100);
                        }
                        else
                        {
                            MessageBox.Show("Please enter a numeric value greater than 0 and less than 100 for percent. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            CloseDatabase();
                            return false;
                        }
                    }
                    else if (!string.IsNullOrEmpty(discountParameters.tbxPercentageP.Text))
                    {
                        MessageBox.Show("Please enter a numeric value for percentage amount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(discountParameters.tbxPercentageP.Text) && discountParameters.cbxTypeP.SelectedIndex == 0)
                    {
                        MessageBox.Show("The percentage amount can not be blank if the type is set to percent. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }                    

                    if (string.IsNullOrEmpty(discountParameters.tbxStartP.Text))
                    {
                        MessageBox.Show("The start date can not be blank for the discount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                    if (string.IsNullOrEmpty(discountParameters.tbxExpirationP.Text))
                    {
                        MessageBox.Show("The expiration date can not be blank for the discount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }

                    cmdUpdate.Parameters.AddWithValue("@StartDate", discountParameters.tbxStartP.Text);
                    cmdUpdate.Parameters.AddWithValue("@ExpirationDate", discountParameters.tbxExpirationP.Text);
                    cmdUpdate.Parameters.AddWithValue("@DiscountType", strType);
                    cmdUpdate.Parameters.AddWithValue("@DiscountLevel", strLevel);
                    SqlDataReader rdUpdate = cmdUpdate.ExecuteReader();

                    rdUpdate.Close();
                }
                CloseDatabase();
                return true;
            }
            catch (Exception ex)
            {
                //close database and show error
                CloseDatabase();
                UpdateDataFail(ex);
                return false;
            }
        }
        //method for updating customer into manager
        internal static void UpdateToManager(TextBox tbxPersonID)
        {
            try
            {
                OpenDatabase();
                string strPosition = "Manager";

                //string command to update inventory
                string strUpdateQuery = "UPDATE " + strSchema + ".Logon SET PositionTitle = @PositionTitle " +
                " WHERE PersonID = @PersonID";

                if (int.TryParse(tbxPersonID.Text, out int intPersonID))
                {
                    //command query
                    SqlCommand cmdUpdate = new SqlCommand(strUpdateQuery, _cntDatabase);
                    cmdUpdate.Parameters.AddWithValue("@PersonID", intPersonID);
                    cmdUpdate.Parameters.AddWithValue("@PositionTitle", strPosition);
                    SqlDataReader rdUpdate = cmdUpdate.ExecuteReader();

                    rdUpdate.Close();
                }
                CloseDatabase();
            }
            catch (Exception ex)
            {
                //close database and show error
                CloseDatabase();
                UpdateDataFail(ex);
            }
        }
        //method for updating customer into employee
        internal static void UpdateToEmployee(TextBox tbxPersonID)
        {
            try
            {
                OpenDatabase();
                string strPosition = "Employee";

                //string command to update inventory
                string strUpdateQuery = "UPDATE " + strSchema + ".Logon SET PositionTitle = @PositionTitle " +
                " WHERE PersonID = @PersonID";

                if (int.TryParse(tbxPersonID.Text, out int intPersonID))
                {
                    //command query
                    SqlCommand cmdUpdate = new SqlCommand(strUpdateQuery, _cntDatabase);
                    cmdUpdate.Parameters.AddWithValue("@PersonID", intPersonID);
                    cmdUpdate.Parameters.AddWithValue("@PositionTitle", strPosition);
                    SqlDataReader rdUpdate = cmdUpdate.ExecuteReader();

                    rdUpdate.Close();
                }
                CloseDatabase();
            }
            catch (Exception ex)
            {
                //close database and show error
                CloseDatabase();
                UpdateDataFail(ex);
            }
        }
        //method for updating to customer
        internal static void UpdateToCustomer(TextBox tbxPersonID)
        {
            try
            {
                OpenDatabase();
                string strPosition = "Customer";

                //string command to update inventory
                string strUpdateQuery = "UPDATE " + strSchema + ".Logon SET PositionTitle = @PositionTitle " +
                " WHERE PersonID = @PersonID";

                if (int.TryParse(tbxPersonID.Text, out int intPersonID))
                {
                    //command query
                    SqlCommand cmdUpdate = new SqlCommand(strUpdateQuery, _cntDatabase);
                    cmdUpdate.Parameters.AddWithValue("@PersonID", intPersonID);
                    cmdUpdate.Parameters.AddWithValue("@PositionTitle", strPosition);
                    SqlDataReader rdUpdate = cmdUpdate.ExecuteReader();

                    rdUpdate.Close();
                }
                CloseDatabase();
            }
            catch (Exception ex)
            {
                //close database and show error
                CloseDatabase();
                UpdateDataFail(ex);
            }
        }
        //method for adding to inventory
        internal static bool AddInventory(clsParameters.InventoryParameters inventoryParameters)
        {
            try
            {
                OpenDatabase();
                //set up discontinued
                string strDiscontinued;
                if (inventoryParameters.cbxDiscontinuedP.SelectedIndex == 0)
                {
                    strDiscontinued = "False";
                }
                else if (inventoryParameters.cbxDiscontinuedP.SelectedIndex == 1)
                {
                    strDiscontinued = "True";
                }
                else
                {
                    strDiscontinued = "";
                }

                //change picture to byte
                Image imgItem = inventoryParameters.pbxItemImageP.Image;

                //query to insert into orders table
                string strInsertQuery = "INSERT INTO " + strSchema + ".Inventory (ItemName, ItemDescription, RetailPrice, Cost, Quantity," +
                        " ItemImage, Discontinued, Size, Color, TeamID, RestockThreshold)" +
                    "  VALUES (@ItemName, @ItemDescription, @RetailPrice, @Cost, @Quantity," +
                    " @ItemImage, @Discontinued, @Size, @Color, @TeamID, @RestockThreshold)";

                if (int.TryParse(inventoryParameters.tbxQuantityP.Text.Trim(), out int intQuantity) &&
                double.TryParse(inventoryParameters.tbxCostP.Text.Trim(), out double dblCost) &&
                double.TryParse(inventoryParameters.tbxRetailPriceP.Text.Trim(), out double dblRetail) &&
                int.TryParse(inventoryParameters.cbxTeamIDP.SelectedValue.ToString(), out int intTeamID) &&
                int.TryParse(inventoryParameters.tbxRestockP.Text.Trim(), out int intRestock))
                {
                    //command query
                    SqlCommand cmdInventory = new SqlCommand(strInsertQuery, _cntDatabase);
                    if (string.IsNullOrEmpty(inventoryParameters.tbxItemNameP.Text))
                    {
                        MessageBox.Show("The item name can not be blank. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                    if (string.IsNullOrEmpty(inventoryParameters.tbxItemDescriptionP.Text))
                    {
                        MessageBox.Show("The item description can not be blank. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                    cmdInventory.Parameters.AddWithValue("@ItemName", inventoryParameters.tbxItemNameP.Text.Trim());
                    cmdInventory.Parameters.AddWithValue("@ItemDescription", inventoryParameters.tbxItemDescriptionP.Text.Trim());
                    if (dblRetail > 0)
                    {
                        cmdInventory.Parameters.AddWithValue("@RetailPrice", dblRetail);
                    }
                    else
                    {
                        MessageBox.Show("The retail price must be greater than 0. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                    if (dblCost >= 0)
                    {
                        cmdInventory.Parameters.AddWithValue("@Cost", dblCost);
                    }
                    else
                    {
                        MessageBox.Show("The cost must be greater than 0. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                    cmdInventory.Parameters.AddWithValue("@Quantity", intQuantity);
                    cmdInventory.Parameters.AddWithValue("@ItemImage", clsManager.ImagetoByteArray(imgItem));
                    cmdInventory.Parameters.AddWithValue("@Discontinued", strDiscontinued);
                    cmdInventory.Parameters.AddWithValue("@Size", inventoryParameters.tbxSizeP.Text.Trim());
                    cmdInventory.Parameters.AddWithValue("@Color", inventoryParameters.tbxColorP.Text.Trim());
                    cmdInventory.Parameters.AddWithValue("@TeamID", intTeamID);
                    cmdInventory.Parameters.AddWithValue("@RestockThreshold", intRestock);
                    SqlDataReader rdInventory = cmdInventory.ExecuteReader();

                    rdInventory.Close();                    
                }
                else
                {
                    MessageBox.Show("Unable to update item. Please ensure all fields are entered correctly. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseDatabase();
                    return false;
                }
                CloseDatabase();
                return true;
            }
            catch (Exception ex)
            {
                //close database and show error                
                CloseDatabase();
                InsertDataFail(ex);
                return false;
            }
        }
        //method for adding to discounts
        internal static bool AddDiscounts(clsParameters.DiscountParameters discountParameters)
        {
            try
            {
                OpenDatabase();
                //set up type and level
                string strType, strLevel;
                if (discountParameters.cbxTypeP.SelectedIndex == 0)
                {
                    strType = "0";
                }
                else if (discountParameters.cbxTypeP.SelectedIndex == 1)
                {
                    strType = "1";
                }
                else
                {
                    strType = "";
                }

                if (discountParameters.cbxLevelP.SelectedIndex == 0)
                {
                    strLevel = "1";
                }
                else if (discountParameters.cbxLevelP.SelectedIndex == 1)
                {
                    strLevel = "0";
                }
                else
                {
                    strLevel = "";
                }

                string strInsertQuery;
                if (discountParameters.cbxLevelP.SelectedIndex == 0 && discountParameters.cbxTypeP.SelectedIndex == 0)
                {
                    //item level and percentage
                    strInsertQuery = "INSERT INTO " + strSchema + ".Discounts (DiscountCode, Description, DiscountPercentage, InventoryID," +
                        " StartDate, ExpirationDate, DiscountLevel, DiscountType)" +
                    "  VALUES (@DiscountCode, @Description, @DiscountPercentage, @InventoryID," +
                    " @StartDate, @ExpirationDate, @DiscountLevel, @DiscountType)";
                }
                else if (discountParameters.cbxLevelP.SelectedIndex == 0 && discountParameters.cbxTypeP.SelectedIndex == 1)
                {
                    //item level and dollar
                    strInsertQuery = "INSERT INTO " + strSchema + ".Discounts (DiscountCode, Description, DiscountDollarAmount, InventoryID," +
                        " StartDate, ExpirationDate, DiscountLevel, DiscountType)" +
                    "  VALUES (@DiscountCode, @Description, @DiscountDollarAmount, @InventoryID," +
                    " @StartDate, @ExpirationDate, @DiscountLevel, @DiscountType)";
                }
                else if (discountParameters.cbxLevelP.SelectedIndex == 1 && discountParameters.cbxTypeP.SelectedIndex == 0)
                {
                    //cart and percentage
                    strInsertQuery = "INSERT INTO " + strSchema + ".Discounts (DiscountCode, Description, DiscountPercentage," +
                        " StartDate, ExpirationDate, DiscountLevel, DiscountType)" +
                    "  VALUES (@DiscountCode, @Description, @DiscountPercentage," +
                    " @StartDate, @ExpirationDate, @DiscountLevel, @DiscountType)";
                }
                else
                {
                    //cart and dollar
                    strInsertQuery = "INSERT INTO " + strSchema + ".Discounts (DiscountCode, Description, DiscountDollarAmount," + 
                        " StartDate, ExpirationDate, DiscountLevel, DiscountType)" +
                        "  VALUES (@DiscountCode, @Description, @DiscountDollarAmount," + 
                        " @StartDate, @ExpirationDate, @DiscountLevel, @DiscountType)";
                }

                //command query
                SqlCommand cmdUpdate = new SqlCommand(strInsertQuery, _cntDatabase);
                if (string.IsNullOrEmpty(discountParameters.tbxDiscountCodeP.Text))
                {
                    MessageBox.Show("The discount code can not be blank for the discount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseDatabase();
                    return false;
                }
                if (string.IsNullOrEmpty(discountParameters.tbxDescriptionP.Text))
                {
                    MessageBox.Show("The description can not be blank for the discount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseDatabase();
                    return false;
                }
                cmdUpdate.Parameters.AddWithValue("@DiscountCode", discountParameters.tbxDiscountCodeP.Text.Trim());
                cmdUpdate.Parameters.AddWithValue("@Description", discountParameters.tbxDescriptionP.Text.Trim());
                if (int.TryParse(discountParameters.tbxInventoryIDP.Text, out int intID))
                {
                    cmdUpdate.Parameters.AddWithValue("@InventoryID", intID);
                }
                else if (!string.IsNullOrEmpty(discountParameters.tbxInventoryIDP.Text))
                {
                    MessageBox.Show("Please enter a numeric value for inventory id. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseDatabase();
                    return false;
                }
                else if (string.IsNullOrEmpty(discountParameters.tbxInventoryIDP.Text) && discountParameters.cbxLevelP.SelectedIndex == 0)
                {
                    MessageBox.Show("The inventory ID can not be blank if the level is set to item level. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseDatabase();
                    return false;
                }

                string strDiscount;
                if (!string.IsNullOrEmpty(discountParameters.tbxDollarP.Text))
                {
                    if (discountParameters.tbxDollarP.Text.Contains("$"))
                    {
                        strDiscount = discountParameters.tbxDollarP.Text.Substring(1);
                    }
                    else
                    {
                        strDiscount = discountParameters.tbxDollarP.Text;
                    }
                }
                else
                {
                    strDiscount = discountParameters.tbxDollarP.Text;
                }

                if (double.TryParse(strDiscount, out double dblDollar))
                {
                    if (dblDollar > 0)
                    {
                        cmdUpdate.Parameters.AddWithValue("@DiscountDollarAmount", dblDollar);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a numeric value that is not negative for dollar amount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                }
                else if (!string.IsNullOrEmpty(discountParameters.tbxDollarP.Text))
                {
                    MessageBox.Show("Please enter a numeric value for dollar amount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseDatabase();
                    return false;
                }
                else if (string.IsNullOrEmpty(discountParameters.tbxDollarP.Text) && discountParameters.cbxTypeP.SelectedIndex == 1)
                {
                    MessageBox.Show("The dollar amount can not be blank if the type is set to dollar. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseDatabase();
                    return false;
                }

                if (double.TryParse(discountParameters.tbxPercentageP.Text.Replace("%", ""), out double dblPercentage))
                {
                    if (dblPercentage <= 100 && dblPercentage > 0)
                    {
                        cmdUpdate.Parameters.AddWithValue("@DiscountPercentage", dblPercentage / 100);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a numeric value greater than 0 and less than 100 for percent. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseDatabase();
                        return false;
                    }
                }
                else if (!string.IsNullOrEmpty(discountParameters.tbxPercentageP.Text))
                {
                    MessageBox.Show("Please enter a numeric value for percentage amount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseDatabase();
                    return false;
                }
                else if (string.IsNullOrEmpty(discountParameters.tbxPercentageP.Text) && discountParameters.cbxTypeP.SelectedIndex == 0)
                {
                    MessageBox.Show("The percentage amount can not be blank if the type is set to percent. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseDatabase();
                    return false;
                }                

                if(string.IsNullOrEmpty(discountParameters.tbxStartP.Text))
                {
                    MessageBox.Show("The start date can not be blank for the discount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseDatabase();
                    return false;
                }
                if (string.IsNullOrEmpty(discountParameters.tbxExpirationP.Text))
                {
                    MessageBox.Show("The expiration date can not be blank for the discount. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseDatabase();
                    return false;
                }
                cmdUpdate.Parameters.AddWithValue("@StartDate", discountParameters.tbxStartP.Text.Trim());
                cmdUpdate.Parameters.AddWithValue("@ExpirationDate", discountParameters.tbxExpirationP.Text.Trim());
                cmdUpdate.Parameters.AddWithValue("@DiscountType", strType);
                cmdUpdate.Parameters.AddWithValue("@DiscountLevel", strLevel);
                SqlDataReader rdUpdate = cmdUpdate.ExecuteReader();

                rdUpdate.Close();

                CloseDatabase();
                return true;
            }
            catch (Exception ex)
            {
                //close database and show error                
                CloseDatabase();
                InsertDataFail(ex);
                return false;
            }
        }

        //reports form
        public static SqlCommand _sqlDailySales;
        //add the data adapter
        public static SqlDataAdapter _daDailySales = new SqlDataAdapter();
        //add the data table
        public static DataTable _dtDailySales = new DataTable();


        public static SqlCommand _sqlWeeklySales;
        //add the data adapter
        public static SqlDataAdapter _daWeeklySales = new SqlDataAdapter();
        //add the data table
        public static DataTable _dtWeeklySales = new DataTable();


        public static SqlCommand _sqlMonthlySales;
        //add the data adapter
        public static SqlDataAdapter _daMonthlySales = new SqlDataAdapter();
        //add the data table
        public static DataTable _dtMonthlySales = new DataTable();

        //method to load sales values
        internal static void DatabaseCommandLoadDailySales(DateTime dateSelected)
        {
            try
            {
                OpenDatabase();
                string strQuery;
                //string to build query 
                strQuery = $"declare @TotalSaleOfOrder money "
                + " set @TotalSaleOfOrder = (select top 1 sum(I.RetailPrice * D.Quantity) as 'Total Daily Sales' from " + strSchema + ".Inventory I FULL JOIN " + strSchema + ".OrderDetails D on I.InventoryID = D.InventoryID " +
                "FULL JOIN "+ strSchema + ".Orders O on O.OrderID = D.OrderID where O.OrderDate = '"+ dateSelected.ToString("yyyy-MM-dd") +"')"
                + " Select D.OrderID, O.OrderDate, I.ItemName, D.Quantity, format(@TotalSaleOfOrder, 'C') as 'Total Daily Sales' from " + strSchema + ".Inventory I, " + strSchema + ".OrderDetails D, " + strSchema + ".Orders O " +
                "WHERE O.OrderDate = '" + dateSelected.ToString("yyyy-MM-dd") +"' and D.OrderID = O.OrderID and I.InventoryID = D.InventoryID order by OrderID;";
                //establish cmd obj
                _sqlDailySales = new SqlCommand(strQuery, _cntDatabase);
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in establishing Daily Sales Table.", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                CloseDatabase();
            }
        }
        internal static void DatabaseCommandLoadWeeklySales(DateTime dateSelectedStart, DateTime dateSelectedEnd)
        {
            try
            {
                OpenDatabase();
                string strQuery;
                //string to build query 
                strQuery = $"declare @TotalSaleOfOrder money "
                + " set @TotalSaleOfOrder = (select top 1 sum(I.RetailPrice * D.Quantity) as 'Total Weekly Sales' from " + strSchema + ".Inventory I FULL JOIN " + strSchema + ".OrderDetails D on I.InventoryID = D.InventoryID " +
                "FULL JOIN " + strSchema + ".Orders O on O.OrderID = D.OrderID where O.OrderDate between '" + dateSelectedStart.ToString("yyyy-MM-dd") + "' and '"+ 
                dateSelectedEnd.ToString("yyyy-MM-dd") +"')"
                + " Select distinct D.OrderID, O.OrderDate, format(sum(I.RetailPrice * D.Quantity) over (partition by Day(O.OrderDate)), 'C') as 'Daily Sales', format(@TotalSaleOfOrder, 'C') as 'Total Weekly Sales' from " + 
                strSchema + ".Inventory I, " + strSchema + ".OrderDetails D, " + strSchema + ".Orders O " +
                "WHERE O.OrderDate between '" + dateSelectedStart.ToString("yyyy-MM-dd") + "' and '" + dateSelectedEnd.ToString("yyyy-MM-dd") + "' and D.OrderID = O.OrderID and I.InventoryID = D.InventoryID order by OrderID;";
                //establish cmd obj
                _sqlWeeklySales = new SqlCommand(strQuery, _cntDatabase);
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in establishing Weekly Sales Table.", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                CloseDatabase();
            }
        }
        internal static void DatabaseCommandLoadMonthlySales(DateTime dateSelectedMonth)
        {
            try
            {
                OpenDatabase();
                string strQuery;
                //string to build query 
                strQuery = $"declare @TotalSaleOfOrder money "
                + " set @TotalSaleOfOrder = (select top 1 sum(I.RetailPrice * D.Quantity) as 'Total Monthly Sales' from " + strSchema + ".Inventory I FULL JOIN " + strSchema + ".OrderDetails D on I.InventoryID = D.InventoryID " +
                "FULL JOIN " + strSchema + ".Orders O on O.OrderID = D.OrderID where month(O.OrderDate) = '" + dateSelectedMonth.ToString("MM") + "')"
                + " Select distinct D.OrderID, O.OrderDate, format(sum(I.RetailPrice * D.Quantity) over (partition by DATEPART(week, O.OrderDate)), 'C') as 'Weekly Sales', format(@TotalSaleOfOrder, 'C') as 'Total Monthly Sales' from " +
                strSchema + ".Inventory I, " + strSchema + ".OrderDetails D, " + strSchema + ".Orders O " +
                "where month(O.OrderDate) = '" + dateSelectedMonth.ToString("MM") + "' and D.OrderID = O.OrderID and I.InventoryID = D.InventoryID order by OrderID;";
                //establish cmd obj
                _sqlMonthlySales = new SqlCommand(strQuery, _cntDatabase);
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in establishing Monthly Sales Table.", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                CloseDatabase();
            }
        }

        public static SqlCommand _sqlInventoryAvailable;
        //add the data adapter
        public static SqlDataAdapter _daInventoryAvailable = new SqlDataAdapter();
        //add the data table
        public static DataTable _dtInventoryAvailable = new DataTable();

        public static SqlCommand _sqlInventoryFull;
        //add the data adapter
        public static SqlDataAdapter _daInventoryFull = new SqlDataAdapter();
        //add the data table
        public static DataTable _dtInventoryFull = new DataTable();

        public static SqlCommand _sqlInventoryRestock;
        //add the data adapter
        public static SqlDataAdapter _daInventoryRestock = new SqlDataAdapter();
        //add the data table
        public static DataTable _dtInventoryRestock = new DataTable();
        //method to load inventory values
        internal static void DatabaseCommandLoadAvailableInventory()
        {
            try
            {
                OpenDatabase();
                string strQuery;
                //string to build query 
                strQuery = "Select InventoryID, ItemName, format(Cost, 'C') as 'Cost', format(RetailPrice, 'C') as 'Retail Price', Quantity, RestockThreshold from " + strSchema +
                    ".Inventory WHERE Discontinued = 0 order by InventoryID ASC;";
                //establish cmd obj
                _sqlInventoryAvailable = new SqlCommand(strQuery, _cntDatabase);
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in establishing Available Inventory Table.", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                CloseDatabase();
            }
        }
        internal static void DatabaseCommandLoadFullInventory()
        {
            try
            {
                OpenDatabase();
                string strQuery;
                //string to build query 
                strQuery = "Select InventoryID, ItemName, format(Cost, 'C') as 'Cost', format(RetailPrice, 'C') as 'Retail Price', Quantity, RestockThreshold from " + strSchema +
                    ".Inventory order by InventoryID ASC;";
                //establish cmd obj
                _sqlInventoryFull = new SqlCommand(strQuery, _cntDatabase);
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in establishing Full Inventory Table.", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                CloseDatabase();
            }
        }
        internal static void DatabaseCommandLoadRestockInventory()
        {
            try
            {
                OpenDatabase();
                string strQuery;
                //string to build query 
                strQuery = "Select InventoryID, ItemName, format(Cost, 'C') as 'Cost', format(RetailPrice, 'C') as 'Retail Price', Quantity, RestockThreshold from " + strSchema +
                    ".Inventory WHERE RestockThreshold >= Quantity and Discontinued = 0 order by InventoryID ASC;";
                //establish cmd obj
                _sqlInventoryRestock = new SqlCommand(strQuery, _cntDatabase);
                CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in establishing Restock Inventory Table.", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                CloseDatabase();
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
