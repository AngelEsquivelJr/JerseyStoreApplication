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
        public static string strPID = "0";
        public static string strDID = "0";
        public static string strDiscountType = "0";

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
                " Address3, City, Zipcode, State, Email, PhonePrimary, PhoneSecondary) VALUES (@Title, @NameFirst, @NameMiddle, @NameLast, @Suffix," +
                " @Address1, @Address2, @Address3, @City, @Zipcode, @State, @Email, @PhonePrimary, @PhoneSecondary)";
            string strInsertQuery2 = "INSERT INTO " + strSchema + ".Logon (PersonID, LogonName, Password, FirstChallengeQuestion, FirstChallengeAnswer," +
                " SecondChallengeQuestion, SecondChallengeAnswer, ThirdChallengeQuestion, ThirdChallengeAnswer, PositionTitle) VALUES (@PersonID, @LogonName," +
                " @Password, @FirstChallengeQuestion, @FirstChallengeAnswer, @SecondChallengeQuestion, @SecondChallengeAnswer, @ThirdChallengeQuestion," +
                " @ThirdChallengeAnswer, 'Customer')";
            string strSelectQuery = "SELECT PersonID, NameFirst FROM " + strSchema + ".Person where NameFirst = @NameFirst;";
            string strSelectQuery2 = "SELECT LogonName FROM " + strSchema + ".Logon where LogonName = @LogonName;";

            //set proper set id to question id var
            bolID1 = int.TryParse(signupParameters.cbxSecQuestion1.SelectedValue.ToString(), out intID1);
            bolID2 = int.TryParse(signupParameters.cbxSecQuestion2.SelectedValue.ToString(), out intID2);
            bolID3 = int.TryParse(signupParameters.cbxSecQuestion3.SelectedValue.ToString(), out intID3);

            OpenDatabase();

            try
            {
                //command query for logon name
                SqlCommand cmdSelectLogon = new SqlCommand(strSelectQuery2, _cntDatabase);
                cmdSelectLogon.Parameters.AddWithValue("@LogonName", signupParameters.tbxUsername.Text);
                SqlDataReader rdLogon = cmdSelectLogon.ExecuteReader();

                //if statement to check if username already exists
                if (rdLogon.Read())
                {
                    //string for returned value
                    string strUsername = rdLogon.GetValue(0).ToString();

                    //if returned username is the same send error
                    if (strUsername.ToUpper().Contains(signupParameters.tbxUsername.Text.ToUpper()))
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
                cmdInsert.Parameters.AddWithValue("@Title", signupParameters.cbxTitle.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@NameFirst", signupParameters.tbxFirstName.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@NameMiddle", signupParameters.tbxMiddleName.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@NameLast", signupParameters.tbxLastName.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@Suffix", signupParameters.tbxSuffix.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@Address1", signupParameters.tbxAddress1.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@Address2", signupParameters.tbxAddress2.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@Address3", signupParameters.tbxAddress3.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@City", signupParameters.tbxCity.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@Zipcode", signupParameters.tbxZipcode.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@State", signupParameters.cbxState.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@Email", signupParameters.tbxEmail.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@PhonePrimary", signupParameters.tbxPhone1.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@PhoneSecondary", signupParameters.tbxPhone2.Text.Trim());

                //executes querys and closes reader
                SqlDataReader rdInsert = cmdInsert.ExecuteReader();
                rdInsert.Close();

                //command query for personId
                SqlCommand cmdSelect = new SqlCommand(strSelectQuery, _cntDatabase);
                cmdSelect.Parameters.AddWithValue("@NameFirst", signupParameters.tbxFirstName.Text);
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
                cmdInsert2.Parameters.AddWithValue("@LogonName", signupParameters.tbxUsername.Text.Trim());
                cmdInsert2.Parameters.AddWithValue("@Password", signupParameters.tbxPassword.Text.Trim());
                cmdInsert2.Parameters.AddWithValue("@FirstChallengeQuestion", intID1);
                cmdInsert2.Parameters.AddWithValue("@FirstChallengeAnswer", signupParameters.tbxAnswer1.Text.Trim());
                cmdInsert2.Parameters.AddWithValue("@SecondChallengeQuestion", intID2);
                cmdInsert2.Parameters.AddWithValue("@SecondChallengeAnswer", signupParameters.tbxAnswer2.Text.Trim());
                cmdInsert2.Parameters.AddWithValue("@ThirdChallengeQuestion", intID3);
                cmdInsert2.Parameters.AddWithValue("@ThirdChallengeAnswer", signupParameters.tbxAnswer3.Text.Trim());

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
            string strSelectQuery = "SELECT LogonName, PersonID, Password, PositionTitle FROM " + strSchema + ".Logon " +
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
                    string strPersonID = rd.GetValue(1).ToString();
                    string strPassword = rd.GetValue(2).ToString();
                    string strTitle = rd.GetValue(3).ToString();

                    //if returned username is the same
                    //make sure its not case sensitive
                    if (strUsername.ToUpper().Contains(tbxUsername.Text.ToUpper()))
                    {
                        //check password
                        if (strPassword == tbxPassword.Text)
                        {
                            //set logon name var
                            strLogonName = strUsername;
                            strPID = strPersonID;
                            
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
            //set command object to null
            _sqlInventoryCommand = null;

            //reset data adapter and data table to new
            _daInventory = new SqlDataAdapter();
            _dtInventoryTable = new DataTable();

            //string query
            string strDGVQuery = "Select ItemImage as 'Image', ItemName as 'Name', RetailPrice as 'Price', Size, Quantity, ItemDescription as 'Description', Color, T.TeamSport as 'Sport' from " + strSchema + ".Inventory I INNER JOIN " +
                strSchema + ".Teams T ON I.TeamID = T.TeamID Where Quantity > 0";

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
                string strFilter = "";

                //setup data
                BindInventoryView(dgvInventory);

                (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = strFilter;

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
                    if (int.TryParse(strQuantity, out int intQuantity))
                    {

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
        //inventory
        //data command
        public static SqlCommand _sqlManagerICommand;
        //data adapter
        public static SqlDataAdapter _daManagerI = new SqlDataAdapter();
        //data tables
        public static DataTable _dtManagerITable = new DataTable();
        //customers
        //data command
        public static SqlCommand _sqlCustomersCommand;
        //data adapter
        public static SqlDataAdapter _daCustomers = new SqlDataAdapter();
        //data tables
        public static DataTable _dtCustomersTable = new DataTable();

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
                string strDGVQuery = "Select InventoryID, ItemName as 'Name', Quantity from " + strSchema + ".Inventory" +
                    " WHERE Quantity <= RestockThreshold AND Discontinued != 0";

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
                foreach (DataGridViewRow row in dgvRestock.Rows)
                {
                    row.Height = 100;
                }

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
                    dgvInventory.Rows[i].Cells[6].Value = imgOut;

                }
                CloseDatabase();
            }
            catch (Exception ex)
            {
                //error message
                MessageBox.Show(ex.Message, "Error gathering images.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string strDGVQuery = "Select InventoryID, ItemName as 'Name', ItemDescription as 'Description', RetailPrice as 'Retail Price', Cost, Quantity, " +
                    "ItemImage as 'Image', Discontinued, Size, Color, TeamID, RestockThreshold from " + strSchema + ".Inventory";

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

                if (!dgvInventory.Columns.Contains("Item Image"))
                {
                    //setup image column
                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                    imageColumn.HeaderText = "Item Image";
                    dgvInventory.Columns.Insert(6, imageColumn);
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
                string strDGVQuery = "Select PersonID, Title, NameFirst as 'First Name', NameMiddle as 'Middle Name', NameLast as 'Last Name', Suffix, Address1, Address2, Address3, " +
                    "City, Zipcode, State, Email, PhonePrimary as 'Primary Phone', PhoneSecondary as 'Secondary Phone', PersonDeleted as 'Deleted' from " + strSchema + ".Person";

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
        //method to fill combo for teamID
        internal static void FillTeamIDCombo(ComboBox cbxTeamID)
        {
            try
            {
                //close previous connections and open new one
                CloseDatabase();
                OpenDatabase();

                //commands for data
                SqlCommand cmdTeamID = new SqlCommand("SELECT distinct T.TeamID FROM " + strSchema +
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
                cbxTeamID.DisplayMember = "TeamID";
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
        internal static void UpdateInventory(clsParameters.InventoryParameters inventoryParameters)
        {
            try
            {
                //set up discontinued
                string strDiscontinued;
                if (inventoryParameters.cbxDiscontinuedP.SelectedIndex == 1)
                {
                    strDiscontinued = "0";
                }
                else if (inventoryParameters.cbxDiscontinuedP.SelectedIndex == 2)
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
                    int.TryParse(inventoryParameters.cbxTeamIDP.Text.Trim(), out int intTeamID) &&
                    int.TryParse(inventoryParameters.tbxRestockP.Text.Trim(), out int intRestock))
                {
                    //command query
                    SqlCommand cmdUpdate = new SqlCommand(strUpdateQuery, _cntDatabase);
                    cmdUpdate.Parameters.AddWithValue("@InventoryID", intInventoryID);
                    cmdUpdate.Parameters.AddWithValue("@ItemName", inventoryParameters.tbxItemNameP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@ItemDescription", inventoryParameters.tbxItemDescriptionP.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@RetailPrice", dblRetail);
                    cmdUpdate.Parameters.AddWithValue("@Cost", dblCost);
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
            }
            catch (Exception ex)
            {
                //close database and show error
                CloseDatabase();
                UpdateDataFail(ex);
            }
        }
        //method for updating customers
        internal static void UpdateCustomers(clsParameters.SignupParameters signupParameters)
        {
            try
            {
                //set up discontinued
                string strDeleted;
                if (signupParameters.cbxDeleted.SelectedIndex == 1)
                {
                    strDeleted = "0";
                }
                else if (signupParameters.cbxDeleted.SelectedIndex == 2)
                {
                    strDeleted = "1";
                }
                else
                {
                    strDeleted = "";
                }

                //string command to update inventory
                string strUpdateQuery = "UPDATE " + strSchema + ".Person SET Title = @Title, NameFirst = @NameFirst, NameMiddle = @NameMiddle, NameLast = @NameLast, Suffix = @Suffix," +
                " Address1 = @Address1, Address2 = @Address2, Address3 = @Address3, City = @city, Zipcode = @ZIpcode, State = @State, Email = @Email," +
                " PhonePrimary = @PhonePrimary, PhoneSecondary = @PhoneSecondary, PersonDeleted = @PersonDeleted WHERE PersonID = @PersonID";

                if (int.TryParse(signupParameters.tbxPersonID.Text, out int intPersonID))
                {
                    //command query
                    SqlCommand cmdUpdate = new SqlCommand(strUpdateQuery, _cntDatabase);
                    cmdUpdate.Parameters.AddWithValue("@PersonID", intPersonID);
                    cmdUpdate.Parameters.AddWithValue("@Title", signupParameters.cbxTitle.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@NameFirst", signupParameters.tbxFirstName.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@NameMiddle", signupParameters.tbxMiddleName.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@NameLast", signupParameters.tbxLastName.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Suffix", signupParameters.tbxSuffix.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Address1", signupParameters.tbxAddress1.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Address2", signupParameters.tbxAddress2.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Address3", signupParameters.tbxAddress3.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@City", signupParameters.tbxCity.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Zipcode", signupParameters.tbxZipcode.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@State", signupParameters.cbxState.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Email", signupParameters.tbxEmail.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@PhonePrimary", signupParameters.tbxPhone1.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@PhoneSecondary", signupParameters.tbxPhone2.Text.Trim());
                    cmdUpdate.Parameters.AddWithValue("@PersonDeleted", strDeleted);
                    SqlDataReader rdUpdate = cmdUpdate.ExecuteReader();

                    rdUpdate.Close();
                }
            }
            catch (Exception ex)
            {
                //close database and show error
                CloseDatabase();
                UpdateDataFail(ex);
            }
        }
        //method for updating customer into manager
        internal static void UpdateToManager(TextBox tbxPersonID)
        {
            try
            {
                //set up discontinued
                string strPosition = "Manager";

                //string command to update inventory
                string strUpdateQuery = "UPDATE " + strSchema + ".Logon SET PositionTitle = @PositionTitle, " +
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
            }
            catch (Exception ex)
            {
                //close database and show error
                CloseDatabase();
                UpdateDataFail(ex);
            }
        }
        //method for adding to inventory
        internal static void AddInventory(clsParameters.InventoryParameters inventoryParameters)
        {
            try
            {
                //set up discontinued
                string strDiscontinued;
                if (inventoryParameters.cbxDiscontinuedP.SelectedIndex == 1)
                {
                    strDiscontinued = "0";
                }
                else if (inventoryParameters.cbxDiscontinuedP.SelectedIndex == 2)
                {
                    strDiscontinued = "1";
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
                int.TryParse(inventoryParameters.cbxTeamIDP.Text.Trim(), out int intTeamID) &&
                int.TryParse(inventoryParameters.tbxRestockP.Text.Trim(), out int intRestock))
                {
                    //command query
                    SqlCommand cmdInventory = new SqlCommand(strInsertQuery, _cntDatabase);
                    cmdInventory.Parameters.AddWithValue("@ItemName", inventoryParameters.tbxItemNameP.Text.Trim());
                    cmdInventory.Parameters.AddWithValue("@ItemDescription", inventoryParameters.tbxItemDescriptionP.Text.Trim());
                    cmdInventory.Parameters.AddWithValue("@RetailPrice", dblRetail);
                    cmdInventory.Parameters.AddWithValue("@Cost", dblCost);
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
            }
            catch (Exception ex)
            {
                //close database and show error                
                CloseDatabase();
                InsertDataFail(ex);
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
