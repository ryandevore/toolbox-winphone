using System;
using System.Collections.Generic;

/// <summary>
/// Useful Utilities
/// </summary>
/// <remarks>
/// LICENSE: You are free to use this code for whatever purposes you desire. The only requirement is that you smile everytime you use it. 
/// </remarks>
namespace UUToolbox
{
    /// <summary>
    /// Extension methods for IDictionary 
    /// </summary>
    public static class UUDictionaryExtensions
    {
        /// <summary>
        /// Safely gets a dictionary value and converts to a UInt8
        /// </summary>
        /// <typeparam name="TKey">Dictionary Key type</typeparam>
        /// <typeparam name="TValue">Dictionary Value type</typeparam>
        /// <param name="obj">Dictionary to query</param>
        /// <param name="key">Lookup key</param>
        /// <param name="defaultValue">Default value returned of object cannot be converted to the proper type</param>
        /// <returns>Converted value or default</returns>
        public static byte UUSafeGetUInt8<TKey, TValue>(this IDictionary<TKey, TValue> obj, TKey key, byte defaultValue = 0)
        {
            var result = defaultValue;

            if (obj != null && obj.ContainsKey(key))
            {
                object val = obj[key];
                if (val is byte)
                {
                    result = (byte)val;
                }
                else if (val is string)
                {
                    result = ((string)val).UUToUInt8(defaultValue);
                }
                else
                {
                    try
                    {
                        result = Convert.ToByte(val);
                    }
                    catch
                    {
                        result = defaultValue;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Safely gets a dictionary value and converts to a UInt16
        /// </summary>
        /// <typeparam name="TKey">Dictionary Key type</typeparam>
        /// <typeparam name="TValue">Dictionary Value type</typeparam>
        /// <param name="obj">Dictionary to query</param>
        /// <param name="key">Lookup key</param>
        /// <param name="defaultValue">Default value returned of object cannot be converted to the proper type</param>
        /// <returns>Converted value or default</returns>
        public static ushort UUSafeGetUInt16<TKey, TValue>(this IDictionary<TKey, TValue> obj, TKey key, ushort defaultValue = 0)
        {
            var result = defaultValue;

            if (obj != null && obj.ContainsKey(key))
            {
                object val = obj[key];
                if (val is ushort)
                {
                    result = (ushort)val;
                }
                else if (val is string)
                {
                    result = ((string)val).UUToUInt16(defaultValue);
                }
                else
                {
                    try
                    {
                        result = Convert.ToUInt16(val);
                    }
                    catch
                    {
                        result = defaultValue;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Safely gets a dictionary value and converts to a UInt32
        /// </summary>
        /// <typeparam name="TKey">Dictionary Key type</typeparam>
        /// <typeparam name="TValue">Dictionary Value type</typeparam>
        /// <param name="obj">Dictionary to query</param>
        /// <param name="key">Lookup key</param>
        /// <param name="defaultValue">Default value returned of object cannot be converted to the proper type</param>
        /// <returns>Converted value or default</returns>
        public static uint UUSafeGetUInt32<TKey, TValue>(this IDictionary<TKey, TValue> obj, TKey key, uint defaultValue = 0)
        {
            var result = defaultValue;

            if (obj != null && obj.ContainsKey(key))
            {
                object val = obj[key];
                if (val is uint)
                {
                    result = (uint)val;
                }
                else if (val is string)
                {
                    result = ((string)val).UUToUInt32(defaultValue);
                }
                else
                {
                    try
                    {
                        result = Convert.ToUInt32(val);
                    }
                    catch
                    {
                        result = defaultValue;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Safely gets a dictionary value and converts to a UInt64
        /// </summary>
        /// <typeparam name="TKey">Dictionary Key type</typeparam>
        /// <typeparam name="TValue">Dictionary Value type</typeparam>
        /// <param name="obj">Dictionary to query</param>
        /// <param name="key">Lookup key</param>
        /// <param name="defaultValue">Default value returned of object cannot be converted to the proper type</param>
        /// <returns>Converted value or default</returns>
        public static ulong UUSafeGetUInt64<TKey, TValue>(this IDictionary<TKey, TValue> obj, TKey key, ulong defaultValue = 0)
        {
            var result = defaultValue;

            if (obj != null && obj.ContainsKey(key))
            {
                object val = obj[key];
                if (val is ulong)
                {
                    result = (ulong)val;
                }
                else if (val is string)
                {
                    result = ((string)val).UUToUInt64(defaultValue);
                }
                else
                {
                    try
                    {
                        result = Convert.ToUInt64(val);
                    }
                    catch
                    {
                        result = defaultValue;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Safely gets a dictionary value and converts to a Int8
        /// </summary>
        /// <typeparam name="TKey">Dictionary Key type</typeparam>
        /// <typeparam name="TValue">Dictionary Value type</typeparam>
        /// <param name="obj">Dictionary to query</param>
        /// <param name="key">Lookup key</param>
        /// <param name="defaultValue">Default value returned of object cannot be converted to the proper type</param>
        /// <returns>Converted value or default</returns>
        public static sbyte UUSafeGetInt8<TKey, TValue>(this IDictionary<TKey, TValue> obj, TKey key, sbyte defaultValue = 0)
        {
            var result = defaultValue;

            if (obj != null && obj.ContainsKey(key))
            {
                object val = obj[key];
                if (val is sbyte)
                {
                    result = (sbyte)val;
                }
                else if (val is string)
                {
                    result = ((string)val).UUToInt8(defaultValue);
                }
                else
                {
                    try
                    {
                        result = Convert.ToSByte(val);
                    }
                    catch
                    {
                        result = defaultValue;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Safely gets a dictionary value and converts to a Int16
        /// </summary>
        /// <typeparam name="TKey">Dictionary Key type</typeparam>
        /// <typeparam name="TValue">Dictionary Value type</typeparam>
        /// <param name="obj">Dictionary to query</param>
        /// <param name="key">Lookup key</param>
        /// <param name="defaultValue">Default value returned of object cannot be converted to the proper type</param>
        /// <returns>Converted value or default</returns>
        public static short UUSafeGetInt16<TKey, TValue>(this IDictionary<TKey, TValue> obj, TKey key, short defaultValue = 0)
        {
            var result = defaultValue;

            if (obj != null && obj.ContainsKey(key))
            {
                object val = obj[key];
                if (val is short)
                {
                    result = (short)val;
                }
                else if (val is string)
                {
                    result = ((string)val).UUToInt16(defaultValue);
                }
                else
                {
                    try
                    {
                        result = Convert.ToInt16(val);
                    }
                    catch
                    {
                        result = defaultValue;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Safely gets a dictionary value and converts to a Int32
        /// </summary>
        /// <typeparam name="TKey">Dictionary Key type</typeparam>
        /// <typeparam name="TValue">Dictionary Value type</typeparam>
        /// <param name="obj">Dictionary to query</param>
        /// <param name="key">Lookup key</param>
        /// <param name="defaultValue">Default value returned of object cannot be converted to the proper type</param>
        /// <returns>Converted value or default</returns>
        public static int UUSafeGetInt32<TKey, TValue>(this IDictionary<TKey, TValue> obj, TKey key, int defaultValue = 0)
        {
            var result = defaultValue;

            if (obj != null && obj.ContainsKey(key))
            {
                object val = obj[key];
                if (val is int)
                {
                    result = (int)val;
                }
                else if (val is string)
                {
                    result = ((string)val).UUToInt32(defaultValue);
                }
                else
                {
                    try
                    {
                        result = Convert.ToInt32(val);
                    }
                    catch
                    {
                        result = defaultValue;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Safely gets a dictionary value and converts to a Int64
        /// </summary>
        /// <typeparam name="TKey">Dictionary Key type</typeparam>
        /// <typeparam name="TValue">Dictionary Value type</typeparam>
        /// <param name="obj">Dictionary to query</param>
        /// <param name="key">Lookup key</param>
        /// <param name="defaultValue">Default value returned of object cannot be converted to the proper type</param>
        /// <returns>Converted value or default</returns>
        public static long UUSafeGetInt64<TKey, TValue>(this IDictionary<TKey, TValue> obj, TKey key, long defaultValue = 0)
        {
            var result = defaultValue;

            if (obj != null && obj.ContainsKey(key))
            {
                object val = obj[key];
                if (val is long)
                {
                    result = (long)val;
                }
                else if (val is string)
                {
                    result = ((string)val).UUToInt64(defaultValue);
                }
                else
                {
                    try
                    {
                        result = Convert.ToInt64(val);
                    }
                    catch
                    {
                        result = defaultValue;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Safely gets a dictionary value and converts to a string
        /// </summary>
        /// <typeparam name="TKey">Dictionary Key type</typeparam>
        /// <typeparam name="TValue">Dictionary Value type</typeparam>
        /// <param name="obj">Dictionary to query</param>
        /// <param name="key">Lookup key</param>
        /// <param name="defaultValue">Default value returned of object cannot be converted to the proper type</param>
        /// <returns>Converted value or default</returns>
        public static string UUSafeGetString<TKey, TValue>(this IDictionary<TKey, TValue> obj, TKey key, string defaultValue = "")
        {
            var result = defaultValue;

            if (obj != null && obj.ContainsKey(key))
            {
                object val = obj[key];
                if (val is string)
                {
                    result = (string)val;
                }
            }

            return result;
        }
    }
}