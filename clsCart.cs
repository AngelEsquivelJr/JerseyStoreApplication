//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
// Application used to browse and buy jerseys.
//*******************************************
// Class Purpose:
// The purpose of this class is to handle all methods in the customer view/cart.

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    internal class clsCart
    {
        //methods to format data grids
        internal static void FormatCartView(DataGridView dgvCart)
        {
            //format data grid view
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                row.Height = 50;
            }

            for (int i = 0; i < dgvCart.ColumnCount; i++)
            {
                dgvCart.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvCart.AutoResizeColumns();
                dgvCart.AllowUserToAddRows = false;
                dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCart.Columns[i].DefaultCellStyle.Font = new Font("Rockwell", 9F, FontStyle.Bold);
            }
        }

        internal static void FormatInventoryView(DataGridView dgvInventory)
        {
            //format data grid view
            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                row.Height = 150;
            }

            for (int i = 0; i < dgvInventory.ColumnCount; i++)
            {
                dgvInventory.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvInventory.AutoResizeColumns();
                dgvInventory.AllowUserToAddRows = false;
                dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvInventory.Columns[i].DefaultCellStyle.Font = new Font("Rockwell", 9F, FontStyle.Bold);
            }
        }
        //list vars for cart and checkout
        public static List<string> strCart = new List<string>();
        public static List<string> strNames = new List<string>();
        public static List<double> dblPrice = new List<double>();
        public static List<string> strPrice = new List<string>();
        public static List<int> intQuantity = new List<int>();
        public static List<int> intItemQuantity = new List<int>();
        public static List<int> intNewQuantity = new List<int>();
        public static List<int> intInventoryID = new List<int>();
        public static List<string> strTotal = new List<string>();
        public static List<double> dblCartPrice = new List<double>();
        public static List<int> intProdCount = new List<int>();

        //method for cart data grid view and adding to cart
        internal static void AddCartView(DataGridView dgvInventory, DataGridView dgvCart, ComboBox cbxQuantity, TextBox tbxItems, TextBox tbxGross, TextBox tbxSub, TextBox tbxDiscount, TextBox tbxTax, TextBox tbxTotal)
        {
            //var for item name, price, quantity, id, and size
            string strItemName;
            string strSize;
            string strPrice;
            string strQuantity;

            //vars for cost and count
            double dblSelectedPrice, dblTotal;
            int intCount = 0;
            int intDGV;

            try
            {
                if (dgvInventory.SelectedCells.Count > 0)
                {
                    int intSelectedRowIndexInventory = dgvInventory.SelectedRows[0].Index;
                    DataGridViewRow selectedRowInventory = dgvInventory.Rows[intSelectedRowIndexInventory];
                    strItemName = Convert.ToString(selectedRowInventory.Cells["Name"].Value);
                    strSize = Convert.ToString(selectedRowInventory.Cells["Size"].Value);
                    strPrice = Convert.ToString(selectedRowInventory.Cells["Price"].Value);
                    strQuantity = Convert.ToString(selectedRowInventory.Cells["Quantity"].Value);
                    string strComboQuantity = cbxQuantity.Text;

                    //set quantity to int
                    if (int.TryParse(strComboQuantity, out int intComboQuantity))
                    {
                        if(intComboQuantity < 0)
                        {
                            //error message
                            MessageBox.Show("Quantity can't be negative. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (int.TryParse(strQuantity, out int intQuantityInventory) &&
                    double.TryParse(strPrice, out dblSelectedPrice))
                    {
                        //check item quantity is greater than 0
                        if (intQuantityInventory > 0)
                        {
                            //add to cart list
                            if (strCart.Contains(strItemName))
                            {
                                //set count
                                if (intComboQuantity > 1)
                                {
                                    //add count to list
                                    intCount = intComboQuantity;

                                    for (int i = 0; i < strCart.Count; i++)
                                    {
                                        int intCheck = intComboQuantity + intProdCount[i];
                                        if (intCheck > intQuantityInventory)
                                        {
                                            //update data grid view
                                            selectedRowInventory.Cells["Quantity"].Value = 0;
                                            intProdCount[i] = intQuantityInventory;
                                            MessageBox.Show(intCheck + " items were selected. The maximum stock was added.", "Item Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            intProdCount[i] = intProdCount[i] + intCount;
                                            //update data grid view
                                            intDGV = intQuantityInventory - intCount;
                                            selectedRowInventory.Cells["Quantity"].Value = intDGV;
                                        }
                                    }
                                }
                                else if (intComboQuantity == 0 && cbxQuantity.SelectedIndex == 2)
                                {
                                    intCount = 0;
                                    MessageBox.Show(intCount + " items were selected.", "Item Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    intCount = 1;
                                    //add count to list
                                    for (int i = 0; i < strCart.Count; i++)
                                    {
                                        if (intProdCount[i] == 0)
                                        {
                                            intProdCount.Add(intCount);
                                            intProdCount[i]++;
                                            //update data grid view
                                            intDGV = intQuantityInventory - intCount;
                                            selectedRowInventory.Cells["Quantity"].Value = intDGV;
                                        }
                                        else
                                        {
                                            intProdCount[i]++;
                                            //update data grid view
                                            intDGV = intQuantityInventory - intCount;
                                            selectedRowInventory.Cells["Quantity"].Value = intDGV;
                                        }
                                    }
                                }
                            }
                            else if (!strCart.Contains(strItemName))
                            {
                                strCart.Clear();
                                intProdCount.Clear();
                                dblPrice.Clear();
                                //set count
                                if (intComboQuantity > 1)
                                {
                                    intCount = intComboQuantity;
                                    intProdCount.Add(intCount);
                                    dblPrice.Add(dblSelectedPrice);
                                    //update data grid view
                                    intDGV = intQuantityInventory - intCount;
                                    selectedRowInventory.Cells["Quantity"].Value = intDGV;
                                    //add to cart list
                                    strCart.Add(strItemName);
                                }
                                else if (intComboQuantity == 0 && cbxQuantity.SelectedIndex == 2)
                                {
                                    intCount = 0;
                                    MessageBox.Show(intCount + " items were selected.", "Item Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    intCount = 1;
                                    intProdCount.Add(intCount);
                                    dblPrice.Add(dblSelectedPrice);
                                    //update data grid view
                                    intDGV = intQuantityInventory - intCount;
                                    selectedRowInventory.Cells["Quantity"].Value = intDGV;
                                    //add to cart list
                                    strCart.Add(strItemName);
                                }
                            }


                            //set price
                            if (intCount >= 1)
                            {
                                for (int i = 0; i < strCart.Count; i++)
                                {
                                    //set price total
                                    dblTotal = dblPrice[i] * intProdCount[i];
                                    //go through each row
                                    foreach (DataGridViewRow row in dgvCart.Rows)
                                    {
                                        for (int j = 0; j < row.Cells.Count; j++)
                                        {
                                            //check value for null
                                            if (row.Cells[j].Value != null)
                                            {
                                                //look for matching text
                                                if (row.Cells[j].Value.ToString().Contains(strItemName))
                                                {
                                                    //select matching row
                                                    dgvCart.CurrentCell = row.Cells[j];
                                                    //get selected quantity
                                                    int intSelectedRowIndexCart = dgvCart.SelectedRows[0].Index;
                                                    DataGridViewRow selectedRowCart = dgvCart.Rows[intSelectedRowIndexCart];
                                                    string strQuantityCart = Convert.ToString(selectedRowCart.Cells["Quantity"].Value);
                                                    if (int.TryParse(strQuantityCart, out int intQuantityCart))
                                                    {
                                                        if (intQuantityInventory >= 1)
                                                        {
                                                            //if statement to set quantity and total in cart
                                                            if (intQuantityCart == 1)
                                                            {
                                                                selectedRowCart.Cells["Quantity"].Value = intProdCount[i];
                                                                selectedRowCart.Cells["Total"].Value = dblTotal.ToString("C");
                                                            }
                                                            else
                                                            {
                                                                int intNew = intQuantityCart + intCount;
                                                                dblTotal = dblPrice[i] * intNew;
                                                                selectedRowCart.Cells["Quantity"].Value = intNew;
                                                                selectedRowCart.Cells["Total"].Value = dblTotal.ToString("C");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //add items
                                    if (dgvCart == null || dgvCart.Rows.Count < 1)
                                    {
                                        clsCartItems items = new clsCartItems
                                        {
                                            Quantity = intProdCount[i],
                                            Name = strItemName,
                                            Size = strSize,
                                            Price = dblSelectedPrice.ToString("C"),
                                            Total = dblTotal.ToString("C"),
                                        };
                                        clsCartData.cartItems.Add(items);
                                        //format cart view
                                        FormatCartView(dgvCart);
                                        //check if there is a selected row
                                        if (dgvCart.SelectedRows.Count == 0)
                                        {
                                            dgvCart.Rows[dgvCart.Rows.Count - 1].Cells[1].Selected = true;
                                        }
                                    }
                                    else
                                    {
                                        //make sure theres a selected row
                                        if (dgvCart.SelectedRows.Count > 0)
                                        {
                                            int intSelectedRowIndex = dgvCart.SelectedRows[0].Index;
                                            DataGridViewRow selectedRow = dgvCart.Rows[intSelectedRowIndex];
                                            //if not in data grid view add item
                                            if (selectedRow.Cells["Name"].Value.ToString() != strItemName)
                                            {
                                                clsCartItems items = new clsCartItems
                                                {
                                                    Quantity = intProdCount[i],
                                                    Name = strItemName,
                                                    Size = strSize,
                                                    Price = dblSelectedPrice.ToString("C"),
                                                    Total = dblTotal.ToString("C"),
                                                };
                                                clsCartData.cartItems.Add(items);
                                                //format cart view
                                                FormatCartView(dgvCart);
                                            }
                                        }
                                    }
                                }

                                //set text boxes in order summary
                                int intTotalItems = 0;
                                double dblGrossSub = 0;
                                double dblTaxAmount = 0;
                                double dblTotalAmount = 0;
                                //total items
                                for (int i = 0; i < dgvCart.Rows.Count; ++i)
                                {
                                    intTotalItems += Convert.ToInt32(dgvCart.Rows[i].Cells[0].Value);
                                }
                                //gross and subtotal
                                for (int i = 0; i < dgvCart.Rows.Count; ++i)
                                {
                                    dblGrossSub += Convert.ToDouble((dgvCart.Rows[i].Cells[4].Value).ToString().Substring(1));
                                }

                                //text boxes
                                tbxItems.Text = intTotalItems.ToString();
                                tbxGross.Text = dblGrossSub.ToString("C");
                                //check if discount is applied
                                if (tbxDiscount.Text == "$0.00")
                                {
                                    //sub
                                    tbxSub.Text = dblGrossSub.ToString("C");
                                    //taxes
                                    dblTaxAmount = dblGrossSub * 0.0825;
                                    tbxTax.Text = dblTaxAmount.ToString("C");
                                    //total
                                    dblTotalAmount = dblGrossSub + dblTaxAmount;
                                    tbxTotal.Text = dblTotalAmount.ToString("C");
                                }
                                else
                                {
                                    //get discount amount
                                    if (double.TryParse(tbxDiscount.Text.Substring(1), out double dblDiscountAmount))
                                    {
                                        //add discount
                                        double dblNewSub = dblGrossSub - dblDiscountAmount;
                                        //sub
                                        tbxSub.Text = dblNewSub.ToString("C");
                                        //taxes
                                        dblTaxAmount = dblNewSub * 0.0825;
                                        tbxTax.Text = dblTaxAmount.ToString("C");
                                        //total
                                        dblTotalAmount = dblNewSub + dblTaxAmount;
                                        tbxTotal.Text = dblTotalAmount.ToString("C");
                                    }
                                }

                            }
                        }
                        else
                        {
                            //cart message
                            MessageBox.Show("Sorry, unfortunately this Item is out of stock. Try Again.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Could not add to cart. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //method to set limit in remove button
        internal static void RemoveAddCart(DataGridView dgvCart, Button btnRemove)
        {
            try
            {
                //make sure theres a selected row
                if (dgvCart.SelectedRows.Count > 0)
                {
                    //get selected quantity
                    int intSelectedRowIndex = dgvCart.SelectedRows[0].Index;
                    DataGridViewRow selectedRow = dgvCart.Rows[intSelectedRowIndex];
                    string strQuantityCart = Convert.ToString(selectedRow.Cells["Quantity"].Value);
                    if (int.TryParse(strQuantityCart, out int intQuantityCart))
                    {
                        //set amount for count
                        if (int.TryParse(btnRemove.Text, out int intCount))
                        {
                            //add to count and change remove button
                            intCount++;
                            if (intCount <= intQuantityCart)
                            {
                                btnRemove.Text = intCount.ToString();
                            }
                        }
                        else
                        {
                            //error message
                            MessageBox.Show("Could not convert count. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Could not add to remove button. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        internal static void RemoveSubtractCart(Button btnRemove)
        {
            try
            {
                string strRemove = btnRemove.Text;
                //set amount for count
                if (int.TryParse(strRemove, out int intCount))
                {
                    //subtract to count and change remove button
                    if (intCount > 0)
                    {
                        intCount--;
                    }
                    btnRemove.Text = intCount.ToString();
                }
                else
                {
                    //error message
                    MessageBox.Show("Could not subtract to remove button. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Could not subtract to remove button. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //method to remove from cart
        internal static void RemoveCart(DataGridView dgvInventory, DataGridView dgvCart, Button btnRemove, TextBox tbxItems, TextBox tbxGross, TextBox tbxSub, TextBox tbxDiscount, TextBox tbxTax, TextBox tbxTotal)
        {
            try
            {
                //make sure theres a selected row
                if (dgvCart.SelectedRows.Count > 0)
                {
                    //get selected quantity
                    int intSelectedRowIndex = dgvCart.SelectedRows[0].Index;
                    DataGridViewRow selectedRow = dgvCart.Rows[intSelectedRowIndex];
                    string strQuantityCart = Convert.ToString(selectedRow.Cells["Quantity"].Value);
                    string strPriceCart = Convert.ToString(selectedRow.Cells["Price"].Value).Substring(1);
                    string strTotalCart = Convert.ToString(selectedRow.Cells["Total"].Value).Substring(1);
                    string strItemName = Convert.ToString(selectedRow.Cells["Name"].Value);

                    //select item your removing from inventory
                    foreach (DataGridViewRow row in dgvInventory.Rows)
                    {
                        // 1 is the column index
                        if (row.Cells[1].Value.ToString().Equals(strItemName))
                        {
                            row.Selected = true;
                        }
                    }

                    if (dgvInventory.SelectedCells.Count > 0)
                    {
                        //change quantity in inventory
                        int intSelectedRowIndexInventory = dgvInventory.SelectedRows[0].Index;
                        DataGridViewRow selectedRowInventory = dgvInventory.Rows[intSelectedRowIndexInventory];
                        string strQuantity = Convert.ToString(selectedRowInventory.Cells["Quantity"].Value);

                        if (int.TryParse(strQuantityCart, out int intQuantityCart) &&
                        double.TryParse(strPriceCart, out double dblPriceCart) &&
                        double.TryParse(strTotalCart, out double dblTotalCart) &&
                        int.TryParse(btnRemove.Text, out int intCount) && int.TryParse(strQuantity, out int intQuantityInventory))
                        {
                            if (intQuantityCart < intCount)
                            {
                                //message for remove button being greater than quantity in cart
                                MessageBox.Show("The quantity trying to be removed is greater than the quantity in your cart. Please decrease the amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                int intRemoveQuantity = intQuantityCart - intCount;
                                int intAddQuantity = intQuantityInventory + intCount;

                                double dblRemoveTotal = dblPriceCart * intRemoveQuantity;
                                if (intRemoveQuantity > 0)
                                {
                                    if (intRemoveQuantity < intCount)
                                    {
                                        btnRemove.Text = intRemoveQuantity.ToString();
                                    }

                                    selectedRow.Cells["Quantity"].Value = intRemoveQuantity;
                                    selectedRow.Cells["Total"].Value = dblRemoveTotal.ToString("C");
                                    selectedRowInventory.Cells["Quantity"].Value = intAddQuantity;
                                }
                                else
                                {
                                    dgvCart.Rows.Remove(selectedRow);
                                    selectedRowInventory.Cells["Quantity"].Value = intAddQuantity;
                                    btnRemove.Text = "0";
                                    //add count to list
                                    for (int i = 0; i < strCart.Count; i++)
                                    {
                                        intProdCount[i] = 0;
                                        if (dgvCart.Rows.Count > 0)
                                        {
                                            dgvCart.Rows[0].Selected = true;
                                        }
                                    }
                                }

                                //set text boxes in order summary
                                int intTotalItems = 0;
                                double dblGrossSub = 0;
                                double dblTaxAmount = 0;
                                double dblTotalAmount = 0;
                                //total items
                                for (int i = 0; i < dgvCart.Rows.Count; ++i)
                                {
                                    intTotalItems += Convert.ToInt32(dgvCart.Rows[i].Cells[0].Value);
                                }
                                //gross and subtotal
                                for (int i = 0; i < dgvCart.Rows.Count; ++i)
                                {
                                    dblGrossSub += Convert.ToDouble((dgvCart.Rows[i].Cells[4].Value).ToString().Substring(1));
                                }

                                //text boxes
                                tbxItems.Text = intTotalItems.ToString();
                                tbxGross.Text = dblGrossSub.ToString("C");
                                //check if discount is applied
                                if (tbxDiscount.Text == "$0.00")
                                {
                                    //sub
                                    tbxSub.Text = dblGrossSub.ToString("C");
                                    //taxes
                                    dblTaxAmount = dblGrossSub * 0.0825;
                                    tbxTax.Text = dblTaxAmount.ToString("C");
                                    //total
                                    dblTotalAmount = dblGrossSub + dblTaxAmount;
                                    tbxTotal.Text = dblTotalAmount.ToString("C");
                                }
                                else
                                {
                                    //get discount amount
                                    if (double.TryParse(tbxDiscount.Text.Substring(1), out double dblDiscountAmount))
                                    {
                                        if (intTotalItems <= 0)
                                        {

                                            tbxSub.Clear();
                                            tbxTax.Clear();
                                            tbxTotal.Clear();
                                        }
                                        else
                                        {
                                            //add discount
                                            double dblNewSub = dblGrossSub - dblDiscountAmount;
                                            //sub
                                            tbxSub.Text = dblNewSub.ToString("C");
                                            //taxes
                                            dblTaxAmount = dblNewSub * 0.0825;
                                            tbxTax.Text = dblTaxAmount.ToString("C");
                                            //total
                                            dblTotalAmount = dblNewSub + dblTaxAmount;
                                            tbxTotal.Text = dblTotalAmount.ToString("C");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Could not remove from cart. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //method to clear cart
        internal static void ClearCart(DataGridView dgvCart)
        {
            try
            {
                if (dgvCart.Rows.Count > 0)
                {
                    //clear cart items
                    strCart.Clear();
                    intProdCount.Clear();
                    dblPrice.Clear();
                    dgvCart.Rows.Clear();
                    dgvCart.Refresh();
                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Could not clear cart. Please Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //method for filtering data grid view
        internal static void FilterInventoryCategory(DataGridView dgvInventory, ComboBox cbxCategory, ComboBox cbxSize, TextBox tbxSearch)
        {
            try
            {

                //check selected index
                if (cbxSize.SelectedIndex == 0 && cbxCategory.SelectedIndex >= 1)
                {
                    //set filter
                    (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = string.Format("Sport = '{0}'", cbxCategory.Text);
                    if (!dgvInventory.Columns.Contains("Item Image"))
                    {
                        clsSQL.ImageInventory(dgvInventory);                        
                    }

                    FormatInventoryView(dgvInventory);
                }
                else
                {
                    if (cbxCategory.SelectedIndex >= 1 && cbxSize.SelectedIndex >= 1)
                    {
                        //set multiple filters
                        (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = string.Format("Sport = '{0}' AND Size = '{1}'", cbxCategory.Text, cbxSize.Text);
                        if (!dgvInventory.Columns.Contains("Item Image"))
                        {
                            clsSQL.ImageInventory(dgvInventory);
                        }
                        FormatInventoryView(dgvInventory);
                    }
                    else if (cbxCategory.SelectedIndex == 0 && cbxSize.SelectedIndex >= 1)
                    {
                        //set filter
                        (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = string.Format("Size = '{0}'", cbxSize.Text);
                        if (!dgvInventory.Columns.Contains("Item Image"))
                        {
                            clsSQL.ImageInventory(dgvInventory);
                        }
                        FormatInventoryView(dgvInventory);
                    }
                    else
                    {
                        (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = "";
                        if (!dgvInventory.Columns.Contains("Item Image"))
                        {
                            clsSQL.ImageInventory(dgvInventory);
                        }
                        FormatInventoryView(dgvInventory);
                        tbxSearch.Focus();
                    }
                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Could not filter category. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal static void FilterInventorySize(DataGridView dgvInventory, ComboBox cbxSize, ComboBox cbxCategory, TextBox tbxSearch)
        {
            try
            {
                //check selected index
                if (cbxCategory.SelectedIndex == 0 && cbxSize.SelectedIndex >= 1)
                {
                    //set filter
                    (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = string.Format("Size = '{0}'", cbxSize.Text);
                    if (!dgvInventory.Columns.Contains("Item Image"))
                    {
                        clsSQL.ImageInventory(dgvInventory);
                    }
                    FormatInventoryView(dgvInventory);
                }
                else
                {
                    if (cbxSize.SelectedIndex >= 1 && cbxCategory.SelectedIndex >= 1)
                    {
                        //set multiple filters
                        (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = string.Format("Sport = '{0}' AND Size = '{1}'", cbxCategory.Text, cbxSize.Text);
                        if (!dgvInventory.Columns.Contains("Item Image"))
                        {
                            clsSQL.ImageInventory(dgvInventory);
                        }
                        FormatInventoryView(dgvInventory);
                    }
                    else if (cbxSize.SelectedIndex == 0 && cbxCategory.SelectedIndex >= 1)
                    {
                        //set filter
                        (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = string.Format("Sport = '{0}'", cbxCategory.Text);
                        if (!dgvInventory.Columns.Contains("Item Image"))
                        {
                            clsSQL.ImageInventory(dgvInventory);
                        }
                        FormatInventoryView(dgvInventory);
                    }
                    else
                    {
                        (dgvInventory.DataSource as DataTable).DefaultView.RowFilter = "";
                        if (!dgvInventory.Columns.Contains("Item Image"))
                        {
                            clsSQL.ImageInventory(dgvInventory);
                        }
                        FormatInventoryView(dgvInventory);
                        tbxSearch.Focus();
                    }
                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Could not filter size. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //method for searching
        internal static void SearchInventory(DataGridView dgvInventory, TextBox tbxSearch, ComboBox cbxSize)
        {
            try
            {
                //check for empty text box
                if (String.IsNullOrEmpty(tbxSearch.Text) || String.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    MessageBox.Show("Search was left blank. Please enter what you need to search. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //go through each row
                    foreach (DataGridViewRow row in dgvInventory.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            //check value for null
                            if (row.Cells[i].Value != null)
                            {
                                //look for matching text
                                if (row.Cells[i].Value.ToString().ToUpper().Contains(tbxSearch.Text.ToUpper()))
                                {
                                    //select matching text
                                    dgvInventory.CurrentCell = row.Cells[i];
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Could not search inventory. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
