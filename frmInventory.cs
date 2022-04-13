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
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            //call method to show inventory
            clsSQL.InitializeManagerInventoryView(dgvInventory);
            //call method to fill combos
            clsSQL.FillTeamIDCombo(cbxTeamID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditInventory_Click(object sender, EventArgs e)
        {
            //set form ready to edit
            lblState.Text = "Editing";
            btnEdit.Visible = true;
            btnAdd.Visible = false;

            //set fields into parameters
            clsParameters.InventoryParameters inventoryParameters = new clsParameters.InventoryParameters()
            {
                tbxInventoryIDP = tbxInventoryID,
                tbxColorP = tbxColor,
                tbxItemNameP = tbxItemName,
                tbxCostP = tbxPrice,
                tbxRetailPriceP = tbxRetail,
                tbxItemDescriptionP = tbxDescription,
                tbxQuantityP = tbxQuantity,
                tbxRestockP = tbxRestock,
                tbxSizeP = tbxSize,
                cbxDiscontinuedP = cbxDiscontinued,
                cbxTeamIDP = cbxTeamID,
                pbxItemImageP = pbxItemImage
            };

            //clear text boxes
            clsManager.ClearInventoryFields(inventoryParameters);
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            //set form ready to add
            lblState.Text = "Adding";
            btnEdit.Visible = false;
            btnAdd.Visible = true;

            //set fields into parameters
            clsParameters.InventoryParameters inventoryParameters = new clsParameters.InventoryParameters()
            {
                tbxInventoryIDP = tbxInventoryID,
                tbxColorP = tbxColor,
                tbxItemNameP = tbxItemName,
                tbxCostP = tbxPrice,
                tbxRetailPriceP = tbxRetail,
                tbxItemDescriptionP = tbxDescription,
                tbxQuantityP = tbxQuantity,
                tbxRestockP = tbxRestock,
                tbxSizeP = tbxSize,
                cbxDiscontinuedP = cbxDiscontinued,
                cbxTeamIDP = cbxTeamID,
                pbxItemImageP = pbxItemImage
            };

            //clear text boxes
            clsManager.ClearInventoryFields(inventoryParameters);
        }

        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            //set fields into parameters
            clsParameters.InventoryParameters inventoryParameters = new clsParameters.InventoryParameters()
            {
                tbxInventoryIDP = tbxInventoryID,
                tbxColorP = tbxColor,
                tbxItemNameP = tbxItemName,
                tbxCostP = tbxPrice,
                tbxRetailPriceP = tbxRetail,
                tbxItemDescriptionP = tbxDescription,
                tbxQuantityP = tbxQuantity,
                tbxRestockP = tbxRestock,
                tbxSizeP = tbxSize,
                cbxDiscontinuedP = cbxDiscontinued,
                cbxTeamIDP = cbxTeamID,
                pbxItemImageP = pbxItemImage
            };

            //call method to update fields
            clsManager.UpdateFieldsInventory(dgvInventory, inventoryParameters, lblState);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //set fields into parameters
            clsParameters.InventoryParameters inventoryParameters = new clsParameters.InventoryParameters()
            {
                tbxInventoryIDP = tbxInventoryID,
                tbxColorP = tbxColor,
                tbxItemNameP = tbxItemName,
                tbxCostP = tbxPrice,
                tbxRetailPriceP = tbxRetail,
                tbxItemDescriptionP = tbxDescription,
                tbxQuantityP = tbxQuantity,
                tbxRestockP = tbxRestock,
                tbxSizeP = tbxSize,
                cbxDiscontinuedP = cbxDiscontinued,
                cbxTeamIDP = cbxTeamID,
                pbxItemImageP = pbxItemImage
            };

            //call method to add to inventory
            clsSQL.AddInventory(inventoryParameters);
            //refresh view
            dgvInventory.DataSource = null;
            clsSQL.InitializeManagerInventoryView(dgvInventory);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //set fields into parameters
            clsParameters.InventoryParameters inventoryParameters = new clsParameters.InventoryParameters()
            {
                tbxInventoryIDP = tbxInventoryID,
                tbxColorP = tbxColor,
                tbxItemNameP = tbxItemName,
                tbxCostP = tbxPrice,
                tbxRetailPriceP = tbxRetail,
                tbxItemDescriptionP = tbxDescription,
                tbxQuantityP = tbxQuantity,
                tbxRestockP = tbxRestock,
                tbxSizeP = tbxSize,
                cbxDiscontinuedP = cbxDiscontinued,
                cbxTeamIDP = cbxTeamID,
                pbxItemImageP = pbxItemImage
            };

            //call method to apply edit
            clsSQL.UpdateInventory(inventoryParameters, dgvInventory);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //call method to select image
            clsManager.BrowseImage(pbxItemImage);
        }
    }
}
