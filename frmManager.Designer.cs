﻿
namespace FinalProject
{
    partial class frmManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManager));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblManager = new System.Windows.Forms.Label();
            this.lblRestock = new System.Windows.Forms.Label();
            this.dgvRestock = new System.Windows.Forms.DataGridView();
            this.gbxOne = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnDiscounts = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestock)).BeginInit();
            this.gbxOne.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(401, 377);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 33);
            this.btnRefresh.TabIndex = 71;
            this.btnRefresh.Text = "Re&fresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // lblManager
            // 
            this.lblManager.BackColor = System.Drawing.Color.Transparent;
            this.lblManager.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManager.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblManager.Location = new System.Drawing.Point(-3, 9);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(136, 49);
            this.lblManager.TabIndex = 70;
            this.lblManager.Text = "Manager: ";
            this.lblManager.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRestock
            // 
            this.lblRestock.BackColor = System.Drawing.Color.Transparent;
            this.lblRestock.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestock.ForeColor = System.Drawing.Color.Red;
            this.lblRestock.Location = new System.Drawing.Point(375, 19);
            this.lblRestock.Name = "lblRestock";
            this.lblRestock.Size = new System.Drawing.Size(136, 49);
            this.lblRestock.TabIndex = 69;
            this.lblRestock.Text = "Item(s) need to be restocked!! ";
            this.lblRestock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRestock.Visible = false;
            // 
            // dgvRestock
            // 
            this.dgvRestock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRestock.Location = new System.Drawing.Point(324, 71);
            this.dgvRestock.Name = "dgvRestock";
            this.dgvRestock.Size = new System.Drawing.Size(240, 294);
            this.dgvRestock.TabIndex = 68;
            // 
            // gbxOne
            // 
            this.gbxOne.BackColor = System.Drawing.Color.DarkSlateGray;
            this.gbxOne.Controls.Add(this.btnClose);
            this.gbxOne.Controls.Add(this.btnInventory);
            this.gbxOne.Controls.Add(this.btnReports);
            this.gbxOne.Controls.Add(this.btnDiscounts);
            this.gbxOne.Controls.Add(this.btnCustomer);
            this.gbxOne.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxOne.Location = new System.Drawing.Point(1, 71);
            this.gbxOne.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbxOne.Name = "gbxOne";
            this.gbxOne.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbxOne.Size = new System.Drawing.Size(317, 339);
            this.gbxOne.TabIndex = 67;
            this.gbxOne.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.LightCyan;
            this.btnClose.Location = new System.Drawing.Point(90, 231);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 63);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnInventory
            // 
            this.btnInventory.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.ForeColor = System.Drawing.Color.LightCyan;
            this.btnInventory.Location = new System.Drawing.Point(23, 43);
            this.btnInventory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(136, 63);
            this.btnInventory.TabIndex = 1;
            this.btnInventory.Text = "&Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            this.btnReports.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.ForeColor = System.Drawing.Color.LightCyan;
            this.btnReports.Location = new System.Drawing.Point(23, 130);
            this.btnReports.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(136, 63);
            this.btnReports.TabIndex = 4;
            this.btnReports.Text = "&Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnDiscounts
            // 
            this.btnDiscounts.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDiscounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscounts.ForeColor = System.Drawing.Color.LightCyan;
            this.btnDiscounts.Location = new System.Drawing.Point(159, 130);
            this.btnDiscounts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDiscounts.Name = "btnDiscounts";
            this.btnDiscounts.Size = new System.Drawing.Size(136, 63);
            this.btnDiscounts.TabIndex = 3;
            this.btnDiscounts.Text = "Edit &Discounts";
            this.btnDiscounts.UseVisualStyleBackColor = true;
            // 
            // btnCustomer
            // 
            this.btnCustomer.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.ForeColor = System.Drawing.Color.LightCyan;
            this.btnCustomer.Location = new System.Drawing.Point(159, 43);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(136, 63);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "C&ustomers";
            this.btnCustomer.UseVisualStyleBackColor = true;
            // 
            // frmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(570, 410);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblManager);
            this.Controls.Add(this.lblRestock);
            this.Controls.Add(this.dgvRestock);
            this.Controls.Add(this.gbxOne);
            this.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AE Sporting Fits | Manager Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestock)).EndInit();
            this.gbxOne.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.Label lblRestock;
        private System.Windows.Forms.DataGridView dgvRestock;
        private System.Windows.Forms.GroupBox gbxOne;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnDiscounts;
        private System.Windows.Forms.Button btnCustomer;
    }
}