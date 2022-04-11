//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
// Application used to browse and buy jerseys.
//*******************************************
// Class Purpose:
// The purpose of this class is to handle all methods for the manager view.

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    internal class clsManager
    {
        //method to clear fields
        internal static void ClearInventoryFields(clsParameters.InventoryParameters inventoryParameters)
        {
            inventoryParameters.cbxDiscontinuedP.SelectedIndex = 0;
            inventoryParameters.cbxTeamIDP.SelectedIndex = 0;
            inventoryParameters.pbxItemImageP.Image = null;
            inventoryParameters.tbxInventoryIDP.Clear();
            inventoryParameters.tbxItemNameP.Clear();
            inventoryParameters.tbxItemDescriptionP.Clear();
            inventoryParameters.tbxColorP.Clear();
            inventoryParameters.tbxCostP.Clear();
            inventoryParameters.tbxQuantityP.Clear();
            inventoryParameters.tbxRetailPriceP.Clear();
            inventoryParameters.tbxSizeP.Clear();
            inventoryParameters.tbxRestockP.Clear();
        }
        //method to search customers
        internal static void SearchCustomers(DataGridView dgvCustomers, TextBox tbxFirst, TextBox tbxLast, TextBox tbxEmail, TextBox tbxCity, TextBox tbxZip, TextBox tbxPhone)
        {
            //set filters
            if (!string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}'", tbxFirst.Text);
            }
            if (!string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text) && string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Last Name] = '{0}' AND [First Name] = '{1}'", tbxLast.Text, tbxFirst.Text);
            }
            else if (!string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxZip.Text) && string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Last Name] = '{1}' AND [Email] = '{2}'", tbxFirst.Text, tbxLast.Text, tbxEmail.Text);
            }
            else if (!string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxZip.Text) && string.IsNullOrEmpty(tbxPhone.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Last Name] = '{1}' AND [Email] = '{2}' AND [City] = '{3}'", tbxFirst.Text, tbxLast.Text, tbxEmail.Text, tbxCity.Text);
            }
            else if (!string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxZip.Text) && string.IsNullOrEmpty(tbxPhone.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Last Name] = '{1}' AND [Email] = '{2}' AND [City] = '{3}' AND [Zipcode] = '{4}'", tbxFirst.Text, tbxLast.Text, tbxEmail.Text, tbxCity.Text, tbxZip.Text);
            }
            else if (!string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxPhone.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Last Name] = '{1}' AND [Email] = '{2}' AND [City] = '{3}' AND [Zipcode] = '{4}' AND [Primary Phone] = '{5}'", tbxFirst.Text, tbxLast.Text, tbxEmail.Text, tbxCity.Text, tbxZip.Text, tbxPhone.Text);
            }
            //(dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Primary Phone] = '{0}'", tbxPhone.Text);
            //(dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Zipcode] = '{0}'", tbxZip.Text);
            //(dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[City] = '{0}'", tbxCity.Text);
            //(dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Email] = '{0}'", tbxEmail.Text);
            //(dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Last Name] = '{0}'", tbxLast.Text);
            //(dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}'", tbxFirst.Text);
            //(dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Primary Phone] = '{0}' AND [Zipcode] = '{1}'", tbxPhone.Text, tbxZip.Text);
        }
        //method to make image into byte[]
        internal static byte[] ImagetoByteArray(Image imgItem)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                imgItem.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }
        //method to update fields when editing
        //when selection is changed in data grid view
        internal static void UpdateFieldsInventory(DataGridView dgvInventory, clsParameters.InventoryParameters inventoryParameters, Label lblState)
        {
            try
            {
                //get selected row values
                if (dgvInventory.SelectedCells.Count > 0)
                {
                    int intSelectedRowIndexInventory = dgvInventory.SelectedRows[0].Index;
                    DataGridViewRow selectedRowInventory = dgvInventory.Rows[intSelectedRowIndexInventory];

                    //set values to text boxes
                    if (lblState.Text == "Editing")
                    {
                        inventoryParameters.tbxInventoryIDP.Text = Convert.ToString(selectedRowInventory.Cells["InventoryID"].Value);
                    }
                    inventoryParameters.tbxItemNameP.Text = Convert.ToString(selectedRowInventory.Cells["Name"].Value);
                    inventoryParameters.tbxItemDescriptionP.Text = Convert.ToString(selectedRowInventory.Cells["Description"].Value);
                    inventoryParameters.tbxCostP.Text = Convert.ToString(selectedRowInventory.Cells["Cost"].Value);
                    inventoryParameters.tbxRetailPriceP.Text = Convert.ToString(selectedRowInventory.Cells["Retail Price"].Value);
                    inventoryParameters.tbxQuantityP.Text = Convert.ToString(selectedRowInventory.Cells["Quantity"].Value);
                    inventoryParameters.tbxColorP.Text = Convert.ToString(selectedRowInventory.Cells["Color"].Value);
                    inventoryParameters.tbxSizeP.Text = Convert.ToString(selectedRowInventory.Cells["Size"].Value);
                    inventoryParameters.tbxRestockP.Text = Convert.ToString(selectedRowInventory.Cells["RestockThreshold"].Value);
                    string strDiscontinued = Convert.ToString(selectedRowInventory.Cells["Discontinued"].Value);
                    inventoryParameters.cbxTeamIDP.Text = Convert.ToString(selectedRowInventory.Cells["TeamID"].Value);
                    string strImage = Convert.ToString(selectedRowInventory.Cells["Item Image"].Value);

                    if (strDiscontinued == "0")
                    {
                        //not discontinued
                        inventoryParameters.cbxDiscontinuedP.SelectedIndex = 1;
                    }
                    else
                    {
                        //discontinued
                        inventoryParameters.cbxDiscontinuedP.SelectedIndex = 2;
                    }

                    byte[] bytImage = Encoding.ASCII.GetBytes(strImage);
                    using (MemoryStream msImage = new MemoryStream(bytImage))
                    {
                        Image imgLoaded = Image.FromStream(msImage);
                        inventoryParameters.pbxItemImageP.Image = imgLoaded;
                    }
                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Could not update fields for inventory item. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //method to select an image
        internal static void BrowseImage(PictureBox pbxItemImage)
        {
            try
            {
                //OpenFileDialog Properties
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.ValidateNames = true;
                openFile.AddExtension = false;
                openFile.Filter = "PNG Image File|*.png";
                openFile.Title = "File to Upload";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    //Convert image into a byte array
                    byte[] bytImage = File.ReadAllBytes(openFile.FileName);
                    using (MemoryStream msImage = new MemoryStream(bytImage))
                    {
                        Image imgLoaded = Image.FromStream(msImage);
                        pbxItemImage.Image = imgLoaded;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error During Upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
