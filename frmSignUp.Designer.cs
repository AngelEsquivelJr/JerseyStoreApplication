
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
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxZipcode = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbxCity = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxAddress3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxAddress2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxPhoneTwo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxSuffix = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxMiddleName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxPhoneOne = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxAddress1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxEmailInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxOne = new System.Windows.Forms.GroupBox();
            this.cbxTitle = new System.Windows.Forms.ComboBox();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.gbxTwo = new System.Windows.Forms.GroupBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.tbxAnswerThree = new System.Windows.Forms.TextBox();
            this.tbxAnswerTwo = new System.Windows.Forms.TextBox();
            this.tbxAnswerOne = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxSecurityThree = new System.Windows.Forms.ComboBox();
            this.cbxSecurityTwo = new System.Windows.Forms.ComboBox();
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
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(20, 83);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 19);
            this.label18.TabIndex = 14;
            this.label18.Text = "*Username";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(11, 591);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(198, 18);
            this.label17.TabIndex = 4;
            this.label17.Text = "*Indicates Required Fields";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(15, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 19);
            this.label15.TabIndex = 0;
            this.label15.Text = "Title";
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
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(17, 418);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 19);
            this.label16.TabIndex = 9;
            this.label16.Text = "*Zip Code";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(203, 365);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 19);
            this.label14.TabIndex = 7;
            this.label14.Text = "*State";
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 359);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 19);
            this.label13.TabIndex = 5;
            this.label13.Text = "*City";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(15, 301);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 19);
            this.label12.TabIndex = 3;
            this.label12.Text = "Address 3";
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "Address 2";
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(193, 478);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 19);
            this.label10.TabIndex = 12;
            this.label10.Text = "Secondary Phone";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(205, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 19);
            this.label9.TabIndex = 8;
            this.label9.Text = "Suffix";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(205, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "Middle Name";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "*Last Name";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 478);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Primary Phone";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "*Address 1";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "*First Name";
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
            this.tbxPassword.TextChanged += new System.EventHandler(this.tbxPassword_TextChanged);
            this.tbxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPassword_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "*Password";
            // 
            // tbxEmailInput
            // 
            this.tbxEmailInput.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEmailInput.Location = new System.Drawing.Point(22, 43);
            this.tbxEmailInput.MaxLength = 40;
            this.tbxEmailInput.Name = "tbxEmailInput";
            this.tbxEmailInput.Size = new System.Drawing.Size(327, 26);
            this.tbxEmailInput.TabIndex = 0;
            this.tbxEmailInput.TextChanged += new System.EventHandler(this.tbxEmailInput_TextChanged);
            this.tbxEmailInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxEmailInput_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email";
            // 
            // gbxOne
            // 
            this.gbxOne.Controls.Add(this.cbxState);
            this.gbxOne.Controls.Add(this.cbxTitle);
            this.gbxOne.Controls.Add(this.label3);
            this.gbxOne.Controls.Add(this.tbxAddress1);
            this.gbxOne.Controls.Add(this.label4);
            this.gbxOne.Controls.Add(this.label11);
            this.gbxOne.Controls.Add(this.tbxAddress2);
            this.gbxOne.Controls.Add(this.label7);
            this.gbxOne.Controls.Add(this.tbxFirstName);
            this.gbxOne.Controls.Add(this.label12);
            this.gbxOne.Controls.Add(this.tbxLastName);
            this.gbxOne.Controls.Add(this.tbxCity);
            this.gbxOne.Controls.Add(this.tbxAddress3);
            this.gbxOne.Controls.Add(this.label14);
            this.gbxOne.Controls.Add(this.label8);
            this.gbxOne.Controls.Add(this.tbxMiddleName);
            this.gbxOne.Controls.Add(this.tbxPhoneOne);
            this.gbxOne.Controls.Add(this.label13);
            this.gbxOne.Controls.Add(this.tbxSuffix);
            this.gbxOne.Controls.Add(this.label5);
            this.gbxOne.Controls.Add(this.label16);
            this.gbxOne.Controls.Add(this.label10);
            this.gbxOne.Controls.Add(this.label9);
            this.gbxOne.Controls.Add(this.tbxZipcode);
            this.gbxOne.Controls.Add(this.tbxPhoneTwo);
            this.gbxOne.Controls.Add(this.label15);
            this.gbxOne.Location = new System.Drawing.Point(9, 12);
            this.gbxOne.Name = "gbxOne";
            this.gbxOne.Size = new System.Drawing.Size(357, 556);
            this.gbxOne.TabIndex = 0;
            this.gbxOne.TabStop = false;
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
            // gbxTwo
            // 
            this.gbxTwo.Controls.Add(this.tbxAnswerThree);
            this.gbxTwo.Controls.Add(this.btnShow);
            this.gbxTwo.Controls.Add(this.tbxAnswerTwo);
            this.gbxTwo.Controls.Add(this.label23);
            this.gbxTwo.Controls.Add(this.tbxEmailInput);
            this.gbxTwo.Controls.Add(this.tbxAnswerOne);
            this.gbxTwo.Controls.Add(this.label22);
            this.gbxTwo.Controls.Add(this.label1);
            this.gbxTwo.Controls.Add(this.label20);
            this.gbxTwo.Controls.Add(this.cbxSecurityThree);
            this.gbxTwo.Controls.Add(this.tbxPassword);
            this.gbxTwo.Controls.Add(this.label19);
            this.gbxTwo.Controls.Add(this.label2);
            this.gbxTwo.Controls.Add(this.label21);
            this.gbxTwo.Controls.Add(this.cbxSecurityTwo);
            this.gbxTwo.Controls.Add(this.tbxUsername);
            this.gbxTwo.Controls.Add(this.label18);
            this.gbxTwo.Controls.Add(this.label6);
            this.gbxTwo.Controls.Add(this.cbxSecurityOne);
            this.gbxTwo.Location = new System.Drawing.Point(398, 12);
            this.gbxTwo.Name = "gbxTwo";
            this.gbxTwo.Size = new System.Drawing.Size(364, 556);
            this.gbxTwo.TabIndex = 1;
            this.gbxTwo.TabStop = false;
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
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(18, 506);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 19);
            this.label23.TabIndex = 8;
            this.label23.Text = "*Answer:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(18, 404);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 19);
            this.label22.TabIndex = 7;
            this.label22.Text = "*Answer:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(18, 301);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 19);
            this.label21.TabIndex = 6;
            this.label21.Text = "*Answer:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(22, 443);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(164, 19);
            this.label20.TabIndex = 2;
            this.label20.Text = "*Security Question 3:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(19, 339);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(164, 19);
            this.label19.TabIndex = 1;
            this.label19.Text = "*Security Question 2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "*Security Question 1:";
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
            // cbxSecurityTwo
            // 
            this.cbxSecurityTwo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSecurityTwo.FormattingEnabled = true;
            this.cbxSecurityTwo.Location = new System.Drawing.Point(22, 362);
            this.cbxSecurityTwo.Name = "cbxSecurityTwo";
            this.cbxSecurityTwo.Size = new System.Drawing.Size(327, 21);
            this.cbxSecurityTwo.TabIndex = 6;
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
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.btnCancel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AE Sporting Fits | Create Your Account";
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
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbxZipcode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbxCity;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbxAddress3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbxAddress2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxPhoneTwo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxSuffix;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxMiddleName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbxPhoneOne;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxAddress1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxEmailInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxOne;
        private System.Windows.Forms.GroupBox gbxTwo;
        private System.Windows.Forms.ComboBox cbxSecurityThree;
        private System.Windows.Forms.ComboBox cbxSecurityTwo;
        private System.Windows.Forms.ComboBox cbxSecurityOne;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbxTitle;
        private System.Windows.Forms.TextBox tbxAnswerThree;
        private System.Windows.Forms.TextBox tbxAnswerTwo;
        private System.Windows.Forms.TextBox tbxAnswerOne;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
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