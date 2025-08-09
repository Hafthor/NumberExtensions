using System.Numerics;
using System.Runtime.InteropServices;

namespace NumberExtensions;

public static class NumberExtensions {
    // used for BitCount and ReverseBits
    private static readonly UInt128
        UINT128_MASK1 = new(0x5555555555555555UL, 0x5555555555555555UL),
        UINT128_MASK2 = new(0x3333333333333333UL, 0x3333333333333333UL),
        UINT128_MASK4 = new(0x0F0F0F0F0F0F0F0FUL, 0x0F0F0F0F0F0F0F0FUL),
        UINT128_MASK8 = new(0x00FF00FF00FF00FFUL, 0x00FF00FF00FF00FFUL),
        UINT128_MASK16 = new(0x0000FFFF0000FFFFUL, 0x0000FFFF0000FFFFUL),
        UINT128_MASK32 = new(0x00000000FFFFFFFFUL, 0x00000000FFFFFFFFUL),
        UINT128_MASK64 = new(0x0000000000000000UL, 0xFFFFFFFFFFFFFFFFUL);

    /// <summary>
    /// Counts the number of bits set in the value.
    /// </summary>
    /// <param name="value">value to count bits in</param>
    /// <returns>number of bits set in value</returns>
    public static int BitCount(this sbyte value) => BitCount((byte)value);

    /// <summary>
    /// Counts the number of bits set in the value.
    /// </summary>
    /// <param name="value">value to count bits in</param>
    /// <returns>number of bits set in value</returns>
    public static int BitCount(this byte value) {
        value = (byte)((value & 0x55) + ((value >> 1) & 0x55));
        value = (byte)((value & 0x33) + ((value >> 2) & 0x33));
        return (value & 0x0F) + (value >> 4);
    }

    /// <summary>
    /// Counts the number of bits set in the value.
    /// </summary>
    /// <param name="value">value to count bits in</param>
    /// <returns>number of bits set in value</returns>
    public static int BitCount(this short value) => BitCount((ushort)value);

    /// <summary>
    /// Counts the number of bits set in the value.
    /// </summary>
    /// <param name="value">value to count bits in</param>
    /// <returns>number of bits set in value</returns>
    public static int BitCount(this ushort value) {
        value = (ushort)((value & 0x5555) + ((value >> 1) & 0x5555));
        value = (ushort)((value & 0x3333) + ((value >> 2) & 0x3333));
        value = (ushort)((value & 0x0F0F) + ((value >> 4) & 0x0F0F));
        return (value & 0x00FF) + (value >> 8);
    }

    /// <summary>
    /// Counts the number of bits set in the value.
    /// </summary>
    /// <param name="value">value to count bits in</param>
    /// <returns>number of bits set in value</returns>
    public static int BitCount(this int value) => BitCount((uint)value);

    /// <summary>
    /// Counts the number of bits set in the value.
    /// </summary>
    /// <param name="value">value to count bits in</param>
    /// <returns>number of bits set in value</returns>
    public static int BitCount(this uint value) {
        value = (value & 0x55555555u) + ((value >> 1) & 0x55555555u);
        value = (value & 0x33333333u) + ((value >> 2) & 0x33333333u);
        value = (value & 0x0F0F0F0Fu) + ((value >> 4) & 0x0F0F0F0Fu);
        value = (value & 0x00FF00FFu) + ((value >> 8) & 0x00FF00FFu);
        return (int)((value & 0x0000FFFFu) + (value >> 16));
    }

    /// <summary>
    /// Counts the number of bits set in the value.
    /// </summary>
    /// <param name="value">value to count bits in</param>
    /// <returns>number of bits set in value</returns>
    public static int BitCount(this long value) => BitCount((ulong)value);

    /// <summary>
    /// Counts the number of bits set in the value.
    /// </summary>
    /// <param name="value">value to count bits in</param>
    /// <returns>number of bits set in value</returns>
    public static int BitCount(this ulong value) {
        value = (value & 0x5555555555555555UL) + ((value >> 1) & 0x5555555555555555UL);
        value = (value & 0x3333333333333333UL) + ((value >> 2) & 0x3333333333333333UL);
        value = (value & 0x0F0F0F0F0F0F0F0FUL) + ((value >> 4) & 0x0F0F0F0F0F0F0F0FUL);
        value = (value & 0x00FF00FF00FF00FFUL) + ((value >> 8) & 0x00FF00FF00FF00FFUL);
        value = (value & 0x0000FFFF0000FFFFUL) + ((value >> 16) & 0x0000FFFF0000FFFFUL);
        return (int)((value & 0x00000000FFFFFFFFUL) + (value >> 32));
    }

