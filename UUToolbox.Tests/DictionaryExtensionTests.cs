using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;

namespace UUToolbox.Tests
{
    [TestClass]
    public class DictionaryExtensionTests
    {
        [TestMethod]
        public void TestGetUInt8()
        {
            var testData = new List<Tuple<string, object, byte, byte>>()
            {
                Tuple.Create("MinActual", (object)byte.MinValue, byte.MinValue, (byte)0),
                Tuple.Create("MaxActual", (object)byte.MaxValue, byte.MaxValue, (byte)0),
                Tuple.Create("MinString", (object)byte.MinValue.ToString(), byte.MinValue, (byte)0),
                Tuple.Create("MaxString", (object)byte.MaxValue.ToString(), byte.MaxValue, (byte)0),
                Tuple.Create("DateString", (object)"2015-01-01 00:00:00", byte.MaxValue, byte.MaxValue),
                Tuple.Create("RandomString", (object)"The quick brown fox jumps over the lazy dog", byte.MaxValue, byte.MaxValue),
                Tuple.Create("Date", (object)DateTime.Now, byte.MaxValue, byte.MaxValue),
                Tuple.Create("ByteArraySameLength", (object)new byte[1], byte.MaxValue, byte.MaxValue),
                Tuple.Create("ByteArrayOverLength", (object)new byte[20], byte.MaxValue, byte.MaxValue),
                Tuple.Create("NumberUnderflow", (object)(byte.MinValue - 1), byte.MaxValue, byte.MaxValue),
                Tuple.Create("NumberOverflow", (object)(byte.MaxValue + 1), byte.MaxValue, byte.MaxValue),
            };

            var d = new Dictionary<string, object>();
            foreach (var td in testData)
            {
                d.Add(td.Item1, td.Item2);
            }

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, d.UUSafeGetUInt8(td.Item1, td.Item4), "Expect SafeGet_{0} to work for key {1}", td.Item3.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestGetUInt16()
        {
            var testData = new List<Tuple<string, object, ushort, ushort>>()
            {
                Tuple.Create("MinActual", (object)ushort.MinValue, ushort.MinValue, (ushort)0),
                Tuple.Create("MaxActual", (object)ushort.MaxValue, ushort.MaxValue, (ushort)0),
                Tuple.Create("MinString", (object)ushort.MinValue.ToString(), ushort.MinValue, (ushort)0),
                Tuple.Create("MaxString", (object)ushort.MaxValue.ToString(), ushort.MaxValue, (ushort)0),
                Tuple.Create("DateString", (object)"2015-01-01 00:00:00", ushort.MaxValue, ushort.MaxValue),
                Tuple.Create("RandomString", (object)"The quick brown fox jumps over the lazy dog", ushort.MaxValue, ushort.MaxValue),
                Tuple.Create("Date", (object)DateTime.Now, ushort.MaxValue, ushort.MaxValue),
                Tuple.Create("ByteArraySameLength", (object)new byte[2], ushort.MaxValue, ushort.MaxValue),
                Tuple.Create("ByteArrayOverLength", (object)new byte[20], ushort.MaxValue, ushort.MaxValue),
                Tuple.Create("NumberUnderflow", (object)(ushort.MinValue - 1), ushort.MaxValue, ushort.MaxValue),
                Tuple.Create("NumberOverflow", (object)(ushort.MaxValue + 1), ushort.MaxValue, ushort.MaxValue),
            };

            var d = new Dictionary<string, object>();
            foreach (var td in testData)
            {
                d.Add(td.Item1, td.Item2);
            }

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, d.UUSafeGetUInt16(td.Item1, td.Item4), "Expect SafeGet_{0} to work for key {1}", td.Item3.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestGetUInt32()
        {
            var testData = new List<Tuple<string, object, uint, uint>>()
            {
                Tuple.Create("MinActual", (object)uint.MinValue, uint.MinValue, (uint)0),
                Tuple.Create("MaxActual", (object)uint.MaxValue, uint.MaxValue, (uint)0),
                Tuple.Create("MinString", (object)uint.MinValue.ToString(), uint.MinValue, (uint)0),
                Tuple.Create("MaxString", (object)uint.MaxValue.ToString(), uint.MaxValue, (uint)0),
                Tuple.Create("DateString", (object)"2015-01-01 00:00:00", uint.MaxValue, uint.MaxValue),
                Tuple.Create("RandomString", (object)"The quick brown fox jumps over the lazy dog", uint.MaxValue, uint.MaxValue),
                Tuple.Create("Date", (object)DateTime.Now, uint.MaxValue, uint.MaxValue),
                Tuple.Create("ByteArraySameLength", (object)new byte[4], uint.MaxValue, uint.MaxValue),
                Tuple.Create("ByteArrayOverLength", (object)new byte[20], uint.MaxValue, uint.MaxValue),
                Tuple.Create("NumberUnderflow", (object)((long)uint.MinValue - 1), uint.MaxValue, uint.MaxValue),
                Tuple.Create("NumberOverflow", (object)((long)uint.MaxValue + 1), uint.MaxValue, uint.MaxValue),
            };

            var d = new Dictionary<string, object>();
            foreach (var td in testData)
            {
                d.Add(td.Item1, td.Item2);
            }

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, d.UUSafeGetUInt32(td.Item1, td.Item4), "Expect SafeGet_{0} to work for key {1}", td.Item3.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestGetUInt64()
        {
            var testData = new List<Tuple<string, object, ulong, ulong>>()
            {
                Tuple.Create("MinActual", (object)ulong.MinValue, ulong.MinValue, (ulong)0),
                Tuple.Create("MaxActual", (object)ulong.MaxValue, ulong.MaxValue, (ulong)0),
                Tuple.Create("MinString", (object)ulong.MinValue.ToString(), ulong.MinValue, (ulong)0),
                Tuple.Create("MaxString", (object)ulong.MaxValue.ToString(), ulong.MaxValue, (ulong)0),
                Tuple.Create("DateString", (object)"2015-01-01 00:00:00", ulong.MaxValue, ulong.MaxValue),
                Tuple.Create("RandomString", (object)"The quick brown fox jumps over the lazy dog", ulong.MaxValue, ulong.MaxValue),
                Tuple.Create("Date", (object)DateTime.Now, ulong.MaxValue, ulong.MaxValue),
                Tuple.Create("ByteArraySameLength", (object)new byte[8], ulong.MaxValue, ulong.MaxValue),
                Tuple.Create("ByteArrayOverLength", (object)new byte[20], ulong.MaxValue, ulong.MaxValue),
                Tuple.Create("NumberUnderflow", (object)unchecked(ulong.MinValue - 1), ulong.MaxValue, ulong.MaxValue),
            };

            var d = new Dictionary<string, object>();
            foreach (var td in testData)
            {
                d.Add(td.Item1, td.Item2);
            }

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, d.UUSafeGetUInt64(td.Item1, td.Item4), "Expect SafeGet_{0} to work for key {1}", td.Item3.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestGetInt8()
        {
            var testData = new List<Tuple<string, object, sbyte, sbyte>>()
            {
                Tuple.Create("MinActual", (object)sbyte.MinValue, sbyte.MinValue, (sbyte)0),
                Tuple.Create("MaxActual", (object)sbyte.MaxValue, sbyte.MaxValue, (sbyte)0),
                Tuple.Create("MinString", (object)sbyte.MinValue.ToString(), sbyte.MinValue, (sbyte)0),
                Tuple.Create("MaxString", (object)sbyte.MaxValue.ToString(), sbyte.MaxValue, (sbyte)0),
                Tuple.Create("DateString", (object)"2015-01-01 00:00:00", sbyte.MaxValue, sbyte.MaxValue),
                Tuple.Create("RandomString", (object)"The quick brown fox jumps over the lazy dog", sbyte.MaxValue, sbyte.MaxValue),
                Tuple.Create("Date", (object)DateTime.Now, sbyte.MaxValue, sbyte.MaxValue),
                Tuple.Create("ByteArraySameLength", (object)new byte[1], sbyte.MaxValue, sbyte.MaxValue),
                Tuple.Create("ByteArrayOverLength", (object)new byte[20], sbyte.MaxValue, sbyte.MaxValue),
                Tuple.Create("NumberUnderflow", (object)(sbyte.MinValue - 1), sbyte.MaxValue, sbyte.MaxValue),
                Tuple.Create("NumberOverflow", (object)(sbyte.MaxValue + 1), sbyte.MaxValue, sbyte.MaxValue),
            };

            var d = new Dictionary<string, object>();
            foreach (var td in testData)
            {
                d.Add(td.Item1, td.Item2);
            }

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, d.UUSafeGetInt8(td.Item1, td.Item4), "Expect SafeGet_{0} to work for key {1}", td.Item3.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestGetInt16()
        {
            var testData = new List<Tuple<string, object, short, short>>()
            {
                Tuple.Create("MinActual", (object)short.MinValue, short.MinValue, (short)0),
                Tuple.Create("MaxActual", (object)short.MaxValue, short.MaxValue, (short)0),
                Tuple.Create("MinString", (object)short.MinValue.ToString(), short.MinValue, (short)0),
                Tuple.Create("MaxString", (object)short.MaxValue.ToString(), short.MaxValue, (short)0),
                Tuple.Create("DateString", (object)"2015-01-01 00:00:00", short.MaxValue, short.MaxValue),
                Tuple.Create("RandomString", (object)"The quick brown fox jumps over the lazy dog", short.MaxValue, short.MaxValue),
                Tuple.Create("Date", (object)DateTime.Now, short.MaxValue, short.MaxValue),
                Tuple.Create("ByteArraySameLength", (object)new byte[2], short.MaxValue, short.MaxValue),
                Tuple.Create("ByteArrayOverLength", (object)new byte[20], short.MaxValue, short.MaxValue),
                Tuple.Create("NumberUnderflow", (object)(short.MinValue - 1), short.MaxValue, short.MaxValue),
                Tuple.Create("NumberOverflow", (object)(short.MaxValue + 1), short.MaxValue, short.MaxValue),
            };

            var d = new Dictionary<string, object>();
            foreach (var td in testData)
            {
                d.Add(td.Item1, td.Item2);
            }

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, d.UUSafeGetInt16(td.Item1, td.Item4), "Expect SafeGet_{0} to work for key {1}", td.Item3.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestGetInt32()
        {
            var testData = new List<Tuple<string, object, int, int>>()
            {
                Tuple.Create("MinActual", (object)int.MinValue, int.MinValue, (int)0),
                Tuple.Create("MaxActual", (object)int.MaxValue, int.MaxValue, (int)0),
                Tuple.Create("MinString", (object)int.MinValue.ToString(), int.MinValue, (int)0),
                Tuple.Create("MaxString", (object)int.MaxValue.ToString(), int.MaxValue, (int)0),
                Tuple.Create("DateString", (object)"2015-01-01 00:00:00", int.MaxValue, int.MaxValue),
                Tuple.Create("RandomString", (object)"The quick brown fox jumps over the lazy dog", int.MaxValue, int.MaxValue),
                Tuple.Create("Date", (object)DateTime.Now, int.MaxValue, int.MaxValue),
                Tuple.Create("ByteArraySameLength", (object)new byte[4], int.MaxValue, int.MaxValue),
                Tuple.Create("ByteArrayOverLength", (object)new byte[20], int.MaxValue, int.MaxValue),
                Tuple.Create("NumberUnderflow", (object)((long)int.MinValue - 1), int.MaxValue, int.MaxValue),
                Tuple.Create("NumberOverflow", (object)((long)int.MaxValue + 1), int.MaxValue, int.MaxValue),
            };

            var d = new Dictionary<string, object>();
            foreach (var td in testData)
            {
                d.Add(td.Item1, td.Item2);
            }

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, d.UUSafeGetInt32(td.Item1, td.Item4), "Expect SafeGet_{0} to work for key {1}", td.Item3.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestGetInt64()
        {
            var testData = new List<Tuple<string, object, long, long>>()
            {
                Tuple.Create("MinActual", (object)long.MinValue, long.MinValue, (long)0),
                Tuple.Create("MaxActual", (object)long.MaxValue, long.MaxValue, (long)0),
                Tuple.Create("MinString", (object)long.MinValue.ToString(), long.MinValue, (long)0),
                Tuple.Create("MaxString", (object)long.MaxValue.ToString(), long.MaxValue, (long)0),
                Tuple.Create("DateString", (object)"2015-01-01 00:00:00", long.MaxValue, long.MaxValue),
                Tuple.Create("RandomString", (object)"The quick brown fox jumps over the lazy dog", long.MaxValue, long.MaxValue),
                Tuple.Create("Date", (object)DateTime.Now, long.MaxValue, long.MaxValue),
                Tuple.Create("ByteArraySameLength", (object)new byte[8], long.MaxValue, long.MaxValue),
                Tuple.Create("ByteArrayOverLength", (object)new byte[20], long.MaxValue, long.MaxValue),
                Tuple.Create("NumberUnderflow", (object)(unchecked((ulong)long.MinValue - 1)), long.MaxValue, long.MaxValue),
                Tuple.Create("NumberOverflow", (object)((ulong)long.MaxValue + 1), long.MaxValue, long.MaxValue),
            };

            var d = new Dictionary<string, object>();
            foreach (var td in testData)
            {
                d.Add(td.Item1, td.Item2);
            }

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, d.UUSafeGetInt64(td.Item1, td.Item4), "Expect SafeGet_{0} to work for key {1}", td.Item3.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestGetString()
        {
            var testData = new List<Tuple<string, object, string, string>>()
            {
                Tuple.Create("Null", (object)null, "Default", "Default"),
                Tuple.Create("RandomString", (object)"A string", "A string", ""),
            };

            var d = new Dictionary<string, object>();
            foreach (var td in testData)
            {
                d.Add(td.Item1, td.Item2);
            }

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, d.UUSafeGetString(td.Item1, td.Item4), "Expect SafeGet_{0} to work for key {1}", td.Item3.GetType(), td.Item1);
            }
        }

        [TestMethod]
        public void TestGetBool()
        {
            var testData = new List<Tuple<string, object, bool, bool>>()
            {
                Tuple.Create("BoolTrue", (object)true, true, false),
                Tuple.Create("BoolFalse", (object)false, false, true),
                Tuple.Create("Int0", (object)0, false, true),
                Tuple.Create("Int1", (object)1, true, false),
                Tuple.Create("IntPos", (object)100, false, true),
                Tuple.Create("IntNeg", (object)-100, false, true),
                Tuple.Create("StringTrue", (object)"true", true, false),
                Tuple.Create("StringFalse", (object)"false", false, true),
                Tuple.Create("RandomString", (object)"test", true, true),
                Tuple.Create("RandomString2", (object)"test", false, false),
            };

            var d = new Dictionary<string, object>();
            foreach (var td in testData)
            {
                d.Add(td.Item1, td.Item2);
            }

            foreach (var td in testData)
            {
                Assert.AreEqual(td.Item3, d.UUSafeGetBool(td.Item1, td.Item4), "Expect SafeGet_{0} to work for key {1}", td.Item3.GetType(), td.Item1);
            }
        }
    }
}