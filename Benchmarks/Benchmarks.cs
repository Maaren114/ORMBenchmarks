using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using EFCoreBenchmarks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [CsvExporter]
    [MaxIterationCount(10000)]
    //[SimpleJob(RunStrategy.ColdStart, launchCount: 1, warmupCount: 10, iterationCount: 100, id: "benchmarks")]
    public class Benchmarks
    {
        private static EFCoreRepository _EFCoreRepository;
        private List<EFCoreBenchmarks.models.Adres> _adressen = new List<EFCoreBenchmarks.models.Adres>();

        public Benchmarks()
        {
            _EFCoreRepository = new EFCoreRepository();
            _adressen = _EFCoreRepository.GetAdressen("Zottegem");
        }


        [Benchmark]
        public void EFCoreCreate1()
        {
            _EFCoreRepository.Create1(_adressen);
        }

        [Benchmark]
        public void EFCoreCreate2()
        {
            _EFCoreRepository.Create2(_adressen);
        }

        [Benchmark]
        public void EFCoreCreate3()
        {
            _EFCoreRepository.Create3(_adressen);
        }
    }
}








