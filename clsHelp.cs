//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
// Application used to browse and buy jerseys.
// Class Purpose: 
/* This class is used to call and display the appropriate Context
 * Sensitive Help files used by this program. It serves as a single method
 * of calling and opening/displaying external help files.
*/
//*******************************************
//*******************************************


using System;
using System.IO;
using System.Windows.Forms;

namespace FinalProject
{
    internal class clsHelp
    {

        //method for opening help file
        internal static void OpenHelp(string strName)
        {
            //get path of pdf
            string strPath = Path.GetFullPath(@"HelpFiles\" + strName );

            try
            {
                //check if file exists
                if (File.Exists(strPath))
                {
                    //open with default process
                    System.Diagnostics.Process.Start(strPath);
                }
                else
                {
                    //error for file not existing
                    MessageBox.Show("This help file was not found. ", "Help File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                //error for no file
                MessageBox.Show("I am unable to open this help file at this time. ", "Help File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
