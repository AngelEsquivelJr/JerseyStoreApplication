﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmSignUp : Form
    {
        frmLogon frmLogin = new frmLogon();

        public frmSignUp()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //closes current form
            this.Close();
        }

        private void frmSignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            //asks user for confirmation of exit and returns to previous form
            e.Cancel = MessageBox.Show("Are you sure you want to exit this form? ",
              "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            frmLogin.Show();
        }
    }
}