    public static int BitCount(this Int128 value) => BitCount((UInt128)value);

    /// <summary>
    /// Counts the number of bits set in the value.
    /// </summary>
    /// <param name="value">value to count bits in</param>
    /// <returns>number of bits set in value</returns>
    public static int BitCount(this UInt128 value) {
        value = (value & UINT128_MASK1) + ((value >> 1) & UINT128_MASK1);
        value = (value & UINT128_MASK2) + ((value >> 2) & UINT128_MASK2);
        value = (value & UINT128_MASK4) + ((value >> 4) & UINT128_MASK4);
        value = (value & UINT128_MASK8) + ((value >> 8) & UINT128_MASK8);
        value = (value & UINT128_MASK16) + ((value >> 16) & UINT128_MASK16);
        value = (value & UINT128_MASK32) + ((value >> 32) & UINT128_MASK32);
        return (int)((value & UINT128_MASK64) + (value >> 64));
    }

    /// <summary>
    /// Reverse the bits in the value.
    /// </summary>
    /// <param name="value">value to reverse bits of</param>
    /// <returns>value with bits reversed</returns>
    public static sbyte ReverseBits(this sbyte value) => (sbyte)ReverseBits((byte)value);

    /// <summary>
    /// Reverse the bits in the value.
    /// </summary>
    /// <param name="value">value to reverse bits of</param>
    /// <returns>value with bits reversed</returns>
    public static byte ReverseBits(this byte value) {
        value = (byte)(((value >> 1) & 0x55) | ((value & 0x55) << 1));
        value = (byte)(((value >> 2) & 0x33) | ((value & 0x33) << 2));
        return (byte)((value >> 4) | (value << 4));
    }

    /// <summary>
    /// Reverse the bits in the value.
    /// </summary>
    /// <param name="value">value to reverse bits of</param>
    /// <returns>value with bits reversed</returns>
    public static short ReverseBits(this short value) => (short)ReverseBits((ushort)value);

    /// <summary>
    /// Reverse the bits in the value.
    /// </summary>
    /// <param name="value">value to reverse bits of</param>
    /// <returns>value with bits reversed</returns>
    public static ushort ReverseBits(this ushort value) {
        value = (ushort)(((value >> 1) & 0x5555) | ((value & 0x5555) << 1));
        value = (ushort)(((value >> 2) & 0x3333) | ((value & 0x3333) << 2));
        value = (ushort)(((value >> 4) & 0x0F0F) | ((value & 0x0F0F) << 4));
        return (ushort)((value >> 8) | (value << 8));
    }

    /// <summary>
    /// Reverse the bits in the value.
    /// </summary>
    /// <param name="value">value to reverse bits of</param>
    /// <returns>value with bits reversed</returns>
    public static int ReverseBits(this int value) => (int)ReverseBits((uint)value);

    /// <summary>
    /// Reverse the bits in the value.
    /// </summary>
    /// <param name="value">value to reverse bits of</param>
    /// <returns>value with bits reversed</returns>
    public static uint ReverseBits(this uint value) {
        value = (uint)(((value >> 1) & 0x55555555) | ((value & 0x55555555) << 1));
        value = (uint)(((value >> 2) & 0x33333333) | ((value & 0x33333333) << 2));
        value = (uint)(((value >> 4) & 0x0F0F0F0F) | ((value & 0x0F0F0F0F) << 4));
        value = (uint)(((value >> 8) & 0x00FF00FF) | ((value & 0x00FF00FF) << 8));
        return (value >> 16) | (value << 16);
    }

    /// <summary>
    /// Reverse the bits in the value.
    /// </summary>
    /// <param name="value">value to reverse bits of</param>
    /// <returns>value with bits reversed</returns>
    public static long ReverseBits(this long value) => (long)ReverseBits((ulong)value);

