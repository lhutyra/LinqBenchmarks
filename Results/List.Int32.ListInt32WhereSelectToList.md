﻿## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                                        Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|                            ValueLinq_Standard |   100 |   527.5 ns | 2.93 ns | 2.60 ns |  1.83 |    0.01 | 0.3090 |     - |     - |     648 B |
|                               ValueLinq_Stack |   100 |   805.9 ns | 2.50 ns | 2.21 ns |  2.79 |    0.02 | 0.1297 |     - |     - |     272 B |
|                     ValueLinq_SharedPool_Push |   100 |   900.5 ns | 1.77 ns | 1.48 ns |  3.12 |    0.02 | 0.1297 |     - |     - |     272 B |
|                     ValueLinq_SharedPool_Pull |   100 |   959.7 ns | 3.62 ns | 3.21 ns |  3.33 |    0.02 | 0.1297 |     - |     - |     272 B |
|                ValueLinq_ValueLambda_Standard |   100 |   367.6 ns | 0.99 ns | 0.83 ns |  1.28 |    0.01 | 0.3095 |     - |     - |     648 B |
|                   ValueLinq_ValueLambda_Stack |   100 |   555.9 ns | 1.07 ns | 0.95 ns |  1.93 |    0.01 | 0.1297 |     - |     - |     272 B |
|         ValueLinq_ValueLambda_SharedPool_Push |   100 |   630.2 ns | 0.72 ns | 0.56 ns |  2.19 |    0.01 | 0.1297 |     - |     - |     272 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |   100 |   851.2 ns | 3.57 ns | 2.98 ns |  2.95 |    0.02 | 0.1297 |     - |     - |     272 B |
|                    ValueLinq_Standard_ByIndex |   100 |   539.1 ns | 3.43 ns | 2.87 ns |  1.87 |    0.01 | 0.3090 |     - |     - |     648 B |
|                       ValueLinq_Stack_ByIndex |   100 |   667.1 ns | 1.19 ns | 1.11 ns |  2.31 |    0.01 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Push_ByIndex |   100 |   942.5 ns | 3.17 ns | 2.81 ns |  3.27 |    0.02 | 0.1297 |     - |     - |     272 B |
|             ValueLinq_SharedPool_Pull_ByIndex |   100 |   850.1 ns | 3.65 ns | 3.23 ns |  2.95 |    0.02 | 0.1297 |     - |     - |     272 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |   100 |   391.8 ns | 3.81 ns | 2.98 ns |  1.36 |    0.01 | 0.3095 |     - |     - |     648 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |   100 |   396.0 ns | 1.44 ns | 1.27 ns |  1.37 |    0.01 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |   100 |   611.0 ns | 1.48 ns | 1.31 ns |  2.12 |    0.01 | 0.1297 |     - |     - |     272 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |   100 |   646.5 ns | 2.06 ns | 1.93 ns |  2.24 |    0.02 | 0.1297 |     - |     - |     272 B |
|                                       ForLoop |   100 |   288.3 ns | 2.07 ns | 1.61 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|                                   ForeachLoop |   100 |   408.6 ns | 3.11 ns | 2.75 ns |  1.42 |    0.01 | 0.3095 |     - |     - |     648 B |
|                                          Linq |   100 |   538.7 ns | 2.77 ns | 2.46 ns |  1.87 |    0.01 | 0.3824 |     - |     - |     800 B |
|                                    LinqFaster |   100 |   483.5 ns | 3.26 ns | 2.89 ns |  1.68 |    0.01 | 0.4396 |     - |     - |     920 B |
|                                        LinqAF |   100 | 1,226.2 ns | 4.98 ns | 4.66 ns |  4.25 |    0.03 | 0.3090 |     - |     - |     648 B |
|                                    StructLinq |   100 |   506.5 ns | 2.48 ns | 2.32 ns |  1.76 |    0.02 | 0.1755 |     - |     - |     368 B |
|                          StructLinq_IFunction |   100 |   298.3 ns | 1.07 ns | 0.89 ns |  1.03 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     Hyperlinq |   100 |   639.5 ns | 1.79 ns | 1.59 ns |  2.22 |    0.01 | 0.1297 |     - |     - |     272 B |
|                           Hyperlinq_IFunction |   100 |   355.8 ns | 1.30 ns | 1.15 ns |  1.23 |    0.01 | 0.1297 |     - |     - |     272 B |
