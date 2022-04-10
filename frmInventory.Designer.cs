﻿
namespace FinalProject
{
    partial class frmInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventory));
            this.gbx2 = new System.Windows.Forms.GroupBox();
            this.cbxTeamID = new System.Windows.Forms.ComboBox();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.tbxColor = new System.Windows.Forms.TextBox();
            this.lbl9 = new System.Windows.Forms.Label();
            this.tbxSize = new System.Windows.Forms.TextBox();
            this.lbl12 = new System.Windows.Forms.Label();
            this.tbxRestock = new System.Windows.Forms.TextBox();
            this.cbxDiscontinued = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.pbxItemImage = new System.Windows.Forms.PictureBox();
            this.tbxQuantity = new System.Windows.Forms.TextBox();
            this.tbxRetail = new System.Windows.Forms.TextBox();
            this.tbxPrice = new System.Windows.Forms.TextBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.tbxItemName = new System.Windows.Forms.TextBox();
            this.tbxInventoryID = new System.Windows.Forms.TextBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.gbx1 = new System.Windows.Forms.GroupBox();
            this.lblState = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnAddInventory = new System.Windows.Forms.Button();
            this.btnEditInventory = new System.Windows.Forms.Button();
            this.gbx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxItemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.gbx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx2
            // 
            this.gbx2.BackColor = System.Drawing.Color.LightGray;
            this.gbx2.Controls.Add(this.cbxTeamID);
            this.gbx2.Controls.Add(this.lbl11);
            this.gbx2.Controls.Add(this.lbl10);
            this.gbx2.Controls.Add(this.tbxColor);
            this.gbx2.Controls.Add(this.lbl9);
            this.gbx2.Controls.Add(this.tbxSize);
            this.gbx2.Controls.Add(this.lbl12);
            this.gbx2.Controls.Add(this.tbxRestock);
            this.gbx2.Controls.Add(this.cbxDiscontinued);
            this.gbx2.Controls.Add(this.btnAdd);
            this.gbx2.Controls.Add(this.btnBrowse);
            this.gbx2.Controls.Add(this.btnEdit);
            this.gbx2.Controls.Add(this.lbl8);
            this.gbx2.Controls.Add(this.lbl7);
            this.gbx2.Controls.Add(this.lbl6);
            this.gbx2.Controls.Add(this.lbl5);
            this.gbx2.Controls.Add(this.lbl4);
            this.gbx2.Controls.Add(this.lbl3);
            this.gbx2.Controls.Add(this.lbl2);
            this.gbx2.Controls.Add(this.lbl1);
            this.gbx2.Controls.Add(this.pbxItemImage);
            this.gbx2.Controls.Add(this.tbxQuantity);
            this.gbx2.Controls.Add(this.tbxRetail);
            this.gbx2.Controls.Add(this.tbxPrice);
            this.gbx2.Controls.Add(this.tbxDescription);
            this.gbx2.Controls.Add(this.tbxItemName);
            this.gbx2.Controls.Add(this.tbxInventoryID);
            this.gbx2.Location = new System.Drawing.Point(164, 334);
            this.gbx2.Name = "gbx2";
            this.gbx2.Size = new System.Drawing.Size(927, 221);
            this.gbx2.TabIndex = 46;
            this.gbx2.TabStop = false;
            // 
            // cbxTeamID
            // 
            this.cbxTeamID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTeamID.FormattingEnabled = true;
            this.cbxTeamID.Location = new System.Drawing.Point(783, 87);
            this.cbxTeamID.Name = "cbxTeamID";
            this.cbxTeamID.Size = new System.Drawing.Size(114, 27);
            this.cbxTeamID.TabIndex = 105;
            // 
            // lbl11
            // 
            this.lbl11.AutoSize = true;
            this.lbl11.Location = new System.Drawing.Point(701, 86);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(76, 19);
            this.lbl11.TabIndex = 104;
            this.lbl11.Text = "Team ID:";
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.Location = new System.Drawing.Point(722, 50);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(55, 19);
            this.lbl10.TabIndex = 102;
            this.lbl10.Text = "Color:";
            // 
            // tbxColor
            // 
            this.tbxColor.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxColor.Location = new System.Drawing.Point(783, 50);
            this.tbxColor.Multiline = true;
            this.tbxColor.Name = "tbxColor";
            this.tbxColor.Size = new System.Drawing.Size(114, 20);
            this.tbxColor.TabIndex = 101;
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.Location = new System.Drawing.Point(734, 15);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(43, 19);
            this.lbl9.TabIndex = 100;
            this.lbl9.Text = "Size:";
            // 
            // tbxSize
            // 
            this.tbxSize.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSize.Location = new System.Drawing.Point(783, 16);
            this.tbxSize.Multiline = true;
            this.tbxSize.Name = "tbxSize";
            this.tbxSize.Size = new System.Drawing.Size(114, 20);
            this.tbxSize.TabIndex = 99;
            // 
            // lbl12
            // 
            this.lbl12.Location = new System.Drawing.Point(686, 117);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(91, 39);
            this.lbl12.TabIndex = 98;
            this.lbl12.Text = "Restock Threshold:";
            // 
            // tbxRestock
            // 
            this.tbxRestock.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRestock.Location = new System.Drawing.Point(783, 134);
            this.tbxRestock.Multiline = true;
            this.tbxRestock.Name = "tbxRestock";
            this.tbxRestock.Size = new System.Drawing.Size(114, 20);
            this.tbxRestock.TabIndex = 97;
            // 
            // cbxDiscontinued
            // 
            this.cbxDiscontinued.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDiscontinued.FormattingEnabled = true;
            this.cbxDiscontinued.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cbxDiscontinued.Location = new System.Drawing.Point(134, 194);
            this.cbxDiscontinued.Name = "cbxDiscontinued";
            this.cbxDiscontinued.Size = new System.Drawing.Size(51, 27);
            this.cbxDiscontinued.TabIndex = 96;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(760, 175);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 40);
            this.btnAdd.TabIndex = 66;
            this.btnAdd.Text = "A&dd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(419, 88);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(68, 40);
            this.btnBrowse.TabIndex = 65;
            this.btnBrowse.Text = "&Browse Image";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(853, 175);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 40);
            this.btnEdit.TabIndex = 64;
            this.btnEdit.Text = "A&pply Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.Location = new System.Drawing.Point(410, 194);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(77, 19);
            this.lbl8.TabIndex = 63;
            this.lbl8.Text = "Quantity:";
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Location = new System.Drawing.Point(389, 66);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(98, 19);
            this.lbl7.TabIndex = 62;
            this.lbl7.Text = "Item Image:";
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Location = new System.Drawing.Point(391, 40);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(96, 19);
            this.lbl6.TabIndex = 61;
            this.lbl6.Text = "Retail Price:";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(436, 14);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(51, 19);
            this.lbl5.TabIndex = 60;
            this.lbl5.Text = "Price:";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(18, 195);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(109, 19);
            this.lbl4.TabIndex = 59;
            this.lbl4.Text = "Discontinued:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(30, 66);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(98, 19);
            this.lbl3.TabIndex = 58;
            this.lbl3.Text = "Description:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(32, 40);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(95, 19);
            this.lbl2.TabIndex = 56;
            this.lbl2.Text = "Item Name:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(25, 15);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(106, 19);
            this.lbl1.TabIndex = 55;
            this.lbl1.Text = "Inventory ID:";
            // 
            // pbxItemImage
            // 
            this.pbxItemImage.Location = new System.Drawing.Point(493, 66);
            this.pbxItemImage.Name = "pbxItemImage";
            this.pbxItemImage.Size = new System.Drawing.Size(187, 123);
            this.pbxItemImage.TabIndex = 54;
            this.pbxItemImage.TabStop = false;
            // 
            // tbxQuantity
            // 
            this.tbxQuantity.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxQuantity.Location = new System.Drawing.Point(493, 195);
            this.tbxQuantity.Multiline = true;
            this.tbxQuantity.Name = "tbxQuantity";
            this.tbxQuantity.Size = new System.Drawing.Size(114, 20);
            this.tbxQuantity.TabIndex = 53;
            // 
            // tbxRetail
            // 
            this.tbxRetail.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRetail.Location = new System.Drawing.Point(493, 40);
            this.tbxRetail.Multiline = true;
            this.tbxRetail.Name = "tbxRetail";
            this.tbxRetail.Size = new System.Drawing.Size(114, 20);
            this.tbxRetail.TabIndex = 52;
            // 
            // tbxPrice
            // 
            this.tbxPrice.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPrice.Location = new System.Drawing.Point(493, 14);
            this.tbxPrice.Multiline = true;
            this.tbxPrice.Name = "tbxPrice";
            this.tbxPrice.Size = new System.Drawing.Size(114, 20);
            this.tbxPrice.TabIndex = 51;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDescription.Location = new System.Drawing.Point(134, 66);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(230, 117);
            this.tbxDescription.TabIndex = 50;
            // 
            // tbxItemName
            // 
            this.tbxItemName.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxItemName.Location = new System.Drawing.Point(134, 40);
            this.tbxItemName.Multiline = true;
            this.tbxItemName.Name = "tbxItemName";
            this.tbxItemName.Size = new System.Drawing.Size(230, 20);
            this.tbxItemName.TabIndex = 48;
            // 
            // tbxInventoryID
            // 
            this.tbxInventoryID.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxInventoryID.Location = new System.Drawing.Point(134, 14);
            this.tbxInventoryID.Multiline = true;
            this.tbxInventoryID.Name = "tbxInventoryID";
            this.tbxInventoryID.ReadOnly = true;
            this.tbxInventoryID.Size = new System.Drawing.Size(51, 20);
            this.tbxInventoryID.TabIndex = 47;
            // 
            // dgvInventory
            // 
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(12, 2);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.Size = new System.Drawing.Size(1079, 325);
            this.dgvInventory.TabIndex = 45;
            // 
            // gbx1
            // 
            this.gbx1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.gbx1.Controls.Add(this.lblState);
            this.gbx1.Controls.Add(this.btnClose);
            this.gbx1.Controls.Add(this.btnHelp);
            this.gbx1.Controls.Add(this.btnAddInventory);
            this.gbx1.Controls.Add(this.btnEditInventory);
            this.gbx1.Location = new System.Drawing.Point(6, 334);
            this.gbx1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbx1.Name = "gbx1";
            this.gbx1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbx1.Size = new System.Drawing.Size(152, 221);
            this.gbx1.TabIndex = 44;
            this.gbx1.TabStop = false;
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.ForeColor = System.Drawing.Color.LightCyan;
            this.lblState.Location = new System.Drawing.Point(12, 17);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(123, 21);
            this.lblState.TabIndex = 52;
            this.lblState.Text = "Editing";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.LightCyan;
            this.btnClose.Location = new System.Drawing.Point(13, 174);
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
            this.btnHelp.Location = new System.Drawing.Point(13, 131);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(122, 35);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnAddInventory
            // 
            this.btnAddInventory.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAddInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInventory.ForeColor = System.Drawing.Color.LightCyan;
            this.btnAddInventory.Location = new System.Drawing.Point(13, 88);
            this.btnAddInventory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddInventory.Name = "btnAddInventory";
            this.btnAddInventory.Size = new System.Drawing.Size(122, 35);
            this.btnAddInventory.TabIndex = 10;
            this.btnAddInventory.Text = "&Add Inventory";
            this.btnAddInventory.UseVisualStyleBackColor = true;
            // 
            // btnEditInventory
            // 
            this.btnEditInventory.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEditInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditInventory.ForeColor = System.Drawing.Color.LightCyan;
            this.btnEditInventory.Location = new System.Drawing.Point(13, 45);
            this.btnEditInventory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditInventory.Name = "btnEditInventory";
            this.btnEditInventory.Size = new System.Drawing.Size(122, 35);
            this.btnEditInventory.TabIndex = 9;
            this.btnEditInventory.Text = "&Edit Inventory";
            this.btnEditInventory.UseVisualStyleBackColor = true;
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1099, 558);
            this.Controls.Add(this.gbx2);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.gbx1);
            this.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AE Sporting Fits | Inventory";
            this.gbx2.ResumeLayout(false);
            this.gbx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxItemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.gbx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx2;
        private System.Windows.Forms.ComboBox cbxTeamID;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.TextBox tbxColor;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.TextBox tbxSize;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.TextBox tbxRestock;
        private System.Windows.Forms.ComboBox cbxDiscontinued;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.PictureBox pbxItemImage;
        private System.Windows.Forms.TextBox tbxQuantity;
        private System.Windows.Forms.TextBox tbxRetail;
        private System.Windows.Forms.TextBox tbxPrice;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.TextBox tbxItemName;
        private System.Windows.Forms.TextBox tbxInventoryID;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.GroupBox gbx1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnAddInventory;
        private System.Windows.Forms.Button btnEditInventory;
    }
}