    /// <summary>
    /// Reverse the bits in the value.
    /// </summary>
    /// <param name="value">value to reverse bits of</param>
    /// <returns>value with bits reversed</returns>
    public static ulong ReverseBits(this ulong value) {
        value = (ulong)(((value >> 1) & 0x5555555555555555UL) | ((value & 0x5555555555555555UL) << 1));
        value = (ulong)(((value >> 2) & 0x3333333333333333UL) | ((value & 0x3333333333333333UL) << 2));
        value = (ulong)(((value >> 4) & 0x0F0F0F0F0F0F0F0FUL) | ((value & 0x0F0F0F0F0F0F0F0FUL) << 4));
        value = (ulong)(((value >> 8) & 0x00FF00FF00FF00FFUL) | ((value & 0x00FF00FF00FF00FFUL) << 8));
        value = (ulong)(((value >> 16) & 0x0000FFFF0000FFFFUL) | ((value & 0x0000FFFF0000FFFFUL) << 16));
        return (value >> 32) | (value << 32);
    }

    /// <summary>
    /// Reverse the bits in the value.
    /// </summary>
    /// <param name="value">value to reverse bits of</param>
    /// <returns>value with bits reversed</returns>
    public static Int128 ReverseBits(this Int128 value) => (Int128)ReverseBits((UInt128)value);

