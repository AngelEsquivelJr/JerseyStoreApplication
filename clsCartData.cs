//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
// Application used to browse and buy jerseys.
// Form Purpose:
// This form is used to create the list for the cart Items.
// 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class clsCartData
    {
        //create binding list for cart items
        public static BindingList<clsCartItems> cartItems { get; set; } = new BindingList<clsCartItems>();
    }
}
