using System;
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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            //call method for data grid view
            clsSQL.InitializeCustomerView(dgvCustomers);
            //call method for combos
            clsSQL.FillPositionTitleCombo(cbxFilterTitle);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCustomerInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select a customer to edit. Once your changes are complete, click 'Apply Edit' to apply changes.",
                  "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnEdit.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //set up parameters
            clsParameters.SignupParameters signupParameters = new clsParameters.SignupParameters
            {
                tbxPersonID = tbxPersonID,
                cbxTitle = cbxTitle,
                tbxFirstName = tbxFirstName,
                tbxMiddleName = tbxMiddleName,
                tbxLastName = tbxLastName,
                tbxSuffix = tbxSuffix,
                tbxCity = tbxCity,
                tbxAddress1 = tbxAddress1,
                tbxAddress2 = tbxAddress2,
                tbxAddress3 = tbxAddress3,
                tbxPhone1 = tbxPrimary,
                tbxPhone2 = tbxSecondary,
                cbxState = cbxState,
                tbxEmail = tbxEmail,
                tbxZipcode = tbxZipcode,
                cbxDeleted = cbxDeleted,
            };

            if (dgvCustomers.SelectedCells.Count > 0)
            {
                //call method to edit customers
                //clsSQL.UpdateCustomers(signupParameters);
            }
            else
            {
                MessageBox.Show("Please Select a customer to edit. Try Again.",
                  "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddManager_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedCells.Count > 0)
            {
                //asks user for confirmation of promotion
                DialogResult drResult = MessageBox.Show("Are you sure you want to promote this customer to a manager? ",
                      "Promotion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (drResult)
                {
                    case DialogResult.Yes:
                        //call method to update customer to manager
                        //clsSQL.UpdateToManager(tbxPersonID);
                        break;
                    case DialogResult.No:
                        //set focus to button
                        btnAddManager.Focus();
                        break;
                }                
            }
            else
            {
                MessageBox.Show("Please Select a customer to promote to manager. Try Again.",
                  "Promote", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clear text boxes
            tbxFirstSearch.Clear();
            tbxLastSearch.Clear();
            tbxEmailSearch.Clear();
            tbxPhoneSearch.Clear();
            tbxZipcodeSearch.Clear();
            tbxCitySearch.Clear();
            //make filter be empty
            (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = "";
            tbxFirstSearch.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //call method to search for customer
            clsManager.SearchCustomers(dgvCustomers, tbxFirstSearch, tbxLastSearch, tbxEmailSearch, tbxCitySearch, tbxZipcodeSearch, tbxPhoneSearch);
        }
    }
}