    /// <summary>
    /// Reverse the bits in the value.
    /// </summary>
    /// <param name="value">value to reverse bits of</param>
    /// <returns>value with bits reversed</returns>
    public static UInt128 ReverseBits(this UInt128 value) {
        value = (UInt128)(((value >> 1) & UINT128_MASK1) | ((value & UINT128_MASK1) << 1));
        value = (UInt128)(((value >> 2) & UINT128_MASK2) | ((value & UINT128_MASK2) << 2));
        value = (UInt128)(((value >> 4) & UINT128_MASK4) | ((value & UINT128_MASK4) << 4));
        value = (UInt128)(((value >> 8) & UINT128_MASK8) | ((value & UINT128_MASK8) << 8));
        value = (UInt128)(((value >> 16) & UINT128_MASK16) | ((value & UINT128_MASK16) << 16));
        value = (UInt128)(((value >> 32) & UINT128_MASK32) | ((value & UINT128_MASK32) << 32));
        return (value >> 64) | (value << 64);
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2<T>(this T value) where T : INumber<T>, IDecrementOperators<T>, IBitwiseOperators<T, T, T> =>
        value.CompareTo(default) > 0 && (value & --value) == default;

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this double value) {
        const int MANTISSA_BITS = 52, EXPONENT_BITS = 11;
        long l = BitConverter.DoubleToInt64Bits(value);
        if (l <= 0) // negative or zero or -NaN or -Infinity
            return false;

        var exponent = l >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            return false;

        var mantissa = l & ((1L << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return mantissa > 0 && (mantissa & (mantissa - 1)) == 0;

        // there is an implied 1 prefix on the mantissa normally
        return mantissa == 0;
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this float value) {
        const int MANTISSA_BITS = 23, EXPONENT_BITS = 8;
        int i = BitConverter.SingleToInt32Bits(value);
        if (i <= 0) // negative or zero or -NaN or -Infinity
            return false;

        var exponent = i >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            return false;

        var mantissa = i & ((1 << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return mantissa > 0 && (mantissa & (mantissa - 1)) == 0;

        // there is an implied 1 prefix on the mantissa normally
        return mantissa == 0;
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this Half value) {
        const int MANTISSA_BITS = 10, EXPONENT_BITS = 5;
        short s = BitConverter.HalfToInt16Bits(value);
        if (s <= 0) // negative or zero or -NaN or -Infinity
            return false;

        var exponent = s >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            return false;

        var mantissa = s & ((1 << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return mantissa > 0 && (mantissa & (mantissa - 1)) == 0;

        // there is an implied 1 prefix on the mantissa normally
        return mantissa == 0;
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Floor(this sbyte value) {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 31 - BitOperations.LeadingZeroCount((uint)value);
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Floor(this byte value) {
        if (value == 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 31 - BitOperations.LeadingZeroCount((uint)value);
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Floor(this short value) {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 31 - BitOperations.LeadingZeroCount((uint)value);
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Floor(this ushort value) {
        if (value == 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 31 - BitOperations.LeadingZeroCount((uint)value);
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Floor(this int value) {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 31 - BitOperations.LeadingZeroCount((uint)value);
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Floor(this uint value) {
        if (value == 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 31 - BitOperations.LeadingZeroCount((uint)value);
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Floor(this long value) {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 63 - BitOperations.LeadingZeroCount((ulong)value);
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Floor(this ulong value) {
        if (value == 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 63 - BitOperations.LeadingZeroCount((ulong)value);
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Floor(this Int128 value) {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        ulong highBits = (ulong)(value >> 64);
        return highBits > 0 ? 127 - BitOperations.LeadingZeroCount((ulong)(value >> 64)) : 63 - BitOperations.LeadingZeroCount((ulong)value);
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Floor(this UInt128 value) {
        if (value == 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        ulong highBits = (ulong)(value >> 64);
        return highBits > 0 ? 127 - BitOperations.LeadingZeroCount((ulong)(value >> 64)) : 63 - BitOperations.LeadingZeroCount((ulong)value);
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative, zero, infinity or NaN</exception>
    public static int Log2Floor(this double value) {
        const int MANTISSA_BITS = 52, EXPONENT_BITS = 11;
        long l = BitConverter.DoubleToInt64Bits(value);
        if (l <= 0) // negative or zero or -NaN or -Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");

        var exponent = l >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive finite number");

        var mantissa = l & ((1L << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return -1011 - BitOperations.LeadingZeroCount((ulong)mantissa);

        // there is an implied 1 prefix on the mantissa normally
        return (int)(exponent - 1023);
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative, zero, infinity or NaN</exception>
    public static int Log2Floor(this float value) {
        const int MANTISSA_BITS = 23, EXPONENT_BITS = 8;
        int i = BitConverter.SingleToInt32Bits(value);
        if (i <= 0) // negative or zero or -NaN or -Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");

        var exponent = i >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive finite number");

        var mantissa = i & ((1 << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return -118 - BitOperations.LeadingZeroCount((uint)mantissa);

        // there is an implied 1 prefix on the mantissa normally
        return exponent - 127;
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative, zero, infinity or NaN</exception>
    public static int Log2Floor(this Half value) {
        const int MANTISSA_BITS = 10, EXPONENT_BITS = 5;
        short s = BitConverter.HalfToInt16Bits(value);
        if (s <= 0) // negative or zero or -NaN or -Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");

        var exponent = s >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive finite number");

        var mantissa = s & ((1 << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return 7 - BitOperations.LeadingZeroCount((uint)mantissa);

        // there is an implied 1 prefix on the mantissa normally
        return exponent - 15;
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Ceiling(this sbyte value) {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 32 - BitOperations.LeadingZeroCount((uint)value - 1);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Ceiling(this byte value) {
        if (value == 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 32 - BitOperations.LeadingZeroCount((uint)value - 1);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Ceiling(this short value) {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 32 - BitOperations.LeadingZeroCount((uint)value - 1);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Ceiling(this ushort value) {
        if (value == 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 32 - BitOperations.LeadingZeroCount((uint)value - 1);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Ceiling(this int value) {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 32 - BitOperations.LeadingZeroCount((uint)value - 1);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Ceiling(this uint value) {
        if (value == 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 32 - BitOperations.LeadingZeroCount((uint)value - 1);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Ceiling(this long value) {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 64 - BitOperations.LeadingZeroCount((ulong)value - 1);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Ceiling(this ulong value) {
        if (value == 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        return 64 - BitOperations.LeadingZeroCount((ulong)value - 1);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Ceiling(this Int128 value) {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        ulong highBits = (ulong)(--value >> 64);
        return highBits > 0 ? 128 - BitOperations.LeadingZeroCount((ulong)(value >> 64)) : 64 - BitOperations.LeadingZeroCount((ulong)value);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Ceiling(this UInt128 value) {
        if (value == 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
        ulong highBits = (ulong)(--value >> 64);
        return highBits > 0 ? 128 - BitOperations.LeadingZeroCount((ulong)(value >> 64)) : 64 - BitOperations.LeadingZeroCount((ulong)value);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative, zero, infinity or NaN</exception>
    public static int Log2Ceiling(this double value) {
        const int MANTISSA_BITS = 52, EXPONENT_BITS = 11;
        long l = BitConverter.DoubleToInt64Bits(value);
        if (l <= 0) // negative or zero or -NaN or -Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");

        var exponent = l >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive finite number");

        var mantissa = l & ((1L << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return -1010 - BitOperations.LeadingZeroCount((ulong)--mantissa);

        // there is an implied 1 prefix on the mantissa normally
        return (int)exponent - (mantissa == 0 ? 1023 : 1022);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative, zero, infinity or NaN</exception>
    public static int Log2Ceiling(this float value) {
        const int MANTISSA_BITS = 23, EXPONENT_BITS = 8;
        int i = BitConverter.SingleToInt32Bits(value);
        if (i <= 0) // negative or zero or -NaN or -Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");

        var exponent = i >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive finite number");

        var mantissa = i & ((1 << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return -117 - BitOperations.LeadingZeroCount((uint)--mantissa);

        // there is an implied 1 prefix on the mantissa normally
        return exponent - (mantissa == 0 ? 127 : 126);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative, zero, infinity or NaN</exception>
    public static int Log2Ceiling(this Half value) {
        const int MANTISSA_BITS = 10, EXPONENT_BITS = 5;
        short s = BitConverter.HalfToInt16Bits(value);
        if (s <= 0) // negative or zero or -NaN or -Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");

        var exponent = s >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive finite number");

        var mantissa = s & ((1 << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return 8 - BitOperations.LeadingZeroCount((uint)--mantissa);

        // there is an implied 1 prefix on the mantissa normally
        return exponent - (mantissa == 0 ? 15 : 14);
    }

    /// <summary>
    /// Performs a modulo multiplication operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="a">multiplicand</param>
    /// <param name="b">multiplicand</param>
    /// <returns>ab % mod</returns>
    public static byte ModMul(this byte mod, byte a, byte b) => (byte)((uint)a * b % mod);

    /// <summary>
    /// Performs a modulo multiplication operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="a">multiplicand</param>
    /// <param name="b">multiplicand</param>
    /// <returns>ab % mod</returns>
    public static sbyte ModMul(this sbyte mod, sbyte a, sbyte b) => (sbyte)((int)a * b % mod);

    /// <summary>
    /// Performs a modulo multiplication operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="a">multiplicand</param>
    /// <param name="b">multiplicand</param>
    /// <returns>ab % mod</returns>
    public static ushort ModMul(this ushort mod, ushort a, ushort b) => (ushort)((uint)a * b % mod);

    /// <summary>
    /// Performs a modulo multiplication operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="a">multiplicand</param>
    /// <param name="b">multiplicand</param>
    /// <returns>ab % mod</returns>
    public static short ModMul(this short mod, short a, short b) => (short)((int)a * b % mod);

    /// <summary>
    /// Performs a modulo multiplication operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="a">multiplicand</param>
    /// <param name="b">multiplicand</param>
    /// <returns>ab % mod</returns>
    public static uint ModMul(this uint mod, uint a, uint b) => (uint)((ulong)a * b % mod);

    /// <summary>
    /// Performs a modulo multiplication operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="a">multiplicand</param>
    /// <param name="b">multiplicand</param>
    /// <returns>ab % mod</returns>
    public static int ModMul(this int mod, int a, int b) => (int)((long)a * b % mod);

    /// <summary>
    /// Performs a modulo multiplication operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="a">multiplicand</param>
    /// <param name="b">multiplicand</param>
    /// <returns>ab % mod</returns>
    public static ulong ModMul(this ulong mod, ulong a, ulong b) => (ulong)((UInt128)a * b % mod);

    /// <summary>
    /// Performs a modulo multiplication operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="a">multiplicand</param>
    /// <param name="b">multiplicand</param>
    /// <returns>ab % mod</returns>
    public static long ModMul(this long mod, long a, long b) => (long)((Int128)a * b % mod);

    /// <summary>
    /// Performs a modulo multiplication operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="a">multiplicand</param>
    /// <param name="b">multiplicand</param>
    /// <returns>ab % mod</returns>
    public static UInt128 ModMul(this UInt128 mod, UInt128 a, UInt128 b) => (UInt128)((BigInteger)a * b % mod);

    /// <summary>
    /// Performs a modulo multiplication operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="a">multiplicand</param>
    /// <param name="b">multiplicand</param>
    /// <returns>ab % mod</returns>
    public static Int128 ModMul(this Int128 mod, Int128 a, Int128 b) => (Int128)((BigInteger)a * b % mod);

    /// <summary>
    /// Performs a modulo multiplication operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="a">multiplicand</param>
    /// <param name="b">multiplicand</param>
    /// <returns>ab % mod</returns>
    public static BigInteger ModMul(this BigInteger mod, BigInteger a, BigInteger b) => a * b % mod;

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <param name="mul">optional multiplicand</param>
    /// <returns>(mul * num^exp) % mod</returns>
    public static byte ModPow(this byte mod, byte num, byte exp, byte mul = 1) {
        if (exp > 0) {
            for (; ; ) {
                if ((exp & 1) == 1)
                    mul = mod.ModMul(mul, num);
                exp >>= 1;
                if (exp == 0)
                    break;
                num = mod.ModMul(num, num);
            }
        }
        return mul;
    }

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <param name="mul">optional multiplicand</param>
    /// <returns>(mul * num^exp) % mod</returns>
    public static sbyte ModPow(this sbyte mod, sbyte num, sbyte exp, sbyte mul = 1) {
        if (exp < 0) {
            num = mod.ModInverse(num);
            exp = (sbyte)-exp;
        }
        if (exp > 0) {
            for (; ; ) {
                if ((exp & 1) == 1)
                    mul = mod.ModMul(mul, num);
                exp >>= 1;
                if (exp == 0)
                    break;
                num = mod.ModMul(num, num);
            }
        }
        return mul;
    }

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <param name="mul">optional multiplicand</param>
    /// <returns>(mul * num^exp) % mod</returns>
    public static ushort ModPow(this ushort mod, ushort num, ushort exp, ushort mul = 1) {
        if (exp > 0) {
            for (; ; ) {
                if ((exp & 1) == 1)
                    mul = mod.ModMul(mul, num);
                exp >>= 1;
                if (exp == 0)
                    break;
                num = mod.ModMul(num, num);
            }
        }
        return mul;
    }

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <param name="mul">optional multiplicand</param>
    /// <returns>(mul * num^exp) % mod</returns>
    public static short ModPow(this short mod, short num, short exp, short mul = 1) {
        if (exp < 0) {
            num = mod.ModInverse(num);
            exp = (short)-exp;
        }
        if (exp > 0) {
            for (; ; ) {
                if ((exp & 1) == 1)
                    mul = mod.ModMul(mul, num);
                exp >>= 1;
                if (exp == 0)
                    break;
                num = mod.ModMul(num, num);
            }
        }
        return mul;
    }

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <param name="mul">optional multiplicand</param>
    /// <returns>(mul * num^exp) % mod</returns>
    public static uint ModPow(this uint mod, uint num, uint exp, uint mul = 1) {
        if (exp > 0) {
            for (; ; ) {
                if ((exp & 1) == 1)
                    mul = mod.ModMul(mul, num);
                exp >>= 1;
                if (exp == 0)
                    break;
                num = mod.ModMul(num, num);
            }
        }
        return mul;
    }

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <param name="mul">optional multiplicand</param>
    /// <returns>(mul * num^exp) % mod</returns>
    public static int ModPow(this int mod, int num, int exp, int mul = 1) {
        if (exp < 0) {
            num = mod.ModInverse(num);
            exp = -exp;
        }
        if (exp > 0) {
            for (; ; ) {
                if ((exp & 1) == 1)
                    mul = mod.ModMul(mul, num);
                exp >>= 1;
                if (exp == 0)
                    break;
                num = mod.ModMul(num, num);
            }
        }
        return mul;
    }

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <param name="mul">optional multiplicand</param>
    /// <returns>(mul * num^exp) % mod</returns>
    public static ulong ModPow(this ulong mod, ulong num, ulong exp, ulong mul = 1) {
        if (exp > 0) {
            for (; ; ) {
                if ((exp & 1) == 1)
                    mul = mod.ModMul(mul, num);
                exp >>= 1;
                if (exp == 0)
                    break;
                num = mod.ModMul(num, num);
            }
        }
        return mul;
    }

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <param name="mul">optional multiplicand</param>
    /// <returns>(mul * num^exp) % mod</returns>
    public static long ModPow(this long mod, long num, long exp, long mul = 1) {
        if (exp < 0) {
            num = mod.ModInverse(num);
            exp = -exp;
        }
        if (exp > 0) {
            for (; ; ) {
                if ((exp & 1) == 1)
                    mul = mod.ModMul(mul, num);
                exp >>= 1;
                if (exp == 0)
                    break;
                num = mod.ModMul(num, num);
            }
        }
        return mul;
    }

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <returns>(num^exp) % mod</returns>
    public static UInt128 ModPow(this UInt128 mod, UInt128 num, UInt128 exp) => mod.ModPow(num, exp, 1);

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <param name="mul">multiplicand</param>
    /// <returns>(mul * num^exp) % mod</returns>
    public static UInt128 ModPow(this UInt128 mod, UInt128 num, UInt128 exp, UInt128 mul) {
        if (exp > 0) {
            for (; ; ) {
                if ((exp & 1) == 1)
                    mul = mod.ModMul(mul, num);
                exp >>= 1;
                if (exp == 0)
                    break;
                num = mod.ModMul(num, num);
            }
        }
        return mul;
    }

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <returns>(num^exp) % mod</returns>
    public static Int128 ModPow(this Int128 mod, Int128 num, Int128 exp) => mod.ModPow(num, exp, 1);

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <param name="mul">multiplicand</param>
    /// <returns>(mul * num^exp) % mod</returns>
    public static Int128 ModPow(this Int128 mod, Int128 num, Int128 exp, Int128 mul) {
        if (exp < 0) {
            num = mod.ModInverse(num);
            exp = -exp;
        }
        if (exp > 0) {
            for (; ; ) {
                if ((exp & 1) == 1)
                    mul = mod.ModMul(mul, num);
                exp >>= 1;
                if (exp == 0)
                    break;
                num = mod.ModMul(num, num);
            }
        }
        return mul;
    }

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <returns>(num^exp) % mod</returns>
    public static BigInteger ModPow(this BigInteger mod, BigInteger num, BigInteger exp) => mod.ModPow(num, exp, 1);

    /// <summary>
    /// Performs a modulo exponentiation operation.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <param name="exp">exponent</param>
    /// <param name="mul">multiplicand</param>
    /// <returns>(mul * num^exp) % mod</returns>
    public static BigInteger ModPow(this BigInteger mod, BigInteger num, BigInteger exp, BigInteger mul) {
        if (exp < 0) {
            num = mod.ModInverse(num);
            exp = (sbyte)-exp;
        }
        if (exp > 0) {
            for (; ; ) {
                if ((exp & 1) == 1)
                    mul = mod.ModMul(mul, num);
                exp >>= 1;
                if (exp == 0)
                    break;
                num = mod.ModMul(num, num);
            }
        }
        return mul;
    }

    /// <summary>
    /// Calculates the modular multiplicative inverse.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <returns>modular multiplicative inverse</returns>
    /// <exception cref="ArgumentException">If modular multiplicative inverse cannot be determined.</exception>
    public static sbyte ModInverse(this sbyte mod, sbyte num) {
        sbyte t = 0, r = mod;
        for (sbyte tNext = 1, rNext = (sbyte)(num % mod); rNext != 0;) {
            sbyte quotient = (sbyte)(r / rNext);
            (r, rNext) = (rNext, (sbyte)(r - quotient * rNext));
            (t, tNext) = (tNext, (sbyte)(t - quotient * tNext));
        }
        if (r > 1) throw new ArgumentException("No inverse exists");
        if (t < 0) t += mod;
        return t;
    }

    /// <summary>
    /// Calculates the modular multiplicative inverse.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <returns>modular multiplicative inverse</returns>
    /// <exception cref="ArgumentException">If modular multiplicative inverse cannot be determined.</exception>
    public static short ModInverse(this short mod, short num) {
        short t = 0, r = mod;
        for (short tNext = 1, rNext = (short)(num % mod); rNext != 0;) {
            short quotient = (short)(r / rNext);
            (r, rNext) = (rNext, (short)(r - quotient * rNext));
            (t, tNext) = (tNext, (short)(t - quotient * tNext));
        }
        if (r > 1) throw new ArgumentException("No inverse exists");
        if (t < 0) t += mod;
        return t;
    }

    /// <summary>
    /// Calculates the modular multiplicative inverse.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <returns>modular multiplicative inverse</returns>
    /// <exception cref="ArgumentException">If modular multiplicative inverse cannot be determined.</exception>
    public static int ModInverse(this int mod, int num) {
        int t = 0, r = mod;
        for (int tNext = 1, rNext = num % mod; rNext != 0;) {
            int quotient = r / rNext;
            (r, rNext) = (rNext, r - quotient * rNext);
            (t, tNext) = (tNext, t - quotient * tNext);
        }
        if (r > 1) throw new ArgumentException("No inverse exists");
        if (t < 0) t += mod;
        return t;
    }

    /// <summary>
    /// Calculates the modular multiplicative inverse.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <returns>modular multiplicative inverse</returns>
    /// <exception cref="ArgumentException">If modular multiplicative inverse cannot be determined.</exception>
    public static long ModInverse(this long mod, long num) {
        long t = 0, r = mod;
        for (long tNext = 1, rNext = num % mod; rNext != 0;) {
            long quotient = r / rNext;
            (r, rNext) = (rNext, r - quotient * rNext);
            (t, tNext) = (tNext, t - quotient * tNext);
        }
        if (r > 1) throw new ArgumentException("No inverse exists");
        if (t < 0) t += mod;
        return t;
    }

    /// <summary>
    /// Calculates the modular multiplicative inverse.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <returns>modular multiplicative inverse</returns>
    /// <exception cref="ArgumentException">If modular multiplicative inverse cannot be determined.</exception>
    public static Int128 ModInverse(this Int128 mod, Int128 num) {
        Int128 t = 0, r = mod;
        for (Int128 tNext = 1, rNext = num % mod; rNext != 0;) {
            Int128 quotient = r / rNext;
            (r, rNext) = (rNext, r - quotient * rNext);
            (t, tNext) = (tNext, t - quotient * tNext);
        }
        if (r > 1) throw new ArgumentException("No inverse exists");
        if (t < 0) t += mod;
        return t;
    }

    /// <summary>
    /// Calculates the modular multiplicative inverse.
    /// </summary>
    /// <param name="mod">modulo</param>
    /// <param name="num">base number</param>
    /// <returns>modular multiplicative inverse</returns>
    /// <exception cref="ArgumentException">If modular multiplicative inverse cannot be determined.</exception>
    public static BigInteger ModInverse(this BigInteger mod, BigInteger num) {
        BigInteger t = BigInteger.Zero, r = mod;
        for (BigInteger tNext = BigInteger.One, rNext = num % mod; rNext != 0;) {
            BigInteger quotient = r / rNext;
            (r, rNext) = (rNext, r - quotient * rNext);
            (t, tNext) = (tNext, t - quotient * tNext);
        }
        if (r > 1) throw new ArgumentException("No inverse exists");
        if (t < 0) t += mod;
        return t;
    }

    /// <summary>
    /// Returns the minimum of provided values.
    /// </summary>
    /// <param name="a">first value</param>
    /// <param name="rest">the remaining values</param>
    /// <typeparam name="T">value type</typeparam>
    /// <returns>value that compares as the minimum of the values provided</returns>
    public static T Min<T>(this T a, params T[] rest) where T : IComparable {
        foreach (var b in rest)
            if (b.CompareTo(a) < 0)
                a = b;
        return a;
    }

    /// <summary>
    /// Returns the maximum of provided values.
    /// </summary>
    /// <param name="a">first value</param>
    /// <param name="rest">the remaining values</param>
    /// <typeparam name="T">value type</typeparam>
    /// <returns>value that compares as the maximum of the values provided</returns>
    public static T Max<T>(this T a, params T[] rest) where T : IComparable {
        foreach (var b in rest)
            if (b.CompareTo(a) > 0)
                a = b;
        return a;
    }

    /// <summary>
    /// Returns the two minimums of provided values.
    /// </summary>
    /// <param name="a">first value</param>
    /// <param name="b">second value</param>
    /// <param name="rest">the remaining values</param>
    /// <typeparam name="T">value type</typeparam>
    /// <returns>two values that compare as the minimums of the values provided</returns>
    public static (T min, T min2) Min2<T>(this T a, T b, params T[] rest) where T : IComparable {
        if (b.CompareTo(a) < 0) (a, b) = (b, a);
        foreach (var c in rest)
            if (c.CompareTo(a) < 0)
                (a, b) = (c, a);
            else if (c.CompareTo(b) < 0)
                b = c;
        return (a, b);
    }

    /// <summary>
    /// Returns the two maximums of provided values.
    /// </summary>
    /// <param name="a">first value</param>
    /// <param name="b">second value</param>
    /// <param name="rest">the remaining values</param>
    /// <typeparam name="T">value type</typeparam>
    /// <returns>two values that compare as the maximums of the values provided</returns>
    public static (T max, T max2) Max2<T>(this T a, T b, params T[] rest) where T : IComparable {
        if (b.CompareTo(a) > 0) (a, b) = (b, a);
        foreach (var c in rest)
            if (c.CompareTo(a) > 0)
                (a, b) = (c, a);
            else if (c.CompareTo(b) > 0)
                b = c;
        return (a, b);
    }
}