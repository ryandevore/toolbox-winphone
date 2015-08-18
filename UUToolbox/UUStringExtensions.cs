using System;
using System.Globalization;
using System.Linq;

/// <summary>
/// Useful Utilities
/// </summary>
/// <remarks>
/// LICENSE: You are free to use this code for whatever purposes you desire. The only requirement is that you smile everytime you use it. 
/// </remarks>
namespace UUToolbox
{
    /// <summary>
    /// Extension methods for String 
    /// </summary>
    public static class UUStringExtensions
    {
        #region Constants

        private const string kUUValidHexDigits = @"0123456789ABCDEF";

        #endregion

        #region Validation Methods

        /// <summary>
        /// Checks to see if a character is a valid Hex digit: 0-9, a-f, A-F
        /// </summary>
        /// <param name="c">The character to check.</param>
        /// <returns>True if the character is in the following set: 0-9, a-f, A-F</returns>
        public static bool UUIsHexChar(this char c)
        {
            return ((c >= '0' && c <= '9') ||
                    (c >= 'A' && c <= 'F') ||
                    (c >= 'a' && c <= 'f'));
        }

        /// <summary>
        /// Checks to see if a string contains all hex digits.
        /// </summary>
        /// <param name="obj">The string to check<param>
        /// <returns>True if the string is not null or empty and every character is a valid hex character.</returns>
        public static bool UUIsHexString(this string obj)
        {
            if (string.IsNullOrEmpty(obj))
            {
                return false;
            }
            
            foreach (char c in obj.ToCharArray())
            {
                if (!c.UUIsHexChar())
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks to see if a string contains all number digits
        /// </summary>
        /// <param name="obj">The string to check<param>
        /// <returns>True if the string is not null or empty and every character is a valid number character.</returns>
        public static bool UUIsDigitString(this string obj)
        {
            if (string.IsNullOrEmpty(obj))
            {
                return false;
            }

            foreach (char c in obj.ToCharArray())
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        /// Converts a string of hex characters into a byte array
        /// </summary>
        /// <param name="obj">The string to convert</param>
        /// <returns>A byte array</returns>
        /// <remarks>Input string must be all hex characters and Length must be divisible by two.</remarks>
        public static byte[] UUToHexData(this string obj)
        {
            byte[] buffer = null;

            if (obj != null && (obj.Length % 2 == 0) && obj.UUIsHexString())
            {
                buffer = new byte[obj.Length / 2];
                for (int i = 0; i < buffer.Length; i++)
                {
                    buffer[i] = byte.Parse(obj.Substring((i * 2), 2), NumberStyles.HexNumber, null);
                }
            }

            return buffer;
        }
        
        /// <summary>
        /// Safely converts a string to a byte
        /// </summary>
        /// <param name="obj">The string to convert</param>
        /// <param name="defaultVal">Default value returned if parsing fails.</param>
        /// <returns>Parsed value or default if parsing fails.</returns>
        public static byte UUToUInt8(this string obj, byte defaultVal = 0)
        {
            byte result = defaultVal;
            if (!byte.TryParse(obj, out result))
            {
                result = defaultVal;
            }

            return result;
        }

        /// <summary>
        /// Safely converts a string to a ushort
        /// </summary>
        /// <param name="obj">The string to convert</param>
        /// <param name="defaultVal">Default value returned if parsing fails.</param>
        /// <returns>Parsed value or default if parsing fails.</returns>
        public static ushort UUToUInt16(this string obj, ushort defaultVal = 0)
        {
            ushort result = defaultVal;
            if (!ushort.TryParse(obj, out result))
            {
                result = defaultVal;
            }

            return result;
        }

        /// <summary>
        /// Safely converts a string to a uint
        /// </summary>
        /// <param name="obj">The string to convert</param>
        /// <param name="defaultVal">Default value returned if parsing fails.</param>
        /// <returns>Parsed value or default if parsing fails.</returns>
        public static uint UUToUInt32(this string obj, uint defaultVal = 0)
        {
            uint result = defaultVal;
            if (!uint.TryParse(obj, out result))
            {
                result = defaultVal;
            }

            return result;
        }

        /// <summary>
        /// Safely converts a string to a ulong
        /// </summary>
        /// <param name="obj">The string to convert</param>
        /// <param name="defaultVal">Default value returned if parsing fails.</param>
        /// <returns>Parsed value or default if parsing fails.</returns>
        public static ulong UUToUInt64(this string obj, ulong defaultVal = 0)
        {
            ulong result = defaultVal;
            if (!ulong.TryParse(obj, out result))
            {
                result = defaultVal;
            }

            return result;
        }

        /// <summary>
        /// Safely converts a string to an sbyte
        /// </summary>
        /// <param name="obj">The string to convert</param>
        /// <param name="defaultVal">Default value returned if parsing fails.</param>
        /// <returns>Parsed value or default if parsing fails.</returns>
        public static sbyte UUToInt8(this string obj, sbyte defaultVal = 0)
        {
            sbyte result = defaultVal;
            if (!sbyte.TryParse(obj, out result))
            {
                result = defaultVal;
            }

            return result;
        }

        /// <summary>
        /// Safely converts a string to a short
        /// </summary>
        /// <param name="obj">The string to convert</param>
        /// <param name="defaultVal">Default value returned if parsing fails.</param>
        /// <returns>Parsed value or default if parsing fails.</returns>
        public static short UUToInt16(this string obj, short defaultVal = 0)
        {
            short result = defaultVal;
            if (!short.TryParse(obj, out result))
            {
                result = defaultVal;
            }

            return result;
        }

        /// <summary>
        /// Safely converts a string to an int
        /// </summary>
        /// <param name="obj">The string to convert</param>
        /// <param name="defaultVal">Default value returned if parsing fails.</param>
        /// <returns>Parsed value or default if parsing fails.</returns>
        public static int UUToInt32(this string obj, int defaultVal = 0)
        {
            int result = defaultVal;
            if (!int.TryParse(obj, out result))
            {
                result = defaultVal;
            }

            return result;
        }

        /// <summary>
        /// Safely converts a string to a long
        /// </summary>
        /// <param name="obj">The string to convert</param>
        /// <param name="defaultVal">Default value returned if parsing fails.</param>
        /// <returns>Parsed value or default if parsing fails.</returns>
        public static long UUToInt64(this string obj, long defaultVal = 0)
        {
            long result = defaultVal;
            if (!long.TryParse(obj, out result))
            {
                result = defaultVal;
            }

            return result;
        }

        /// <summary>
        /// Safely converts a string to a DateTime
        /// </summary>
        /// <param name="obj">The string to convert.</param>
        /// <param name="formats">Array of date format strings. If non null TryParseExact is used. If null, TryParse is used.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="dateTimeStyles">DateTime style options.</param>
        /// <returns>Parsed value or default if parsing fails</returns>
        public static DateTime? UUToDateTime(this string obj, string[] formats = null, DateTime? defaultValue = null, IFormatProvider formatProvider = null, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
        {
            DateTime? dt = defaultValue;

            if (!string.IsNullOrEmpty(obj))
            {
                DateTime outDate;

                if (formats != null && formats.Length > 0)
                {
                    if (DateTime.TryParseExact(obj, formats, formatProvider, dateTimeStyles, out outDate))
                    {
                        dt = outDate;
                    }
                }
                else
                {
                    if (DateTime.TryParse(obj, formatProvider, dateTimeStyles, out outDate))
                    {
                        dt = outDate;
                    }
                }
            }

            return dt;
        }

        #endregion
    }
}