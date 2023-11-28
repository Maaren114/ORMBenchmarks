using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using DapperBenchmarks;
using EFCoreBenchmarks;
using LinqToDbBenchmarks;
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
    [MaxIterationCount(100)]
    //[SimpleJob(RunStrategy.ColdStart, launchCount: 1, warmupCount: 10, iterationCount: 100, id: "benchmarks")]
    public class Benchmarks
    {
        private static EFCoreRepository _EFCoreRepository;
        private static ZZZProjectsRepository _zzzProjectRepository;
        private static DapperRepository _dapperRepository;
        private static LinqToDbRepository _linqToDbRepository;


        private List<EFCoreBenchmarks.models.Adres> _adressen1 = new List<EFCoreBenchmarks.models.Adres>();
        private List<ZZZProjectsBenchmarks.models.Adres> _adressen2 = new List<ZZZProjectsBenchmarks.models.Adres>();
        private List<DapperBenchmarks.models.Adres> _adressen3 = new List<DapperBenchmarks.models.Adres>();
        private List<LinqToDbBenchmarks.models.Adres> _adressen4 = new List<LinqToDbBenchmarks.models.Adres>();


        public Benchmarks()
        {
            _EFCoreRepository = new EFCoreRepository();
            _zzzProjectRepository = new ZZZProjectsRepository();
            _dapperRepository = new DapperRepository();
            _linqToDbRepository = new LinqToDbRepository();
            _adressen1 = _EFCoreRepository.GetAdressen("Zottegem");
            _adressen2 = _zzzProjectRepository.GetAdressen("Zottegem");
            _adressen3 = _dapperRepository.GetAddressen("Zottegem");
            _adressen4 = _linqToDbRepository.GetAdressen("Zottegem");
            _adressen1.ForEach(adres => adres.AdresId = 0);
            _adressen2.ForEach(adres => adres.AdresId = 0);
            _adressen3.ForEach(adres => adres.AdresId = 0);
            _adressen4.ForEach(adres => adres.AdresID = 0);
        }

        //[Benchmark]
        //public void EFAddRange()
        //{
        //    _EFCoreRepository.AddRange(_adressen1);
        //}

        [Benchmark]
        public void EFBorisDjCreate()
        {
            _EFCoreRepository.EFBorisDjCreate(_adressen1);
        }

        [Benchmark]
        public void EFCoreExecuteSqlRaw()
        {
            _EFCoreRepository.ExecuteSqlRaw(_adressen1);
        }

        [Benchmark]
        public void EFCoreExecuteSql()
        {
            _EFCoreRepository.ExecuteSql(_adressen1);
        }

        [Benchmark]
        public void EFCoreZzzProjectsCreate()
        {
            _zzzProjectRepository.Create1(_adressen2);
        }

        [Benchmark]
        public void DapperExecute()
        {
            _dapperRepository.DapperExecute(_adressen3);
        }

        [Benchmark]
        public void DapperPlus()
        {
            _dapperRepository.DapperPlus(_adressen3);
        }

        [Benchmark]
        public void LinqToDbExecute()
        {
            _linqToDbRepository.CreateExecute(_adressen4);
        }

        [Benchmark]
        public void LinqToDbBulkCopy()
        {
            _linqToDbRepository.CreateBulkCopy(_adressen4);
        }

        [IterationCleanup]
        public void CleanupAfterIteration()
        {

        }
    }
}










