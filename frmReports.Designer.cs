
namespace FinalProject
{
    partial class frmReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReports));
            this.gbxInventory = new System.Windows.Forms.GroupBox();
            this.btnPrintFull = new System.Windows.Forms.Button();
            this.btnPrintRestock = new System.Windows.Forms.Button();
            this.btnPrintAvailable = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblState = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.gbxSales = new System.Windows.Forms.GroupBox();
            this.btnPrintSales = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cbxDays = new System.Windows.Forms.ComboBox();
            this.calendarSalesReports = new System.Windows.Forms.MonthCalendar();
            this.gbxInventory.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbxSales.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxInventory
            // 
            this.gbxInventory.Controls.Add(this.btnPrintFull);
            this.gbxInventory.Controls.Add(this.btnPrintRestock);
            this.gbxInventory.Controls.Add(this.btnPrintAvailable);
            this.gbxInventory.Controls.Add(this.lbl2);
            this.gbxInventory.Location = new System.Drawing.Point(2, 281);
            this.gbxInventory.Name = "gbxInventory";
            this.gbxInventory.Size = new System.Drawing.Size(638, 115);
            this.gbxInventory.TabIndex = 2;
            this.gbxInventory.TabStop = false;
            // 
            // btnPrintFull
            // 
            this.btnPrintFull.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintFull.Location = new System.Drawing.Point(491, 53);
            this.btnPrintFull.Name = "btnPrintFull";
            this.btnPrintFull.Size = new System.Drawing.Size(122, 40);
            this.btnPrintFull.TabIndex = 3;
            this.btnPrintFull.Text = "Print &Full Inventory Report";
            this.btnPrintFull.UseVisualStyleBackColor = true;
            this.btnPrintFull.Click += new System.EventHandler(this.btnPrintFull_Click);
            // 
            // btnPrintRestock
            // 
            this.btnPrintRestock.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintRestock.Location = new System.Drawing.Point(258, 53);
            this.btnPrintRestock.Name = "btnPrintRestock";
            this.btnPrintRestock.Size = new System.Drawing.Size(126, 40);
            this.btnPrintRestock.TabIndex = 2;
            this.btnPrintRestock.Text = "Print &Restock Inventory Report";
            this.btnPrintRestock.UseVisualStyleBackColor = true;
            this.btnPrintRestock.Click += new System.EventHandler(this.btnPrintRestock_Click);
            // 
            // btnPrintAvailable
            // 
            this.btnPrintAvailable.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintAvailable.Location = new System.Drawing.Point(35, 53);
            this.btnPrintAvailable.Name = "btnPrintAvailable";
            this.btnPrintAvailable.Size = new System.Drawing.Size(129, 40);
            this.btnPrintAvailable.TabIndex = 1;
            this.btnPrintAvailable.Text = "Print &Available Inventory Report";
            this.btnPrintAvailable.UseVisualStyleBackColor = true;
            this.btnPrintAvailable.Click += new System.EventHandler(this.btnPrintAvailable_Click);
            // 
            // lbl2
            // 
            this.lbl2.BackColor = System.Drawing.Color.Transparent;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl2.Location = new System.Drawing.Point(237, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(159, 41);
            this.lbl2.TabIndex = 0;
            this.lbl2.Text = "Inventory Reports";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox1.Controls.Add(this.lblState);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnHelp);
            this.groupBox1.Location = new System.Drawing.Point(2, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(152, 253);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.ForeColor = System.Drawing.Color.LightCyan;
            this.lblState.Location = new System.Drawing.Point(12, 26);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(123, 21);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "Reports";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.LightCyan;
            this.btnClose.Location = new System.Drawing.Point(16, 204);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.ForeColor = System.Drawing.Color.LightCyan;
            this.btnHelp.Location = new System.Drawing.Point(16, 145);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(122, 35);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // gbxSales
            // 
            this.gbxSales.Controls.Add(this.btnPrintSales);
            this.gbxSales.Controls.Add(this.lbl1);
            this.gbxSales.Controls.Add(this.cbxDays);
            this.gbxSales.Controls.Add(this.calendarSalesReports);
            this.gbxSales.Location = new System.Drawing.Point(160, 12);
            this.gbxSales.Name = "gbxSales";
            this.gbxSales.Size = new System.Drawing.Size(480, 263);
            this.gbxSales.TabIndex = 1;
            this.gbxSales.TabStop = false;
            // 
            // btnPrintSales
            // 
            this.btnPrintSales.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintSales.Location = new System.Drawing.Point(333, 217);
            this.btnPrintSales.Name = "btnPrintSales";
            this.btnPrintSales.Size = new System.Drawing.Size(122, 40);
            this.btnPrintSales.TabIndex = 3;
            this.btnPrintSales.Text = "Print &Sales Report";
            this.btnPrintSales.UseVisualStyleBackColor = true;
            this.btnPrintSales.Click += new System.EventHandler(this.btnPrintSales_Click);
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl1.Location = new System.Drawing.Point(166, 8);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(136, 29);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Sales Reports";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxDays
            // 
            this.cbxDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDays.FormattingEnabled = true;
            this.cbxDays.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.cbxDays.Location = new System.Drawing.Point(10, 228);
            this.cbxDays.Name = "cbxDays";
            this.cbxDays.Size = new System.Drawing.Size(150, 24);
            this.cbxDays.TabIndex = 2;
            this.cbxDays.SelectedIndexChanged += new System.EventHandler(this.cbxDays_SelectedIndexChanged);
            // 
            // calendarSalesReports
            // 
            this.calendarSalesReports.CalendarDimensions = new System.Drawing.Size(2, 1);
            this.calendarSalesReports.Location = new System.Drawing.Point(10, 46);
            this.calendarSalesReports.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.calendarSalesReports.Name = "calendarSalesReports";
            this.calendarSalesReports.TabIndex = 1;
            this.calendarSalesReports.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendarSalesReports_DateSelected);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(644, 400);
            this.Controls.Add(this.gbxInventory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxSales);
            this.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AE Sporting Fits | Reports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.gbxInventory.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbxSales.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxInventory;
        private System.Windows.Forms.Button btnPrintFull;
        private System.Windows.Forms.Button btnPrintRestock;
        private System.Windows.Forms.Button btnPrintAvailable;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.GroupBox gbxSales;
        private System.Windows.Forms.Button btnPrintSales;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cbxDays;
        private System.Windows.Forms.MonthCalendar calendarSalesReports;
    }
}