using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TechDistribution.VALIDATION
{
    public class Validator
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (!Regex.IsMatch(phoneNumber, @"^\(\d{3}\)\d{3}-\d{4}$"))
                return false;
            return true;
        }
        public static bool IsValidText(string text)
        {
            if (text.Length == 0)
                return false;
            else
                if (!Regex.IsMatch(text, @"^[A-Za-z]+$"))
                return false;
            return true;
        }
    }
}
