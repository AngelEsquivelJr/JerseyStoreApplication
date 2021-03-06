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
    public partial class frmDiscount : Form
    {
        public frmDiscount()
        {
            InitializeComponent();
        }

        private void frmDiscount_Load(object sender, EventArgs e)
        {
            //call method to initialize discount view
            clsSQL.InitializeDiscountsView(dgvDiscounts);
            clsSQL.FillItemsCombo(cbxItems);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditDiscount_Click(object sender, EventArgs e)
        {
            //set form ready to edit
            lblState.Text = "Editing";
            clsParameters.DiscountParameters discountParameters = new clsParameters.DiscountParameters()
            {
                tbxDiscountIDP = tbxDiscountID,
                tbxDiscountCodeP = tbxDiscountCode,
                cbxLevelP = cbxLevel,
                cbxItems = cbxItems,
                tbxDescriptionP = tbxDescription,
                tbxDollarP = tbxDollarAmount,
                cbxTypeP = cbxType,
                tbxPercentageP = tbxPercentage,
                tbxStartP = tbxStart,
                tbxExpirationP = tbxExpiration,
                tbxInventoryIDP = tbxInventoryID,
            };

            clsManager.UpdateFieldsDiscount(dgvDiscounts, discountParameters, lblState);            
            btnEdit.Visible = true;
            btnAdd.Visible = false;
            tbxDiscountCode.Focus();
        }

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            //set form ready to add
            lblState.Text = "Adding";
            tbxDiscountCode.Clear();
            tbxDescription.Clear();
            tbxInventoryID.Clear();
            tbxPercentage.Clear();
            tbxDollarAmount.Clear();
            tbxStart.Clear();
            tbxExpiration.Clear();
            btnEdit.Visible = false;
            btnAdd.Visible = true;
            tbxDiscountID.Clear();
            tbxDiscountCode.Focus();
        }

        private void dgvDiscounts_SelectionChanged(object sender, EventArgs e)
        {
            clsParameters.DiscountParameters discountParameters = new clsParameters.DiscountParameters()
            {
                tbxDiscountIDP = tbxDiscountID,
                tbxDiscountCodeP = tbxDiscountCode,
                cbxLevelP = cbxLevel,
                tbxDescriptionP = tbxDescription,
                tbxDollarP = tbxDollarAmount,
                cbxTypeP = cbxType,
                cbxItems = cbxItems,
                tbxPercentageP = tbxPercentage,
                tbxStartP = tbxStart,
                tbxExpirationP = tbxExpiration,
                tbxInventoryIDP = tbxInventoryID,
            };

            //call method to update fields
            clsManager.UpdateFieldsDiscount(dgvDiscounts, discountParameters, lblState);
        }

        private void cbxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxLevel.SelectedIndex == 0)
            {
                cbxItems.Enabled = true;
            }
            else
            {
                cbxItems.Enabled = false;
                cbxItems.SelectedIndex = 0;
                tbxInventoryID.ReadOnly = true;
                tbxInventoryID.Clear();
            }
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxType.SelectedIndex == 0)
            {
                tbxPercentage.ReadOnly = false;
                tbxDollarAmount.ReadOnly = true;
                tbxDollarAmount.Clear();
            }
            else
            {
                tbxPercentage.ReadOnly = true;
                tbxDollarAmount.ReadOnly = false;
                tbxPercentage.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsParameters.DiscountParameters discountParameters = new clsParameters.DiscountParameters()
            {
                tbxDiscountIDP = tbxDiscountID,
                tbxDiscountCodeP = tbxDiscountCode,
                cbxLevelP = cbxLevel,
                tbxDescriptionP = tbxDescription,
                tbxDollarP = tbxDollarAmount,
                cbxTypeP = cbxType,
                tbxPercentageP = tbxPercentage,
                tbxStartP = tbxStart,
                tbxExpirationP = tbxExpiration,
                tbxInventoryIDP = tbxInventoryID,
            };

            //call method to add discount
            if(clsSQL.AddDiscounts(discountParameters))
            {
                //refresh view
                dgvDiscounts.DataSource = null;
                clsSQL.InitializeDiscountsView(dgvDiscounts);
            }            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            clsParameters.DiscountParameters discountParameters = new clsParameters.DiscountParameters()
            {
                tbxDiscountIDP = tbxDiscountID,
                tbxDiscountCodeP = tbxDiscountCode,
                cbxLevelP = cbxLevel,
                tbxDescriptionP = tbxDescription,
                tbxDollarP = tbxDollarAmount,
                cbxTypeP = cbxType,
                tbxPercentageP = tbxPercentage,
                tbxStartP = tbxStart,
                tbxExpirationP = tbxExpiration,
                tbxInventoryIDP = tbxInventoryID,
            };

            //call method to edit discounts
            if(clsSQL.UpdateDiscounts(discountParameters))
            {
                //refresh view
                dgvDiscounts.DataSource = null;
                clsSQL.InitializeDiscountsView(dgvDiscounts);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //help file
            clsHelp.OpenHelp("DiscountHelp.pdf");
        }

        private void cbxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxItems.SelectedIndex > 0)
            {
                tbxInventoryID.Text = cbxItems.SelectedValue.ToString();
            }
        }
    }
}
