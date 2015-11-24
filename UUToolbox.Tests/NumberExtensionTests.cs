using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Collections.Generic;

namespace UUToolbox.Tests
{
    [TestClass]
    public class NumberExtensionTests
    {
        [TestMethod]
        public void TestNumberExtensionsSandbox()
        {
            // Test method for code fiddling
        }

        #region Byte Swapping

        [TestMethod]
        public void TestSwapByteOrder_ushort()
        {
            var testData = new List<Tuple<ushort, ushort>>()
            {
                new Tuple<ushort, ushort>(0xABCD, 0xCDAB),
                new Tuple<ushort, ushort>(0, 0),
                new Tuple<ushort, ushort>(0xFFFF, 0xFFFF),
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item2, td.Item1.UUSwapByteOrder(), "Expect byte swap to work for type {0}", td.Item1.GetType());
            }
        }

        [TestMethod]
        public void TestSwapByteOrder_uint()
        {
            var testData = new List<Tuple<uint, uint>>()
            {
                new Tuple<uint, uint>(0xABCD1234, 0x3412CDAB),
                new Tuple<uint, uint>(0, 0),
                new Tuple<uint, uint>(0xFFFFFFFF, 0xFFFFFFFF),
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item2, td.Item1.UUSwapByteOrder(), "Expect byte swap to work for type {0}", td.Item1.GetType());
            }
        }

        [TestMethod]
        public void TestSwapByteOrder_ulong()
        {
            var testData = new List<Tuple<ulong, ulong>>()
            {
                new Tuple<ulong, ulong>(0xABCDEF0123456789, 0x8967452301EFCDAB),
                new Tuple<ulong, ulong>(0, 0),
                new Tuple<ulong, ulong>(0xFFFFFFFFFFFFFFFF, 0xFFFFFFFFFFFFFFFF),
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item2, td.Item1.UUSwapByteOrder(), "Expect byte swap to work for type {0}", td.Item1.GetType());
            }
        }

        [TestMethod]
        public void TestSwapByteOrder_short()
        {
            var testData = new List<Tuple<short, short>>()
            {
                new Tuple<short, short>(0x1234, 0x3412),
                new Tuple<short, short>(0, 0),
                new Tuple<short, short>(0x7FFF, unchecked((short)0xFF7F)),
                new Tuple<short, short>(-0x8000, 0x0080),
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item2, td.Item1.UUSwapByteOrder(), "Expect byte swap to work for type {0}", td.Item1.GetType());
            }
        }

        [TestMethod]
        public void TestSwapByteOrder_int()
        {
            var testData = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0x12345678, 0x78563412),
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(0x7FFFFFFF, unchecked((int)0xFFFFFF7F)),
                new Tuple<int, int>(-0x80000000, 0x00000080),

            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item2, td.Item1.UUSwapByteOrder(), "Expect byte swap to work for type {0}", td.Item1.GetType());
            }
        }

        [TestMethod]
        public void TestSwapByteOrder_long()
        {
            var testData = new List<Tuple<long, long>>()
            {
                new Tuple<long, long>(0x1234567890123456, 0x5634129078563412),
                new Tuple<long, long>(0, 0),
                new Tuple<long, long>(0x7FFFFFFFFFFFFFFF, unchecked((long)0xFFFFFFFFFFFFFF7F)),
                new Tuple<long, long>(-0x8000000000000000, 0x0000000000000080),
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item2, td.Item1.UUSwapByteOrder(), "Expect byte swap to work for type {0}", td.Item1.GetType());
            }
        }

        #endregion

        #region Binary Coded Decimal

        [TestMethod]
        public void TestToBcd_byte()
        {
            var testData = new List<Tuple<byte, byte>>()
            {
                new Tuple<byte, byte>(0x01, 1),
                new Tuple<byte, byte>(0x02, 2),
                new Tuple<byte, byte>(0x03, 3),
                new Tuple<byte, byte>(0x04, 4),
                new Tuple<byte, byte>(0x05, 5),
                new Tuple<byte, byte>(0x06, 6),
                new Tuple<byte, byte>(0x07, 7),
                new Tuple<byte, byte>(0x08, 8),
                new Tuple<byte, byte>(0x09, 9),
                new Tuple<byte, byte>(0x10, 10),
                new Tuple<byte, byte>(0xC0, 120),
                new Tuple<byte, byte>(0x99, 99),
                new Tuple<byte, byte>(0xA0, 100),
                new Tuple<byte, byte>(0x0A, 10),

                new Tuple<byte, byte>(0xFF, 165), //0xF * 10 + 0xF * 1
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item2, td.Item1.UUToBcd(), "Expect ToBcd convert to work");
            }
        }

        [TestMethod]
        public void TestToBcd_ushort()
        {
            var testData = new List<Tuple<ushort, ushort>>()
            {
                // all the bcd8 inputs should work the same here...
                new Tuple<ushort, ushort>(0x01, 1),
                new Tuple<ushort, ushort>(0x02, 2),
                new Tuple<ushort, ushort>(0x03, 3),
                new Tuple<ushort, ushort>(0x04, 4),
                new Tuple<ushort, ushort>(0x05, 5),
                new Tuple<ushort, ushort>(0x06, 6),
                new Tuple<ushort, ushort>(0x07, 7),
                new Tuple<ushort, ushort>(0x08, 8),
                new Tuple<ushort, ushort>(0x09, 9),
                new Tuple<ushort, ushort>(0x10, 10),
                new Tuple<ushort, ushort>(0x99, 99),
                new Tuple<ushort, ushort>(0xA0, 100),
                new Tuple<ushort, ushort>(0x0A, 10),
                new Tuple<ushort, ushort>(0xC0, 120),
                new Tuple<ushort, ushort>(0xFF, 165), //0xF * 10 + 0xF * 1

                new Tuple<ushort, ushort>(0x800, 800),
                new Tuple<ushort, ushort>(0x9000, 9000),
                new Tuple<ushort, ushort>(0xABCD, 10000 + 1100 + 120 + 13), // (0xA * 1000) + (0xB * 100) + (0xC * 10) + (0xD * 1)
                new Tuple<ushort, ushort>(0x9999, 9999),
                new Tuple<ushort, ushort>(0xFFFF, 15000 + 1500 + 150 + 15),
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item2, td.Item1.UUToBcd(), "Expect bcd convert to work");
            }
        }

        [TestMethod]
        public void TestFromBcd_byte()
        {
            var testData = new List<Tuple<byte, byte>>()
            {
                new Tuple<byte, byte>(0x01, 1),
                new Tuple<byte, byte>(0x02, 2),
                new Tuple<byte, byte>(0x03, 3),
                new Tuple<byte, byte>(0x04, 4),
                new Tuple<byte, byte>(0x05, 5),
                new Tuple<byte, byte>(0x06, 6),
                new Tuple<byte, byte>(0x07, 7),
                new Tuple<byte, byte>(0x08, 8),
                new Tuple<byte, byte>(0x09, 9),
                new Tuple<byte, byte>(0x10, 10),

                new Tuple<byte, byte>(0x99, 99),
                new Tuple<byte, byte>(0, 100),
                new Tuple<byte, byte>(0, 105),

                new Tuple<byte, byte>(0, 120),
                
                new Tuple<byte, byte>(0, 165), // 165 / 10 = 16 = 0x0F shifted ==> 0xF0
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item1, td.Item2.UUFromBcd(), "Expect FromBcd convert to work");
            }
        }

        [TestMethod]
        public void TestFromBcd_ushort()
        {
            var testData = new List<Tuple<ushort, ushort>>()
            {
                new Tuple<ushort, ushort>(0x0100, 100),
                new Tuple<ushort, ushort>(0x0200, 200),
                new Tuple<ushort, ushort>(0x0300, 300),
                new Tuple<ushort, ushort>(0x0400, 400),
                new Tuple<ushort, ushort>(0x0500, 500),
                new Tuple<ushort, ushort>(0x0600, 600),
                new Tuple<ushort, ushort>(0x0700, 700),
                new Tuple<ushort, ushort>(0x0900, 900),
                new Tuple<ushort, ushort>(0x0800, 800),
                new Tuple<ushort, ushort>(0x1000, 1000),
                new Tuple<ushort, ushort>(0x9900, 9900),

                new Tuple<ushort, ushort>(0x0001, 1),
                new Tuple<ushort, ushort>(0x0002, 2),
                new Tuple<ushort, ushort>(0x0003, 3),
                new Tuple<ushort, ushort>(0x0004, 4),
                new Tuple<ushort, ushort>(0x0005, 5),
                new Tuple<ushort, ushort>(0x0006, 6),
                new Tuple<ushort, ushort>(0x0007, 7),
                new Tuple<ushort, ushort>(0x0009, 9),
                new Tuple<ushort, ushort>(0x0008, 8),
                new Tuple<ushort, ushort>(0x0010, 10),
                new Tuple<ushort, ushort>(0x0099, 99),
                
                new Tuple<ushort, ushort>(0x9000, 9000),
                new Tuple<ushort, ushort>(0x9999, 9999),
                
                // Anything over 9999 returns zero
                new Tuple<ushort, ushort>(0, 10000),
                new Tuple<ushort, ushort>(0, 10000 + 1100 + 120 + 13),
                
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item1, td.Item2.UUFromBcd(), "Expect FromBcd convert to work");
            }
        }

        [TestMethod]
        public void TestFromBcdToFrom()
        {
            var testData = new List<Tuple<ushort, ushort>>()
            {
                new Tuple<ushort, ushort>(0x0100, 100),
                new Tuple<ushort, ushort>(0x0200, 200),
                new Tuple<ushort, ushort>(0x0300, 300),
                new Tuple<ushort, ushort>(0x0400, 400),
                new Tuple<ushort, ushort>(0x0500, 500),
                new Tuple<ushort, ushort>(0x0600, 600),
                new Tuple<ushort, ushort>(0x0700, 700),
                new Tuple<ushort, ushort>(0x0900, 900),
                new Tuple<ushort, ushort>(0x0800, 800),
                new Tuple<ushort, ushort>(0x1000, 1000),
                new Tuple<ushort, ushort>(0x9900, 9900),

                new Tuple<ushort, ushort>(0x0001, 1),
                new Tuple<ushort, ushort>(0x0002, 2),
                new Tuple<ushort, ushort>(0x0003, 3),
                new Tuple<ushort, ushort>(0x0004, 4),
                new Tuple<ushort, ushort>(0x0005, 5),
                new Tuple<ushort, ushort>(0x0006, 6),
                new Tuple<ushort, ushort>(0x0007, 7),
                new Tuple<ushort, ushort>(0x0009, 9),
                new Tuple<ushort, ushort>(0x0008, 8),
                new Tuple<ushort, ushort>(0x0010, 10),
                new Tuple<ushort, ushort>(0x0099, 99),

                new Tuple<ushort, ushort>(0x9000, 9000),
                new Tuple<ushort, ushort>(0x9999, 9999),

            };

            foreach (var td in testData)
            {
                var toBcd = td.Item1.UUToBcd();
                Assert.AreEqual(td.Item2, toBcd);

                var fromBcd = toBcd.UUFromBcd();
                Assert.AreEqual(td.Item1, fromBcd, "Expect to/from BCD to work");
            }
        }

        #endregion
    }
}
