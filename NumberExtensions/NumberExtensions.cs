namespace NumberExtensions;

public static class NumberExtensions {
    // used for BitCount and ReverseBits
    private static readonly UInt128 UINT128_MASK1 = new(0x5555555555555555UL, 0x5555555555555555UL);
    private static readonly UInt128 UINT128_MASK2 = new(0x3333333333333333UL, 0x3333333333333333UL);
    private static readonly UInt128 UINT128_MASK4 = new(0x0F0F0F0F0F0F0F0FUL, 0x0F0F0F0F0F0F0F0FUL);
    private static readonly UInt128 UINT128_MASK8 = new(0x00FF00FF00FF00FFUL, 0x00FF00FF00FF00FFUL);
    private static readonly UInt128 UINT128_MASK16 = new(0x0000FFFF0000FFFFUL, 0x0000FFFF0000FFFFUL);
    private static readonly UInt128 UINT128_MASK32 = new(0x00000000FFFFFFFFUL, 0x00000000FFFFFFFFUL);
    private static readonly UInt128 UINT128_MASK64 = new(0x0000000000000000UL, 0xFFFFFFFFFFFFFFFFUL);
    
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
    public static bool IsPowerOf2(this sbyte value) {
        return value > 0 && (value & (value - 1)) == 0;
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this byte value) {
        return value > 0 && (value & (value - 1)) == 0;
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this short value) {
        return value > 0 && (value & (value - 1)) == 0;
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this ushort value) {
        return value > 0 && (value & (value - 1)) == 0;
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this int value) {
        return value > 0 && (value & (value - 1)) == 0;
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this uint value) {
        return value > 0 && (value & (value - 1)) == 0;
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this long value) {
        return value > 0 && (value & (value - 1)) == 0;
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this ulong value) {
        return value > 0 && (value & (value - 1)) == 0;
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this Int128 value) {
        return value > 0 && (value & (value - 1)) == 0;
    }
    
    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this UInt128 value) {
        return value > 0 && (value & (value - 1)) == 0;
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this double value) {
        const int MANTISSA_BITS = 52;
        const int EXPONENT_BITS = 11;
        long l = BitConverter.DoubleToInt64Bits(value);
        if (l <= 0) // negative or zero or -NaN or -Infinity
            return false;

        var exponent = l >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            return false;

        var mantissa = l & ((1L << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return mantissa.IsPowerOf2();

        // there is an implied 1 prefix on the mantissa normally
        return mantissa == 0;
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this float value) {
        const int MANTISSA_BITS = 23;
        const int EXPONENT_BITS = 8;
        int i = BitConverter.SingleToInt32Bits(value);
        if (i <= 0) // negative or zero or -NaN or -Infinity
            return false;

        var exponent = i >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            return false;

        var mantissa = i & ((1 << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return mantissa.IsPowerOf2();

        // there is an implied 1 prefix on the mantissa normally
        return mantissa == 0;
    }

    /// <summary>
    /// Determines if number is a power of 2.
    /// </summary>
    /// <param name="value">value to check</param>
    /// <returns>true if value is a power of 2</returns>
    public static bool IsPowerOf2(this Half value) {
        const int MANTISSA_BITS = 10;
        const int EXPONENT_BITS = 5;
        short s = BitConverter.HalfToInt16Bits(value);
        if (s <= 0) // negative or zero or -NaN or -Infinity
            return false;

        var exponent = s >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            return false;

        var mantissa = s & ((1 << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return mantissa.IsPowerOf2();

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
        int log = 6;
        for (sbyte b = 1 << 6; b > 0; b >>= 1, log--)
            if (value >= b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Floor(this byte value) {
        int log = 7;
        for (byte b = 1 << 7; b > 0; b >>= 1, log--)
            if (value >= b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be non-zero");
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Floor(this short value) {
        int log = 14;
        for (short b = 1 << 14; b > 0; b >>= 1, log--)
            if (value >= b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Floor(this ushort value) {
        int log = 15;
        for (ushort b = 1 << 15; b > 0; b >>= 1, log--)
            if (value >= b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be non-zero");
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Floor(this int value) {
        int log = 30;
        for (int b = 1 << 30; b > 0; b >>= 1, log--)
            if (value >= b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Floor(this uint value) {
        int log = 31;
        for (uint b = 1U << 31; b > 0; b >>= 1, log--)
            if (value >= b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be non-zero");
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Floor(this long value) {
        int log = 62;
        for (long b = 1L << 62; b > 0; b >>= 1, log--)
            if (value >= b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }
    
    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Floor(this ulong value) {
        int log = 63;
        for (ulong b = 1UL << 63; b > 0; b >>= 1, log--)
            if (value >= b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be non-zero");
    }

    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Floor(this Int128 value) {
        int log = 126;
        for (Int128 b = ((Int128)1) << 126; b > 0; b >>= 1, log--)
            if (value >= b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }
    
    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Floor(this UInt128 value) {
        int log = 127;
        for (UInt128 b = ((UInt128)1) << 127; b > 0; b >>= 1, log--)
            if (value >= b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be non-zero");
    }
    
    /// <summary>
    /// Calculates the integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative, zero, infinity or NaN</exception>
    public static int Log2Floor(this double value) {
        const int MANTISSA_BITS = 52;
        const int EXPONENT_BITS = 11;
        long l = BitConverter.DoubleToInt64Bits(value);
        if (l <= 0) // negative or zero or -NaN or -Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");

        var exponent = l >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive finite number");

        var mantissa = l & ((1L << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return mantissa.Log2Floor() - 1023 - 51;

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
        const int MANTISSA_BITS = 23;
        const int EXPONENT_BITS = 8;
        int i = BitConverter.SingleToInt32Bits(value);
        if (i <= 0) // negative or zero or -NaN or -Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");

        var exponent = i >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive finite number");

        var mantissa = i & ((1 << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return mantissa.Log2Floor() - 127 - 22;

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
        const int MANTISSA_BITS = 10;
        const int EXPONENT_BITS = 5;
        short s = BitConverter.HalfToInt16Bits(value);
        if (s <= 0) // negative or zero or -NaN or -Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");

        var exponent = s >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive finite number");

        var mantissa = s & ((1 << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return mantissa.Log2Floor() - 15 - 9;

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
        if (value == 1) return 0;
        int log = 7;
        for (sbyte b = 1 << 6; b > 0; b >>= 1, log--)
            if (value > b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Ceiling(this byte value) {
        if (value == 1) return 0;
        int log = 8;
        for (byte b = 1 << 7; b > 0; b >>= 1, log--)
            if (value > b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Ceiling(this short value) {
        if (value == 1) return 0;
        int log = 15;
        for (short b = 1 << 14; b > 0; b >>= 1, log--)
            if (value > b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Ceiling(this ushort value) {
        if (value == 1) return 0;
        int log = 16;
        for (ushort b = 1 << 15; b > 0; b >>= 1, log--)
            if (value > b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Ceiling(this int value) {
        if (value == 1) return 0;
        int log = 31;
        for (int b = 1 << 30; b > 0; b >>= 1, log--)
            if (value > b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Ceiling(this uint value) {
        if (value == 1) return 0;
        int log = 32;
        for (uint b = 1U << 31; b > 0; b >>= 1, log--)
            if (value > b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Ceiling(this long value) {
        if (value == 1) return 0;
        int log = 63;
        for (long b = 1L << 62; b > 0; b >>= 1, log--)
            if (value > b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Ceiling(this ulong value) {
        if (value == 1) return 0;
        int log = 64;
        for (ulong b = 1UL << 63; b > 0; b >>= 1, log--)
            if (value > b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative or zero</exception>
    public static int Log2Ceiling(this Int128 value) {
        if (value == 1) return 0;
        int log = 127;
        for (Int128 b = ((Int128)1) << 126; b > 0; b >>= 1, log--)
            if (value > b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is zero</exception>
    public static int Log2Ceiling(this UInt128 value) {
        if (value == 1) return 0;
        int log = 128;
        for (UInt128 b = ((UInt128)1) << 127; b > 0; b >>= 1, log--)
            if (value > b)
                return log;
        throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative, zero, infinity or NaN</exception>
    public static int Log2Ceiling(this double value) {
        const int MANTISSA_BITS = 52;
        const int EXPONENT_BITS = 11;
        long l = BitConverter.DoubleToInt64Bits(value);
        if (l <= 0) // negative or zero or -NaN or -Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");

        var exponent = l >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive finite number");

        var mantissa = l & ((1L << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return mantissa.Log2Ceiling() - 1023 - 51;

        // there is an implied 1 prefix on the mantissa normally
        return (int)(exponent - 1023) + (mantissa == 0 ? 0 : 1);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative, zero, infinity or NaN</exception>
    public static int Log2Ceiling(this float value) {
        const int MANTISSA_BITS = 23;
        const int EXPONENT_BITS = 8;
        int i = BitConverter.SingleToInt32Bits(value);
        if (i <= 0) // negative or zero or -NaN or -Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");

        var exponent = i >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive finite number");

        var mantissa = i & ((1 << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return mantissa.Log2Ceiling() - 127 - 22;

        // there is an implied 1 prefix on the mantissa normally
        return exponent - 127 + (mantissa == 0 ? 0 : 1);
    }

    /// <summary>
    /// Calculates the rounded up integer portion of the base 2 logarithm of the value.
    /// </summary>
    /// <param name="value">value to take log2 of</param>
    /// <returns>integer portion of the base 2 logarithm of value</returns>
    /// <exception cref="ArgumentOutOfRangeException">if value is negative, zero, infinity or NaN</exception>
    public static int Log2Ceiling(this Half value) {
        const int MANTISSA_BITS = 10;
        const int EXPONENT_BITS = 5;
        short s = BitConverter.HalfToInt16Bits(value);
        if (s <= 0) // negative or zero or -NaN or -Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive non-zero");

        var exponent = s >> MANTISSA_BITS;
        if (exponent == (1 << EXPONENT_BITS) - 1) // max exponent = NaN or Infinity
            throw new ArgumentOutOfRangeException(nameof(value), "value must be positive finite number");

        var mantissa = s & ((1 << MANTISSA_BITS) - 1);
        if (exponent == 0) // min exponent = denormalized or zero
            return mantissa.Log2Ceiling() - 15 - 9;

        // there is an implied 1 prefix on the mantissa normally
        return exponent - 15 + (mantissa == 0 ? 0 : 1);
    }
}