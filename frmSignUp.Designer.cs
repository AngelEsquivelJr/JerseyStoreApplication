
namespace FinalProject
{
    partial class frmSignUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignUp));
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.lbl15 = new System.Windows.Forms.Label();
            this.lbl24 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.tbxZipcode = new System.Windows.Forms.TextBox();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.tbxCity = new System.Windows.Forms.TextBox();
            this.lbl9 = new System.Windows.Forms.Label();
            this.tbxAddress3 = new System.Windows.Forms.TextBox();
            this.lbl8 = new System.Windows.Forms.Label();
            this.tbxAddress2 = new System.Windows.Forms.TextBox();
            this.lbl7 = new System.Windows.Forms.Label();
            this.tbxPhoneTwo = new System.Windows.Forms.TextBox();
            this.lbl13 = new System.Windows.Forms.Label();
            this.tbxSuffix = new System.Windows.Forms.TextBox();
            this.lbl5 = new System.Windows.Forms.Label();
            this.tbxMiddleName = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxPhoneOne = new System.Windows.Forms.TextBox();
            this.lbl12 = new System.Windows.Forms.Label();
            this.tbxAddress1 = new System.Windows.Forms.TextBox();
            this.lbl6 = new System.Windows.Forms.Label();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.lbl16 = new System.Windows.Forms.Label();
            this.tbxEmailInput = new System.Windows.Forms.TextBox();
            this.lbl14 = new System.Windows.Forms.Label();
            this.gbxOne = new System.Windows.Forms.GroupBox();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.cbxTitle = new System.Windows.Forms.ComboBox();
            this.gbxTwo = new System.Windows.Forms.GroupBox();
            this.tbxAnswerThree = new System.Windows.Forms.TextBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.tbxAnswerTwo = new System.Windows.Forms.TextBox();
            this.lbl22 = new System.Windows.Forms.Label();
            this.tbxAnswerOne = new System.Windows.Forms.TextBox();
            this.lbl20 = new System.Windows.Forms.Label();
            this.lbl21 = new System.Windows.Forms.Label();
            this.cbxSecurityThree = new System.Windows.Forms.ComboBox();
            this.lbl19 = new System.Windows.Forms.Label();
            this.lbl18 = new System.Windows.Forms.Label();
            this.cbxSecurityTwo = new System.Windows.Forms.ComboBox();
            this.lbl17 = new System.Windows.Forms.Label();
            this.cbxSecurityOne = new System.Windows.Forms.ComboBox();
            this.securityQuestionsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.inew2332sp22TableDataSet = new FinalProject.inew2332sp22TableDataSet();
            this.securityQuestionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inew2332sp22DataSet = new FinalProject.inew2332sp22DataSet();
            this.btnHelp = new System.Windows.Forms.Button();
            this.securityQuestionsTableAdapter = new FinalProject.inew2332sp22DataSetTableAdapters.SecurityQuestionsTableAdapter();
            this.securityQuestionsTableAdapter1 = new FinalProject.inew2332sp22TableDataSetTableAdapters.SecurityQuestionsTableAdapter();
            this.gbxOne.SuspendLayout();
            this.gbxTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.securityQuestionsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inew2332sp22TableDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityQuestionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inew2332sp22DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxUsername
            // 
            this.tbxUsername.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUsername.Location = new System.Drawing.Point(22, 105);
            this.tbxUsername.MaxLength = 20;
            this.tbxUsername.Multiline = true;
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(327, 26);
            this.tbxUsername.TabIndex = 1;
            this.tbxUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxUsername_KeyPress);
            // 
            // lbl15
            // 
            this.lbl15.AutoSize = true;
            this.lbl15.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl15.Location = new System.Drawing.Point(20, 83);
            this.lbl15.Name = "lbl15";
            this.lbl15.Size = new System.Drawing.Size(92, 19);
            this.lbl15.TabIndex = 14;
            this.lbl15.Text = "*Username";
            // 
            // lbl24
            // 
            this.lbl24.AutoSize = true;
            this.lbl24.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl24.Location = new System.Drawing.Point(11, 591);
            this.lbl24.Name = "lbl24";
            this.lbl24.Size = new System.Drawing.Size(198, 18);
            this.lbl24.TabIndex = 4;
            this.lbl24.Text = "*Indicates Required Fields";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(15, 21);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(40, 19);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Title";
            // 
            // tbxZipcode
            // 
            this.tbxZipcode.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxZipcode.Location = new System.Drawing.Point(19, 440);
            this.tbxZipcode.MaxLength = 10;
            this.tbxZipcode.Multiline = true;
            this.tbxZipcode.Name = "tbxZipcode";
            this.tbxZipcode.Size = new System.Drawing.Size(177, 26);
            this.tbxZipcode.TabIndex = 11;
            this.tbxZipcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxZipcode_KeyPress);
            // 
            // lbl11
            // 
            this.lbl11.AutoSize = true;
            this.lbl11.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl11.Location = new System.Drawing.Point(17, 418);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(84, 19);
            this.lbl11.TabIndex = 9;
            this.lbl11.Text = "*Zip Code";
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl10.Location = new System.Drawing.Point(203, 365);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(54, 19);
            this.lbl10.TabIndex = 7;
            this.lbl10.Text = "*State";
            // 
            // tbxCity
            // 
            this.tbxCity.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCity.Location = new System.Drawing.Point(19, 381);
            this.tbxCity.MaxLength = 30;
            this.tbxCity.Multiline = true;
            this.tbxCity.Name = "tbxCity";
            this.tbxCity.Size = new System.Drawing.Size(179, 26);
            this.tbxCity.TabIndex = 9;
            this.tbxCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCity_KeyPress);
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl9.Location = new System.Drawing.Point(17, 359);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(47, 19);
            this.lbl9.TabIndex = 5;
            this.lbl9.Text = "*City";
            // 
            // tbxAddress3
            // 
            this.tbxAddress3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAddress3.Location = new System.Drawing.Point(19, 323);
            this.tbxAddress3.MaxLength = 30;
            this.tbxAddress3.Name = "tbxAddress3";
            this.tbxAddress3.ReadOnly = true;
            this.tbxAddress3.Size = new System.Drawing.Size(321, 26);
            this.tbxAddress3.TabIndex = 8;
            this.tbxAddress3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAddress3_KeyPress);
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl8.Location = new System.Drawing.Point(15, 301);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(83, 19);
            this.lbl8.TabIndex = 3;
            this.lbl8.Text = "Address 3";
            // 
            // tbxAddress2
            // 
            this.tbxAddress2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAddress2.Location = new System.Drawing.Point(19, 264);
            this.tbxAddress2.MaxLength = 30;
            this.tbxAddress2.Name = "tbxAddress2";
            this.tbxAddress2.ReadOnly = true;
            this.tbxAddress2.Size = new System.Drawing.Size(321, 26);
            this.tbxAddress2.TabIndex = 7;
            this.tbxAddress2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAddress2_KeyPress);
            this.tbxAddress2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxAddress2_KeyUp);
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl7.Location = new System.Drawing.Point(16, 242);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(83, 19);
            this.lbl7.TabIndex = 0;
            this.lbl7.Text = "Address 2";
            // 
            // tbxPhoneTwo
            // 
            this.tbxPhoneTwo.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPhoneTwo.Location = new System.Drawing.Point(197, 500);
            this.tbxPhoneTwo.MaxLength = 20;
            this.tbxPhoneTwo.Name = "tbxPhoneTwo";
            this.tbxPhoneTwo.ReadOnly = true;
            this.tbxPhoneTwo.Size = new System.Drawing.Size(147, 26);
            this.tbxPhoneTwo.TabIndex = 13;
            this.tbxPhoneTwo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPhoneTwo_KeyPress);
            // 
            // lbl13
            // 
            this.lbl13.AutoSize = true;
            this.lbl13.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl13.Location = new System.Drawing.Point(193, 478);
            this.lbl13.Name = "lbl13";
            this.lbl13.Size = new System.Drawing.Size(137, 19);
            this.lbl13.TabIndex = 12;
            this.lbl13.Text = "Secondary Phone";
            // 
            // tbxSuffix
            // 
            this.tbxSuffix.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSuffix.Location = new System.Drawing.Point(208, 151);
            this.tbxSuffix.MaxLength = 20;
            this.tbxSuffix.Name = "tbxSuffix";
            this.tbxSuffix.Size = new System.Drawing.Size(132, 26);
            this.tbxSuffix.TabIndex = 5;
            this.tbxSuffix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSuffix_KeyPress);
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(205, 129);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(50, 19);
            this.lbl5.TabIndex = 8;
            this.lbl5.Text = "Suffix";
            // 
            // tbxMiddleName
            // 
            this.tbxMiddleName.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMiddleName.Location = new System.Drawing.Point(209, 99);
            this.tbxMiddleName.MaxLength = 20;
            this.tbxMiddleName.Name = "tbxMiddleName";
            this.tbxMiddleName.Size = new System.Drawing.Size(131, 26);
            this.tbxMiddleName.TabIndex = 3;
            this.tbxMiddleName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxMiddleName_KeyPress);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(205, 77);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(108, 19);
            this.lbl3.TabIndex = 7;
            this.lbl3.Text = "Middle Name";
            // 
            // tbxLastName
            // 
            this.tbxLastName.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLastName.Location = new System.Drawing.Point(19, 151);
            this.tbxLastName.MaxLength = 20;
            this.tbxLastName.Multiline = true;
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(183, 26);
            this.tbxLastName.TabIndex = 4;
            this.tbxLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxLastName_KeyPress);
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(17, 129);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(94, 19);
            this.lbl4.TabIndex = 4;
            this.lbl4.Text = "*Last Name";
            // 
            // btnSignUp
            // 
            this.btnSignUp.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.Location = new System.Drawing.Point(687, 576);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(75, 33);
            this.btnSignUp.TabIndex = 5;
            this.btnSignUp.Text = "&Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(606, 576);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbxPhoneOne
            // 
            this.tbxPhoneOne.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPhoneOne.Location = new System.Drawing.Point(17, 500);
            this.tbxPhoneOne.MaxLength = 20;
            this.tbxPhoneOne.Name = "tbxPhoneOne";
            this.tbxPhoneOne.Size = new System.Drawing.Size(170, 26);
            this.tbxPhoneOne.TabIndex = 12;
            this.tbxPhoneOne.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPhoneOne_KeyPress);
            this.tbxPhoneOne.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxPhoneOne_KeyUp);
            // 
            // lbl12
            // 
            this.lbl12.AutoSize = true;
            this.lbl12.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl12.Location = new System.Drawing.Point(15, 478);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(117, 19);
            this.lbl12.TabIndex = 11;
            this.lbl12.Text = "Primary Phone";
            // 
            // tbxAddress1
            // 
            this.tbxAddress1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAddress1.Location = new System.Drawing.Point(19, 205);
            this.tbxAddress1.MaxLength = 30;
            this.tbxAddress1.Name = "tbxAddress1";
            this.tbxAddress1.Size = new System.Drawing.Size(321, 26);
            this.tbxAddress1.TabIndex = 6;
            this.tbxAddress1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAddress1_KeyPress);
            this.tbxAddress1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxAddress1_KeyUp);
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl6.Location = new System.Drawing.Point(15, 183);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(91, 19);
            this.lbl6.TabIndex = 0;
            this.lbl6.Text = "*Address 1";
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFirstName.Location = new System.Drawing.Point(19, 99);
            this.tbxFirstName.MaxLength = 20;
            this.tbxFirstName.Multiline = true;
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(183, 26);
            this.tbxFirstName.TabIndex = 2;
            this.tbxFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxFirstName_KeyPress);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(17, 77);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(97, 19);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "*First Name";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassword.Location = new System.Drawing.Point(22, 161);
            this.tbxPassword.MaxLength = 20;
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(327, 26);
            this.tbxPassword.TabIndex = 2;
            this.tbxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPassword_KeyPress);
            // 
            // lbl16
            // 
            this.lbl16.AutoSize = true;
            this.lbl16.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl16.Location = new System.Drawing.Point(20, 139);
            this.lbl16.Name = "lbl16";
            this.lbl16.Size = new System.Drawing.Size(87, 19);
            this.lbl16.TabIndex = 16;
            this.lbl16.Text = "*Password";
            // 
            // tbxEmailInput
            // 
            this.tbxEmailInput.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEmailInput.Location = new System.Drawing.Point(22, 43);
            this.tbxEmailInput.MaxLength = 40;
            this.tbxEmailInput.Name = "tbxEmailInput";
            this.tbxEmailInput.Size = new System.Drawing.Size(327, 26);
            this.tbxEmailInput.TabIndex = 0;
            this.tbxEmailInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxEmailInput_KeyPress);
            // 
            // lbl14
            // 
            this.lbl14.AutoSize = true;
            this.lbl14.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl14.Location = new System.Drawing.Point(22, 21);
            this.lbl14.Name = "lbl14";
            this.lbl14.Size = new System.Drawing.Size(115, 19);
            this.lbl14.TabIndex = 0;
            this.lbl14.Text = "Email Address";
            // 
            // gbxOne
            // 
            this.gbxOne.Controls.Add(this.cbxState);
            this.gbxOne.Controls.Add(this.cbxTitle);
            this.gbxOne.Controls.Add(this.lbl6);
            this.gbxOne.Controls.Add(this.tbxAddress1);
            this.gbxOne.Controls.Add(this.lbl2);
            this.gbxOne.Controls.Add(this.lbl7);
            this.gbxOne.Controls.Add(this.tbxAddress2);
            this.gbxOne.Controls.Add(this.lbl4);
            this.gbxOne.Controls.Add(this.tbxFirstName);
            this.gbxOne.Controls.Add(this.lbl8);
            this.gbxOne.Controls.Add(this.tbxLastName);
            this.gbxOne.Controls.Add(this.tbxCity);
            this.gbxOne.Controls.Add(this.tbxAddress3);
            this.gbxOne.Controls.Add(this.lbl10);
            this.gbxOne.Controls.Add(this.lbl3);
            this.gbxOne.Controls.Add(this.tbxMiddleName);
            this.gbxOne.Controls.Add(this.tbxPhoneOne);
            this.gbxOne.Controls.Add(this.lbl9);
            this.gbxOne.Controls.Add(this.tbxSuffix);
            this.gbxOne.Controls.Add(this.lbl12);
            this.gbxOne.Controls.Add(this.lbl11);
            this.gbxOne.Controls.Add(this.lbl13);
            this.gbxOne.Controls.Add(this.lbl5);
            this.gbxOne.Controls.Add(this.tbxZipcode);
            this.gbxOne.Controls.Add(this.tbxPhoneTwo);
            this.gbxOne.Controls.Add(this.lbl1);
            this.gbxOne.Location = new System.Drawing.Point(9, 12);
            this.gbxOne.Name = "gbxOne";
            this.gbxOne.Size = new System.Drawing.Size(357, 556);
            this.gbxOne.TabIndex = 0;
            this.gbxOne.TabStop = false;
            // 
            // cbxState
            // 
            this.cbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Items.AddRange(new object[] {
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
            this.cbxState.Location = new System.Drawing.Point(207, 386);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(125, 21);
            this.cbxState.TabIndex = 10;
            // 
            // cbxTitle
            // 
            this.cbxTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTitle.FormattingEnabled = true;
            this.cbxTitle.Items.AddRange(new object[] {
            "Mr",
            "Mrs",
            "Miss",
            "Ms",
            "Sir",
            "Dr",
            "Lady",
            "Lord"});
            this.cbxTitle.Location = new System.Drawing.Point(21, 44);
            this.cbxTitle.Name = "cbxTitle";
            this.cbxTitle.Size = new System.Drawing.Size(121, 21);
            this.cbxTitle.TabIndex = 1;
            // 
            // gbxTwo
            // 
            this.gbxTwo.Controls.Add(this.tbxAnswerThree);
            this.gbxTwo.Controls.Add(this.btnShow);
            this.gbxTwo.Controls.Add(this.tbxAnswerTwo);
            this.gbxTwo.Controls.Add(this.lbl22);
            this.gbxTwo.Controls.Add(this.tbxEmailInput);
            this.gbxTwo.Controls.Add(this.tbxAnswerOne);
            this.gbxTwo.Controls.Add(this.lbl20);
            this.gbxTwo.Controls.Add(this.lbl14);
            this.gbxTwo.Controls.Add(this.lbl21);
            this.gbxTwo.Controls.Add(this.cbxSecurityThree);
            this.gbxTwo.Controls.Add(this.tbxPassword);
            this.gbxTwo.Controls.Add(this.lbl19);
            this.gbxTwo.Controls.Add(this.lbl16);
            this.gbxTwo.Controls.Add(this.lbl18);
            this.gbxTwo.Controls.Add(this.cbxSecurityTwo);
            this.gbxTwo.Controls.Add(this.tbxUsername);
            this.gbxTwo.Controls.Add(this.lbl15);
            this.gbxTwo.Controls.Add(this.lbl17);
            this.gbxTwo.Controls.Add(this.cbxSecurityOne);
            this.gbxTwo.Location = new System.Drawing.Point(398, 12);
            this.gbxTwo.Name = "gbxTwo";
            this.gbxTwo.Size = new System.Drawing.Size(364, 556);
            this.gbxTwo.TabIndex = 1;
            this.gbxTwo.TabStop = false;
            // 
            // tbxAnswerThree
            // 
            this.tbxAnswerThree.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAnswerThree.Location = new System.Drawing.Point(95, 503);
            this.tbxAnswerThree.MaxLength = 20;
            this.tbxAnswerThree.Multiline = true;
            this.tbxAnswerThree.Name = "tbxAnswerThree";
            this.tbxAnswerThree.Size = new System.Drawing.Size(254, 24);
            this.tbxAnswerThree.TabIndex = 9;
            this.tbxAnswerThree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAnswerThree_KeyPress);
            // 
            // btnShow
            // 
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.Color.LightCyan;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Rockwell", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Image = global::FinalProject.Properties.Resources.showPassEye;
            this.btnShow.Location = new System.Drawing.Point(19, 189);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(51, 23);
            this.btnShow.TabIndex = 3;
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // tbxAnswerTwo
            // 
            this.tbxAnswerTwo.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAnswerTwo.Location = new System.Drawing.Point(95, 399);
            this.tbxAnswerTwo.MaxLength = 20;
            this.tbxAnswerTwo.Multiline = true;
            this.tbxAnswerTwo.Name = "tbxAnswerTwo";
            this.tbxAnswerTwo.Size = new System.Drawing.Size(254, 24);
            this.tbxAnswerTwo.TabIndex = 7;
            this.tbxAnswerTwo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAnswerTwo_KeyPress);
            // 
            // lbl22
            // 
            this.lbl22.AutoSize = true;
            this.lbl22.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl22.Location = new System.Drawing.Point(22, 506);
            this.lbl22.Name = "lbl22";
            this.lbl22.Size = new System.Drawing.Size(77, 19);
            this.lbl22.TabIndex = 8;
            this.lbl22.Text = "*Answer:";
            // 
            // tbxAnswerOne
            // 
            this.tbxAnswerOne.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAnswerOne.Location = new System.Drawing.Point(95, 296);
            this.tbxAnswerOne.MaxLength = 20;
            this.tbxAnswerOne.Multiline = true;
            this.tbxAnswerOne.Name = "tbxAnswerOne";
            this.tbxAnswerOne.Size = new System.Drawing.Size(254, 24);
            this.tbxAnswerOne.TabIndex = 5;
            this.tbxAnswerOne.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAnswerOne_KeyPress);
            // 
            // lbl20
            // 
            this.lbl20.AutoSize = true;
            this.lbl20.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl20.Location = new System.Drawing.Point(18, 404);
            this.lbl20.Name = "lbl20";
            this.lbl20.Size = new System.Drawing.Size(77, 19);
            this.lbl20.TabIndex = 7;
            this.lbl20.Text = "*Answer:";
            // 
            // lbl21
            // 
            this.lbl21.AutoSize = true;
            this.lbl21.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl21.Location = new System.Drawing.Point(22, 443);
            this.lbl21.Name = "lbl21";
            this.lbl21.Size = new System.Drawing.Size(164, 19);
            this.lbl21.TabIndex = 2;
            this.lbl21.Text = "*Security Question 3:";
            // 
            // cbxSecurityThree
            // 
            this.cbxSecurityThree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSecurityThree.FormattingEnabled = true;
            this.cbxSecurityThree.Location = new System.Drawing.Point(22, 465);
            this.cbxSecurityThree.Name = "cbxSecurityThree";
            this.cbxSecurityThree.Size = new System.Drawing.Size(327, 21);
            this.cbxSecurityThree.TabIndex = 8;
            // 
            // lbl19
            // 
            this.lbl19.AutoSize = true;
            this.lbl19.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl19.Location = new System.Drawing.Point(19, 339);
            this.lbl19.Name = "lbl19";
            this.lbl19.Size = new System.Drawing.Size(164, 19);
            this.lbl19.TabIndex = 1;
            this.lbl19.Text = "*Security Question 2:";
            // 
            // lbl18
            // 
            this.lbl18.AutoSize = true;
            this.lbl18.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl18.Location = new System.Drawing.Point(18, 301);
            this.lbl18.Name = "lbl18";
            this.lbl18.Size = new System.Drawing.Size(77, 19);
            this.lbl18.TabIndex = 6;
            this.lbl18.Text = "*Answer:";
            // 
            // cbxSecurityTwo
            // 
            this.cbxSecurityTwo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSecurityTwo.FormattingEnabled = true;
            this.cbxSecurityTwo.Location = new System.Drawing.Point(22, 362);
            this.cbxSecurityTwo.Name = "cbxSecurityTwo";
            this.cbxSecurityTwo.Size = new System.Drawing.Size(327, 21);
            this.cbxSecurityTwo.TabIndex = 6;
            // 
            // lbl17
            // 
            this.lbl17.AutoSize = true;
            this.lbl17.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl17.Location = new System.Drawing.Point(20, 233);
            this.lbl17.Name = "lbl17";
            this.lbl17.Size = new System.Drawing.Size(164, 19);
            this.lbl17.TabIndex = 0;
            this.lbl17.Text = "*Security Question 1:";
            // 
            // cbxSecurityOne
            // 
            this.cbxSecurityOne.DataSource = this.securityQuestionsBindingSource1;
            this.cbxSecurityOne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSecurityOne.FormattingEnabled = true;
            this.cbxSecurityOne.Location = new System.Drawing.Point(22, 255);
            this.cbxSecurityOne.Name = "cbxSecurityOne";
            this.cbxSecurityOne.Size = new System.Drawing.Size(327, 21);
            this.cbxSecurityOne.TabIndex = 4;
            // 
            // securityQuestionsBindingSource1
            // 
            this.securityQuestionsBindingSource1.DataMember = "SecurityQuestions";
            this.securityQuestionsBindingSource1.DataSource = this.inew2332sp22TableDataSet;
            // 
            // inew2332sp22TableDataSet
            // 
            this.inew2332sp22TableDataSet.DataSetName = "inew2332sp22TableDataSet";
            this.inew2332sp22TableDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // securityQuestionsBindingSource
            // 
            this.securityQuestionsBindingSource.DataMember = "SecurityQuestions";
            this.securityQuestionsBindingSource.DataSource = this.inew2332sp22DataSet;
            // 
            // inew2332sp22DataSet
            // 
            this.inew2332sp22DataSet.DataSetName = "inew2332sp22DataSet";
            this.inew2332sp22DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(525, 576);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 32);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // securityQuestionsTableAdapter
            // 
            this.securityQuestionsTableAdapter.ClearBeforeFill = true;
            // 
            // securityQuestionsTableAdapter1
            // 
            this.securityQuestionsTableAdapter1.ClearBeforeFill = true;
            // 
            // frmSignUp
            // 
            this.AcceptButton = this.btnSignUp;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(774, 619);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.gbxTwo);
            this.Controls.Add(this.gbxOne);
            this.Controls.Add(this.lbl24);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.btnCancel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Your Account | AE Sporting Fits";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSignUp_FormClosing);
            this.Load += new System.EventHandler(this.frmSignUp_Load);
            this.gbxOne.ResumeLayout(false);
            this.gbxOne.PerformLayout();
            this.gbxTwo.ResumeLayout(false);
            this.gbxTwo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.securityQuestionsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inew2332sp22TableDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityQuestionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inew2332sp22DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Label lbl15;
        private System.Windows.Forms.Label lbl24;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox tbxZipcode;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.TextBox tbxCity;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.TextBox tbxAddress3;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.TextBox tbxAddress2;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.TextBox tbxPhoneTwo;
        private System.Windows.Forms.Label lbl13;
        private System.Windows.Forms.TextBox tbxSuffix;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.TextBox tbxMiddleName;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbxPhoneOne;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.TextBox tbxAddress1;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label lbl16;
        private System.Windows.Forms.TextBox tbxEmailInput;
        private System.Windows.Forms.Label lbl14;
        private System.Windows.Forms.GroupBox gbxOne;
        private System.Windows.Forms.GroupBox gbxTwo;
        private System.Windows.Forms.ComboBox cbxSecurityThree;
        private System.Windows.Forms.ComboBox cbxSecurityTwo;
        private System.Windows.Forms.ComboBox cbxSecurityOne;
        private System.Windows.Forms.Label lbl17;
        private System.Windows.Forms.Label lbl21;
        private System.Windows.Forms.Label lbl19;
        private System.Windows.Forms.ComboBox cbxTitle;
        private System.Windows.Forms.TextBox tbxAnswerThree;
        private System.Windows.Forms.TextBox tbxAnswerTwo;
        private System.Windows.Forms.TextBox tbxAnswerOne;
        private System.Windows.Forms.Label lbl22;
        private System.Windows.Forms.Label lbl20;
        private System.Windows.Forms.Label lbl18;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnHelp;
        private inew2332sp22DataSet inew2332sp22DataSet;
        private System.Windows.Forms.BindingSource securityQuestionsBindingSource;
        private inew2332sp22DataSetTableAdapters.SecurityQuestionsTableAdapter securityQuestionsTableAdapter;
        private inew2332sp22TableDataSet inew2332sp22TableDataSet;
        private System.Windows.Forms.BindingSource securityQuestionsBindingSource1;
        private inew2332sp22TableDataSetTableAdapters.SecurityQuestionsTableAdapter securityQuestionsTableAdapter1;
    }
}