//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
// Application used to browse and buy jerseys.
// Class Purpose:
// This class is used for holding parameters to avoid excessive overloaded methods.
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    class clsParameters
    {
        //structures for holding parameters
        public struct SignupParameters
        {
            public ComboBox cbxTitleP, cbxStateP, cbxSecQuestion1P, cbxSecQuestion2P, cbxSecQuestion3P, cbxDeletedP;

            public TextBox tbxPersonIDP, tbxFirstNameP, tbxMiddleNameP, tbxLastNameP, tbxSuffixP, tbxAddress1P, tbxAddress2P, tbxAddress3P, tbxCityP, tbxZipcodeP, tbxEmailP, tbxPhone1P, tbxPhone2P, tbxAnswer1P, tbxAnswer2P, tbxAnswer3P, tbxUsernameP, tbxPasswordP;
        }

        public struct CheckoutParameters
        {
            public DataGridView dgvCartP, dgvInventoryP;

            public TextBox tbxCardNumberP, tbxExpiryP, tbxCCVP, tbxItemsP, tbxGrossP, tbxCodeP, tbxDiscountP, tbxSubP, tbxTaxP, tbxTotalP;
        }

        public struct InventoryParameters
        {
            public ComboBox cbxDiscontinuedP, cbxTeamIDP;

            public PictureBox pbxItemImageP;

            public TextBox tbxInventoryIDP, tbxItemNameP, tbxItemDescriptionP, tbxRetailPriceP, tbxCostP, tbxQuantityP, tbxSizeP, tbxColorP, tbxRestockP;
        }

        public struct DiscountParameters
        {
            public ComboBox cbxLevelP, cbxTypeP;

            public TextBox tbxDiscountIDP, tbxDiscountCodeP, tbxDescriptionP, tbxInventoryIDP, tbxPercentageP, tbxDollarP, tbxStartP, tbxExpirationP;
        }
    }
}
