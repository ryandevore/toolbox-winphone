using System;
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
    /// Extension methods for primitive integer types
    /// </summary>
    public static class UUNumberExtensions
    {
        #region Byte Order Swapping

        public static ulong UUSwapByteOrder(this ulong obj)
        {
            byte[] tmp = BitConverter.GetBytes(obj);
            return BitConverter.ToUInt64(tmp.Reverse().ToArray(), 0);
        }

        public static uint UUSwapByteOrder(this uint obj)
        {
            byte[] tmp = BitConverter.GetBytes(obj);
            return BitConverter.ToUInt32(tmp.Reverse().ToArray(), 0);
        }

        public static ushort UUSwapByteOrder(this ushort obj)
        {
            byte[] tmp = BitConverter.GetBytes(obj);
            return BitConverter.ToUInt16(tmp.Reverse().ToArray(), 0);
        }

        public static long UUSwapByteOrder(this long obj)
        {
            byte[] tmp = BitConverter.GetBytes(obj);
            return BitConverter.ToInt64(tmp.Reverse().ToArray(), 0);
        }

        public static int UUSwapByteOrder(this int obj)
        {
            byte[] tmp = BitConverter.GetBytes(obj);
            return BitConverter.ToInt32(tmp.Reverse().ToArray(), 0);
        }

        public static short UUSwapByteOrder(this short obj)
        {
            byte[] tmp = BitConverter.GetBytes(obj);
            return BitConverter.ToInt16(tmp.Reverse().ToArray(), 0);
        }

        #endregion

        #region Binary Coded Decimal

        public static byte UUToBcd(this byte obj)
        {
            byte result = 0;
            result += (byte)(((obj & 0xF0) >> 4) * 10);
            result += (byte)(((obj & 0x0F) >> 0) * 1);
            return result;
        }

        public static ushort UUToBcd(this ushort obj)
        {
            ushort result = 0;
            result += (ushort)(((obj & 0xF000) >> 12) * 1000);
            result += (ushort)(((obj & 0x0F00) >> 8 ) * 100);
            result += (ushort)(((obj & 0x00F0) >> 4 ) * 10);
            result += (ushort)(((obj & 0x000F) >> 0 ) * 1);
            return result;
        }

        public static byte UUFromBcd(this byte obj)
        {
            byte result = 0;

            if (obj >= 0 && obj <= 99)
            {
                result += (byte)((obj / 10) << 4);
                result += (byte)((obj % 10) << 0);
            }

            return result;
        }

        public static ushort UUFromBcd(this ushort obj)
        {
            int tmp = obj;
            int div = 1000;
            int dataSize = sizeof(ushort);
            byte[] buffer = new byte[dataSize];

            if (obj >= 0 && obj <= 9999)
            {
                for (int i = 0; i < dataSize; i++)
                {
                    buffer[i] = 0;

                    buffer[i] |= (byte)(((tmp / div) & 0xF) << 4);
                    tmp %= div;
                    div /= 10;

                    buffer[i] |= (byte)(((tmp / div) & 0xF) << 0);
                    tmp %= div;
                    div /= 10;
                }
            }

            return BitConverter.ToUInt16(buffer, 0).UUSwapByteOrder();
        }

        #endregion 
    }
}
