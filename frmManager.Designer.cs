
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManager));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblManager = new System.Windows.Forms.Label();
            this.lblRestock = new System.Windows.Forms.Label();
            this.dgvRestock = new System.Windows.Forms.DataGridView();
            this.gbxOne = new System.Windows.Forms.GroupBox();
            this.btnHelp = new System.Windows.Forms.Button();
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
            this.btnRefresh.Location = new System.Drawing.Point(483, 377);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 33);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Re&fresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.BackColor = System.Drawing.Color.Transparent;
            this.lblManager.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManager.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblManager.Location = new System.Drawing.Point(12, 9);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(108, 23);
            this.lblManager.TabIndex = 0;
            this.lblManager.Text = "Manager: ";
            this.lblManager.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRestock
            // 
            this.lblRestock.BackColor = System.Drawing.Color.Transparent;
            this.lblRestock.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestock.ForeColor = System.Drawing.Color.Red;
            this.lblRestock.Location = new System.Drawing.Point(454, 19);
            this.lblRestock.Name = "lblRestock";
            this.lblRestock.Size = new System.Drawing.Size(148, 49);
            this.lblRestock.TabIndex = 1;
            this.lblRestock.Text = "Item(s) that need to be restocked!! ";
            this.lblRestock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRestock.Visible = false;
            // 
            // dgvRestock
            // 
            this.dgvRestock.AllowUserToAddRows = false;
            this.dgvRestock.AllowUserToDeleteRows = false;
            this.dgvRestock.AllowUserToResizeColumns = false;
            this.dgvRestock.AllowUserToResizeRows = false;
            this.dgvRestock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRestock.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRestock.Location = new System.Drawing.Point(324, 71);
            this.dgvRestock.MultiSelect = false;
            this.dgvRestock.Name = "dgvRestock";
            this.dgvRestock.ReadOnly = true;
            this.dgvRestock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRestock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRestock.Size = new System.Drawing.Size(403, 294);
            this.dgvRestock.TabIndex = 3;
            // 
            // gbxOne
            // 
            this.gbxOne.BackColor = System.Drawing.Color.DarkSlateGray;
            this.gbxOne.Controls.Add(this.btnHelp);
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
            this.gbxOne.TabIndex = 2;
            this.gbxOne.TabStop = false;
            // 
            // btnHelp
            // 
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.ForeColor = System.Drawing.Color.LightCyan;
            this.btnHelp.Location = new System.Drawing.Point(23, 231);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(136, 63);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.LightCyan;
            this.btnClose.Location = new System.Drawing.Point(159, 231);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 63);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.btnInventory.TabIndex = 0;
            this.btnInventory.Text = "&Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnReports
            // 
            this.btnReports.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.ForeColor = System.Drawing.Color.LightCyan;
            this.btnReports.Location = new System.Drawing.Point(23, 139);
            this.btnReports.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(136, 63);
            this.btnReports.TabIndex = 2;
            this.btnReports.Text = "&Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnDiscounts
            // 
            this.btnDiscounts.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDiscounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscounts.ForeColor = System.Drawing.Color.LightCyan;
            this.btnDiscounts.Location = new System.Drawing.Point(159, 139);
            this.btnDiscounts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDiscounts.Name = "btnDiscounts";
            this.btnDiscounts.Size = new System.Drawing.Size(136, 63);
            this.btnDiscounts.TabIndex = 3;
            this.btnDiscounts.Text = "Edit &Discounts";
            this.btnDiscounts.UseVisualStyleBackColor = true;
            this.btnDiscounts.Click += new System.EventHandler(this.btnDiscounts_Click);
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
            this.btnCustomer.TabIndex = 1;
            this.btnCustomer.Text = "C&ustomers";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // frmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(734, 410);
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
            this.Text = "Manager Dashboard | AE Sporting Fits";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManager_FormClosing);
            this.Load += new System.EventHandler(this.frmManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestock)).EndInit();
            this.gbxOne.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnHelp;
    }
}