using System;
using System.Text;

/// <summary>
/// Useful Utilities
/// </summary>
/// <remarks>
/// LICENSE: You are free to use this code for whatever purposes you desire. The only requirement is that you smile everytime you use it. 
/// </remarks>
namespace UUToolbox
{
    /// <summary>
    /// Extensions methods on byte[] objects
    /// </summary>
    public static class UUByteArrayExtensions
    {
        #region Get Methods

        public static byte[] UUGetBytes(this byte[] obj, int index, int count)
        {
            byte[] result = null;

            if (obj != null && obj.Length >= (index + count))
            {
                result = new byte[count];
                Buffer.BlockCopy(obj, index, result, 0, count);
            }

            return result;
        }

        public static byte UUGetUInt8(this byte[] obj, int index)
        {
            byte result = 0;
            int dataSize = sizeof(byte);

            if (obj != null && obj.Length >= (index + dataSize))
            {
                result = obj[index];
            }

            return result;
        }
        
        public static ushort UUGetUInt16(this byte[] obj, int index)
        {
            ushort result = 0;
            int dataSize = sizeof(ushort);

            if (obj != null && obj.Length >= (index + dataSize))
            {
                result = BitConverter.ToUInt16(obj, index);
            }

            return result;
        }

        public static uint UUGetUInt32(this byte[] obj, int index)
        {
            uint result = 0;
            int dataSize = sizeof(uint);

            if (obj != null && obj.Length >= (index + dataSize))
            {
                result = BitConverter.ToUInt32(obj, index);
            }

            return result;
        }

        public static ulong UUGetUInt64(this byte[] obj, int index)
        {
            ulong result = 0;
            int dataSize = sizeof(ulong);

            if (obj != null && obj.Length >= (index + dataSize))
            {
                result = BitConverter.ToUInt64(obj, index);
            }

            return result;
        }

        public static sbyte UUGetInt8(this byte[] obj, int index)
        {
            sbyte result = 0;
            int dataSize = sizeof(sbyte);

            if (obj != null && obj.Length >= (index + dataSize))
            {
                result = (sbyte)obj[index];
            }

            return result;
        }

        public static short UUGetInt16(this byte[] obj, int index)
        {
            short result = 0;
            int dataSize = sizeof(short);

            if (obj != null && obj.Length >= (index + dataSize))
            {
                result = BitConverter.ToInt16(obj, index);
            }

            return result;
        }

        public static int UUGetInt32(this byte[] obj, int index)
        {
            int result = 0;
            int dataSize = sizeof(int);

            if (obj != null && obj.Length >= (index + dataSize))
            {
                result = BitConverter.ToInt32(obj, index);
            }

            return result;
        }

        public static long UUGetInt64(this byte[] obj, int index)
        {
            long result = 0;
            int dataSize = sizeof(long);

            if (obj != null && obj.Length >= (index + dataSize))
            {
                result = BitConverter.ToInt64(obj, index);
            }

            return result;
        }

        public static string UUGetString(this byte[] obj, int index, int size, Encoding encoding)
        {
            string result = string.Empty;

            if (obj != null && obj.Length >= (index + size))
            {
                int endIndex = index + size;
                int dataLength = obj.Length;
                int realSize = 0;

                for (int i = index; i < dataLength && i < endIndex && obj[i] != 0; i++)
                {
                    ++realSize;
                }

                byte[] subData = obj.UUGetBytes(index, realSize);
                result = new string(encoding.GetChars(subData));
            }

            return result;
        }
        
        #endregion

        #region Put Methods

        public static int UUPutBytes(this byte[] obj, byte[] data, int index)
        {
            int bytesCopied = 0;

            if (obj != null && data != null && ((index + data.Length) <= obj.Length))
            {
                Buffer.BlockCopy(data, 0, obj, index, data.Length);
                bytesCopied = data.Length;
            }

            return bytesCopied;
        }

        public static int UUPutUInt8(this byte[] obj, byte data, int index)
        {
            byte[] insert = new byte[] { data };
            return obj.UUPutBytes(insert, index);
        }

        public static int UUPutUInt16(this byte[] obj, ushort data, int index)
        {
            byte[] insert = BitConverter.GetBytes(data);
            return obj.UUPutBytes(insert, index);
        }

        public static int UUPutUInt32(this byte[] obj, uint data, int index)
        {
            byte[] insert = BitConverter.GetBytes(data);
            return obj.UUPutBytes(insert, index);
        }

        public static int UUPutUInt64(this byte[] obj, ulong data, int index)
        {
            byte[] insert = BitConverter.GetBytes(data);
            return obj.UUPutBytes(insert, index);
        }

        public static int UUPutInt8(this byte[] obj, sbyte data, int index)
        {
            byte[] insert = new byte[] { (byte)data };
            return obj.UUPutBytes(insert, index);
        }

        public static int UUPutInt16(this byte[] obj, short data, int index)
        {
            byte[] insert = BitConverter.GetBytes(data);
            return obj.UUPutBytes(insert, index);
        }

        public static int UUPutInt32(this byte[] obj, int data, int index)
        {
            byte[] insert = BitConverter.GetBytes(data);
            return obj.UUPutBytes(insert, index);
        }

        public static int UUPutInt64(this byte[] obj, long data, int index)
        {
            byte[] insert = BitConverter.GetBytes(data);
            return obj.UUPutBytes(insert, index);
        }

        public static void UUZeroBytes(this byte[] obj, int index, int length)
        {
            if (obj != null && index < obj.Length)
            {
                if ((index + length) > obj.Length)
                {
                    length = obj.Length - index;
                }

                Array.Clear(obj, index, length);
            }
        }

        public static int UUPutString(this byte[] obj, string data, int index, int fillSize, Encoding encoding)
        {
            int filled = 0;

            if (obj != null)
            {
                obj.UUZeroBytes(index, fillSize);
                
                byte[] dataBytes = encoding.GetBytes(data);
                
                if (dataBytes.Length > fillSize)
                {
                    dataBytes = dataBytes.UUGetBytes(0, fillSize);
                }

                obj.UUPutBytes(dataBytes, index);
                filled = fillSize;
            }

            return filled;
        }

        #endregion

        #region String Methods

        public static string UUToHexString(this byte[] obj)
        {
            StringBuilder sb = new StringBuilder();

            if (obj != null)
            {
                foreach (byte b in obj)
                {
                    sb.AppendFormat(null, "{0:X2}", b);
                }
            }

            return sb.ToString();
        }

        #endregion

        #region Index Methods

        public static int UUFirstIndexOf(this byte[] obj, int startIndex, int searchLimit, byte searchByte)
        {
            if ((startIndex + searchLimit) > obj.Length)
            {
                searchLimit = obj.Length - startIndex;
            }

            return Array.IndexOf(obj, searchByte, startIndex, searchLimit);
        }

        #endregion
    }
}
