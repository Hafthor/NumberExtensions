using System.Numerics;
using NumberExtensions;

namespace NumberExtensionsTests;

[TestClass]
public class NumberExtensionsTests {
    [TestMethod]
    public void TestBitCount() {
        var bitCounts = new[] {
            0, 1, 1, 2, 1, 2, 2, 3, // 0-7
            1, 2, 2, 3, 2, 3, 3, 4, // 8-15
        };
        byte b = 0, bp = 0x11;
        ushort w = 0, wp = 0x1111;
        uint dw = 0, dwp = 0x11111111;
        ulong qw = 0, qwp = 0x1111111111111111;
        UInt128 ow = 0, owp = new UInt128(0x1111111111111111, 0x1111111111111111);
        for (int i = 0; i < 16; i++, b += bp, w += wp, dw += dwp, qw += qwp, ow += owp) {
            var bitCount = bitCounts[i];
            Assert.AreEqual(bitCount, ((byte)i).BitCount());
            Assert.AreEqual(bitCount, ((sbyte)i).BitCount());
            Assert.AreEqual(bitCount, ((ushort)i).BitCount());
            Assert.AreEqual(bitCount, ((short)i).BitCount());
            Assert.AreEqual(bitCount, ((uint)i).BitCount());
            Assert.AreEqual(bitCount, ((int)i).BitCount());
            Assert.AreEqual(bitCount, ((ulong)i).BitCount());
            Assert.AreEqual(bitCount, ((long)i).BitCount());
            Assert.AreEqual(bitCount, ((Int128)i).BitCount());
            Assert.AreEqual(bitCount, ((UInt128)i).BitCount());

            Assert.AreEqual(bitCount * 2, b.BitCount());
            Assert.AreEqual(bitCount * 2, ((sbyte)b).BitCount());
            Assert.AreEqual(bitCount * 4, w.BitCount());
            Assert.AreEqual(bitCount * 4, ((short)w).BitCount());
            Assert.AreEqual(bitCount * 8, dw.BitCount());
            Assert.AreEqual(bitCount * 8, ((int)dw).BitCount());
            Assert.AreEqual(bitCount * 16, qw.BitCount());
            Assert.AreEqual(bitCount * 16, ((long)qw).BitCount());
            Assert.AreEqual(bitCount * 32, ow.BitCount());
            Assert.AreEqual(bitCount * 32, ((Int128)ow).BitCount());
        }

        Assert.AreEqual(7, sbyte.MaxValue.BitCount());
        Assert.AreEqual(8, byte.MaxValue.BitCount());
        Assert.AreEqual(15, short.MaxValue.BitCount());
        Assert.AreEqual(16, ushort.MaxValue.BitCount());
        Assert.AreEqual(31, int.MaxValue.BitCount());
        Assert.AreEqual(32, uint.MaxValue.BitCount());
        Assert.AreEqual(63, long.MaxValue.BitCount());
        Assert.AreEqual(64, ulong.MaxValue.BitCount());
        Assert.AreEqual(127, Int128.MaxValue.BitCount());
        Assert.AreEqual(128, UInt128.MaxValue.BitCount());

        Assert.AreEqual(8, ((sbyte)-1).BitCount());
        Assert.AreEqual(16, ((short)-1).BitCount());
        Assert.AreEqual(32, ((int)-1).BitCount());
        Assert.AreEqual(64, ((long)-1).BitCount());
        Assert.AreEqual(128, ((Int128)(-1)).BitCount());
    }

    [TestMethod]
    public void TestReverseBits() {
        Assert.AreEqual(unchecked((sbyte)0xD2), ((sbyte)0x4B).ReverseBits());
        Assert.AreEqual((byte)0xD2, ((byte)0x4B).ReverseBits());
        Assert.AreEqual(unchecked((short)0xDB42), ((short)0x42DB).ReverseBits());
        Assert.AreEqual((ushort)0xDB42, ((ushort)0x42DB).ReverseBits());
        Assert.AreEqual(unchecked((int)0xDB42DB42), ((int)0x42DB42DB).ReverseBits());
        Assert.AreEqual((uint)0xDB42DB42, ((uint)0x42DB42DB).ReverseBits());
        Assert.AreEqual(unchecked((long)0xDB42DB42DB42DB42), ((long)0x42DB42DB42DB42DB).ReverseBits());
        Assert.AreEqual((ulong)0xDB42DB42DB42DB42, ((ulong)0x42DB42DB42DB42DB).ReverseBits());
        Assert.AreEqual(new Int128(0xDB42DB42DB42DB42, 0xDB42DB42DB42DB42),
            new Int128(0x42DB42DB42DB42DBUL, 0x42DB42DB42DB42DBUL).ReverseBits());
        Assert.AreEqual(new UInt128(0xDB42DB42DB42DB42, 0xDB42DB42DB42DB42),
            new UInt128(0x42DB42DB42DB42DBUL, 0x42DB42DB42DB42DBUL).ReverseBits());
    }

