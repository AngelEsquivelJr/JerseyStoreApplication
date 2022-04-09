//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
// Application used to browse and buy jerseys.
// Class Purpose:
// This class is used to fill the cart data grid view.
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class clsCartItems
    {
        //class vars
        private string strItem, strSize, strTotal, strPrice;
        private int intQuantity;

        //class items
        public int Quantity
        {
            get => intQuantity;
            set { intQuantity = value;}
        }
        public string Name 
        {
            get => strItem;
            set { strItem = value;}
        }
        public string Size
        {
            get => strSize;
            set { strSize = value; }
        }
        public string Price
        {
            get => strPrice;
            set { strPrice = value; }
        }
        public string Total
        {
            get => strTotal;
            set { strTotal = value;}
        }
    }
}
