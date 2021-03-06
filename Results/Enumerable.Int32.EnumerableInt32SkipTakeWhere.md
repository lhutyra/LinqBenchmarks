﻿## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop | 1000 |   100 | 3.006 μs | 0.0229 μs | 0.0191 μs |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 4.524 μs | 0.0143 μs | 0.0112 μs |  1.50 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |   100 | 4.638 μs | 0.0275 μs | 0.0244 μs |  1.54 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |   100 | 3.442 μs | 0.0169 μs | 0.0158 μs |  1.14 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |   100 | 3.301 μs | 0.0071 μs | 0.0059 μs |  1.10 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |   100 | 4.075 μs | 0.0091 μs | 0.0076 μs |  1.36 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |   100 | 3.879 μs | 0.0141 μs | 0.0125 μs |  1.29 | 0.0153 |     - |     - |      40 B |
