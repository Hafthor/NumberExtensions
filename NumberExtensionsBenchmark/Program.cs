using BenchmarkDotNet.Attributes;
using NumberExtensions;

namespace NumberExtensionsBenchmark; 

public class NumberExtensionsBenchmark {
    private readonly double d;
    private readonly float f;

    public NumberExtensionsBenchmark() {
        Random random = new(1);
        ushort w = (ushort)random.Next(0, 65536);
        uint dw = (uint)random.Next(0, 65536) << 16 | w;
        ulong qw = (ulong)random.Next(0, 65536) << 48 | (ulong)random.Next(0, 65536) << 32 | dw;
        d = BitConverter.UInt64BitsToDouble(qw);
        f = BitConverter.UInt32BitsToSingle(dw);
        if (double.IsNegative(d) || double.IsInfinity(d) || double.IsNaN(d))
            throw new ApplicationException();
        if (double.IsNegative(f) || double.IsInfinity(f) || double.IsNaN(f))
            throw new ApplicationException();
    }

    public static void Main() {
        BenchmarkDotNet.Running.BenchmarkRunner.Run<NumberExtensionsBenchmark>();
    }
    
    [Benchmark] // 0.7857 ns (3x faster)
    public int DoubleLog2Floor() => d.Log2Floor();

    [Benchmark] // 0.7674 ns (3x faster)
    public int FloatLog2Floor() => f.Log2Floor();

    [Benchmark] // 0.9200 ns (2.6x faster)
    public int DoubleLog2Ceiling() => d.Log2Ceiling();

    [Benchmark] // 0.9111 ns (2.6x faster)
    public int FloatLog2Ceiling() => f.Log2Ceiling();

    [Benchmark] // 2.3891 ns
    public int DoubleFloorLog2() => (int)Math.Floor(Math.Log2(d));

    [Benchmark] // 2.3999 ns
    public int FloatFloorLog2() => (int)Math.Floor(Math.Log2(f));

    [Benchmark] // 2.3977 ns
    public int DoubleCeilingLog2() => (int)Math.Ceiling(Math.Log2(d));

    [Benchmark] // 2.3997 ns
    public int FloatCeilingLog2() => (int)Math.Ceiling(Math.Log2(f));
}