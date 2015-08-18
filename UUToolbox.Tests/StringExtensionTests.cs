using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace UUToolbox.Tests
{
    [TestClass]
    public class StringExtensionTests
    {
        #region Validation Tests

        [TestMethod]
        public void TestIsHexChar()
        {
            var testData = new List<Tuple<char, bool>>()
            {
                Tuple.Create('a', true),
                Tuple.Create('b', true),
                Tuple.Create('c', true),
                Tuple.Create('d', true),
                Tuple.Create('e', true),
                Tuple.Create('f', true),
                Tuple.Create('A', true),
                Tuple.Create('B', true),
                Tuple.Create('C', true),
                Tuple.Create('D', true),
                Tuple.Create('E', true),
                Tuple.Create('F', true),

                Tuple.Create('0', true),
                Tuple.Create('1', true),
                Tuple.Create('2', true),
                Tuple.Create('3', true),
                Tuple.Create('4', true),
                Tuple.Create('5', true),
                Tuple.Create('6', true),
                Tuple.Create('7', true),
                Tuple.Create('8', true),
                Tuple.Create('9', true),


                Tuple.Create('g', false),
                Tuple.Create('h', false),
                Tuple.Create('i', false),
                Tuple.Create('x', false),
                Tuple.Create('y', false),
                Tuple.Create('z', false),
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item2, td.Item1.UUIsHexChar());
            }
        }

        [TestMethod]
        public void TestIsHexString()
        {
            var testData = new List<Tuple<string, bool>>()
            {
                Tuple.Create("", false),
                Tuple.Create<string,bool>(null, false),
                Tuple.Create("0", true),
                Tuple.Create("the quick brown fox jumps over the lazy dog", false),
                Tuple.Create("00112233445566778899AABBCCDDEEFF", true),
                Tuple.Create("x0112233445566778899AABBCCDDEEFF", false),
                Tuple.Create("00112233445566778899AABBCCDDEEFz", false),
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item2, td.Item1.UUIsHexString(), "Expect IsHexString to work for input {0}", td.Item1);
            }
        }

        [TestMethod]
        public void TestIsDigitString()
        {
            var testData = new List<Tuple<string, bool>>()
            {
                Tuple.Create("", false),
                Tuple.Create<string,bool>(null, false),
                Tuple.Create("0", true),
                Tuple.Create("the quick brown fox jumps over the lazy dog", false),
                Tuple.Create("00112233445566778899AABBCCDDEEFF", false),
                Tuple.Create("x0112233445566778899AABBCCDDEEFF", false),
                Tuple.Create("00112233445566778899AABBCCDDEEFz", false),

                Tuple.Create("0123456789", true),
            };

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item2, td.Item1.UUIsDigitString(), "Expect IsDigitString to work for input {0}", td.Item1);
            }
        }

        #endregion

        #region Conversion Tests

        [TestMethod]
        public void TestToHexData()
        {
            var testData = new List<Tuple<string, byte[], bool>>()
            {
                Tuple.Create<string,byte[],bool>("", null, false),
                Tuple.Create<string,byte[],bool>(null, null, false),
                Tuple.Create<string,byte[],bool>("0", null, false),
                Tuple.Create<string,byte[],bool>("the quick brown fox jumps over the lazy dog", null, false),
                Tuple.Create<string,byte[],bool>("x0112233445566778899AABBCCDDEEFF", null, false),
                Tuple.Create<string,byte[],bool>("00112233445566778899AABBCCDDEEFz", null, false),
                Tuple.Create<string,byte[],bool>("00112233445566778899AABBCCDDEEFFA", null, false), // length wrong

                Tuple.Create<string,byte[],bool>("ABCDEF", new byte[] { 0xAB, 0xCD, 0xEF }, true ),

            };

            foreach (var td in testData)
            {
                byte[] actual = td.Item1.UUToHexData();
                if (td.Item3)
                {
                    Assert.IsNotNull(actual);
                    CollectionAssert.AreEqual(td.Item2, actual, "Expect ToHexData to work for input {0}", td.Item1);
                }
                else
                {
                    Assert.IsNull(actual, "Expect ToHexData to fail for input {0}", td.Item1);
                }
            }
        }
        
        [TestMethod]
        public void TestToUInt8()
        {
            var testData = new List<Tuple<string, byte, byte>>()
            {
                // Failure cases
                Tuple.Create<string,byte,byte>("", 0, 0),
                Tuple.Create<string,byte,byte>("", 255, 255),
                Tuple.Create<string,byte,byte>(null, 22, 22),
                Tuple.Create<string,byte,byte>("256", 7, 7),

                // Success cases
                Tuple.Create<string,byte,byte>("0", 99, byte.MinValue),
                Tuple.Create<string,byte,byte>("255", 99, byte.MaxValue),
                Tuple.Create<string,byte,byte>("57", 99, 57),
                Tuple.Create<string,byte,byte>("233", 99, 233),
            };
            
            foreach (var td in testData)
            {
                var actual = td.Item1.UUToUInt8(td.Item2);
                Assert.AreEqual(td.Item3, actual, "Expect To_{0} to work for input {1}", td.Item2.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestToInt8()
        {
            var testData = new List<Tuple<string, sbyte, sbyte>>()
            {
                // Failure cases
                Tuple.Create<string,sbyte,sbyte>("", 0, 0),
                Tuple.Create<string,sbyte,sbyte>("", 127, 127),
                Tuple.Create<string,sbyte,sbyte>(null, 22, 22),
                Tuple.Create<string,sbyte,sbyte>("-129", 13, 13),
                Tuple.Create<string,sbyte,sbyte>("128", 7, 7),

                // Success cases
                Tuple.Create<string,sbyte,sbyte>("-128", 99, sbyte.MinValue),
                Tuple.Create<string,sbyte,sbyte>("127", 99, sbyte.MaxValue),
                Tuple.Create<string,sbyte,sbyte>("-128", 99, -128),
                Tuple.Create<string,sbyte,sbyte>("57", 99, 57),
                Tuple.Create<string,sbyte,sbyte>("-26", 99, -26),
            };

            foreach (var td in testData)
            {
                var actual = td.Item1.UUToInt8(td.Item2);
                Assert.AreEqual(td.Item3, actual, "Expect To_{0} to work for input {1}", td.Item2.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestToUInt16()
        {
            var testData = new List<Tuple<string, ushort, ushort>>()
            {
                // Failure cases
                Tuple.Create<string,ushort,ushort>("", 0, 0),
                Tuple.Create<string,ushort,ushort>("", 255, 255),
                Tuple.Create<string,ushort,ushort>(null, 22, 22),
                Tuple.Create<string,ushort,ushort>("-1", 13, 13),
                Tuple.Create<string,ushort,ushort>("65536", 7, 7),

                // Success cases
                Tuple.Create<string,ushort,ushort>("0", 99, ushort.MinValue),
                Tuple.Create<string,ushort,ushort>("65535", 99, ushort.MaxValue),
                Tuple.Create<string,ushort,ushort>("57", 99, 57),
                Tuple.Create<string,ushort,ushort>("233", 99, 233),
            };

            foreach (var td in testData)
            {
                var actual = td.Item1.UUToUInt16(td.Item2);
                Assert.AreEqual(td.Item3, actual, "Expect To_{0} to work for input {1}", td.Item2.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestToInt16()
        {
            var testData = new List<Tuple<string, short, short>>()
            {
                // Failure cases
                Tuple.Create<string,short,short>("", 0, 0),
                Tuple.Create<string,short,short>("", 127, 127),
                Tuple.Create<string,short,short>(null, 22, 22),
                Tuple.Create<string,short,short>("-32769", 13, 13),
                Tuple.Create<string,short,short>("32768", 7, 7),

                // Success cases
                Tuple.Create<string,short,short>("-32768", 99, short.MinValue),
                Tuple.Create<string,short,short>("32767", 99, short.MaxValue),
                Tuple.Create<string,short,short>("-128", 99, -128),
                Tuple.Create<string,short,short>("57", 99, 57),
                Tuple.Create<string,short,short>("-26", 99, -26),
            };

            foreach (var td in testData)
            {
                var actual = td.Item1.UUToInt16(td.Item2);
                Assert.AreEqual(td.Item3, actual, "Expect To_{0} to work for input {1}", td.Item2.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestToUInt32()
        {
            var testData = new List<Tuple<string, uint, uint>>()
            {
                // Failure cases
                Tuple.Create<string,uint,uint>("", 0, 0),
                Tuple.Create<string,uint,uint>("", 255, 255),
                Tuple.Create<string,uint,uint>(null, 22, 22),
                Tuple.Create<string,uint,uint>("-1", 13, 13),
                Tuple.Create<string,uint,uint>("4294967296", 7, 7),

                // Success cases
                Tuple.Create<string,uint,uint>("0", 99, uint.MinValue),
                Tuple.Create<string,uint,uint>("4294967295", 99, uint.MaxValue),
                Tuple.Create<string,uint,uint>("57", 99, 57),
                Tuple.Create<string,uint,uint>("233", 99, 233),
                Tuple.Create<string,uint,uint>("998877", 99, 998877),
            };

            foreach (var td in testData)
            {
                var actual = td.Item1.UUToUInt32(td.Item2);
                Assert.AreEqual(td.Item3, actual, "Expect To_{0} to work for input {1}", td.Item2.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestToInt32()
        {
            var testData = new List<Tuple<string, int, int>>()
            {
                // Failure cases
                Tuple.Create<string,int,int>("", 0, 0),
                Tuple.Create<string,int,int>("", 127, 127),
                Tuple.Create<string,int,int>(null, 22, 22),
                Tuple.Create<string,int,int>("-2147483649", 13, 13),
                Tuple.Create<string,int,int>("2147483648", 7, 7),

                // Success cases
                Tuple.Create<string,int,int>("-2147483648", 99, int.MinValue),
                Tuple.Create<string,int,int>("2147483647", 99, int.MaxValue),
                Tuple.Create<string,int,int>("-128", 99, -128),
                Tuple.Create<string,int,int>("57", 99, 57),
                Tuple.Create<string,int,int>("-26", 99, -26),
                Tuple.Create<string,int,int>("-99887766", 99, -99887766),
                Tuple.Create<string,int,int>("1234567", 99, 1234567),
            };

            foreach (var td in testData)
            {
                var actual = td.Item1.UUToInt32(td.Item2);
                Assert.AreEqual(td.Item3, actual, "Expect To_{0} to work for input {1}", td.Item2.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestToUInt64()
        {
            var testData = new List<Tuple<string, ulong, ulong>>()
            {
                // Failure cases
                Tuple.Create<string,ulong,ulong>("", 0, 0),
                Tuple.Create<string,ulong,ulong>("", 255, 255),
                Tuple.Create<string,ulong,ulong>(null, 22, 22),
                Tuple.Create<string,ulong,ulong>("-1", 13, 13),
                Tuple.Create<string,ulong,ulong>("18446744073709551616", 7, 7),

                // Success cases
                Tuple.Create<string,ulong,ulong>("0", 99, 0),
                Tuple.Create<string,ulong,ulong>("18446744073709551615", 99, ulong.MaxValue),
                Tuple.Create<string,ulong,ulong>("57", 99, 57),
                Tuple.Create<string,ulong,ulong>("233", 99, 233),
                Tuple.Create<string,ulong,ulong>("789509", 99, 789509),
                Tuple.Create<string,ulong,ulong>("2563738436", 99, 2563738436),
                Tuple.Create<string,ulong,ulong>("4294967296", 99, 4294967296),
                Tuple.Create<string,ulong,ulong>("5738362937627392", 99, 5738362937627392),
            };

            foreach (var td in testData)
            {
                var actual = td.Item1.UUToUInt64(td.Item2);
                Assert.AreEqual(td.Item3, actual, "Expect To_{0} to work for input {1}", td.Item2.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestToInt64()
        {
            var testData = new List<Tuple<string, long, long>>()
            {
                // Failure cases
                Tuple.Create<string,long,long>("", 0, 0),
                Tuple.Create<string,long,long>("", 127, 127),
                Tuple.Create<string,long,long>(null, 22, 22),
                Tuple.Create<string,long,long>("-9223372036854775809", 13, 13),
                Tuple.Create<string,long,long>("9223372036854775808", 7, 7),

                // Success cases
                Tuple.Create<string,long,long>("-9223372036854775808", 99, long.MinValue),
                Tuple.Create<string,long,long>("9223372036854775807", 99, long.MaxValue),
                Tuple.Create<string,long,long>("-128", 99, -128),
                Tuple.Create<string,long,long>("57", 99, 57),
                Tuple.Create<string,long,long>("-26", 99, -26),
            };

            foreach (var td in testData)
            {
                var actual = td.Item1.UUToInt64(td.Item2);
                Assert.AreEqual(td.Item3, actual, "Expect To_{0} to work for input {1}", td.Item2.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestToDateTime()
        {
            var testData = new List<Tuple<string, string[], DateTime?, IFormatProvider, DateTimeStyles, DateTime>>()
            {
                // Failure cases
                Tuple.Create<string, string[], DateTime?, IFormatProvider, DateTimeStyles, DateTime>(
                    "FooBar", null, null, null, DateTimeStyles.None, DateTime.MinValue),
                Tuple.Create<string, string[], DateTime?, IFormatProvider, DateTimeStyles, DateTime>(
                    "FooBar", new string[] {  "yyyy-MM-dd hh:mm:sstt" }, null, null, DateTimeStyles.None, DateTime.MinValue),
                
                Tuple.Create<string, string[], DateTime?, IFormatProvider, DateTimeStyles, DateTime>(
                    "2015-08-18 02:18:22PM", new string[] { "MM/dd/yyyy hh:mm:sstt" }, null, null, DateTimeStyles.None,
                    DateTime.MinValue),
                Tuple.Create<string, string[], DateTime?, IFormatProvider, DateTimeStyles, DateTime>(
                    "2015-08-18 02:18:22AM", new string[] { "MM/dd/yyyy hh:mm:sstt" }, null, null, DateTimeStyles.None,
                    DateTime.MinValue),

                // Success cases
                Tuple.Create<string, string[], DateTime?, IFormatProvider, DateTimeStyles, DateTime>(
                    "2015-08-18 02:18:22PM", new string[] { "yyyy-MM-dd hh:mm:sstt" }, null, null, DateTimeStyles.None, 
                    new DateTime(2015, 8, 18, 2+12, 18, 22, 00, DateTimeKind.Unspecified)),
                Tuple.Create<string, string[], DateTime?, IFormatProvider, DateTimeStyles, DateTime>(
                    "2015-08-18 02:18:22AM", new string[] { "yyyy-MM-dd hh:mm:sstt" }, null, null, DateTimeStyles.None,
                    new DateTime(2015, 8, 18, 2, 18, 22, 00, DateTimeKind.Unspecified)),

                Tuple.Create<string, string[], DateTime?, IFormatProvider, DateTimeStyles, DateTime>(
                    "2015-08-18 02:18:22PM", null, null, null, DateTimeStyles.None,
                    new DateTime(2015, 8, 18, 2+12, 18, 22, 00, DateTimeKind.Unspecified)),
                Tuple.Create<string, string[], DateTime?, IFormatProvider, DateTimeStyles, DateTime>(
                    "2015-08-18 02:18:22AM", null, null, null, DateTimeStyles.None,
                    new DateTime(2015, 8, 18, 2, 18, 22, 00, DateTimeKind.Unspecified)),


            };

            foreach (var td in testData)
            {
                var actual = td.Item1.UUToDateTime(td.Item2, td.Item3, td.Item4, td.Item5);
                Assert.AreEqual(td.Item6, actual, "Expect ToDateTime to work for inpu");
            }
        }

        #endregion
    }
}
