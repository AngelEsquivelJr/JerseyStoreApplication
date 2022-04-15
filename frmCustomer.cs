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
                tbxPersonIDP = tbxPersonID,
                cbxTitleP = cbxTitle,
                tbxFirstNameP = tbxFirstName,
                tbxMiddleNameP = tbxMiddleName,
                tbxLastNameP = tbxLastName,
                tbxSuffixP = tbxSuffix,
                tbxCityP = tbxCity,
                tbxAddress1P = tbxAddress1,
                tbxAddress2P = tbxAddress2,
                tbxAddress3P = tbxAddress3,
                tbxPhone1P = tbxPrimary,
                tbxPhone2P = tbxSecondary,
                cbxStateP = cbxState,
                tbxEmailP = tbxEmail,
                tbxZipcodeP = tbxZipcode,
                cbxDeletedP = cbxDeleted,
            };

            if (dgvCustomers.SelectedCells.Count > 0)
            {                
                //check required fields
                if (clsValidation.ValidateTwo(signupParameters))
                {
                    //call method to edit customers
                    clsSQL.UpdateCustomers(signupParameters);
                    //refresh view
                    dgvCustomers.DataSource = null;
                    clsSQL.InitializeCustomerView(dgvCustomers);
                }
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
                        clsSQL.UpdateToManager(tbxPersonID);
                        //refresh  view
                        dgvCustomers.DataSource = null;
                        clsSQL.InitializeCustomerView(dgvCustomers);
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

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            //set up parameters
            clsParameters.SignupParameters customerParameters = new clsParameters.SignupParameters
            {
                tbxPersonIDP = tbxPersonID,
                cbxTitleP = cbxTitle,
                tbxFirstNameP = tbxFirstName,
                tbxMiddleNameP = tbxMiddleName,
                tbxLastNameP = tbxLastName,
                tbxSuffixP = tbxSuffix,
                tbxCityP = tbxCity,
                tbxAddress1P = tbxAddress1,
                tbxAddress2P = tbxAddress2,
                tbxAddress3P = tbxAddress3,
                tbxPhone1P = tbxPrimary,
                tbxPhone2P = tbxSecondary,
                cbxStateP = cbxState,
                tbxEmailP = tbxEmail,
                tbxZipcodeP = tbxZipcode,
                cbxDeletedP = cbxDeleted,
            };

            //prevent self deletion
            if (clsSQL.strName == tbxFirstName.Text + " " + tbxLastName.Text)
            {
                cbxDeleted.Enabled = false;
            }
            else
            {
                cbxDeleted.Enabled = true;
            }
            //call methods for fields
            clsManager.UpdateFieldsCustomer(dgvCustomers,customerParameters);
        }

        private void cbxFilterTitle_SelectedIndexChanged(object sender, EventArgs e)
        {            
            //call method for filter
            clsManager.FilterCustomerPosition(dgvCustomers, cbxFilterTitle);
        }

        private void tbxAddress2_KeyUp(object sender, KeyEventArgs e)
        {
            //if statement to allow access to other textboxes
            if (string.IsNullOrEmpty(tbxAddress2.Text) == false)
            {
                tbxAddress3.ReadOnly = false;
            }
            else
            {
                tbxAddress3.ReadOnly = true;
                tbxAddress3.Clear();
            }
        }

        private void tbxAddress1_KeyUp(object sender, KeyEventArgs e)
        {
            //if statement to allow access to other textboxes
            if (string.IsNullOrEmpty(tbxAddress1.Text) == false)
            {
                tbxAddress2.ReadOnly = false;
            }
            else
            {
                tbxAddress2.ReadOnly = true;
                tbxAddress3.ReadOnly = true;
                tbxAddress2.Clear();
                tbxAddress3.Clear();
            }
        }

        private void tbxPrimary_KeyUp(object sender, KeyEventArgs e)
        {
            //if statement to allow access to other textboxes
            if (string.IsNullOrEmpty(tbxPrimary.Text) == false)
            {
                tbxSecondary.ReadOnly = false;
            }
            else
            {
                tbxPrimary.ReadOnly = true;
                tbxSecondary.Clear();
            }
        }

        private void tbxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.NameAllowedKeys(e);
        }

        private void tbxMiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.NameAllowedKeys(e);
        }

        private void tbxLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.NameAllowedKeys(e);
        }

        private void tbxSuffix_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.NameAllowedKeys(e);
        }

        private void tbxAddress1_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AddressAllowedKeys(e);
        }

        private void tbxAddress2_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AddressAllowedKeys(e);
        }

        private void tbxAddress3_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.AddressAllowedKeys(e);
        }

        private void tbxCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.CityAllowedKeys(e);
        }

        private void tbxPrimary_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.PhoneAllowedKeys(e);
        }

        private void tbxSecondary_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidation.PhoneAllowedKeys(e);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmSignUp frmSign = new frmSignUp();
            frmSign.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvCustomers.DataSource = null;
            clsSQL.InitializeCustomerView(dgvCustomers);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            //call method to get info
            if (clsManager.GetSelectedCustomerInfo(dgvCustomers, tbxFirstName, tbxLastName, tbxPersonID))
            {
                frmPastTransactions frmPast = new frmPastTransactions();
                frmPast.ShowDialog();
            }
        }

        private void btnCustomerLogin_Click(object sender, EventArgs e)
        {
            //call method to get info
            if(clsManager.GetSelectedCustomerInfo(dgvCustomers, tbxFirstName, tbxLastName, tbxPersonID))
            {
                frmMain frmMain = new frmMain();
                frmMain.ShowDialog();
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //prevent self deletion
            if (clsSQL.strName == tbxFirstName.Text + " " + tbxLastName.Text)
            {
                cbxDeleted.Enabled = false;
            }
            else
            {
                cbxDeleted.Enabled = true;
            }
        }

        private void dgvCustomers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //prevent self deletion
            if (clsSQL.strName == tbxFirstName.Text + " " + tbxLastName.Text)
            {
                cbxDeleted.Enabled = false;
            }
            else
            {
                cbxDeleted.Enabled = true;
            }
        }
    }
}
