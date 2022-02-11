//*******************************************
//*******************************************
// Programmer: Angel Esquivel
// Course: INEW 2332.7Z1 (Final Project)
// Program Description:
// Application used to browse and buy jerseys.
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
            bool bolHasSpecial = false;
            bool bolHasSpaces = false;
            string strSpace = " ";
            string strAllowedKeys = "()!@#$%^&*";

            //space characters
            foreach (char chLetter in strUsername)
            {
                if (strSpace.Contains(chLetter.ToString()))
                    bolHasSpaces = true;
            }

            if (bolHasSpaces)
            {
                MessageBox.Show("Password has spaces. Spaces are not allowed. (see help)", "Password Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

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

            //special characters
            foreach (char chLetter in strUsername)
            {
                if (strAllowedKeys.Contains(chLetter.ToString()))
                    bolHasSpecial = true;
            }

            if (bolHasSpecial)
            {
                MessageBox.Show("Username cannot contain special characters.", "Username Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                intComplextiyCtr++;

            //if complexity is greater than or equal to 2 it returns true
            return intComplextiyCtr >= 3;

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
            bool bolHasDisallowed = false;
            bool bolHasSpaces = false;
            string strAllowedKeys = "()!@#$%^&*";
            string strDisallowed = @"`~-_=+{}[]:;,<.>?/'\|";
            string strSpace = " ";

            //disallowed characters
            foreach (char chLetter in strPassword)
            {
                if (strDisallowed.Contains(chLetter.ToString()))
                    bolHasDisallowed = true;
            }

            if (bolHasDisallowed)
            {
                MessageBox.Show("Password has disallowed characters. (see help)", "Password Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //space characters
            foreach (char chLetter in strPassword)
            {
                if (strSpace.Contains(chLetter.ToString()))
                    bolHasSpaces = true;
            }

            if (bolHasSpaces)
            {
                MessageBox.Show("Password has spaces. Spaces are not allowed. (see help)", "Password Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

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

        //method to check for spaces
        internal static bool SpaceCheck(string strString)
        {
            if (string.IsNullOrWhiteSpace(strString))
            {
                MessageBox.Show("Fields can't be just white space.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
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
        internal static bool AddressExist(string strAddress)
        {
            if (string.IsNullOrEmpty(strAddress))
            {
                MessageBox.Show("Address is a required field.", "Address Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (SpaceCheck(strAddress))
                {
                    return true;
                }
                else
                    return false;
            }
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
        internal static bool CityExist(string strCity)
        {
            if (string.IsNullOrEmpty(strCity))
            {
                MessageBox.Show("City is a required field.", "City Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (SpaceCheck(strCity))
                {
                    return true;
                }
                else
                    return false;
            }
        }

        //method for required field
        internal static bool StateExist(string strState)
        {
            if (string.IsNullOrEmpty(strState))
            {
                MessageBox.Show("State is a required field.", "State Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (SpaceCheck(strState))
                {
                    return true;
                }
                else
                    return false;
            }
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
        internal static bool ZipCodeMatch(string strZipCode)
        {
            string pattern = @"^\d{5}(?:[-\s]\d{4})?$";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(strZipCode))
            {
                return regex.IsMatch(strZipCode);
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

        //using regex
        internal static bool PhoneMatch(string strPhone)
        {
            string strPattern = @"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}";
            string strSpace = @"\s";

            Regex regexOne = new Regex(strPattern);
            Regex regexTwo = new Regex(strSpace);

            if (string.IsNullOrEmpty(strPhone))
            {
                return true;
            }
            else
            {
                if (regexTwo.IsMatch(strPhone))
                {
                    MessageBox.Show("Space is not an allowed entry.", "Phone Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (regexOne.IsMatch(strPhone))
                    {
                        return regexOne.IsMatch(strPhone);
                    }
                    else
                    {
                        MessageBox.Show("Phone was invalid. (see help)", "Phone Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }                
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
                if (SpaceCheck(ansOne) || SpaceCheck(ansTwo) || SpaceCheck(ansThr))
                {
                    return true;
                }
                else
                    return false;
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
                if (quesOne == "Please Select" || quesTwo == "Please Select" || quesThr == "Please Select")
                {
                    MessageBox.Show("Questions are a required field.", "Question Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
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
        internal static bool EmailMatch(string strEmail)
        {
            string strPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                            + "@"
                            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";

            Regex regex = new Regex(strPattern);

            if (regex.IsMatch(strEmail))
            {
                return regex.IsMatch(strEmail);
            }
            else
            {
                MessageBox.Show("Email was invalid. (see help)", "Email Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //method for required field
        internal static bool EmailExist(string strEmail)
        {
            if (string.IsNullOrEmpty(strEmail))
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
        internal static bool NameExist(string strFName, string strLName)
        {
            if (string.IsNullOrEmpty(strFName))
            {
                MessageBox.Show("First name is a required field.", "Name Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(strLName))
            {
                MessageBox.Show("Last name is a required field.", "Name Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (SpaceCheck(strFName))
                {
                    if (SpaceCheck(strLName))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
                
        }

        //method for all required fields
        internal static bool RequiredFields(string strNameF, string strNameL, string strAddress, string strCity, string strState, string strQues1, string strQues2, string strQues3, string strAns1, string strAns2, string strAns3)
        {
            if(AddressExist(strAddress))
            {
                if (CityExist(strCity))
                {
                    if (StateExist(strState))
                    {
                        if (NameExist(strNameF, strNameL))
                        {
                            if (QuestionExist(strQues1, strQues2, strQues3))
                            {
                                if (AnswerExist(strAns1, strAns2, strAns3))
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
