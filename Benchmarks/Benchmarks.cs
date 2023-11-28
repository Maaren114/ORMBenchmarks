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
using Tools;
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
        private static EFCoreRepository? _EFCoreRepository;
        private static ZZZProjectsRepository? _zzzProjectRepository;
        private static DapperRepository? _dapperRepository;
        private static LinqToDbRepository? _linqToDbRepository;
        private static NHibernateRepository? _nhibernateRepository;
        private static NormNetRepository? _normNetRepository;
        private static OrmLiteRepository? _ormLiteRepository;
        private static PetaPocoRepository? _petapocorepository;
        private static RepoDbRepository? _repoDbRepository;

        private List<AdresX> _adressen = new List<AdresX>();

        public Benchmarks()
        {
            _EFCoreRepository = new EFCoreRepository();
            _zzzProjectRepository = new ZZZProjectsRepository();
            _dapperRepository = new DapperRepository();
            _linqToDbRepository = new LinqToDbRepository();
            _nhibernateRepository = new NHibernateRepository();
            _normNetRepository = new NormNetRepository();
            _ormLiteRepository = new OrmLiteRepository();
            _petapocorepository = new PetaPocoRepository();
            _repoDbRepository = new RepoDbRepository();
            _adressen = _EFCoreRepository.GetAdressen("Zottegem");
        }

        #region EF Core
        [Benchmark]
        public void EFBorisDjCreate()
        {
            _EFCoreRepository.EFBorisDjCreate(_adressen);
        }

        [Benchmark]
        public void EFCoreExecuteSqlRaw()
        {
            _EFCoreRepository.ExecuteSqlRaw(_adressen);
        }

        [Benchmark]
        public void EFCoreExecuteSql()
        {
            _EFCoreRepository.ExecuteSql(_adressen);
        }

        [Benchmark]
        public void EFCoreZzzProjectsCreate()
        {
            _zzzProjectRepository.Create1(_adressen);
        }
        #endregion

        #region Dapper
        [Benchmark]
        public void DapperExecute()
        {
            _dapperRepository.DapperExecute(_adressen);
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










