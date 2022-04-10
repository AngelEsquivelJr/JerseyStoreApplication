
namespace FinalProject
{
    partial class frmReset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReset));
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.lbl6 = new System.Windows.Forms.Label();
            this.tbxPassTwo = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.gbxOne = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnShowTwo = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.tbxAnswerThree = new System.Windows.Forms.TextBox();
            this.tbxAnswerTwo = new System.Windows.Forms.TextBox();
            this.tbxAnswerOne = new System.Windows.Forms.TextBox();
            this.tbxQuestionThree = new System.Windows.Forms.TextBox();
            this.tbxQuestionTwo = new System.Windows.Forms.TextBox();
            this.tbxQuestionOne = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.gbxOne.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(6, 41);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(99, 21);
            this.lbl1.TabIndex = 10;
            this.lbl1.Text = "Username";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(5, 349);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(140, 21);
            this.lbl5.TabIndex = 14;
            this.lbl5.Text = "New Password";
            // 
            // tbxUsername
            // 
            this.tbxUsername.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUsername.Location = new System.Drawing.Point(106, 41);
            this.tbxUsername.MaxLength = 20;
            this.tbxUsername.Multiline = true;
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(190, 26);
            this.tbxUsername.TabIndex = 1;
            this.tbxUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxUsername_KeyPress);
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassword.Location = new System.Drawing.Point(146, 349);
            this.tbxPassword.MaxLength = 20;
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.ReadOnly = true;
            this.tbxPassword.Size = new System.Drawing.Size(190, 30);
            this.tbxPassword.TabIndex = 6;
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl6.Location = new System.Drawing.Point(344, 349);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(172, 21);
            this.lbl6.TabIndex = 15;
            this.lbl6.Text = "Confirm Password";
            // 
            // tbxPassTwo
            // 
            this.tbxPassTwo.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassTwo.Location = new System.Drawing.Point(522, 349);
            this.tbxPassTwo.MaxLength = 20;
            this.tbxPassTwo.Name = "tbxPassTwo";
            this.tbxPassTwo.PasswordChar = '*';
            this.tbxPassTwo.ReadOnly = true;
            this.tbxPassTwo.Size = new System.Drawing.Size(190, 30);
            this.tbxPassTwo.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(12, 431);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(656, 431);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 33);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // gbxOne
            // 
            this.gbxOne.Controls.Add(this.btnUpdate);
            this.gbxOne.Controls.Add(this.btnShowTwo);
            this.gbxOne.Controls.Add(this.btnShow);
            this.gbxOne.Controls.Add(this.lbl4);
            this.gbxOne.Controls.Add(this.lbl3);
            this.gbxOne.Controls.Add(this.lbl2);
            this.gbxOne.Controls.Add(this.tbxAnswerThree);
            this.gbxOne.Controls.Add(this.tbxAnswerTwo);
            this.gbxOne.Controls.Add(this.tbxAnswerOne);
            this.gbxOne.Controls.Add(this.tbxQuestionThree);
            this.gbxOne.Controls.Add(this.tbxQuestionTwo);
            this.gbxOne.Controls.Add(this.tbxQuestionOne);
            this.gbxOne.Controls.Add(this.tbxUsername);
            this.gbxOne.Controls.Add(this.lbl1);
            this.gbxOne.Controls.Add(this.lbl5);
            this.gbxOne.Controls.Add(this.tbxPassTwo);
            this.gbxOne.Controls.Add(this.tbxPassword);
            this.gbxOne.Controls.Add(this.lbl6);
            this.gbxOne.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxOne.Location = new System.Drawing.Point(12, 12);
            this.gbxOne.Name = "gbxOne";
            this.gbxOne.Size = new System.Drawing.Size(719, 414);
            this.gbxOne.TabIndex = 0;
            this.gbxOne.TabStop = false;
            this.gbxOne.Text = "Enter your Username first and then Answer Your Security Questions";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(326, 36);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 32);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "&Find Username";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnShowTwo
            // 
            this.btnShowTwo.FlatAppearance.BorderColor = System.Drawing.Color.LightCyan;
            this.btnShowTwo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowTwo.Font = new System.Drawing.Font("Rockwell", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowTwo.Image = global::FinalProject.Properties.Resources.showPassEye;
            this.btnShowTwo.Location = new System.Drawing.Point(522, 385);
            this.btnShowTwo.Name = "btnShowTwo";
            this.btnShowTwo.Size = new System.Drawing.Size(47, 23);
            this.btnShowTwo.TabIndex = 9;
            this.btnShowTwo.UseVisualStyleBackColor = true;
            this.btnShowTwo.Click += new System.EventHandler(this.btnShowTwo_Click);
            // 
            // btnShow
            // 
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.Color.LightCyan;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Rockwell", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Image = global::FinalProject.Properties.Resources.showPassEye;
            this.btnShow.Location = new System.Drawing.Point(146, 385);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(47, 23);
            this.btnShow.TabIndex = 7;
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(82, 253);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(23, 19);
            this.lbl4.TabIndex = 13;
            this.lbl4.Text = "3:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(82, 176);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(23, 19);
            this.lbl3.TabIndex = 12;
            this.lbl3.Text = "2:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(82, 99);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(23, 19);
            this.lbl2.TabIndex = 11;
            this.lbl2.Text = "1:";
            // 
            // tbxAnswerThree
            // 
            this.tbxAnswerThree.Location = new System.Drawing.Point(106, 285);
            this.tbxAnswerThree.Name = "tbxAnswerThree";
            this.tbxAnswerThree.Size = new System.Drawing.Size(506, 26);
            this.tbxAnswerThree.TabIndex = 5;
            this.tbxAnswerThree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAnswerThree_KeyPress);
            // 
            // tbxAnswerTwo
            // 
            this.tbxAnswerTwo.Location = new System.Drawing.Point(106, 208);
            this.tbxAnswerTwo.Name = "tbxAnswerTwo";
            this.tbxAnswerTwo.Size = new System.Drawing.Size(506, 26);
            this.tbxAnswerTwo.TabIndex = 4;
            this.tbxAnswerTwo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAnswerTwo_KeyPress);
            // 
            // tbxAnswerOne
            // 
            this.tbxAnswerOne.Location = new System.Drawing.Point(106, 131);
            this.tbxAnswerOne.Name = "tbxAnswerOne";
            this.tbxAnswerOne.Size = new System.Drawing.Size(506, 26);
            this.tbxAnswerOne.TabIndex = 3;
            this.tbxAnswerOne.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAnswerOne_KeyPress);
            // 
            // tbxQuestionThree
            // 
            this.tbxQuestionThree.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxQuestionThree.Location = new System.Drawing.Point(106, 253);
            this.tbxQuestionThree.MaxLength = 20;
            this.tbxQuestionThree.Multiline = true;
            this.tbxQuestionThree.Name = "tbxQuestionThree";
            this.tbxQuestionThree.ReadOnly = true;
            this.tbxQuestionThree.Size = new System.Drawing.Size(506, 26);
            this.tbxQuestionThree.TabIndex = 0;
            this.tbxQuestionThree.TabStop = false;
            // 
            // tbxQuestionTwo
            // 
            this.tbxQuestionTwo.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxQuestionTwo.Location = new System.Drawing.Point(106, 176);
            this.tbxQuestionTwo.MaxLength = 20;
            this.tbxQuestionTwo.Multiline = true;
            this.tbxQuestionTwo.Name = "tbxQuestionTwo";
            this.tbxQuestionTwo.ReadOnly = true;
            this.tbxQuestionTwo.Size = new System.Drawing.Size(506, 26);
            this.tbxQuestionTwo.TabIndex = 17;
            this.tbxQuestionTwo.TabStop = false;
            // 
            // tbxQuestionOne
            // 
            this.tbxQuestionOne.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxQuestionOne.Location = new System.Drawing.Point(106, 99);
            this.tbxQuestionOne.MaxLength = 20;
            this.tbxQuestionOne.Multiline = true;
            this.tbxQuestionOne.Name = "tbxQuestionOne";
            this.tbxQuestionOne.ReadOnly = true;
            this.tbxQuestionOne.Size = new System.Drawing.Size(506, 26);
            this.tbxQuestionOne.TabIndex = 16;
            this.tbxQuestionOne.TabStop = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(338, 432);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 32);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmReset
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(743, 476);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.gbxOne);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "frmReset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AE Sporting Fits | Reset Password";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReset_FormClosing);
            this.gbxOne.ResumeLayout(false);
            this.gbxOne.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.TextBox tbxPassTwo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox gbxOne;
        private System.Windows.Forms.TextBox tbxQuestionOne;
        private System.Windows.Forms.TextBox tbxQuestionThree;
        private System.Windows.Forms.TextBox tbxQuestionTwo;
        private System.Windows.Forms.TextBox tbxAnswerThree;
        private System.Windows.Forms.TextBox tbxAnswerTwo;
        private System.Windows.Forms.TextBox tbxAnswerOne;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnShowTwo;
        private System.Windows.Forms.Button btnUpdate;
    }
}