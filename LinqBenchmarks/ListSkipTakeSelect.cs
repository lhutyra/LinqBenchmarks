﻿using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks
{
    public class ListSkipTakeSelect : BenchmarkBase
    {
        List<int> source;

        [Params(1_000)]
        public int Skip { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
            => source = Enumerable.Range(0, Skip + Count).ToList();

        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var end = Skip + Count;
            for (var index = Skip; index < end; index++)
                sum += source[index] * 2;
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            using var enumerator = ((IEnumerable<int>)source).GetEnumerator();
            for (var index = 0; index < Skip; index++)
                _ = enumerator.MoveNext();
            var sum = 0;
            for (var index = 0; index < Count; index++)
                sum += enumerator.Current * 2;
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in Enumerable.Skip(source, Skip).Take(Count).Select(item => item * 2))
                sum += item;
            return sum;
        }

        //[Benchmark]
        //public int LinqFaster()
        //{
        //    var items = JM.LinqFaster.LinqFaster.SelectF(source, item => item * 2);
        //    var sum = 0;
        //    for (var index = 0; index < items.Length; index++)
        //        sum += items[index];
        //    return sum;
        //}

        //[Benchmark]
        //public int StructLinq()
        //{
        //    var sum = 0;
        //    foreach (var item in source.ToStructEnumerable().Select(item => item * 2, x => x))
        //        sum += item;
        //    return sum;
        //}

        //[Benchmark]
        //public int StructLinq_IFunction()
        //{
        //    var sum = 0;
        //    var mult = new Mult();
        //    foreach (var item in source.ToStructEnumerable().Select(ref mult, x => x))
        //        sum += item;
        //    return sum;
        //}

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            var items = ListBindings.Skip(source, Skip).Take(Count).Select(item => item * 2);
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        struct Mult: IFunction<int, int>
        {
            public int Eval(int element)
                => element * 2;
        }
    }
}