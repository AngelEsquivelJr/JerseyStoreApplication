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

        //var for login name
        public static string strLogonName = "Guest";

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

        //structure for holding textbox and combobox parameters
        public struct ParametersSQL
        {
            public ComboBox cbxTitle, cbxState, cbxSecQuestion1, cbxSecQuestion2, cbxSecQuestion3;

            public TextBox tbxFirstName, tbxMiddleName, tbxLastName, tbxSuffix, tbxAddress1, tbxAddress2, tbxAddress3, tbxCity, tbxZipcode, tbxEmail, tbxPhone1, tbxPhone2, tbxAnswer1, tbxAnswer2, tbxAnswer3, tbxUser, tbxPassword;
        }

        //method to write new user info to database
        internal static bool WriteLoginData(ParametersSQL boxParams)
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
                " Address3, City, Zipcode, State, Email, PhonePrimary, PhoneSecondary) VALUES (@Title, @NameFirst, @NameMiddle, @NameLast, @Suffix," +
                " @Address1, @Address2, @Address3, @City, @Zipcode, @State, @Email, @PhonePrimary, @PhoneSecondary)";
            string strInsertQuery2 = "INSERT INTO " + strSchema + ".Logon (PersonID, LogonName, Password, FirstChallengeQuestion, FirstChallengeAnswer," +
                " SecondChallengeQuestion, SecondChallengeAnswer, ThirdChallengeQuestion, ThirdChallengeAnswer, PositionTitle) VALUES (@PersonID, @LogonName," +
                " @Password, @FirstChallengeQuestion, @FirstChallengeAnswer, @SecondChallengeQuestion, @SecondChallengeAnswer, @ThirdChallengeQuestion," +
                " @ThirdChallengeAnswer, 'Customer')";
            string strSelectQuery = "SELECT PersonID, NameFirst FROM " + strSchema + ".Person where NameFirst = @NameFirst;";
            string strSelectQuery2 = "SELECT LogonName FROM " + strSchema + ".Logon where LogonName = @LogonName;";

            //set proper set id to question id var
            bolID1 = int.TryParse(boxParams.cbxSecQuestion1.SelectedValue.ToString(), out intID1);
            bolID2 = int.TryParse(boxParams.cbxSecQuestion2.SelectedValue.ToString(), out intID2);
            bolID3 = int.TryParse(boxParams.cbxSecQuestion3.SelectedValue.ToString(), out intID3);

            OpenDatabase();

            try
            {

                //command query for logon name
                SqlCommand cmd4 = new SqlCommand(strSelectQuery2, _cntDatabase);
                cmd4.Parameters.AddWithValue("@LogonName", boxParams.tbxUser.Text);
                SqlDataReader rd4 = cmd4.ExecuteReader();

                //if statement to check if username already exists
                if (rd4.Read())
                {
                    //string for returned value
                    string strUsername = rd4.GetValue(0).ToString();

                    //if returned username is the same send error
                    if (strUsername.ToUpper().Contains(boxParams.tbxUser.Text.ToUpper()))
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
                SqlCommand cmd = new SqlCommand(strInsertQuery, _cntDatabase);
                cmd.Parameters.AddWithValue("@Title", boxParams.cbxTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@NameFirst", boxParams.tbxFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@NameMiddle", boxParams.tbxMiddleName.Text.Trim());
                cmd.Parameters.AddWithValue("@NameLast", boxParams.tbxLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Suffix", boxParams.tbxSuffix.Text.Trim());
                cmd.Parameters.AddWithValue("@Address1", boxParams.tbxAddress1.Text.Trim());
                cmd.Parameters.AddWithValue("@Address2", boxParams.tbxAddress2.Text.Trim());
                cmd.Parameters.AddWithValue("@Address3", boxParams.tbxAddress3.Text.Trim());
                cmd.Parameters.AddWithValue("@City", boxParams.tbxCity.Text.Trim());
                cmd.Parameters.AddWithValue("@Zipcode", boxParams.tbxZipcode.Text.Trim());
                cmd.Parameters.AddWithValue("@State", boxParams.cbxState.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", boxParams.tbxEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@PhonePrimary", boxParams.tbxPhone1.Text.Trim());
                cmd.Parameters.AddWithValue("@PhoneSecondary", boxParams.tbxPhone2.Text.Trim());

                //executes querys and closes reader
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Close();

                //command query for personId
                SqlCommand cmd3 = new SqlCommand(strSelectQuery, _cntDatabase);
                cmd3.Parameters.AddWithValue("@NameFirst", boxParams.tbxFirstName.Text);
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
                SqlCommand cmd2 = new SqlCommand(strInsertQuery2, _cntDatabase);
                cmd2.Parameters.AddWithValue("@PersonID", intPersonID);
                cmd2.Parameters.AddWithValue("@LogonName", boxParams.tbxUser.Text.Trim());
                cmd2.Parameters.AddWithValue("@Password", boxParams.tbxPassword.Text.Trim());
                cmd2.Parameters.AddWithValue("@FirstChallengeQuestion", intID1);
                cmd2.Parameters.AddWithValue("@FirstChallengeAnswer", boxParams.tbxAnswer1.Text.Trim());
                cmd2.Parameters.AddWithValue("@SecondChallengeQuestion", intID2);
                cmd2.Parameters.AddWithValue("@SecondChallengeAnswer", boxParams.tbxAnswer2.Text.Trim());
                cmd2.Parameters.AddWithValue("@ThirdChallengeQuestion", intID3);
                cmd2.Parameters.AddWithValue("@ThirdChallengeAnswer", boxParams.tbxAnswer3.Text.Trim());

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
            string strSelectQuery = "SELECT LogonName, Password, PositionTitle FROM " + strSchema + ".Logon " +
                "WHERE LogonName = @LogonName";
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
                    string strPassword = rd.GetValue(1).ToString();
                    string strTitle = rd.GetValue(2).ToString();

                    //if returned username is the same
                    //make sure its not case sensitive
                    if (strUsername.ToUpper().Contains(tbxUsername.Text.ToUpper()))
                    {
                        //check password
                        if (strPassword == tbxPassword.Text)
                        {
                            //set logon name var
                            strLogonName = strUsername;
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
                string strSelectQuery = "SELECT LogonName, Q1.QuestionPrompt, Q2.QuestionPrompt, Q3.QuestionPrompt FROM " + strSchema +
                    ".Logon L FULL JOIN " + strSchema + ".SecurityQuestions Q1 ON L.FirstChallengeQuestion = Q1.QuestionID" +
                    " FULL JOIN " + strSchema + ".SecurityQuestions Q2 ON L.SecondChallengeQuestion = Q2.QuestionID" +
                    " FULL JOIN " + strSchema + ".SecurityQuestions Q3 ON L.ThirdChallengeQuestion = Q3.QuestionID" +
                    " WHERE LogonName = @LogonName";

                //command query
                SqlCommand cmd = new SqlCommand(strSelectQuery, _cntDatabase);
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
            //make command and byte var
            SqlCommand imgCommand = null;
            byte[] imageData = null;
            Int32 intWidth = 140;

            try
            {
                //query for images
                string strImageQuery = "SELECT ItemImage from " + strSchema + ".Inventory";
                imgCommand = new SqlCommand(strImageQuery, _cntDatabase);
                //close previous connections and open new one
                CloseDatabase();
                OpenDatabase();

                //create reader and open reader
                SqlDataReader rdImage = imgCommand.ExecuteReader();
                if(rdImage.HasRows)
                {                                        
                    while (rdImage.Read())
                    {
                        //set image to byte and use temporary image
                        imageData = (byte[])rdImage[0];
                        Image tmpImage = Image.FromStream(new MemoryStream(imageData));
                        //scale image and set resized image
                        double dblScaleImg = (double)intWidth / (double)tmpImage.Width;
                        Graphics tmpGraphics = default(Graphics);
                        Bitmap tmpResizedImage = new Bitmap(Convert.ToInt32(dblScaleImg * tmpImage.Width), Convert.ToInt32(dblScaleImg * tmpImage.Height));
                        tmpGraphics = Graphics.FromImage(tmpResizedImage);
                        tmpGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                        tmpGraphics.DrawImage(tmpImage, 0, 0, tmpResizedImage.Width + 1, tmpResizedImage.Height + 1);
                        Image imgOut = tmpResizedImage;                        

                        for (int i = 0; i < dgvInventory.Rows.Count; i++)
                        {                                                                                                                    
                                //add image to data grid view
                                dgvInventory.Rows[i].Cells[0].Value = imgOut;
                        }                        
                    }                  
                }

                //close reader and close database
                rdImage.Close();
                CloseDatabase();                
            }
            catch(Exception ex)
            {
                //error message
                MessageBox.Show(ex.Message, "Error gathering images.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        //method to format and bind data grid view
        internal static void BindInventoryView(DataGridView dgvInventory)
        {
            dgvInventory.Rows.Clear();
            //set command object to null
            _sqlInventoryCommand = null;

            //reset data adapter and data table to new
            _daInventory = new SqlDataAdapter();
            _dtInventoryTable = new DataTable();

            //string query
            string strDGVQuery = "Select ItemName as 'Name', RetailPrice as 'Price', Size, Quantity, ItemDescription as 'Description', Color, T.TeamSport as 'Sport' from " + strSchema + ".Inventory I INNER JOIN " +
                strSchema + ".Teams T ON I.TeamID = T.TeamID";

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

            (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = "";
        }
        internal static void FormatInventoryView(DataGridView dgvInventory)
        {            

            //format data grid view
            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                row.Height = 150;
            }

            for (int i = 0; i < dgvInventory.ColumnCount; i++)
            {
                dgvInventory.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvInventory.AutoResizeColumns();
                dgvInventory.AllowUserToAddRows = false;
                dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvInventory.Columns[i].DefaultCellStyle.Font = new Font("Rockwell", 9F, FontStyle.Bold);
            }
        }

        //method to initialize data grid view
        internal static void InitializeInventoryView(DataGridView dgvInventory)
        {
            //open database
            OpenDatabase();

            //fill tables and objects
            try
            {
                //setup data
                BindInventoryView(dgvInventory);

                //setup image column
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();                
                imageColumn.HeaderText = "Item Image";
                dgvInventory.Columns.Insert(0, imageColumn);

                //setup image
                ImageInventory(dgvInventory);

                //format view
                FormatInventoryView(dgvInventory);

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

        //method for cart data grid view and adding to cart
        internal static void CartView(DataGridView dgvInventory, DataGridView dgvCart)
        {
            //var for item name, price, quantity, and size
            string strItemName = "";
            string strSize = "";
            string strPrice = "";
            string strQuantity = "";
            //vars for cost
            double dblCost;

            if (dgvInventory.SelectedCells.Count > 0)
            {
                int intSelectedRowIndex = dgvInventory.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dgvInventory.Rows[intSelectedRowIndex];
                strItemName = Convert.ToString(selectedRow.Cells["Name"].Value);
                strSize = Convert.ToString(selectedRow.Cells["Size"].Value);
                strPrice = Convert.ToString(selectedRow.Cells["Price"].Value);
                strQuantity = Convert.ToString(selectedRow.Cells["Quantity"].Value);
                //set quantity to int
                int.TryParse(strQuantity, out int intQuantity);
                



                MessageBox.Show("1 " + dgvInventory.CurrentRow.Cells[1].Value.ToString() + " has been added to your cart", "Item added", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand cmdCategory = new SqlCommand("SELECT distinct T.TeamName, T.TeamSport FROM " + strSchema +
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
                 cbxCategory.ValueMember = "TeamName";
                   
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
                SqlCommand cmdSize = new SqlCommand("SELECT distinct I.Size, T.TeamName FROM " + strSchema +
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
        internal static void FillQuantityCombo(DataGridView dgvInventory, ComboBox cbxCategory)
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
                    int.TryParse(strQuantity, out int intQuantity);

                    //query for getting inventory id
                    string strSelectID = "SELECT InventoryID from " + strSchema + ".Inventory WHERE ItemName = '" + strItem + "' AND Size = '" + strSize + "'";
                    //command query for inventory id
                    SqlCommand cmdInventoryID = new SqlCommand(strSelectID, _cntDatabase);
                    SqlDataReader rdInventoryID = cmdInventoryID.ExecuteReader();

                    //if statement to set inventory id
                    if (rdInventoryID.Read())
                    {
                        //string for returned values
                        strInventoryID = rdInventoryID.GetValue(0).ToString();
                        
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

                        for (int i = 0; i < intQuantity; i++)
                        {
                            dtQuantity.Rows.Add(i);
                        }
                        dtQuantity.Rows.InsertAt(drQuantity, 0);

                        //setup comboboxes
                        cbxCategory.DataSource = dtQuantity;
                        cbxCategory.DisplayMember = "Quantity";
                        cbxCategory.ValueMember = "Quantity";

                    }
                    else
                    {
                        //error for not finding id
                        MessageBox.Show("Could not find Inventory ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rdInventoryID.Close();
                        CloseDatabase();
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

        //method for filtering data grid view
        internal static void FilterInventoryCategory(DataGridView dgvInventory, ComboBox cbxCategory, ComboBox cbxSize, TextBox tbxSearch)
        {
            //check selected index
            if (cbxSize.SelectedIndex == 0 && cbxCategory.SelectedIndex >= 1)
            {
                //set filter
                (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = string.Format("Sport = '{0}'", cbxCategory.Text);
                if (!dgvInventory.Columns.Contains("Item Image"))
                {
                    ImageInventory(dgvInventory);
                }
                FormatInventoryView(dgvInventory);
            }
            else
            {
                if (cbxCategory.SelectedIndex >= 1 && cbxSize.SelectedIndex >= 1)
                {
                    //set multiple filters
                    (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = string.Format("Sport = '{0}' AND Size = '{1}'", cbxCategory.Text, cbxSize.Text);
                    if (!dgvInventory.Columns.Contains("Item Image"))
                    {
                        ImageInventory(dgvInventory);
                    }
                    FormatInventoryView(dgvInventory);
                }
                else if (cbxCategory.SelectedIndex == 0 && cbxSize.SelectedIndex >= 1)
                {
                    //set filter
                    (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = string.Format("Size = '{0}'", cbxSize.Text);
                    if (!dgvInventory.Columns.Contains("Item Image"))
                    {
                        ImageInventory(dgvInventory);
                    }
                    FormatInventoryView(dgvInventory);
                }
                else
                {
                    (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = "";
                    if (!dgvInventory.Columns.Contains("Item Image"))
                    {
                        ImageInventory(dgvInventory);
                    }
                    FormatInventoryView(dgvInventory);
                    tbxSearch.Focus();
                }
            }
        }
        internal static void FilterInventorySize(DataGridView dgvInventory, ComboBox cbxSize, ComboBox cbxCategory, TextBox tbxSearch)
        {            
            
            //check selected index
            if (cbxCategory.SelectedIndex == 0 && cbxSize.SelectedIndex >= 1)
            {
                //set filter
                (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = string.Format("Size = '{0}'", cbxSize.Text);
                if (!dgvInventory.Columns.Contains("Item Image"))
                {
                    ImageInventory(dgvInventory);
                }
                FormatInventoryView(dgvInventory);
            }
            else
            {
                if (cbxSize.SelectedIndex >= 1 && cbxCategory.SelectedIndex >= 1)
                {
                    //set multiple filters
                    (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = string.Format("Sport = '{0}' AND Size = '{1}'", cbxCategory.Text, cbxSize.Text);
                    if (!dgvInventory.Columns.Contains("Item Image"))
                    {
                        ImageInventory(dgvInventory);
                    }
                    FormatInventoryView(dgvInventory);
                }
                else if (cbxSize.SelectedIndex == 0 && cbxCategory.SelectedIndex >= 1)
                {
                    //set filter
                    (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = string.Format("Sport = '{0}'", cbxCategory.Text);
                    if (!dgvInventory.Columns.Contains("Item Image"))
                    {
                        ImageInventory(dgvInventory);
                    }
                    FormatInventoryView(dgvInventory);
                }
                else
                {
                    (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = "";
                    if (!dgvInventory.Columns.Contains("Item Image"))
                    {
                        ImageInventory(dgvInventory);
                    }
                    FormatInventoryView(dgvInventory);
                    tbxSearch.Focus();
                }
            }
        }

        //method for searching
        internal static void SearchInventory(DataGridView dgvInventory, TextBox tbxSearch, ComboBox cbxSize)
        {            
                //check for empty text box
                if (String.IsNullOrEmpty(tbxSearch.Text) || String.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    MessageBox.Show("Search was left blank. Please enter what you need to search. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {                    
                    //go through each row
                    foreach (DataGridViewRow row in dgvInventory.Rows)
                    {
                        //MessageBox.Show(row.Cells.ToString());
                        for (int i = 0; i < row.Cells.Count; i++)
                        {        
                            //check value for null
                            if (row.Cells[i].Value != null)
                            {
                                //look for matching text
                                if (row.Cells[i].Value.ToString().ToUpper().Contains(tbxSearch.Text.ToUpper()))
                                {
                                    //select matching text
                                    dgvInventory.CurrentCell = row.Cells[i];
                                }
                            }
                        }
                    }                
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