    [TestMethod]
    public void TestIsPowerOf2() {
        // test non-powers of 2
        foreach (var v in new[] { -1, 0, 3, 5, 6, 7, 9, 10, 11, 12, 13, 14, 15 }) {
            Assert.IsFalse(((sbyte)v).IsPowerOf2());
            Assert.IsFalse(((byte)v).IsPowerOf2());
            Assert.IsFalse(((short)v).IsPowerOf2());
            Assert.IsFalse(((ushort)v).IsPowerOf2());
            Assert.IsFalse(((int)v).IsPowerOf2());
            Assert.IsFalse(((uint)v).IsPowerOf2());
            Assert.IsFalse(((long)v).IsPowerOf2());
            Assert.IsFalse(((ulong)v).IsPowerOf2());
            Assert.IsFalse(((Int128)v).IsPowerOf2());
            Assert.IsFalse(((UInt128)v).IsPowerOf2());
            Assert.IsFalse(((Half)v).IsPowerOf2());
            Assert.IsFalse(((float)v).IsPowerOf2());
            Assert.IsFalse(((double)v).IsPowerOf2());
        }

        // test powers of 2
        foreach (var v in new[] { 1, 2, 4, 8, 16, 32, 64 }) {
            Assert.IsTrue(((sbyte)v).IsPowerOf2());
            Assert.IsTrue(((byte)v).IsPowerOf2());
            Assert.IsTrue(((short)v).IsPowerOf2());
            Assert.IsTrue(((ushort)v).IsPowerOf2());
            Assert.IsTrue(((int)v).IsPowerOf2());
            Assert.IsTrue(((uint)v).IsPowerOf2());
            Assert.IsTrue(((long)v).IsPowerOf2());
            Assert.IsTrue(((ulong)v).IsPowerOf2());
            Assert.IsTrue(((Int128)v).IsPowerOf2());
            Assert.IsTrue(((UInt128)v).IsPowerOf2());
            Assert.IsTrue(((Half)v).IsPowerOf2());
            Assert.IsTrue(((float)v).IsPowerOf2());
            Assert.IsTrue(((double)v).IsPowerOf2());
        }

        // test one less than highest power of 2
        Assert.IsFalse(((sbyte)((1 << 6) - 1)).IsPowerOf2());
        Assert.IsFalse(((byte)((1 << 7) - 1)).IsPowerOf2());
        Assert.IsFalse(((short)((1 << 14) - 1)).IsPowerOf2());
        Assert.IsFalse(((ushort)((1 << 15) - 1)).IsPowerOf2());
        Assert.IsFalse(((int)((1 << 30) - 1)).IsPowerOf2());
        Assert.IsFalse(((uint)((1U << 31) - 1)).IsPowerOf2());
        Assert.IsFalse(((long)((1L << 62) - 1)).IsPowerOf2());
        Assert.IsFalse(((ulong)((1UL << 63) - 1)).IsPowerOf2());
        Assert.IsFalse((((Int128.One << 126) - 1)).IsPowerOf2());
        Assert.IsFalse((((UInt128.One << 127) - 1)).IsPowerOf2());

        // test highest power of 2
        Assert.IsTrue(((sbyte)(1 << 6)).IsPowerOf2());
        Assert.IsTrue(((byte)(1 << 7)).IsPowerOf2());
        Assert.IsTrue(((short)(1 << 14)).IsPowerOf2());
        Assert.IsTrue(((ushort)(1 << 15)).IsPowerOf2());
        Assert.IsTrue(((int)(1 << 30)).IsPowerOf2());
        Assert.IsTrue(((uint)(1U << 31)).IsPowerOf2());
        Assert.IsTrue(((long)(1L << 62)).IsPowerOf2());
        Assert.IsTrue(((ulong)(1UL << 63)).IsPowerOf2());
        Assert.IsTrue(((Int128.One << 126)).IsPowerOf2());
        Assert.IsTrue(((UInt128.One << 127)).IsPowerOf2());

        // test one more than highest power of 2
        Assert.IsFalse(((sbyte)((1 << 6) + 1)).IsPowerOf2());
        Assert.IsFalse(((byte)((1 << 7) + 1)).IsPowerOf2());
        Assert.IsFalse(((short)((1 << 14) + 1)).IsPowerOf2());
        Assert.IsFalse(((ushort)((1 << 15) + 1)).IsPowerOf2());
        Assert.IsFalse(((int)((1 << 30) + 1)).IsPowerOf2());
        Assert.IsFalse(((uint)((1U << 31) + 1)).IsPowerOf2());
        Assert.IsFalse(((long)((1L << 62) + 1)).IsPowerOf2());
        Assert.IsFalse(((ulong)((1UL << 63) + 1)).IsPowerOf2());
        Assert.IsFalse((((Int128.One << 126) + 1)).IsPowerOf2());
        Assert.IsFalse((((UInt128.One << 127) + 1)).IsPowerOf2());

        // test special floating point values
        Assert.IsFalse(double.PositiveInfinity.IsPowerOf2());
        Assert.IsFalse(double.NegativeInfinity.IsPowerOf2());
        Assert.IsFalse(double.NaN.IsPowerOf2());
        Assert.IsFalse(float.PositiveInfinity.IsPowerOf2());
        Assert.IsFalse(float.NegativeInfinity.IsPowerOf2());
        Assert.IsFalse(float.NaN.IsPowerOf2());
        Assert.IsFalse(Half.PositiveInfinity.IsPowerOf2());
        Assert.IsFalse(Half.NegativeInfinity.IsPowerOf2());
        Assert.IsFalse(Half.NaN.IsPowerOf2());

        // test full range of floating point values
        for (double d = 1; !double.IsPositiveInfinity(d); d *= 2) {
            Assert.IsTrue(d.IsPowerOf2());
            Assert.IsFalse((d * .75).IsPowerOf2());
        }
        for (double d = 1; d != 0; d /= 2) {
            Assert.IsTrue(d.IsPowerOf2());
            Assert.IsFalse((d * 3).IsPowerOf2());
        }

        for (float f = 1; !float.IsPositiveInfinity(f); f *= 2) {
            Assert.IsTrue(f.IsPowerOf2());
            Assert.IsFalse((f * .75).IsPowerOf2());
        }
        for (float f = 1; f != 0; f /= 2) {
            Assert.IsTrue(f.IsPowerOf2());
            Assert.IsFalse((f * 3).IsPowerOf2());
        }

        for (Half h = (Half)1; !Half.IsPositiveInfinity(h); h *= (Half)2) {
            Assert.IsTrue(h.IsPowerOf2());
            Assert.IsFalse((h * (Half).75).IsPowerOf2());
        }
        for (Half h = (Half)1; h != (Half)0; h /= (Half)2) {
            Assert.IsTrue(h.IsPowerOf2());
            Assert.IsFalse((h * (Half)3).IsPowerOf2());
        }
    }

