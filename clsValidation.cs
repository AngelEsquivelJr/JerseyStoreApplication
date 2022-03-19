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
            //A¶@123456
            //allow backspace to work
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //method to check username requirements
        internal static bool UsernameValidation(string strUsername)
        {
            //creates complexity counter
            int intComplextiyCtr = 0;
            bool bolHasSpecial = false;
            bool bolHasSpaces = false;
            string strSpace = " ";
            string strDisallowedKeys = @"()!@#$%^&*`¶¤§~-_=+{}£¥[]¢:;,<.>?¿/'µ\|±‡©®þ";

            //space characters
            foreach (char chLetter in strUsername)
            {
                if (strSpace.Contains(chLetter.ToString()))
                    bolHasSpaces = true;
            }

            if (bolHasSpaces)
            {
                MessageBox.Show("Username has spaces. Spaces are not allowed. (see help)", "Username Error",
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
            if (Char.IsDigit(strUsername[0]))
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
                if (strDisallowedKeys.Contains(chLetter.ToString()))
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

            //if complexity is greater than or equal to 3 it returns true
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
        internal static bool PasswordValidation(string strPassword)
        {
            //creates complexity counter
            int intComplextiyCtr = 0;
            bool bolHasSpecial = false;
            bool bolHasDisallowed = false;
            bool bolHasSpaces = false;
            string strAllowedKeys = "()!@#$%^&*";
            string strDisallowed = @"`¶¤§~-_=+{}£¥[]¢:;,<.>?¿/'µ\|±‡©®þ";
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
                MessageBox.Show("Fields entered can't be only white space.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        //method for address validation
        internal static void AddressAllowedKeys(KeyPressEventArgs e)
        {
            string strAllowedKeys = "/-:";

            //allow letters and numbers only
            //allow backspace and space to work
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) ||
                strAllowedKeys.Contains(e.KeyChar.ToString()))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //method for required field
        internal static bool AddressValidation(string strAddress)
        {
            if (string.IsNullOrEmpty(strAddress))
            {
                MessageBox.Show("Missing one or more required fields. ", "Error",
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
                {
                    return false;
                }

            }
        }

        //method for city validation
        internal static void CityAllowedKeys(KeyPressEventArgs e)
        {
            string strAllowedKeys = "-";

            //allow letters only
            //allow backspace and space to work
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) ||
                strAllowedKeys.Contains(e.KeyChar.ToString()))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //method for required field
        internal static bool CityValidation(string strCity)
        {
            if (string.IsNullOrEmpty(strCity))
            {
                MessageBox.Show("Missing one or more required fields. ", "Error",
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
                {
                    return false;
                }
            }
        }

        //method for required field
        internal static bool StateValidation(string strState)
        {
            if (string.IsNullOrEmpty(strState))
            {
                MessageBox.Show("Missing one or more required fields.", "Error",
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
                {
                    return false;
                }
            }
        }

        //methods for zipcode validation
        internal static void ZipAllowedKeys(KeyPressEventArgs e)
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
        internal static bool ZipCodeValidation(string strZipCode)
        {
            string pattern = @"^\d{5}(?:[-\s]\d{4})?$";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(strZipCode))
            {
                return regex.IsMatch(strZipCode);
            }
            else
            {
                MessageBox.Show("The zip code that was entered is invalid. Please try again.", "Zipcode Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //method for phone validation
        internal static void PhoneAllowedKeys(KeyPressEventArgs e)
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
        internal static bool PhoneValidation(string strPhone)
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
                        MessageBox.Show("The phone number that was entered is invalid. Please try again.", "Phone Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        //method for answers validation
        internal static void AnswerAllowedKeys(KeyPressEventArgs e)
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
        internal static bool AnswerValidation(string ansOne, string ansTwo, string ansThr)
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
                {
                    return false;
                }
            }
        }

        //method for required field
        internal static bool QuestionValidation(string quesOne, string quesTwo, string quesThr)
        {
            if (string.IsNullOrEmpty(quesOne) || string.IsNullOrEmpty(quesTwo) || string.IsNullOrEmpty(quesThr))
            {
                MessageBox.Show("Missing one or more required fields.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (quesOne == "Please Select" || quesTwo == "Please Select" || quesThr == "Please Select")
                {
                    MessageBox.Show("Missing one or more required fields.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                    return true;
            }

        }

        //method for email validation
        internal static void EmailAllowedKeys(KeyPressEventArgs e)
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

        //method for required field
        internal static bool CheckEmailExist(string strEmail)
        {
            if (string.IsNullOrEmpty(strEmail))
            {
                return false;
            }
            else
                return true;
        }

        //using regex
        internal static bool EmailValidation(string strEmail)
        {
            if (CheckEmailExist(strEmail))
            {
                string strPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-zA-Z]{2,4}[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

                Regex regex = new Regex(strPattern);

                if (regex.IsMatch(strEmail))
                {
                    return regex.IsMatch(strEmail);
                }
                else
                {
                    MessageBox.Show("The email address that was entered is invalid. Please try again.", "Email Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
        //methods for Credit Card Validation
        internal static void CardAllowedKeys(KeyPressEventArgs e)
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
        //methods for Expiration Validation
        internal static void ExpirationAllowedKeys(KeyPressEventArgs e)
        {
            string strAllowedKeys = "/";

            //allow numbers only
            //allow slashes only
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

        //methods for CCV Validation
        internal static void CCVAllowedKeys(KeyPressEventArgs e)
        {

            //allow numbers only
            //allow backspace to work
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //full card info validation
        internal static bool CardInfoValidation(string strCardNumber, string strExpiry, string strCcv)
        {
            var cardCheck = new Regex(@"^[1-9][0-9]{3}-[1-3]{4}-[0-9]{4}-[0-9]{4}$");
            var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
            var yearCheck = new Regex(@"^20[0-9]{2}$");
            var ccvCheck = new Regex(@"^\d{3}$");

            //check card number
            if (!cardCheck.IsMatch(strCardNumber))
            {
                MessageBox.Show("The card number that was entered is invalid. Please try again.", "Card Number Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //check ccv
            if (!ccvCheck.IsMatch(strCcv))
            {
                MessageBox.Show("The card verification number that was entered is invalid. Please try again.", "CCV Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //set expiration date as mm/yyyy
            var dateParts = strExpiry.Split('/');
            if (!monthCheck.IsMatch(dateParts[0]) || !yearCheck.IsMatch(dateParts[1]))
            {
                MessageBox.Show("The expiration date that was entered is invalid. Please try again.", "Expiration Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //vars for date
            int.TryParse(dateParts[1], out var year);
            int.TryParse(dateParts[0], out var month);
            //get expiration date
            var lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month);
            var cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);

            //check expiry greater than today & within next 5 years
            if (cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(5))
            {
                return true;
            }
            else
            {
                MessageBox.Show("The expiration date that was entered is invalid. Please try again.", "Expiration Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //method for required field
        internal static bool NameValidation(string strFName, string strLName)
        {
            if (string.IsNullOrEmpty(strFName))
            {
                MessageBox.Show("Missing one or more required fields.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(strLName))
            {
                MessageBox.Show("Missing one or more required fields. ", "Error",
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
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

        }

        //methods for all required fields
        internal static bool RequiredFields(string strNameF, string strNameL, string strAddress, string strCity, string strState)
        {
            if (NameValidation(strNameF, strNameL))
            {
                if (AddressValidation(strAddress))
                {
                    if (CityValidation(strCity))
                    {
                        if (StateValidation(strState))
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
            {
                return false;
            }
        }

        internal static bool RequiredFieldsTwo(string strQues1, string strQues2, string strQues3, string strAns1, string strAns2, string strAns3)
        {
            if (QuestionValidation(strQues1, strQues2, strQues3))
            {
                if (AnswerValidation(strAns1, strAns2, strAns3))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public struct StringParams
        {
            public string strUsername, strPassword, strAddress, strCity, strState, strZipCode, strPhone, strPhone2;
            public string strQuestion1, strQuestion2, strQuestion3, strAnswer1, strAnswer2, strAnswer3;
            public string strNameFirst, strNameLast, strEmail;
        }

        //method for calling all validations for signing up
        internal static bool Validate(StringParams strParams)
        {
            //check required fields
            if (RequiredFields(strParams.strNameFirst, strParams.strNameLast, strParams.strAddress, strParams.strCity, strParams.strState))
            {
                //check zip code
                if (ZipCodeValidation(strParams.strZipCode))
                {
                    //check phones
                    if (PhoneValidation(strParams.strPhone))
                    {
                        if (PhoneValidation(strParams.strPhone2))
                        {
                            //check email
                            if (EmailValidation(strParams.strEmail))
                            {
                                //check username
                                if (UsernameValidation(strParams.strUsername))
                                {
                                    //check password
                                    if (PasswordValidation(strParams.strPassword))
                                    {
                                        //check required fields
                                        if (RequiredFieldsTwo(strParams.strQuestion1, strParams.strQuestion2, strParams.strQuestion3, strParams.strAnswer1, strParams.strAnswer2, strParams.strAnswer3))
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
                        return false;
                }
                else
                    return false;
            }
            else
                return false;


        }

    }
}
