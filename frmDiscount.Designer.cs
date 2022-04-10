﻿
namespace FinalProject
{
    partial class frmDiscount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiscount));
            this.dgvDiscounts = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.cbxLevel = new System.Windows.Forms.ComboBox();
            this.lbl9 = new System.Windows.Forms.Label();
            this.tbxExpiration = new System.Windows.Forms.TextBox();
            this.tbxStart = new System.Windows.Forms.TextBox();
            this.tbxDollarAmount = new System.Windows.Forms.TextBox();
            this.tbxPercentage = new System.Windows.Forms.TextBox();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.tbxInventoryID = new System.Windows.Forms.TextBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.tbxDiscountCode = new System.Windows.Forms.TextBox();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.btnEditChanges = new System.Windows.Forms.Button();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.tbxDiscountID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnAddDiscount = new System.Windows.Forms.Button();
            this.btnEditDiscount = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDiscounts
            // 
            this.dgvDiscounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscounts.Location = new System.Drawing.Point(492, 12);
            this.dgvDiscounts.Name = "dgvDiscounts";
            this.dgvDiscounts.Size = new System.Drawing.Size(434, 375);
            this.dgvDiscounts.TabIndex = 49;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGray;
            this.groupBox2.Controls.Add(this.cbxType);
            this.groupBox2.Controls.Add(this.cbxLevel);
            this.groupBox2.Controls.Add(this.lbl9);
            this.groupBox2.Controls.Add(this.tbxExpiration);
            this.groupBox2.Controls.Add(this.tbxStart);
            this.groupBox2.Controls.Add(this.tbxDollarAmount);
            this.groupBox2.Controls.Add(this.tbxPercentage);
            this.groupBox2.Controls.Add(this.lbl11);
            this.groupBox2.Controls.Add(this.lbl10);
            this.groupBox2.Controls.Add(this.lbl8);
            this.groupBox2.Controls.Add(this.lbl7);
            this.groupBox2.Controls.Add(this.tbxInventoryID);
            this.groupBox2.Controls.Add(this.tbxDescription);
            this.groupBox2.Controls.Add(this.tbxDiscountCode);
            this.groupBox2.Controls.Add(this.lbl6);
            this.groupBox2.Controls.Add(this.lbl5);
            this.groupBox2.Controls.Add(this.lbl4);
            this.groupBox2.Controls.Add(this.btnEditChanges);
            this.groupBox2.Controls.Add(this.lbl3);
            this.groupBox2.Controls.Add(this.lbl2);
            this.groupBox2.Controls.Add(this.tbxDiscountID);
            this.groupBox2.Location = new System.Drawing.Point(160, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 375);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.cbxType.Location = new System.Drawing.Point(116, 172);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(204, 24);
            this.cbxType.TabIndex = 96;
            // 
            // cbxLevel
            // 
            this.cbxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel.FormattingEnabled = true;
            this.cbxLevel.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.cbxLevel.Location = new System.Drawing.Point(116, 119);
            this.cbxLevel.Name = "cbxLevel";
            this.cbxLevel.Size = new System.Drawing.Size(204, 24);
            this.cbxLevel.TabIndex = 95;
            // 
            // lbl9
            // 
            this.lbl9.Location = new System.Drawing.Point(6, 235);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(104, 33);
            this.lbl9.TabIndex = 94;
            this.lbl9.Text = "Discount Dollar Amount:";
            this.lbl9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxExpiration
            // 
            this.tbxExpiration.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxExpiration.Location = new System.Drawing.Point(116, 305);
            this.tbxExpiration.Multiline = true;
            this.tbxExpiration.Name = "tbxExpiration";
            this.tbxExpiration.Size = new System.Drawing.Size(204, 20);
            this.tbxExpiration.TabIndex = 93;
            // 
            // tbxStart
            // 
            this.tbxStart.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxStart.Location = new System.Drawing.Point(116, 279);
            this.tbxStart.Multiline = true;
            this.tbxStart.Name = "tbxStart";
            this.tbxStart.Size = new System.Drawing.Size(204, 20);
            this.tbxStart.TabIndex = 92;
            // 
            // tbxDollarAmount
            // 
            this.tbxDollarAmount.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDollarAmount.Location = new System.Drawing.Point(116, 246);
            this.tbxDollarAmount.Multiline = true;
            this.tbxDollarAmount.Name = "tbxDollarAmount";
            this.tbxDollarAmount.Size = new System.Drawing.Size(204, 20);
            this.tbxDollarAmount.TabIndex = 91;
            // 
            // tbxPercentage
            // 
            this.tbxPercentage.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPercentage.Location = new System.Drawing.Point(116, 215);
            this.tbxPercentage.Multiline = true;
            this.tbxPercentage.Name = "tbxPercentage";
            this.tbxPercentage.Size = new System.Drawing.Size(204, 20);
            this.tbxPercentage.TabIndex = 90;
            // 
            // lbl11
            // 
            this.lbl11.AutoSize = true;
            this.lbl11.Location = new System.Drawing.Point(11, 305);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(101, 16);
            this.lbl11.TabIndex = 88;
            this.lbl11.Text = "Expiration Date:";
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.Location = new System.Drawing.Point(43, 279);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(69, 16);
            this.lbl10.TabIndex = 87;
            this.lbl10.Text = "Start Date:";
            // 
            // lbl8
            // 
            this.lbl8.Location = new System.Drawing.Point(22, 202);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(88, 33);
            this.lbl8.TabIndex = 86;
            this.lbl8.Text = "Discount Percentage:";
            this.lbl8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Location = new System.Drawing.Point(22, 172);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(94, 16);
            this.lbl7.TabIndex = 85;
            this.lbl7.Text = "Discount Type:";
            // 
            // tbxInventoryID
            // 
            this.tbxInventoryID.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxInventoryID.Location = new System.Drawing.Point(116, 145);
            this.tbxInventoryID.Multiline = true;
            this.tbxInventoryID.Name = "tbxInventoryID";
            this.tbxInventoryID.Size = new System.Drawing.Size(204, 20);
            this.tbxInventoryID.TabIndex = 84;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDescription.Location = new System.Drawing.Point(116, 71);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(204, 42);
            this.tbxDescription.TabIndex = 82;
            // 
            // tbxDiscountCode
            // 
            this.tbxDiscountCode.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDiscountCode.Location = new System.Drawing.Point(116, 45);
            this.tbxDiscountCode.Multiline = true;
            this.tbxDiscountCode.Name = "tbxDiscountCode";
            this.tbxDiscountCode.Size = new System.Drawing.Size(204, 20);
            this.tbxDiscountCode.TabIndex = 81;
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Location = new System.Drawing.Point(33, 145);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(83, 16);
            this.lbl6.TabIndex = 73;
            this.lbl6.Text = "Inventory ID:";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(20, 119);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(96, 16);
            this.lbl5.TabIndex = 71;
            this.lbl5.Text = "Discount Level:";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(38, 71);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(78, 16);
            this.lbl4.TabIndex = 70;
            this.lbl4.Text = "Description:";
            // 
            // btnEditChanges
            // 
            this.btnEditChanges.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditChanges.Location = new System.Drawing.Point(116, 335);
            this.btnEditChanges.Name = "btnEditChanges";
            this.btnEditChanges.Size = new System.Drawing.Size(115, 30);
            this.btnEditChanges.TabIndex = 64;
            this.btnEditChanges.Text = "Apply E&dit";
            this.btnEditChanges.UseVisualStyleBackColor = true;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(21, 45);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(97, 16);
            this.lbl3.TabIndex = 63;
            this.lbl3.Text = "Discount Code:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(34, 19);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(78, 16);
            this.lbl2.TabIndex = 55;
            this.lbl2.Text = "Discount ID:";
            // 
            // tbxDiscountID
            // 
            this.tbxDiscountID.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDiscountID.Location = new System.Drawing.Point(116, 19);
            this.tbxDiscountID.Multiline = true;
            this.tbxDiscountID.Name = "tbxDiscountID";
            this.tbxDiscountID.ReadOnly = true;
            this.tbxDiscountID.Size = new System.Drawing.Size(47, 20);
            this.tbxDiscountID.TabIndex = 47;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Controls.Add(this.btnAddDiscount);
            this.groupBox1.Controls.Add(this.btnEditDiscount);
            this.groupBox1.Controls.Add(this.lblState);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnHelp);
            this.groupBox1.Location = new System.Drawing.Point(2, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(152, 375);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // lbl1
            // 
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.LightCyan;
            this.lbl1.Location = new System.Drawing.Point(7, 70);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(139, 43);
            this.lbl1.TabIndex = 55;
            this.lbl1.Text = "Select a Discount to Edit";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddDiscount
            // 
            this.btnAddDiscount.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAddDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDiscount.ForeColor = System.Drawing.Color.LightCyan;
            this.btnAddDiscount.Location = new System.Drawing.Point(16, 190);
            this.btnAddDiscount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddDiscount.Name = "btnAddDiscount";
            this.btnAddDiscount.Size = new System.Drawing.Size(122, 35);
            this.btnAddDiscount.TabIndex = 54;
            this.btnAddDiscount.Text = "&Add Discount";
            this.btnAddDiscount.UseVisualStyleBackColor = true;
            // 
            // btnEditDiscount
            // 
            this.btnEditDiscount.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEditDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDiscount.ForeColor = System.Drawing.Color.LightCyan;
            this.btnEditDiscount.Location = new System.Drawing.Point(16, 134);
            this.btnEditDiscount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditDiscount.Name = "btnEditDiscount";
            this.btnEditDiscount.Size = new System.Drawing.Size(122, 35);
            this.btnEditDiscount.TabIndex = 53;
            this.btnEditDiscount.Text = "&Edit Discount";
            this.btnEditDiscount.UseVisualStyleBackColor = true;
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.ForeColor = System.Drawing.Color.LightCyan;
            this.lblState.Location = new System.Drawing.Point(12, 26);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(123, 21);
            this.lblState.TabIndex = 52;
            this.lblState.Text = "Discounts";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.LightCyan;
            this.btnClose.Location = new System.Drawing.Point(16, 305);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 35);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.ForeColor = System.Drawing.Color.LightCyan;
            this.btnHelp.Location = new System.Drawing.Point(16, 246);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(122, 35);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // frmDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(928, 389);
            this.Controls.Add(this.dgvDiscounts);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AE Sporting Fits | Discounts";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDiscounts;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.ComboBox cbxLevel;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.TextBox tbxExpiration;
        private System.Windows.Forms.TextBox tbxStart;
        private System.Windows.Forms.TextBox tbxDollarAmount;
        private System.Windows.Forms.TextBox tbxPercentage;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.TextBox tbxInventoryID;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.TextBox tbxDiscountCode;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Button btnEditChanges;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox tbxDiscountID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnAddDiscount;
        private System.Windows.Forms.Button btnEditDiscount;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnHelp;
    }
}