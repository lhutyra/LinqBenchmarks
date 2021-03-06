﻿using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;

namespace LinqBenchmarks.List.ValueType
{
    public class ListValueTypeSelectSum: ValueTypeListBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
                sum += source[index].Value0;
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
                sum += item.Value0;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int Linq()
            => System.Linq.Enumerable.Sum(source, item => item.Value0);

        [Benchmark]
        public int LinqFaster()
            => source.SumF(item => item.Value0);

        [Benchmark]
        public int LinqAF()
            => global::LinqAF.ListExtensionMethods.Sum(source, item => item.Value0);

        [Benchmark]
        public int StructLinq()
            => source.ToRefStructEnumerable()
                .Sum((in FatValueType x) => x.Value0);

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var selector = new Value0Selector();
            return source
                .ToRefStructEnumerable()
                .Sum(ref selector, x => x, x => x);
        }

        [Benchmark]
        public int Hyperlinq()
            => source.AsValueEnumerableRef()
                .Select((in FatValueType item) => item.Value0)
                .Sum();

        [Benchmark]
        public int Hyperlinq_IFunction()
            => source.AsValueEnumerableRef()
                .Select<int, Value0Selector>()
                .Sum();
    }
}
