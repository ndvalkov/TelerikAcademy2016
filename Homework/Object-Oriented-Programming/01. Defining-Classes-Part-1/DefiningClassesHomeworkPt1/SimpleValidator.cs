using System;
using System.Text.RegularExpressions;

static class SimpleValidator
{
    const string nullOrEmptyMsg = "Cannot be null or empty";
    const string nullOrWhiteSpaceMsg = "Cannot be null or white space";
    const string zeroOrLessMsg = "Cannot be equal or less than 0";
    const string enumRangeMsg = "Cannot be a value outside the specified enum range";
    const string invalidDateTimeMsg = "Cannot be a value outside the specified time boundaries";
    const string invalidPhoneMsg = "Must be a valid phone number";

    
    public static void CheckNullOrEmpty(string argValue, string argName)
    {
        if (string.IsNullOrEmpty(argValue))
        {
            throw new ArgumentException(nullOrEmptyMsg, argName);
        }
    }

    public static void CheckNullOrWhiteSpace(string argValue, string argName)
    {
        if (string.IsNullOrWhiteSpace(argValue))
        {
            throw new ArgumentException(nullOrWhiteSpaceMsg, argName);
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
            throw new ArgumentException(zeroOrLessMsg, argName);
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
                enumRangeMsg);
        }
    }

    public static void CheckDateTimeIsValid(DateTime argValue, string argName)
    {
        if (argValue.Year < 1900 || argValue.Year > DateTime.Today.Year)
        {
            throw new ArgumentOutOfRangeException(
                argName,
                argValue,
                invalidDateTimeMsg);
        }
    }

    public static void CheckPhoneNumberIsValid(string argValue, string argName)
    {
        if (!Regex.Match(argValue, @"^\+?[0-9]+(\([0-9]+\))?[0-9-]*[0-9]$").Success)
        {
            throw new ArgumentException(invalidPhoneMsg, argName);
        }
    }
}
