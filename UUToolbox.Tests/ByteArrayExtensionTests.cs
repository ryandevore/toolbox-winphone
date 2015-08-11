using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UUToolbox.Tests
{
    [TestClass]
    public class ByteArrayExtensionTests
    {
        #region Get Tests

        [TestMethod]
        public void TestGet_byteArray()
        {
            var testData = new List<Tuple<byte[], int, int, byte[]>>()
            {
                Tuple.Create(new byte[] { 0x00 }, 0, 1, new byte[] { 0x00 }),
                Tuple.Create(new byte[] { 0xFF }, 0, 1, new byte[] { 0xFF }),
                Tuple.Create(new byte[] { 0x01, 0x09, 0x0F }, 1, 1, new byte[] { 0x09 }),

                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF }, 2, 4, new byte[] { 0x56, 0x78, 0x90, 0xAB }),
                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF }, 5, 3, new byte[] { 0xAB, 0xCD, 0xEF }),
                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF }, 1, 6, new byte[] { 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD }),
                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF }, 3, 5, new byte[] { 0x78, 0x90, 0xAB, 0xCD, 0xEF }),


                // Out of bounds cases. Will return null
                Tuple.Create<byte[], int, int, byte[]>(new byte[] { 0x57 }, 5, 1, null),
                Tuple.Create<byte[], int, int, byte[]>(new byte[] { 0x0A, 0x0B, 0x0C, 0x0D }, 1, 5, null),
            };

            foreach (var td in testData)
            {
                byte[] actual = td.Item1.UUGetBytes(td.Item2, td.Item3);
                CollectionAssert.AreEqual(td.Item4, actual, "Expect UUGetBytes to work");
            }
        }

        [TestMethod]
        public void TestGet_byte()
        {
            var testData = new List<Tuple<byte[], int, byte>>()
            {
                Tuple.Create(new byte[] { 0x00 }, 0, (byte)0),
                Tuple.Create(new byte[] { 0xFF }, 0, (byte)0xFF),
                Tuple.Create(new byte[] { 0x01, 0x09, 0x0F }, 1, (byte)0x09),

                // Out of bounds cases. Will return 0
                Tuple.Create(new byte[] { 0x57 }, 5, (byte)0),
                Tuple.Create(new byte[] { 0x0A, 0x0B, 0x0C, 0x0D }, 5, (byte)0),
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, td.Item1.UUGetUInt8(td.Item2), "Expect Get_{0} to work", td.Item3.GetType());
            }
        }

        [TestMethod]
        public void TestGet_ushort()
        {
            var testData = new List<Tuple<byte[], int, ushort>>()
            {
                Tuple.Create(new byte[] { 0xFF, 0xFF }, 0, (ushort)0xFFFF),
                Tuple.Create(new byte[] { 0x00, 0x00 }, 0, (ushort)0x0000),
                Tuple.Create(new byte[] { 0x12, 0x34 }, 0, (ushort)0x3412),
                Tuple.Create(new byte[] { 0xAB, 0xCD }, 0, (ushort)0xCDAB),
                Tuple.Create(new byte[] { 0x00, 0x80 }, 0, (ushort)0x8000),
                Tuple.Create(new byte[] { 0xFF, 0x7F }, 0, (ushort)0x7FFF),

                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90 }, 3, (ushort)0x9078),
                Tuple.Create(new byte[] { 0xAB, 0xCD, 0xEF, 0xFE, 0xDC }, 1, (ushort)0xEFCD),

                // Out of bounds cases. Will return 0
                Tuple.Create(new byte[] { 0xFF, 0xFF }, 1, (ushort)0), // overlap
                Tuple.Create(new byte[] { 0x00, 0x00 }, 2, (ushort)0), // completely out of range
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, td.Item1.UUGetUInt16(td.Item2), "Expect Get_{0} to work", td.Item3.GetType());
            }
        }

        [TestMethod]
        public void TestGet_uint()
        {
            var testData = new List<Tuple<byte[], int, uint>>()
            {
                Tuple.Create(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, (uint)0xFFFFFFFF),
                Tuple.Create(new byte[] { 0x00, 0x00, 0x00, 0x00 }, 0, (uint)0x00000000),
                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78 }, 0, (uint)0x78563412),
                Tuple.Create(new byte[] { 0xAB, 0xCD, 0xEF, 0x12 }, 0, (uint)0x12EFCDAB),
                Tuple.Create(new byte[] { 0x00, 0x00, 0x00, 0x80 }, 0, (uint)0x80000000),
                Tuple.Create(new byte[] { 0xFF, 0xFF, 0xFF, 0x7F }, 0, (uint)0x7FFFFFFF),

                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF }, 4, (uint)0xEFCDAB90),
                Tuple.Create(new byte[] { 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0x12, 0x34, 0x56 }, 1, (uint)0xDCFEEFCD),

                // Out of bounds cases. Will return 0
                Tuple.Create(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }, 1, (uint)0), // overlap
                Tuple.Create(new byte[] { 0x00, 0x00, 0x00, 0x00 }, 5, (uint)0), // completely out of range
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, td.Item1.UUGetUInt32(td.Item2), "Expect Get_{0} to work", td.Item3.GetType());
            }
        }

        [TestMethod]
        public void TestGet_ulong()
        {
            var testData = new List<Tuple<byte[], int, ulong>>()
            {
                Tuple.Create(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, 0, (ulong)0xFFFFFFFFFFFFFFFF),
                Tuple.Create(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, 0, (ulong)0x0000000000000000),
                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78, 0xAB, 0xCD, 0xEF, 0x99 }, 0, (ulong)0x99EFCDAB78563412),
                Tuple.Create(new byte[] { 0xAB, 0xCD, 0xEF, 0x12, 0x12, 0x34, 0x56, 0x78 }, 0, (ulong)0x7856341212EFCDAB),
                Tuple.Create(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, 0, (ulong)0x8000000000000000),
                Tuple.Create(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F }, 0, (ulong)0x7FFFFFFFFFFFFFFF),

                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF }, 8, (ulong)0xEFCDAB9078563412),
                Tuple.Create(new byte[] { 0xAB, 0xEF, 0xBE, 0xAD, 0xDE, 0x0D, 0xF0, 0xAD, 0x8B, 0x34, 0x56, 0x78, 0x90, 0xCD, 0xEF, 0x12 }, 1, (ulong)0x8BADF00DDEADBEEF),

                // Out of bounds cases. Will return 0
                Tuple.Create(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, 1, (ulong)0), // overlap
                Tuple.Create(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, 9, (ulong)0), // completely out of range
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, td.Item1.UUGetUInt64(td.Item2), "Expect Get_{0} to work", td.Item3.GetType());
            }
        }

        [TestMethod]
        public void TestGet_sbyte()
        {
            var testData = new List<Tuple<byte[], int, sbyte>>()
            {
                Tuple.Create(new byte[] { 0x00 }, 0, (sbyte)0),
                Tuple.Create(new byte[] { 0xFF }, 0, (sbyte)-1),
                Tuple.Create(new byte[] { 0x01, 0x09, 0x0F }, 1, (sbyte)0x09),

                // Out of bounds cases. Will return 0
                Tuple.Create(new byte[] { 0x57 }, 5, (sbyte)0),
                Tuple.Create(new byte[] { 0x0A, 0x0B, 0x0C, 0x0D }, 5, (sbyte)0),
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, td.Item1.UUGetInt8(td.Item2), "Expect Get_{0} to work", td.Item3.GetType());
            }
        }

        [TestMethod]
        public void TestGet_short()
        {
            var testData = new List<Tuple<byte[], int, short>>()
            {
                Tuple.Create(new byte[] { 0xFF, 0xFF }, 0, (short)-1),
                Tuple.Create(new byte[] { 0x00, 0x00 }, 0, (short)0x0000),
                Tuple.Create(new byte[] { 0x12, 0x34 }, 0, (short)0x3412),
                Tuple.Create(new byte[] { 0x00, 0x80 }, 0, (short)-0x8000),
                Tuple.Create(new byte[] { 0xFF, 0x7F }, 0, (short)0x7FFF),

                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90 }, 2, (short)0x7856),
                Tuple.Create(new byte[] { 0xAB, 0xCD, 0xEF, 0xFE, 0xDC }, 1, unchecked((short)0xEFCD)),

                // Out of bounds cases. Will return 0
                Tuple.Create(new byte[] { 0xFF, 0xFF }, 1, (short)0), // overlap
                Tuple.Create(new byte[] { 0x00, 0x00 }, 2, (short)0), // completely out of range
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, td.Item1.UUGetInt16(td.Item2), "Expect Get_{0} to work", td.Item3.GetType());
            }
        }

        [TestMethod]
        public void TestGet_int()
        {
            var testData = new List<Tuple<byte[], int, int>>()
            {
                Tuple.Create(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, (int)-1),
                Tuple.Create(new byte[] { 0x00, 0x00, 0x00, 0x00 }, 0, (int)0x00000000),
                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78 }, 0, (int)0x78563412),
                Tuple.Create(new byte[] { 0xAB, 0xCD, 0xEF, 0x12 }, 0, (int)0x12EFCDAB),
                Tuple.Create(new byte[] { 0x00, 0x00, 0x00, 0x80 }, 0, (int)-0x80000000),
                Tuple.Create(new byte[] { 0xFF, 0xFF, 0xFF, 0x7F }, 0, (int)0x7FFFFFFF),

                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF }, 4, unchecked((int)0xEFCDAB90)),
                Tuple.Create(new byte[] { 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0x12, 0x34, 0x56 }, 1, unchecked((int)0xDCFEEFCD)),

                // Out of bounds cases. Will return 0
                Tuple.Create(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }, 1, (int)0), // overlap
                Tuple.Create(new byte[] { 0x00, 0x00, 0x00, 0x00 }, 5, (int)0), // completely out of range
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, td.Item1.UUGetInt32(td.Item2), "Expect Get_{0} to work", td.Item3.GetType());
            }
        }

        [TestMethod]
        public void TestGet_long()
        {
            var testData = new List<Tuple<byte[], int, long>>()
            {
                Tuple.Create(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, 0, (long)-1),
                Tuple.Create(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, 0, (long)0x0000000000000000),
                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78, 0xAB, 0xCD, 0xEF, 0x99 }, 0, unchecked((long)0x99EFCDAB78563412)),
                Tuple.Create(new byte[] { 0xAB, 0xCD, 0xEF, 0x12, 0x12, 0x34, 0x56, 0x78 }, 0, (long)0x7856341212EFCDAB),
                Tuple.Create(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, 0, (long)-0x8000000000000000),
                Tuple.Create(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, 0, unchecked((long)0x8000000000000000)),
                Tuple.Create(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F }, 0, (long)0x7FFFFFFFFFFFFFFF),

                Tuple.Create(new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF }, 8, unchecked((long)0xEFCDAB9078563412)),
                Tuple.Create(new byte[] { 0xAB, 0xEF, 0xBE, 0xAD, 0xDE, 0x0D, 0xF0, 0xAD, 0x8B, 0x34, 0x56, 0x78, 0x90, 0xCD, 0xEF, 0x12 }, 1, unchecked((long)0x8BADF00DDEADBEEF)),

                // Out of bounds cases. Will return 0
                Tuple.Create(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, 1, (long)0), // overlap
                Tuple.Create(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, 9, (long)0), // completely out of range
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, td.Item1.UUGetInt64(td.Item2), "Expect Get_{0} to work", td.Item3.GetType());
            }
        }
        
        #endregion

        #region Put Tests

        [TestMethod]
        public void TestPut_byteArray()
        {
            // src, input, index, expected bytes copied, do get check
            var testData = new List<Tuple<byte[], byte[], int, int, bool>>()
            {
                Tuple.Create(new byte[] { 0x00 }, new byte[] { 0xFF }, 0, 1, true),
                Tuple.Create(new byte[10], new byte[] { 0x12, 0x34 }, 8, 2, true), // copy end
                Tuple.Create(new byte[10], new byte[] { 0x12, 0x34, 0x56, 0x78 }, 3, 4, true),
                Tuple.Create(new byte[10], new byte[] { 0x12, 0x34, 0x11 }, 1, 3, true),

                // Out of bounds cases. Will return zero.
                Tuple.Create(new byte[] { 0x00 }, new byte[] { 0xFF }, 1, 0, false),
                Tuple.Create(new byte[] { }, new byte[] { 0xFF }, 0, 0, false),
                Tuple.Create(new byte[] { 0x00, 0x12, 0x34 }, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 0, false), // length too long
                Tuple.Create(new byte[] { 0x00, 0x12, 0x34, 0x56, 0x78 }, new byte[] { 0xFF, 0xFF, 0xFF }, 3, 0, false), // length+index too long
            };

            foreach (var td in testData)
            {
                int bytesCopied = td.Item1.UUPutBytes(td.Item2, td.Item3);
                Assert.AreEqual(td.Item4, bytesCopied, "Expect UUPutBytes to return correct number of bytes copied");

                if (td.Item5)
                {
                    byte[] lookup = td.Item1.UUGetBytes(td.Item3, bytesCopied);
                    CollectionAssert.AreEqual(td.Item2, lookup, "Expect get after put to return same bytes");
                }
            }
        }

        [TestMethod]
        public void TestPut_byte()
        {
            // src, input, index, do get check
            var testData = new List<Tuple<int, byte, int, bool>>()
            {
                Tuple.Create(1, (byte)0xFF, 0, true), // copy beginning
                Tuple.Create(10, (byte)0x12, 9, true), // copy end

                // Out of bounds cases. Will return zero.
                Tuple.Create(1, (byte)0xFF, 1, false),
                Tuple.Create(0, (byte)0xFF, 0, false),
                Tuple.Create(3, (byte)0xFF, 3, false), // length too long
                Tuple.Create(5, (byte)0xFF, 6, false), // length+index too long
            };

            Random r = new Random();
            foreach (var td in testData)
            {
                byte[] input = new byte[td.Item1];
                r.NextBytes(input);

                int bytesCopied = input.UUPutUInt8(td.Item2, td.Item3);
                
                if (td.Item4)
                {
                    Assert.AreEqual(System.Runtime.InteropServices.Marshal.SizeOf(td.Item2), bytesCopied, "Expect UUPut_{0} to return correct number of bytes copied", td.Item2.GetType());
                    var lookup = input.UUGetUInt8(td.Item3);
                    Assert.AreEqual(td.Item2, lookup, "Expect get after put to return same value");
                }
                else
                {
                    Assert.AreEqual(0, bytesCopied, "Expect UUPut_{0} to return zero when put fails", td.Item2.GetType());
                }
            }
        }

        [TestMethod]
        public void TestPut_sbyte()
        {
            // src, input, index, do get check
            var testData = new List<Tuple<int, sbyte, int, bool>>()
            {
                Tuple.Create(1, (sbyte)0x7F, 0, true), // copy beginning
                Tuple.Create(10, (sbyte)0x12, 9, true), // copy end

                // Out of bounds cases. Will return zero.
                Tuple.Create(1, (sbyte)0x7F, 1, false),
                Tuple.Create(0, (sbyte)0x7F, 0, false),
                Tuple.Create(3, (sbyte)0x7F, 3, false), // length too long
                Tuple.Create(5, (sbyte)0x7F, 6, false), // length+index too long
            };

            Random r = new Random();
            foreach (var td in testData)
            {
                byte[] input = new byte[td.Item1];
                r.NextBytes(input);

                int bytesCopied = input.UUPutInt8(td.Item2, td.Item3);

                if (td.Item4)
                {
                    Assert.AreEqual(System.Runtime.InteropServices.Marshal.SizeOf(td.Item2), bytesCopied, "Expect UUPut_{0} to return correct number of bytes copied", td.Item2.GetType());
                    var lookup = input.UUGetInt8(td.Item3);
                    Assert.AreEqual(td.Item2, lookup, "Expect get after put to return same value");
                }
                else
                {
                    Assert.AreEqual(0, bytesCopied, "Expect UUPut_{0} to return zero when put fails", td.Item2.GetType());
                }
            }
        }

        [TestMethod]
        public void TestPut_ushort()
        {
            // src, input, index, do get check
            var testData = new List<Tuple<int, ushort, int, bool>>()
            {
                Tuple.Create<int, ushort, int, bool>(2, 0xFFFF, 0, true), // copy beginning
                Tuple.Create<int, ushort, int, bool>(10, 0x1234, 8, true), // copy end

                // Out of bounds cases. Will return zero.
                Tuple.Create<int, ushort, int, bool>(1, 0xFFFF, 1, false),
                Tuple.Create<int, ushort, int, bool>(0, 0xFFFF, 0, false),
                Tuple.Create<int, ushort, int, bool>(3, 0xFFFF, 2, false), // length too long
                Tuple.Create<int, ushort, int, bool>(5, 0xFFFF, 6, false), // length+index too long
            };

            Random r = new Random();
            foreach (var td in testData)
            {
                byte[] input = new byte[td.Item1];
                r.NextBytes(input);

                int bytesCopied = input.UUPutUInt16(td.Item2, td.Item3);

                if (td.Item4)
                {
                    Assert.AreEqual(System.Runtime.InteropServices.Marshal.SizeOf(td.Item2), bytesCopied, "Expect UUPut_{0} to return correct number of bytes copied", td.Item2.GetType());
                    var lookup = input.UUGetUInt16(td.Item3);
                    Assert.AreEqual(td.Item2, lookup, "Expect get after put to return same value");
                }
                else
                {
                    Assert.AreEqual(0, bytesCopied, "Expect UUPut_{0} to return zero when put fails", td.Item2.GetType());
                }
            }
        }

        [TestMethod]
        public void TestPut_short()
        {
            // src, input, index, do get check
            var testData = new List<Tuple<int, short, int, bool>>()
            {
                Tuple.Create<int, short, int, bool>(2, 1234, 0, true), // copy beginning
                Tuple.Create<int, short, int, bool>(10, 1234, 8, true), // copy end

                // Out of bounds cases. Will return zero.
                Tuple.Create<int, short, int, bool>(1, 1234, 1, false),
                Tuple.Create<int, short, int, bool>(0, 1234, 0, false),
                Tuple.Create<int, short, int, bool>(3, 1234, 2, false), // length too long
                Tuple.Create<int, short, int, bool>(5, 1234, 6, false), // length+index too long
            };

            Random r = new Random();
            foreach (var td in testData)
            {
                byte[] input = new byte[td.Item1];
                r.NextBytes(input);

                int bytesCopied = input.UUPutInt16(td.Item2, td.Item3);

                if (td.Item4)
                {
                    Assert.AreEqual(System.Runtime.InteropServices.Marshal.SizeOf(td.Item2), bytesCopied, "Expect UUPut_{0} to return correct number of bytes copied", td.Item2.GetType());
                    var lookup = input.UUGetInt16(td.Item3);
                    Assert.AreEqual(td.Item2, lookup, "Expect get after put to return same value");
                }
                else
                {
                    Assert.AreEqual(0, bytesCopied, "Expect UUPut_{0} to return zero when put fails", td.Item2.GetType());
                }
            }
        }

        [TestMethod]
        public void TestPut_uint()
        {
            // src, input, index, do get check
            var testData = new List<Tuple<int, uint, int, bool>>()
            {
                Tuple.Create<int, uint, int, bool>(4, 12345678, 0, true), // copy beginning
                Tuple.Create<int, uint, int, bool>(10, 12345678, 6, true), // copy end

                // Out of bounds cases. Will return zero.
                Tuple.Create<int, uint, int, bool>(1, 12345678, 1, false),
                Tuple.Create<int, uint, int, bool>(0, 12345678, 0, false),
                Tuple.Create<int, uint, int, bool>(5, 12345678, 2, false), // length too long
                Tuple.Create<int, uint, int, bool>(9, 12345678, 6, false), // length+index too long
            };

            Random r = new Random();
            foreach (var td in testData)
            {
                byte[] input = new byte[td.Item1];
                r.NextBytes(input);

                int bytesCopied = input.UUPutUInt32(td.Item2, td.Item3);

                if (td.Item4)
                {
                    Assert.AreEqual(System.Runtime.InteropServices.Marshal.SizeOf(td.Item2), bytesCopied, "Expect UUPut_{0} to return correct number of bytes copied", td.Item2.GetType());
                    var lookup = input.UUGetUInt32(td.Item3);
                    Assert.AreEqual(td.Item2, lookup, "Expect get after put to return same value");
                }
                else
                {
                    Assert.AreEqual(0, bytesCopied, "Expect UUPut_{0} to return zero when put fails", td.Item2.GetType());
                }
            }
        }

        [TestMethod]
        public void TestPut_int()
        {
            // src, input, index, do get check
            var testData = new List<Tuple<int, int, int, bool>>()
            {
                Tuple.Create<int, int, int, bool>(4, 12345678, 0, true), // copy beginning
                Tuple.Create<int, int, int, bool>(10, 12345678, 6, true), // copy end

                // Out of bounds cases. Will return zero.
                Tuple.Create<int, int, int, bool>(1, 12345678, 1, false),
                Tuple.Create<int, int, int, bool>(0, 12345678, 0, false),
                Tuple.Create<int, int, int, bool>(5, 12345678, 2, false), // length too long
                Tuple.Create<int, int, int, bool>(9, 12345678, 6, false), // length+index too long
            };

            Random r = new Random();
            foreach (var td in testData)
            {
                byte[] input = new byte[td.Item1];
                r.NextBytes(input);

                int bytesCopied = input.UUPutInt32(td.Item2, td.Item3);

                if (td.Item4)
                {
                    Assert.AreEqual(System.Runtime.InteropServices.Marshal.SizeOf(td.Item2), bytesCopied, "Expect UUPut_{0} to return correct number of bytes copied", td.Item2.GetType());
                    var lookup = input.UUGetInt32(td.Item3);
                    Assert.AreEqual(td.Item2, lookup, "Expect get after put to return same value");
                }
                else
                {
                    Assert.AreEqual(0, bytesCopied, "Expect UUPut_{0} to return zero when put fails", td.Item2.GetType());
                }
            }
        }

        [TestMethod]
        public void TestPut_ulong()
        {
            // src, input, index, do get check
            var testData = new List<Tuple<int, ulong, int, bool>>()
            {
                Tuple.Create<int, ulong, int, bool>(8, 12345678, 0, true), // copy beginning
                Tuple.Create<int, ulong, int, bool>(10, 12345678, 2, true), // copy end

                // Out of bounds cases. Will return zero.
                Tuple.Create<int, ulong, int, bool>(1, 12345678, 1, false),
                Tuple.Create<int, ulong, int, bool>(0, 12345678, 0, false),
                Tuple.Create<int, ulong, int, bool>(9, 12345678, 2, false), // length too long
                Tuple.Create<int, ulong, int, bool>(13, 12345678, 6, false), // length+index too long
            };

            Random r = new Random();
            foreach (var td in testData)
            {
                byte[] input = new byte[td.Item1];
                r.NextBytes(input);

                int bytesCopied = input.UUPutUInt64(td.Item2, td.Item3);

                if (td.Item4)
                {
                    Assert.AreEqual(System.Runtime.InteropServices.Marshal.SizeOf(td.Item2), bytesCopied, "Expect UUPut_{0} to return correct number of bytes copied", td.Item2.GetType());
                    var lookup = input.UUGetUInt64(td.Item3);
                    Assert.AreEqual(td.Item2, lookup, "Expect get after put to return same value");
                }
                else
                {
                    Assert.AreEqual(0, bytesCopied, "Expect UUPut_{0} to return zero when put fails", td.Item2.GetType());
                }
            }
        }

        [TestMethod]
        public void TestPut_long()
        {
            // src, input, index, do get check
            var testData = new List<Tuple<int, long, int, bool>>()
            {
                Tuple.Create<int, long, int, bool>(8, 12345678, 0, true), // copy beginning
                Tuple.Create<int, long, int, bool>(10, 12345678, 2, true), // copy end

                // Out of bounds cases. Will return zero.
                Tuple.Create<int, long, int, bool>(1, 12345678, 1, false),
                Tuple.Create<int, long, int, bool>(0, 12345678, 0, false),
                Tuple.Create<int, long, int, bool>(9, 12345678, 2, false), // length too long
                Tuple.Create<int, long, int, bool>(13, 12345678, 6, false), // length+index too long
            };

            Random r = new Random();
            foreach (var td in testData)
            {
                byte[] input = new byte[td.Item1];
                r.NextBytes(input);

                int bytesCopied = input.UUPutInt64(td.Item2, td.Item3);

                if (td.Item4)
                {
                    Assert.AreEqual(System.Runtime.InteropServices.Marshal.SizeOf(td.Item2), bytesCopied, "Expect UUPut_{0} to return correct number of bytes copied", td.Item2.GetType());
                    var lookup = input.UUGetInt64(td.Item3);
                    Assert.AreEqual(td.Item2, lookup, "Expect get after put to return same value");
                }
                else
                {
                    Assert.AreEqual(0, bytesCopied, "Expect UUPut_{0} to return zero when put fails", td.Item2.GetType());
                }
            }
        }

        #endregion

        #region ToString Tests

        [TestMethod]
        public void TestToHexString()
        {
            var testData = new List<Tuple<byte[], string>>()
            {
                Tuple.Create(new byte[] { 0x00 }, "00"),
                Tuple.Create(new byte[] { 0xDE, 0xAD, 0xBE, 0xEF }, "DEADBEEF"),
                Tuple.Create(new byte[] { 0x8B, 0xAD, 0xF0, 0x0D }, "8BADF00D"),
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item2, td.Item1.UUToHexString(), "Expect ToHexString to work");
            }
        }

        #endregion
    }
}
