//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description: {Program Purpose Goes here}
//*******************************************
// Class Purpose: 
/*    Handles input validation for controls or user input before reaching the server
 *      Validate TextBox input of required fields
 *          - Logon ID
 *          - Password
 *          - Address lines
 *          - City
 *          - State
 *          - Zip Code
 *          - Phone Number
 *          - Date
 *          - etc.
*/

//*******************************************
//*******************************************

// To See the 'ToDo' tags, go to the 'View' Menu and then select 'Task List'
// You can then double click on a 'ToDo' to go to that specific one in the list

//ToDo: ------------ clsValidation: Remove Form ToDo List, once completed (Listed Below) ------------
//ToDo: ------------ clsValidation: Remove Form ToDo List, once completed (Listed Above) ------------

using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FinalProject
{
    internal class clsValidation
    {
        //method for allowed keys Username
        internal static void UsernameAllowedKeys(KeyPressEventArgs e)
        {
            //allow letters,digits only
            //allow backspace to work
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar) )
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //method to check username requirements
        internal static bool UsernameHasComplexity(string strUsername)
        {
            //creates complexity counter
            int intComplextiyCtr = 0;

            //check length
            if (strUsername.Length >= 8 && strUsername.Length <= 20)
            {
                intComplextiyCtr++;
            }
            else
            {
                MessageBox.Show("Username must be longer than 8 characters long and must be less than 20 characters.", "Username Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //check first character for digit
            if(Char.IsDigit(strUsername[0]))
            {
                MessageBox.Show("Username cannot start with a number.", "Username Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                intComplextiyCtr++;
            }

            //if complexity is greater than or equal to 2 it returns true
            return intComplextiyCtr >= 2;

        }

        //method for allowed keys password
        internal static void PasswordAllowedKeys(KeyPressEventArgs e)
        {
            string strAllowedKeys = "()!@#$%^&*";

            //allow letters,digits,special characters only
            //allow backspace to work
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar) ||
                strAllowedKeys.Contains(e.KeyChar.ToString()))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //method to check password requirements
        internal static bool PasswordHasComplexity(string strPassword)
        {
            //creates complexity counter
            int intComplextiyCtr = 0;
            bool bolHasSpecial = false;
            string strAllowedKeys = "()!@#$%^&*";

            //check length
            if (strPassword.Length >= 8 && strPassword.Length <= 20)
            {
                intComplextiyCtr++;
            }
            else
            {
                MessageBox.Show("Password must be longer than 8 characters long and less than 20 characters.", "Password Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //LINQ
            if (strPassword.Any(char.IsUpper))
                intComplextiyCtr++;

            if (strPassword.Any(char.IsLower))
                intComplextiyCtr++;

            if (strPassword.Any(char.IsDigit))
                intComplextiyCtr++;

            //special characters
            foreach (char chLetter in strPassword)
            {
                if (strAllowedKeys.Contains(chLetter.ToString()))
                    bolHasSpecial = true;
            }

            if (bolHasSpecial)
                intComplextiyCtr++;

            //if complexity is greater than or equal to 4 it returns true
            if (intComplextiyCtr >= 4)
            {
                return intComplextiyCtr >= 4;
            }
            else
            {
                MessageBox.Show("Password does not meet all requirements. (see help)", "Password Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //method for address validation
        internal static void AddressAllowed(KeyPressEventArgs e)
        {
            //allow letters and numbers only
            //allow backspace and space to work
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //method for required field
        internal static bool AddressExist(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Address is a required field.", "Address Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        //method for city validation
        internal static void CityAllowed(KeyPressEventArgs e)
        {
            //allow letters only
            //allow backspace and space to work
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //method for required field
        internal static bool CityExist(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("City is a required field.", "City Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        //method for required field
        internal static bool StateExist(string state)
        {
            if (string.IsNullOrEmpty(state))
            {
                MessageBox.Show("State is a required field.", "State Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        //methods for zipcode validation
        internal static void ZipAllowed(KeyPressEventArgs e)
        {
            string strAllowedKeys = "-";

            //allow numbers only
            //allow dashes only
            //allow backspace to work
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) ||
                strAllowedKeys.Contains(e.KeyChar.ToString()))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //using regex
        internal static bool ZipCodeMatch(string zipCode)
        {
            string pattern = "^[0-9]{5}(?:-[0-9]{4})?$";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(zipCode))
            {
                return regex.IsMatch(zipCode);
            }
            else
            {
                MessageBox.Show("Zipcode was invalid. (see help)", "Zipcode Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //method for phone validation
        internal static void PhoneAllowed(KeyPressEventArgs e)
        {
            string strAllowedKeys = "-";

            //allow numbers only
            //allow dashes only
            //allow backspace to work
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || 
                strAllowedKeys.Contains(e.KeyChar.ToString()))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //method for answers validation
        internal static void AnswerAllowed(KeyPressEventArgs e)
        {
            //allow letters and digits only
            //allow backspace and space to work
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //method for required field
        internal static bool AnswerExist(string ansOne, string ansTwo, string ansThr)
        {
            if (string.IsNullOrEmpty(ansOne) || string.IsNullOrEmpty(ansTwo) || string.IsNullOrEmpty(ansThr))
            {
                MessageBox.Show("Answers are a required field.", "Answer Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }         
            else
            {
                return true;
            }
        }

        //method for required field
        internal static bool QuestionExist(string quesOne, string quesTwo, string quesThr)
        {
            if (string.IsNullOrEmpty(quesOne) || string.IsNullOrEmpty(quesTwo) || string.IsNullOrEmpty(quesThr))
            {
                MessageBox.Show("Questions are a required field.", "Question Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }

        }

        //method for email validation
        internal static void EmailAllowed(KeyPressEventArgs e)
        {
            //dont allow spaces
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        //using regex
        internal static bool EmailMatch(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(email))
            {
                return regex.IsMatch(email);
            }
            else
            {
                MessageBox.Show("Email was invalid. (see help)", "Email Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //method for required field
        internal static bool EmailExist(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            else
                return true;
        }

        //method for name validation
        internal static void NameAllowedKeys(KeyPressEventArgs e)
        {
            string strDisAllowedKeys = "()!@#$%^&*";

            //disallow special chars
            if (strDisAllowedKeys.Contains(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        //method for required field
        internal static bool NameExist(string fname, string lname)
        {
            if (string.IsNullOrEmpty(fname))
            {
                MessageBox.Show("First name is a required field.", "Name Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(lname))
            {
                MessageBox.Show("Last name is a required field.", "Name Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
                
        }

        //method for all required fields
        internal static bool RequiredFields(string nameF, string nameL, string address, string city, string state, string ques1, string ques2, string ques3, string ans1, string ans2, string ans3)
        {
            if(AddressExist(address))
            {
                if (CityExist(city))
                {
                    if (StateExist(state))
                    {
                        if (NameExist(nameF, nameL))
                        {
                            if (QuestionExist(ques1, ques2, ques3))
                            {
                                if (AnswerExist(ans1, ans2, ans3))
                                {
                                    return true;
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}
