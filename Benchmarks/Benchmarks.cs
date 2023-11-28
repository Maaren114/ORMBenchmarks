using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using DapperBenchmarks;
using EFCoreBenchmarks;
using LinqToDbBenchmarks;
using NHibernateBenchmarks;
using Norm.NetBenchmarks;
using OrmLiteBenchmarks;
using PetaPocoBenchmarks;
using RepoDbBenchmarks;
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
        private static NHibernateRepository _nhibernateRepository;
        private static NormNetRepository _normNetRepository;
        private static OrmLiteRepository _ormLiteRepository;
        private static PetaPocoRepository _petapocorepository;
        private static RepoDbRepository _repoDbRepository;

        private List<EFCoreBenchmarks.models.Adres> _efCoreAdressen = new List<EFCoreBenchmarks.models.Adres>();
        private List<ZZZProjectsBenchmarks.models.Adres> _adressen2 = new List<ZZZProjectsBenchmarks.models.Adres>();
        private List<DapperBenchmarks.models.Adres> _dapperAdressen = new List<DapperBenchmarks.models.Adres>();
        private List<LinqToDbBenchmarks.models.Adres> _linqToDbAdressen = new List<LinqToDbBenchmarks.models.Adres>();

        public Benchmarks()
        {
            _EFCoreRepository = new EFCoreRepository();
            _zzzProjectRepository = new ZZZProjectsRepository();
            _dapperRepository = new DapperRepository();
            _linqToDbRepository = new LinqToDbRepository();
            _efCoreAdressen = _EFCoreRepository.GetAdressen("Zottegem");
            _adressen2 = _zzzProjectRepository.GetAdressen("Zottegem");
            _dapperAdressen = _dapperRepository.GetAddressen("Zottegem");
            _linqToDbAdressen = _linqToDbRepository.GetAdressen("Zottegem");
            _efCoreAdressen.ForEach(adres => adres.AdresId = 0);
            _adressen2.ForEach(adres => adres.AdresId = 0);
            _dapperAdressen.ForEach(adres => adres.AdresId = 0);
            _linqToDbAdressen.ForEach(adres => adres.AdresID = 0);
        }

        #region EF Core
        [Benchmark]
        public void EFBorisDjCreate()
        {
            _EFCoreRepository.EFBorisDjCreate(_efCoreAdressen);
        }

        [Benchmark]
        public void EFCoreExecuteSqlRaw()
        {
            _EFCoreRepository.ExecuteSqlRaw(_efCoreAdressen);
        }

        [Benchmark]
        public void EFCoreExecuteSql()
        {
            _EFCoreRepository.ExecuteSql(_efCoreAdressen);
        }

        [Benchmark]
        public void EFCoreZzzProjectsCreate()
        {
            _zzzProjectRepository.Create1(_adressen2);
        }
        #endregion

        #region Dapper
        [Benchmark]
        public void DapperExecute()
        {
            _dapperRepository.DapperExecute(_dapperAdressen);
        }

        [Benchmark]
        public void DapperPlus()
        {
            _dapperRepository.DapperPlus(_dapperAdressen);
        }
        #endregion

        #region Linq to DB
        [Benchmark]
        public void LinqToDbExecute()
        {
            _linqToDbRepository.CreateExecute(_linqToDbAdressen);
        }

        [Benchmark]
        public void LinqToDbBulkCopy()
        {
            _linqToDbRepository.CreateBulkCopy(_linqToDbAdressen);
        }
        #endregion

        #region NHibernate

        #endregion

        #region Norm.NET

        #endregion

        #region OrmLite

        #endregion

        #region PetaPoco

        #endregion

        #region RepoDB

        #endregion



        [IterationCleanup]
        public void CleanupAfterIteration()
        {

        }
    }
}










