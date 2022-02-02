//ToDo: Change the entries below indicated by {} to your values
//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: {Program Purpose Goes here}
// Application used to browse and buy jerseys.
// Form Purpose: {What is this form used for}
// Information on my application and information
// about my program.

// To See the 'ToDo' tags, go to the 'View' Menu and then select 'Task List'
// You can then double click on a 'ToDo' to go to that specific one in the list

//ToDo: ------------ frmMain - Remove Form ToDo List, once completed (Listed Below) ------------
//ToDo: frmMain - Review Syllabus, the Project requirements, Moodle, the course Google Meeting content and the Course Chat for compliance with requirements
//ToDo: frmMain - --- Set Form Properties (As Below) ---
//ToDo: frmMain - AcceptButton - Set as appropriate
//ToDo: frmMain - CancelButton - Set as appropriate
//ToDo: --- frmMain - Set Form Properties (As Above) ---
//ToDo: frmMain - Display with the appropriate Mode state
//ToDo: frmMain - All MessageBox's must be fully formed -> MessageBox.Show("Text to Display","Title to Display",MessageBoxButtons.OK,MessageBoxIcon.Information);
//ToDo: frmMain - Set Comments - Brief comments must be placed directly above or inside each EVENT, FUNCTION, or PROCEDURE briefly describing its purpose and any other relevant information.
//ToDo: frmMain - No Empty Functions/Methods
//ToDo: frmMain - Try/Catch or Try/Catch/Finally - Used as appropriate to avoid Unhandled Exceptions, etc.
//ToDo: frmMain - {DataType}.TryParse(...) - Used in an IF(!{DataType}.TryParse(...)) or IF/ELSE decision structure and handled to course standards
//ToDo: frmMain - Validation - All Data and user input must be validated and formatted to the expected allowable values for each control before inserting into the SQL Database/Table.
//ToDo: frmMain - ADA - Course ADA Requirements must be met
//ToDo: frmMain - Files - Any files such as receipts or reports must be created and accessed from the User's "Documents" or "My Documents" Special Folder and uniquely named and stored in a Project Specific subfolder.
//ToDo: frmMain - Help - Add appropriate, context sensitive help
//ToDo: ------------ frmMain - Remove Form ToDo List, once completed (Listed Above) ------------

//ToDo: frmMain - Remove any unused or unneeded 'using' statements once complete
using System;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmLogon : Form
    {
        public frmLogon()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //exits application
            Application.Exit();
        }

        private void btnShow_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
        private void btnShow_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void tbxUsername_Click(object sender, EventArgs e)
        {
            //clears textbox text
            if (tbxUsername.Text == "Username")
            {
                tbxUsername.Clear();
            }
        }

        private void tbxPassword_Click(object sender, EventArgs e)
        {
            //clears password text
            if (tbxPassword.Text == "Password")
            {
                tbxPassword.Clear();
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            //opens sign up form
            frmSignUp frmSign = new frmSignUp();
            frmSign.Show();
            this.Hide();
        }

        private void btnPasswordReset_Click(object sender, EventArgs e)
        {
            //opens reset form
            frmReset frmReset = new frmReset();
            frmReset.Show();
            this.Hide();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //if statement for showing password
            if (tbxPassword.PasswordChar == (char)0)
            {
                tbxPassword.PasswordChar = '*';
            }
            else
            {
                tbxPassword.PasswordChar = (char)0;
            }
        }

        private void frmLogon_FormClosing(object sender, FormClosingEventArgs e)
        {
            //allow exit through x button
            //close datatbase upon exit
            Application.Exit();
            clsSQL.CloseDatabase();
        }
    }
}