    [TestMethod]
    public void TestLog2FloorAndLog2Ceiling() {
        // // test log2(-1) throws exception
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((sbyte)-1).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((short)-1).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((int)-1).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((long)-1).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((sbyte)-1).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((short)-1).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((int)-1).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((long)-1).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((Int128)(-1)).Log2Ceiling());
        //
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((double)-1).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((float)-1).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((Half)(-1)).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((double)-1).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((float)-1).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((Half)(-1)).Log2Ceiling());
        //
        // // test log2(0) throws exception
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((byte)0).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((sbyte)0).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((ushort)0).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((short)0).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((uint)0).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((int)0).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((ulong)0).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((long)0).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => Int128.Zero.Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => UInt128.Zero.Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((byte)0).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((sbyte)0).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((ushort)0).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((short)0).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((uint)0).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((int)0).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((ulong)0).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((long)0).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => Int128.Zero.Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => UInt128.Zero.Log2Ceiling());
        //
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((double)0).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((float)0).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((Half)0).Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((double)0).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((float)0).Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((Half)0).Log2Ceiling());
        //
        // // test log2(special floating-point values) throws exception
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => double.NaN.Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => float.NaN.Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => Half.NaN.Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => double.NaN.Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => float.NaN.Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => Half.NaN.Log2Ceiling());
        //
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => double.PositiveInfinity.Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => float.PositiveInfinity.Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => Half.PositiveInfinity.Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => double.PositiveInfinity.Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => float.PositiveInfinity.Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => Half.PositiveInfinity.Log2Ceiling());
        //
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => double.NegativeInfinity.Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => float.NegativeInfinity.Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => Half.NegativeInfinity.Log2Floor());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => double.NegativeInfinity.Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => float.NegativeInfinity.Log2Ceiling());
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => Half.NegativeInfinity.Log2Ceiling());

        // test ceiling of log2(1) is 0 since this is handled by a special case
        Assert.AreEqual(0, ((byte)1).Log2Ceiling());
        Assert.AreEqual(0, ((sbyte)1).Log2Ceiling());
        Assert.AreEqual(0, ((ushort)1).Log2Ceiling());
        Assert.AreEqual(0, ((short)1).Log2Ceiling());
        Assert.AreEqual(0, ((uint)1).Log2Ceiling());
        Assert.AreEqual(0, ((int)1).Log2Ceiling());
        Assert.AreEqual(0, ((ulong)1).Log2Ceiling());
        Assert.AreEqual(0, ((long)1).Log2Ceiling());
        Assert.AreEqual(0, UInt128.One.Log2Ceiling());
        Assert.AreEqual(0, Int128.One.Log2Ceiling());

        // test log2(maxvalue) and log2(epsilon) is correct
        // Note: .NET incorrectly calculates Math.Log2(double.MaxValue) as exactly 1024
        Assert.AreEqual(Math.Floor(Math.Log2(double.MaxValue)) - 1, double.MaxValue.Log2Floor());
        Assert.AreEqual(Math.Floor(Math.Log2(double.Epsilon)), double.Epsilon.Log2Floor());
        Assert.AreEqual(Math.Ceiling(Math.Log2(double.MaxValue)), double.MaxValue.Log2Ceiling());
        Assert.AreEqual(Math.Ceiling(Math.Log2(double.Epsilon)), double.Epsilon.Log2Ceiling());

        Assert.AreEqual(Math.Floor(Math.Log2(float.MaxValue)), float.MaxValue.Log2Floor());
        Assert.AreEqual(Math.Floor(Math.Log2(float.Epsilon)), float.Epsilon.Log2Floor());
        Assert.AreEqual(Math.Ceiling(Math.Log2(float.MaxValue)), float.MaxValue.Log2Ceiling());
        Assert.AreEqual(Math.Ceiling(Math.Log2(float.Epsilon)), float.Epsilon.Log2Ceiling());

        Assert.AreEqual(Math.Floor(Math.Log2((double)Half.MaxValue)), ((double)Half.MaxValue).Log2Floor());
        Assert.AreEqual(Math.Floor(Math.Log2((double)Half.Epsilon)), ((double)Half.Epsilon).Log2Floor());
        Assert.AreEqual(Math.Ceiling(Math.Log2((double)Half.MaxValue)), ((double)Half.MaxValue).Log2Ceiling());
        Assert.AreEqual(Math.Ceiling(Math.Log2((double)Half.Epsilon)), ((double)Half.Epsilon).Log2Ceiling());

        var random = new Random(0);
        int byteCount = 0,
            sbyteCount = 0,
            ushortCount = 0,
            shortCount = 0,
            uintCount = 0,
            intCount = 0,
            ulongCount = 0,
            longCount = 0,
            int128Count = 0,
            uint128Count = 0,
            doubleCount = 0,
            floatCount = 0,
            halfCount = 0;
        const int tests = 1_000_000, expectedUnsigned = 990_000, expectedSigned = 480_000;
        for (int testNumber = 0; testNumber < tests; testNumber++) {
            var byteValue = (byte)random.Next(0, 256);
            var sbyteValue = (sbyte)byteValue;
            var ushortValue = (ushort)random.Next(0, 65536);
            var shortValue = (short)ushortValue;
            var uintValue = (uint)random.Next(0, 65536) << 16 | ushortValue;
            var intValue = (int)uintValue;
            var ulongValue = (ulong)random.Next(0, 65536) << 48 | (ulong)random.Next(0, 65536) << 32 | uintValue;
            var longValue = (long)ulongValue;
            var int128LowValue = (ulong)random.Next(0, 65536) << 48 | (ulong)random.Next(0, 16777216) << 24 |
                                 (ulong)random.Next(0, 16777216);
            var uint128Value = new UInt128(ulongValue, int128LowValue);
            var int128Value = new Int128((ulong)longValue, int128LowValue);
            var doubleValue = BitConverter.UInt64BitsToDouble(ulongValue);
            var floatValue = BitConverter.UInt32BitsToSingle(uintValue);
            var halfValue = BitConverter.UInt16BitsToHalf(ushortValue);

            // test log2 of random values
            if (byteValue > 0) {
                Assert.AreEqual(Math.Floor(Math.Log2(byteValue)), byteValue.Log2Floor());
                Assert.AreEqual(Math.Ceiling(Math.Log2(byteValue)), byteValue.Log2Ceiling());
                byteCount++;
            }
            if (sbyteValue > 0) {
                Assert.AreEqual(Math.Floor(Math.Log2(sbyteValue)), sbyteValue.Log2Floor());
                Assert.AreEqual(Math.Ceiling(Math.Log2(sbyteValue)), sbyteValue.Log2Ceiling());
                sbyteCount++;
            }
            if (ushortValue > 0) {
                Assert.AreEqual(Math.Floor(Math.Log2(ushortValue)), ushortValue.Log2Floor());
                Assert.AreEqual(Math.Ceiling(Math.Log2(ushortValue)), ushortValue.Log2Ceiling());
                ushortCount++;
            }
            if (shortValue > 0) {
                Assert.AreEqual(Math.Floor(Math.Log2(shortValue)), shortValue.Log2Floor());
                Assert.AreEqual(Math.Ceiling(Math.Log2(shortValue)), shortValue.Log2Ceiling());
                shortCount++;
            }
            if (uintValue > 0) {
                Assert.AreEqual(Math.Floor(Math.Log2(uintValue)), uintValue.Log2Floor());
                Assert.AreEqual(Math.Ceiling(Math.Log2(uintValue)), uintValue.Log2Ceiling());
                uintCount++;
            }
            if (intValue > 0) {
                Assert.AreEqual(Math.Floor(Math.Log2(intValue)), intValue.Log2Floor());
                Assert.AreEqual(Math.Ceiling(Math.Log2(intValue)), intValue.Log2Ceiling());
                intCount++;
            }
            if (ulongValue > 0) {
                Assert.AreEqual(Math.Floor(Math.Log2(ulongValue)), ulongValue.Log2Floor());
                Assert.AreEqual(Math.Ceiling(Math.Log2(ulongValue)), ulongValue.Log2Ceiling());
                ulongCount++;
            }
            if (longValue > 0) {
                Assert.AreEqual(Math.Floor(Math.Log2(longValue)), longValue.Log2Floor());
                Assert.AreEqual(Math.Ceiling(Math.Log2(longValue)), longValue.Log2Ceiling());
                longCount++;
            }
            // NOTE: forced to convert to double since Math.Log2 and Math.Floor do not support Int128/UInt128
            //       but this should not affect the test results unless we get really unlucky on an edge case
            //       on a really large number. The random seed used (0) is fixed, so this test is predictable.
            if (uint128Value > 0) {
                Assert.AreEqual(Math.Floor(Math.Log2((double)uint128Value)), uint128Value.Log2Floor());
                Assert.AreEqual(Math.Ceiling(Math.Log2((double)uint128Value)), uint128Value.Log2Ceiling());
                uint128Count++;
            }
            if (int128Value > 0) {
                Assert.AreEqual(Math.Floor(Math.Log2((double)int128Value)), int128Value.Log2Floor());
                Assert.AreEqual(Math.Ceiling(Math.Log2((double)int128Value)), int128Value.Log2Ceiling());
                int128Count++;
            }

            if (!double.IsNaN(doubleValue) && doubleValue > 0 && !double.IsPositiveInfinity(doubleValue)) {
                Assert.AreEqual(Math.Floor(Math.Log2(doubleValue)), doubleValue.Log2Floor());
                Assert.AreEqual(Math.Ceiling(Math.Log2(doubleValue)), doubleValue.Log2Ceiling());
                doubleCount++;
            }
            if (!float.IsNaN(floatValue) && floatValue > 0 && !float.IsPositiveInfinity(floatValue)) {
                Assert.AreEqual(Math.Floor(Math.Log2(floatValue)), floatValue.Log2Floor());
                Assert.AreEqual(Math.Ceiling(Math.Log2(floatValue)), floatValue.Log2Ceiling());
                floatCount++;
            }
            if (!Half.IsNaN(halfValue) && halfValue > (Half)0 && !Half.IsPositiveInfinity(halfValue)) {
                Assert.AreEqual(Math.Floor(Math.Log2((float)halfValue)), halfValue.Log2Floor());
                Assert.AreEqual(Math.Ceiling(Math.Log2((float)halfValue)), halfValue.Log2Ceiling());
                halfCount++;
            }
        }
        Assert.IsTrue(byteCount > expectedUnsigned, "number of byte values tested less than expected");
        Assert.IsTrue(sbyteCount > expectedSigned, "number of sbyte values tested less than expected");
        Assert.IsTrue(ushortCount > expectedUnsigned, "number of ushort values tested less than expected");
        Assert.IsTrue(shortCount > expectedSigned, "number of short values tested less than expected");
        Assert.IsTrue(uintCount > expectedUnsigned, "number of uint values tested less than expected");
        Assert.IsTrue(intCount > expectedSigned, "number of int values tested less than expected");
        Assert.IsTrue(ulongCount > expectedUnsigned, "number of ulong values tested less than expected");
        Assert.IsTrue(longCount > expectedSigned, "number of long values tested less than expected");
        Assert.IsTrue(uint128Count > expectedUnsigned, "number of uint128 values tested less than expected");
        Assert.IsTrue(int128Count > expectedSigned, "number of int128 values tested less than expected");
        Assert.IsTrue(doubleCount > expectedSigned, "number of double values tested less than expected");
        Assert.IsTrue(floatCount > expectedSigned, "number of float values tested less than expected");
        Assert.IsTrue(halfCount > expectedSigned, "number of Half values tested less than expected");
    }

    [TestMethod]
    public void TestModMul() {
        Assert.AreEqual((byte)3, ((byte)(byte.MaxValue - 2)).ModMul(byte.MaxValue - 3, byte.MaxValue - 5));
        Assert.AreEqual((sbyte)3, (sbyte.MaxValue - 2).ModMul(sbyte.MaxValue - 3, sbyte.MaxValue - 5));
        Assert.AreEqual((ushort)3, ((ushort)(ushort.MaxValue - 2)).ModMul(ushort.MaxValue - 3, ushort.MaxValue - 5));
        Assert.AreEqual((short)3, (short.MaxValue - 2).ModMul(short.MaxValue - 3, short.MaxValue - 5));
        Assert.AreEqual((uint)3, (uint.MaxValue - 2).ModMul(uint.MaxValue - 3, uint.MaxValue - 5));
        Assert.AreEqual((int)3, (int.MaxValue - 2).ModMul(int.MaxValue - 3, int.MaxValue - 5));
        Assert.AreEqual((ulong)3, (ulong.MaxValue - 2).ModMul(ulong.MaxValue - 3, ulong.MaxValue - 5));
        Assert.AreEqual((long)3, (long.MaxValue - 2).ModMul(long.MaxValue - 3, long.MaxValue - 5));
        Assert.AreEqual((UInt128)3, (UInt128.MaxValue - 2).ModMul(UInt128.MaxValue - 3, UInt128.MaxValue - 5));
        Assert.AreEqual((Int128)3, (Int128.MaxValue - 2).ModMul(Int128.MaxValue - 3, Int128.MaxValue - 5));
        Assert.AreEqual((BigInteger)3, ((BigInteger)(Int128.MaxValue - 2)).ModMul(Int128.MaxValue - 3, Int128.MaxValue - 5));
    }

    [TestMethod]
    public void TestModPow() {
        Assert.AreEqual((byte)1, ((byte)(byte.MaxValue - 2)).ModPow(byte.MaxValue - 3, byte.MaxValue - 5));
        Assert.AreEqual((sbyte)1, (sbyte.MaxValue - 2).ModPow(sbyte.MaxValue - 3, sbyte.MaxValue - 5));
        Assert.AreEqual((ushort)1, ((ushort)(ushort.MaxValue - 2)).ModPow(ushort.MaxValue - 3, ushort.MaxValue - 5));
        Assert.AreEqual((short)1, (short.MaxValue - 2).ModPow(short.MaxValue - 3, short.MaxValue - 5));
        Assert.AreEqual((uint)1, (uint.MaxValue - 2).ModPow(uint.MaxValue - 3, uint.MaxValue - 5));
        Assert.AreEqual((int)1, (int.MaxValue - 2).ModPow(int.MaxValue - 3, int.MaxValue - 5));
        Assert.AreEqual((ulong)1, (ulong.MaxValue - 2).ModPow(ulong.MaxValue - 3, ulong.MaxValue - 5));
        Assert.AreEqual((long)1, (long.MaxValue - 2).ModPow(long.MaxValue - 3, long.MaxValue - 5));
        Assert.AreEqual((UInt128)1, (UInt128.MaxValue - 2).ModPow(UInt128.MaxValue - 3, UInt128.MaxValue - 5));
        Assert.AreEqual((Int128)1, (Int128.MaxValue - 2).ModPow(Int128.MaxValue - 3, Int128.MaxValue - 5));
        Assert.AreEqual(BigInteger.One, ((BigInteger)(Int128.MaxValue - 2)).ModPow(Int128.MaxValue - 3, Int128.MaxValue - 5));
        
        // Test with negative exponent
        Assert.AreEqual((sbyte)6, ((sbyte)13).ModPow(7, -17));
        Assert.AreEqual((short)6, ((short)13).ModPow(7, -17));
        Assert.AreEqual((int)6, ((int)13).ModPow(7, -17));
        Assert.AreEqual((long)6, ((long)13).ModPow(7, -17));
        Assert.AreEqual((Int128)6, ((Int128)13).ModPow(7, -17));
        Assert.AreEqual((BigInteger)6, ((BigInteger)13).ModPow(7, -17));
    }

    [TestMethod]
    public void TestModInverse() {
        Assert.AreEqual((sbyte)2, ((sbyte)13).ModInverse(7));
        Assert.AreEqual((short)2, ((short)13).ModInverse(7));
        Assert.AreEqual((int)2, ((int)13).ModInverse(7));
        Assert.AreEqual((long)2, ((long)13).ModInverse(7));
        Assert.AreEqual((Int128)2, ((Int128)13).ModInverse(7));
        Assert.AreEqual((BigInteger)2, ((BigInteger)13).ModInverse(7));
        
        Assert.AreEqual((sbyte)25, ((sbyte)29).ModInverse(7));
        Assert.AreEqual((short)25, ((short)29).ModInverse(7));
        Assert.AreEqual((int)25, ((int)29).ModInverse(7));
        Assert.AreEqual((long)25, ((long)29).ModInverse(7));
        Assert.AreEqual((Int128)25, ((Int128)29).ModInverse(7));
        Assert.AreEqual((BigInteger)25, ((BigInteger)29).ModInverse(7));
        
        Assert.ThrowsExactly<ArgumentException>(() => ((sbyte)2).ModInverse(0));
        Assert.ThrowsExactly<ArgumentException>(() => ((short)2).ModInverse(0));
        Assert.ThrowsExactly<ArgumentException>(() => ((int)2).ModInverse(0));
        Assert.ThrowsExactly<ArgumentException>(() => ((long)2).ModInverse(0));
        Assert.ThrowsExactly<ArgumentException>(() => ((Int128)2).ModInverse(0));
        Assert.ThrowsExactly<ArgumentException>(() => ((BigInteger)2).ModInverse(0));
    }

    [TestMethod]
    public void TestMinMax() {
        Assert.AreEqual(1, 3.Min(1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9));
        Assert.AreEqual(9, 3.Max(1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9));
        Assert.AreEqual("five", "three".Min("one", "four", "one", "five", "nine"));
        Assert.AreEqual("three", "three".Max("one", "four", "one", "five", "nine"));
        Assert.AreEqual(("five", "four"), "three".Min2("one", "four", "one", "five", "nine"));
        Assert.AreEqual(("three", "one"), "three".Max2("one", "four", "one", "five", "nine"));
    }
}
