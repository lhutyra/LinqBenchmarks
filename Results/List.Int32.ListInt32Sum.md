﻿## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   104.16 ns |  0.261 ns |  0.204 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   508.70 ns | 10.765 ns | 31.741 ns |  4.92 |    0.35 |      - |     - |     - |         - |
|                 Linq |   100 | 1,396.40 ns | 27.713 ns | 64.779 ns | 13.42 |    0.71 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |   100 | 1,423.74 ns | 28.149 ns | 66.350 ns | 13.60 |    0.82 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 1,145.08 ns | 26.169 ns | 77.161 ns | 11.27 |    0.78 |      - |     - |     - |         - |
|           StructLinq |   100 |    92.23 ns |  0.460 ns |  0.384 ns |  0.89 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |    67.30 ns |  0.378 ns |  0.354 ns |  0.65 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |    25.83 ns |  0.395 ns |  0.369 ns |  0.25 |    0.00 |      - |     - |     - |         - |
