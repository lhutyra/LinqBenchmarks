﻿## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   491.6 ns |   2.05 ns |   1.81 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 5,336.4 ns |  19.64 ns |  16.40 ns | 10.85 |    0.04 | 0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |   100 | 1,852.1 ns |   6.74 ns |   5.97 ns |  3.77 |    0.02 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 2,402.9 ns |  21.45 ns |  19.02 ns |  4.89 |    0.04 | 6.3133 |     - |     - |   13224 B |
|               LinqAF | 1000 |   100 | 9,336.5 ns | 172.37 ns | 169.29 ns | 19.00 |    0.37 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   655.3 ns |   1.81 ns |   1.60 ns |  1.33 |    0.01 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   532.3 ns |   2.06 ns |   1.92 ns |  1.08 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   537.4 ns |   2.11 ns |   1.87 ns |  1.09 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   495.5 ns |   6.80 ns |   6.03 ns |  1.01 |    0.01 |      - |     - |     - |         - |
