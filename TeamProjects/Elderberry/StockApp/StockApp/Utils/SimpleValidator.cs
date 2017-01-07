using System;
using System.Text.RegularExpressions;

namespace DefiningClasses
{
    static class SimpleValidator
    {
        const string NullOrEmptyMsg = "Cannot be null or empty";
        const string NullOrWhiteSpaceMsg = "Cannot be null or white space";
        const string ZeroOrLessMsg = "Cannot be equal or less than 0";
        const string EnumRangeMsg = "Cannot be a value outside the specified enum range";
        const string InvalidDateTimeMsg = "Cannot be a value outside the specified time boundaries";
        const string InvalidPhoneMsg = "Must be a valid phone number";


        public static void CheckNullOrEmpty(string argValue, string argName)
        {
            if (string.IsNullOrEmpty(argValue))
            {
                throw new ArgumentException(NullOrEmptyMsg, argName);
            }
        }

        public static void CheckNullOrWhiteSpace(string argValue, string argName)
        {
            if (string.IsNullOrWhiteSpace(argValue))
            {
                throw new ArgumentException(NullOrWhiteSpaceMsg, argName);
            }
        }

        public static void CheckNull<T>(T argValue, string argName)
        {
            if (argValue == null)
            {
                throw new ArgumentNullException(argName);
            }
        }

        public static void CheckNotPositive(decimal argValue, string argName)
        {
            if (argValue <= 0)
            {
                throw new ArgumentException(ZeroOrLessMsg, argName);
            }
        }

        public static void CheckInEnumRange(Type enumType, int argValue, string argName)
        {
            bool defined = Enum.IsDefined(enumType, argValue);

            if (!defined)
            {
                throw new ArgumentOutOfRangeException(
                    argName,
                    argValue,
                    EnumRangeMsg);
            }
        }

        public static void CheckDateTimeIsValid(DateTime argValue, string argName)
        {
            if (argValue.Year < 1900 || argValue.Year > DateTime.Today.Year)
            {
                throw new ArgumentOutOfRangeException(
                    argName,
                    argValue,
                    InvalidDateTimeMsg);
            }
        }

        public static void CheckPhoneNumberIsValid(string argValue, string argName)
        {
            if (!Regex.Match(argValue, @"^\+?[0-9]+(\([0-9]+\))?[0-9-]*[0-9]$").Success)
            {
                throw new ArgumentException(InvalidPhoneMsg, argName);
            }
        }
    }
}