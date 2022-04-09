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
            public ComboBox cbxTitle, cbxState, cbxSecQuestion1, cbxSecQuestion2, cbxSecQuestion3;

            public TextBox tbxFirstName, tbxMiddleName, tbxLastName, tbxSuffix, tbxAddress1, tbxAddress2, tbxAddress3, tbxCity, tbxZipcode, tbxEmail, tbxPhone1, tbxPhone2, tbxAnswer1, tbxAnswer2, tbxAnswer3, tbxUsername, tbxPassword;
        }

        public struct CheckoutParameters
        {
            public DataGridView dgvCart, dgvInventory;

            public TextBox tbxCardNumber, tbxExpiry, tbxCCV, tbxItems, tbxGross, tbxCode, tbxDiscount, tbxSub, tbxTax, tbxTotal;
        }

    }
}
