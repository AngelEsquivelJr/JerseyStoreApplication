//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
// Application used to browse and buy jerseys.
// Form Purpose:
// This form is the main form to the application.
// 


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
    public partial class frmMain : Form
    {        
        public frmMain()
        {
            InitializeComponent();

            //set up cart data grid view
            dgvCart.DataSource = clsCartData.cartItems;        
        }        

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            //login form
            frmLogon frmLogin = new frmLogon();

            if (string.IsNullOrEmpty(tbxTotal.Text) || string.IsNullOrEmpty(tbxCCV.Text))
            {
                //asks user for confirmation of exit and returns to previous form
                DialogResult drResult = MessageBox.Show("Are you sure you want to exit? ",
                  "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (drResult)
                {
                    case DialogResult.Yes:
                        frmLogin.Show();
                        //reset logon name
                        clsSQL.strLogonName = "Guest";
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                }
            }
            else
            {
                //return to login
                frmLogin.Show();
                //reset logon name
                clsSQL.strLogonName = "Guest";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close form
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //call method to set up data grid view
            clsSQL.InitializeInventoryView(dgvInventory);
            //call method to fill category combo and size combo
            clsSQL.FillCategoryCombo(cbxCategories);
            clsSQL.FillSizeCombo(cbxSizes);
            //clear cart
            clsSQL.ClearCart(dgvCart);

            //check if guest
            if (clsSQL.strLogonName == "Guest")
            {
                //set form for guest
                btnCheck.Enabled = false;
                btnAddtoCart.Enabled = false;
                btnDiscountCode.Enabled = false;
                lblIntroDesc.Text = "Please login to make an order.";
                //set label
                lblIntro.Text = "Welcome " + clsSQL.strLogonName + "!";
            }
            else
            {
                //set labels
                lblIntroDesc.Text = " ";
                lblIntro.Text = "Welcome " + clsSQL.strLogonName + "!";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clear search text box and categories combo box
            tbxSearch.Clear();
            cbxCategories.SelectedIndex = 0;
            cbxSizes.SelectedIndex = 0;
            //set focus
            tbxSearch.Focus();
        }

        private void btnClearBilling_Click(object sender, EventArgs e)
        {
            //clear billing text boxes
            tbxCardNumber.Clear();
            tbxExpiration.Clear();
            tbxCCV.Clear();
            //set focus
            tbxCardNumber.Focus();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            //clear cart
            clsSQL.ClearCart(dgvCart);
            //clear text boxes
            tbxItems.Clear();
            tbxGross.Clear();
            tbxSub.Clear();
            tbxTax.Clear();
            tbxTotal.Clear();
            //set focus
            btnAddtoCart.Focus();
        }

        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            //call method to set up combos
            clsSQL.FillQuantityCombo(dgvInventory, cbxQuantity);            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {            
            //call method for searching
            clsSQL.SearchInventory(dgvInventory, tbxSearch, cbxSizes);
        }

        private void tbxCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //method for allowed keys
            clsValidation.CardAllowedKeys(e);
        }

        private void tbxExpiration_KeyPress(object sender, KeyPressEventArgs e)
        {
            //method for allowed keys
            clsValidation.ExpirationAllowedKeys(e);
        }

        private void tbxCCV_KeyPress(object sender, KeyPressEventArgs e)
        {
            //method for allowed keys
            clsValidation.CCVAllowedKeys(e);
        }

        private void tbxCardNumber_Click(object sender, EventArgs e)
        {
            //clears card number text
            if (tbxCardNumber.Text == "1234-5678-1234-5678")
            {
                tbxCardNumber.Clear();
                tbxCardNumber.ForeColor = Color.Black;
            }
        }

        private void tbxExpiration_Click(object sender, EventArgs e)
        {
            //clears expiration text
            if (tbxExpiration.Text == "12/2023")
            {
                tbxExpiration.Clear();
                tbxExpiration.ForeColor = Color.Black;
            }
        }

        private void tbxCCV_Click(object sender, EventArgs e)
        {
            //clears ccv text
            if (tbxCCV.Text == "123")
            {
                tbxCCV.Clear();
                tbxCCV.ForeColor = Color.Black;
            }
        }

        private void tbxCardNumber_TextChanged(object sender, EventArgs e)
        {
            //make text proper color
            tbxCardNumber.ForeColor = Color.Black;
        }

        private void tbxExpiration_TextChanged(object sender, EventArgs e)
        {
            //make text proper color
            tbxExpiration.ForeColor = Color.Black;
        }

        private void tbxCCV_TextChanged(object sender, EventArgs e)
        {
            //make text proper color
            tbxCCV.ForeColor = Color.Black;
        }        

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            clsSQL.AddCartView(dgvInventory, dgvCart, cbxQuantity, tbxItems, tbxGross, tbxSub, tbxDiscount, tbxTax, tbxTotal);
        }

        private void cbxSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //call method for filtering view
            clsSQL.FilterInventorySize(dgvInventory, cbxSizes, cbxCategories, tbxSearch);
        }

        private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //call method for filtering view
            clsSQL.FilterInventoryCategory(dgvInventory, cbxCategories, cbxSizes, tbxSearch);
        }

        private void btnCartAdd_Click(object sender, EventArgs e)
        {
            //set amount for count
            int.TryParse(btnRemove.Text, out int intCount);
            //add to count and change remove button
            intCount++;
            btnRemove.Text = intCount.ToString();
        }

        private void btnCartSubtract_Click(object sender, EventArgs e)
        {
            //set amount for count
            int.TryParse(btnRemove.Text, out int intCount);
            //subtract to count and change remove button
            if (intCount > 0)
            {
                intCount--;
            }
            btnRemove.Text = intCount.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //call method for removing from cart
            clsSQL.RemoveCart(dgvCart, btnRemove, tbxItems, tbxGross, tbxSub, tbxDiscount, tbxTax, tbxTotal);
        }

        private void btnDiscountCode_Click(object sender, EventArgs e)
        {
            //call method to apply discount
            clsSQL.ApplyDiscount(dgvCart, tbxGross, tbxCode, tbxDiscount, tbxSub, tbxTax, tbxTotal);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //call method to checkout
            clsSQL.CheckOut(dgvCart, tbxGross, tbxItems, tbxDiscount, tbxTax, tbxTotal);
        }
    }
}
