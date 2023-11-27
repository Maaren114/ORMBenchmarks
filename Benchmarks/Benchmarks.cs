using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using EFCoreBenchmarks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZZProjectsBenchmarks;

namespace Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [CsvExporter]
    //[MaxIterationCount(10000)]
    //[SimpleJob(RunStrategy.ColdStart, launchCount: 1, warmupCount: 10, iterationCount: 100, id: "benchmarks")]
    public class Benchmarks
    {
        private static EFCoreRepository _EFCoreRepository;
        private static ZZZProjectsRepository _zzzProjectRepository;

        private List<EFCoreBenchmarks.models.Adres> _adressen1 = new List<EFCoreBenchmarks.models.Adres>();
        private List<ZZZProjectsBenchmarks.models.Adres> _adressen2 = new List<ZZZProjectsBenchmarks.models.Adres>();

        public Benchmarks()
        {
            _EFCoreRepository = new EFCoreRepository();
            _zzzProjectRepository = new ZZZProjectsRepository();
            _adressen1 = _EFCoreRepository.GetAdressen("Zottegem");
            _adressen2 = _zzzProjectRepository.GetAdressen("Zottegem");
        }


        [Benchmark]
        public void EFBorisDjCreate()
        {
            _EFCoreRepository.EFBorisDjCreate(_adressen1);
        }

        [Benchmark]
        public void EFCoreZzzProjectsCreate()
        {
            _zzzProjectRepository.Create1(_adressen2);
        }

        [IterationCleanup]
        public void CleanupAfterIteration()
        {


        }
    }
}








