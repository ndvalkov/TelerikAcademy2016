namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        /// <summary>
        /// Transforms the given string to a hexadecimal string, using the MD5 encryption algorithm.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to be encrypted.</param>
        /// <returns>A <see cref="string"/> representing th md5 hash.</returns>
        public static string ToMd5Hash(this string value)
        {
            var md5Hash = MD5.Create();

            // Convert the value string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Converts the given string to its true/false-like equivalent.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to be converted.</param>
        /// <returns>A <see cref="bool"/> representing the true/false-like result.</returns>
        public static bool ToBoolean(this string value)
        {
            var stringTrueValues = new[] {"true", "ok", "yes", "1", "да"};
            return stringTrueValues.Contains(value.ToLower());
        }

        /// <summary>
        /// Converts the given string to a 16-bit signed integer.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to be converted.</param>
        /// <returns>A <see cref="short"/> representing the parsed value. </returns>
        public static short ToShort(this string value)
        {
            short shortValue;
            // Should throw the proper Exception if the parse is unsuccessful
            short.TryParse(value, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the given string to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to be converted.</param>
        /// <returns>A <see cref="int"/> representing the parsed value. </returns>
        public static int ToInteger(this string value)
        {
            int integerValue;
            // Should throw the proper Exception if the parse is unsuccessful
            int.TryParse(value, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the given string to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to be converted.</param>
        /// <returns>A <see cref="long"/> representing the parsed value. </returns>
        public static long ToLong(this string value)
        {
            long longValue;
            // Should throw the proper Exception if the parse is unsuccessful
            long.TryParse(value, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the given string to DateTime struct.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to be converted.</param>
        /// <returns>A <see cref="DateTime"/> representing the parsed value. </returns>
        public static DateTime ToDateTime(this string value)
        {
            DateTime dateTimeValue;
            // Should throw the proper Exception if the parse is unsuccessful
            DateTime.TryParse(value, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Returns the same string with the first character to upper case.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to be capitalized.</param>
        /// <returns>A <see cref="string"/> with the first character to upper case.</returns>
        public static string CapitalizeFirstCharacter(this string value)
        {
            // should throw an Exception if the argument is null
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var capitalizedFirst = value.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) +
                                   value.Substring(1, value.Length - 1);

            return capitalizedFirst;
        }

        /// <summary>
        /// Returns the string partial between the start and end substrings, starting from a given index.
        /// </summary>
        /// <param name="value">The target <see cref="string"/>.</param>
        /// <param name="start">Starting substring.</param>
        /// <param name="end">End substring.</param>
        /// <param name="from">The starting position.</param>
        /// <returns>A <see cref="string"/> representing the part between start and end.</returns>
        public static string GetStringBetween(this string value, string start,
            string end, int from = 0)
        {
            value = value.Substring(from);
            from = 0;

            if (!value.Contains(start) || !value.Contains(end))
            {
                return string.Empty;
            }

            // set the start position to the end of the starting string
            var startPosition = value.IndexOf(start, from, StringComparison.Ordinal) + start.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            // set the end position to the start of the ending string
            var endPosition = value.IndexOf(end, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            var stringBetween = value.Substring(startPosition, endPosition - startPosition);

            return stringBetween;
        }

        /// <summary>
        /// Converts the cyrilic letters to their latin equvalent.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to be converted.</param>
        /// <returns>A <see cref="string"/> representing the value converted to latin.</returns>
        public static string ConvertCyrillicToLatinLetters(this string value)
        {
            // TODO: Consider extracting as a constant field
            var _bulgarianLetters = new[]
            {
                "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
            };

            // TODO: Consider extracting as a constant field
            var _latinRepresentationsOfBulgarianLetters = new[]
            {
                "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
            };

            for (var i = 0; i < _bulgarianLetters.Length; i++)
            {
                value = value.Replace(_bulgarianLetters[i],
                    _latinRepresentationsOfBulgarianLetters[i]);
                value = value.Replace(_bulgarianLetters[i].ToUpper(),
                    _latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstCharacter());
            }

            return value;
        }

        /// <summary>
        /// Converts the latin letters to their cyrilic equvalent.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to be converted.</param>
        /// <returns>A <see cref="string"/> representing the value converted to cyrilic.</returns>
        public static string ConvertLatinToCyrillicLetters(this string value)
        {
            // TODO: Consider extracting as a constant field
            var _latinLetters = new[]
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

            // TODO: Consider extracting as a constant field
            var _bulgarianRepresentationOfLatinLetters = new[]
            {
                "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                "в", "ь", "ъ", "з"
            };

            for (int i = 0; i < _latinLetters.Length; i++)
            {
                value = value.Replace(_latinLetters[i],
                    _bulgarianRepresentationOfLatinLetters[i]);
                value = value.Replace(_latinLetters[i].ToUpper(),
                    _bulgarianRepresentationOfLatinLetters[i].ToUpper());
            }

            return value;
        }

        /// <summary>
        /// Converts the string value to a new string that adheres to the rules of a valid latin username.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to be converted.</param>
        /// <returns>A <see cref="string"/> representing the valid username.</returns>
        public static string ToValidLatinUsername(this string value)
        {
            value = value.ConvertCyrillicToLatinLetters();

            // TODO: Probabable incorrect regex pattern ...
            // Should clear everything except letters, digits, underscore and dot characters?
            // Currently leaves characters like '\' and ']', and should be [^a-zA-Z0-9_\.]+
            return Regex.Replace(value, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts the string value to a new string that adheres to the rules of a valid latin filename.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to be converted.</param>
        /// <returns>A <see cref="string"/> representing the value filename.</returns>
        public static string ToValidLatinFilename(this string value)
        {
            value = value.Replace(" ", "-").ConvertCyrillicToLatinLetters();

            // TODO: Probabable incorrect regex pattern ...
            // Should clear everything except letters, digits, underscore, dot, dash characters?
            // Currently leaves characters like '\' and ']', and should be [^a-zA-Z0-9_\.\-]+
            // '\' is not allowed in filenames
            return Regex.Replace(value, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Return a substring from the start of the value, with length equal to charsCount.
        /// If charsCount is equal or greater than the string value's length, will substring
        /// to the value's length.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to convert.</param>
        /// <param name="charsCount">The number of characters from the start.</param>
        /// <returns>A <see cref="string"/> representing the target number of characters from the start.</returns>
        public static string GetFirstCharacters(this string value, int charsCount)
        {
            return value.Substring(0, Math.Min(value.Length, charsCount));
        }

        /// <summary>
        /// Returns the file extension part of a given string value, if there is any.
        /// Otherwise, returns an empty string.
        /// </summary>
        /// <param name="value">The target <see cref="string"/>.</param>
        /// <returns>A <see cref="string"/> representing the file extension.</returns>
        public static string GetFileExtension(this string value)
        {
            // Should throw an Exception if value is null? OK to have this 'null' in extension method?
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            string[] fileParts = value.Split(new[] {"."}, StringSplitOptions.None);

            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the file content type of a given string value, if there is any.
        /// Otherwise, returns a default content type ("application/octet-stream").
        /// </summary>
        /// <param name="value">The target <see cref="string"/>.</param>
        /// <returns>A <see cref="string"/> representing the file content type.</returns>
        public static string GetContentType(this string value)
        {
            // TODO: Consider extracting as a constant field
            var _fileExtensionToContentType = new Dictionary<string, string>
            {
                {
                    "jpg",
                    "image/jpeg"
                },
                {
                    "jpeg",
                    "image/jpeg"
                },
                {
                    "png",
                    "image/x-png"
                },
                {
                    "docx",
                    "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                },
                {
                    "doc",
                    "application/msword"
                },
                {
                    "pdf",
                    "application/pdf"
                },
                {
                    "txt",
                    "value/plain"
                },
                {
                    "rtf",
                    "application/rtf"
                }
            };

            if (_fileExtensionToContentType.ContainsKey(value.Trim()))
            {
                return _fileExtensionToContentType[value.Trim()];
            }

            var defaultContentType = "application/octet-stream";

            return defaultContentType;
        }

        /// <summary>
        /// Copies the characters in the string value to a byte array, and return a reference to it.
        /// </summary>
        /// <param name="value">The target <see cref="string"/>.</param>
        /// <returns>A byte array representing the characters in the string value.</returns>
        public static byte[] ToByteArray(this string value)
        {
            var byteArray = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, byteArray, 0, byteArray.Length);
            return byteArray;
        }
    }
}