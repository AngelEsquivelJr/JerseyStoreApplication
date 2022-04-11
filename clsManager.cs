﻿//*******************************************
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
            //1
            //first name
            if (!string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}'", tbxFirst.Text);
            }
            //last and first
            else if (!string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text) && string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Last Name] = '{0}' AND [First Name] = '{1}'", tbxLast.Text, tbxFirst.Text);
            }
            //first, last, and email
            else if (!string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxZip.Text) && string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Last Name] = '{1}' AND [Email] = '{2}'", tbxFirst.Text, tbxLast.Text, tbxEmail.Text);
            }
            //first, last, email, and city
            else if (!string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxZip.Text) && string.IsNullOrEmpty(tbxPhone.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Last Name] = '{1}' AND [Email] = '{2}' AND [City] = '{3}'", tbxFirst.Text, tbxLast.Text, tbxEmail.Text, tbxCity.Text);
            }
            //first, last, email, city, and zip
            else if (!string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxZip.Text) && string.IsNullOrEmpty(tbxPhone.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Last Name] = '{1}' AND [Email] = '{2}' AND [City] = '{3}' AND [Zipcode] = '{4}'", tbxFirst.Text, tbxLast.Text, tbxEmail.Text, tbxCity.Text, tbxZip.Text);
            }
            //first, last, email, city, zip, and phone
            else if (!string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxPhone.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Last Name] = '{1}' AND [Email] = '{2}' AND [City] = '{3}' AND [Zipcode] = '{4}' AND [Primary Phone] = '{5}'", tbxFirst.Text, tbxLast.Text, tbxEmail.Text, tbxCity.Text, tbxZip.Text, tbxPhone.Text);
            }

            //first and city
            if (!string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [City] = '{1}'", tbxFirst.Text, tbxCity.Text);
            }
            //first and phone
            if (!string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Primary Phone] = '{1}'", tbxFirst.Text, tbxPhone.Text);
            }
            //first and zip
            if (!string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Zipcode] = '{1}'", tbxFirst.Text, tbxZip.Text);
            }

            //2
            //last name
            if (string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Last Name] = '{0}'", tbxLast.Text);
            }
            //last and email
            else if (!string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxPhone.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text) && string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Last Name] = '{0}' AND [Email] = '{1}'", tbxLast.Text, tbxEmail.Text);
            }
            //last, email, and city
            else if (!string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Last Name] = '{0}' AND [Email] = '{1}' AND [City] = '{2}'", tbxLast.Text, tbxEmail.Text, tbxCity.Text);
            }
            //last, email, city, and zip
            else if (!string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxZip.Text) && string.IsNullOrEmpty(tbxPhone.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Last Name] = '{0}' AND [Email] = '{1}' AND [City] = '{2}' AND [Zipcode] = '{3}'", tbxLast.Text, tbxEmail.Text, tbxCity.Text, tbxZip.Text);
            }
            //last, email, city, zip, and phone
            else if (!string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxPhone.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Last Name] = '{0}' AND [Email] = '{1}' AND [City] = '{2}' AND [Zipcode] = '{3}' AND [Primary Phone] = '{4}'", tbxLast.Text, tbxEmail.Text, tbxCity.Text, tbxZip.Text, tbxPhone.Text);
            }

            //last and city
            if (string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Last Name] = '{0}' AND [City] = '{1}'", tbxLast.Text, tbxCity.Text);
            }
            //last and phone
            if (string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Last Name] = '{0}' AND [Primary Phone] = '{1}'", tbxLast.Text, tbxPhone.Text);
            }
            //last and zip
            if (string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Last Name] = '{0}' AND [Zipcode] = '{1}'", tbxLast.Text, tbxZip.Text);
            }

            //3
            //email
            if (string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxPhone.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Email] = '{0}'", tbxEmail.Text);
            }
            //first and email
            else if (string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxPhone.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text) && string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Email] = '{1}'", tbxFirst.Text, tbxEmail.Text);
            }
            //first, email, and city
            else if (string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Email] = '{1}' AND [City] = '{2}'", tbxFirst.Text, tbxEmail.Text, tbxCity.Text);
            }
            //first, email, city, and zip
            else if (string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxZip.Text) && string.IsNullOrEmpty(tbxPhone.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Email] = '{1}' AND [City] = '{2}' AND [Zipcode] = '{3}'", tbxFirst.Text, tbxEmail.Text, tbxCity.Text, tbxZip.Text);
            }
            //first, email, city, zip, and phone
            else if (string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxPhone.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[First Name] = '{0}' AND [Email] = '{1}' AND [City] = '{2}' AND [Zipcode] = '{3}' AND [Primary Phone] = '{4}'", tbxFirst.Text, tbxEmail.Text, tbxCity.Text, tbxZip.Text, tbxPhone.Text);
            }

            //email and zip
            if (string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxPhone.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Email] = '{0}' AND [Zipcode] = '{1}'", tbxEmail.Text, tbxZip.Text);
            }

            //4
            //city
            if (string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[City] = '{0}'", tbxCity.Text);
            }
            //city and email
            else if (string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxPhone.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[City] = '{0}' AND [Email] = '{1}'", tbxCity.Text, tbxEmail.Text);
            }
            //zip, email, and city
            else if (string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxPhone.Text) && !string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Zipcode] = '{0}' AND [Email] = '{1}' AND [City] = '{2}'", tbxZip.Text, tbxEmail.Text, tbxCity.Text);
            }
            //zip, email, city, and phone
            else if (string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxPhone.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Zipcode] = '{0}' AND [Email] = '{1}' AND [City] = '{2}' AND [Primary Phone] = '{3}'", tbxZip.Text, tbxEmail.Text, tbxCity.Text, tbxPhone.Text);
            }

            //5
            //zip
            if (string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Zipcode] = '{0}'", tbxZip.Text);
            }
            //city and zip
            else if (string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[City] = '{0}' AND [Zipcode] = '{1}'", tbxCity.Text, tbxZip.Text);
            }
            //zip, phone, and city
            else if (string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxPhone.Text) && !string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Zipcode] = '{0}' AND [Primary Phone] = '{1}' AND [City] = '{2}'", tbxZip.Text, tbxPhone.Text, tbxCity.Text);
            }
            //zip, first, city, and phone
            else if (string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxPhone.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Zipcode] = '{0}' AND [First Name] = '{1}' AND [City] = '{2}' AND [Primary Phone] = '{3}'", tbxZip.Text, tbxFirst.Text, tbxCity.Text, tbxPhone.Text);
            }

            //6
            //phone
            if (string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Primary Phone] = '{0}'", tbxPhone.Text);
            }
            //phone and zip
            else if (string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxZip.Text) && string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Primary Phone] = '{0}' AND [Zipcode] = '{1}'", tbxPhone.Text, tbxZip.Text);
            }
            //zip, phone, and last
            else if (string.IsNullOrEmpty(tbxLast.Text) && string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxPhone.Text) && !string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxCity.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Zipcode] = '{0}' AND [Primary Phone] = '{1}' AND [Last Name] = '{2}'", tbxZip.Text, tbxPhone.Text, tbxLast.Text);
            }
            //zip, last, city, and phone
            else if (string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxCity.Text) && !string.IsNullOrEmpty(tbxZip.Text) && !string.IsNullOrEmpty(tbxPhone.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Zipcode] = '{0}' AND [Last Name] = '{1}' AND [City] = '{2}' AND [Primary Phone] = '{3}'", tbxZip.Text, tbxLast.Text, tbxCity.Text, tbxPhone.Text);
            }

            //phone and city
            if (string.IsNullOrEmpty(tbxFirst.Text) && !string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxPhone.Text) && string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Primary Phone] = '{0}' AND [City] = '{1}'", tbxPhone.Text, tbxCity.Text);
            }
            //phone and email
            if (string.IsNullOrEmpty(tbxFirst.Text) && string.IsNullOrEmpty(tbxCity.Text) && string.IsNullOrEmpty(tbxLast.Text) && !string.IsNullOrEmpty(tbxPhone.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && string.IsNullOrEmpty(tbxZip.Text))
            {
                (dgvCustomers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Primary Phone] = '{0}' AND [Email] = '{1}'", tbxPhone.Text, tbxEmail.Text);
            }
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