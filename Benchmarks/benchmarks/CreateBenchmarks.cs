using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using DapperBenchmarks.repositories;
using EFCoreBenchmarks.repositories;
using LinqToDbBenchmarks.repositories;
using NHibernateBenchmarks;
using NHibernateBenchmarks.repositories;
using Norm.NetBenchmarks.repositories;
using OrmLiteBenchmarks.repositories;
using PetaPocoBenchmarks.repositories;
using RepoDbBenchmarks.repositories;
using Tools;
using ZZZProjectsBenchmarks.repositories;

namespace Benchmarks.benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [CsvExporter]
    [MaxIterationCount(100)]
    //[SimpleJob(RunStrategy.ColdStart, launchCount: 1, warmupCount: 10, iterationCount: 100, id: "benchmarks")]
    public class CreateBenchmarks
    {
        private static EFCoreCreateRepository _EFCoreRepository = null!;
        private static ZZZProjectsCreateRepository _zzzProjectRepository = null!;
        private static DapperCreateRepository _dapperRepository = null!;
        private static LinqToDbCreateRepository _linqToDbRepository = null!;
        private static NHibernateCreateRepository _nhibernateRepository = null!;
        private static NormNetCreateRepository _normNetRepository = null!;
        private static OrmLiteCreateRepository _ormLiteRepository = null!;
        private static PetaPocoCreateRepository _petapocorepository = null!;
        private static RepoDbCreateRepository _repoDbRepository = null!;

        private List<AdresX> _adressen = new List<AdresX>();

        public CreateBenchmarks()
        {
            _EFCoreRepository = new EFCoreCreateRepository();
            _zzzProjectRepository = new ZZZProjectsCreateRepository();
            _dapperRepository = new DapperCreateRepository();
            _linqToDbRepository = new LinqToDbCreateRepository();
            _nhibernateRepository = new NHibernateCreateRepository();
            _normNetRepository = new NormNetCreateRepository();
            _ormLiteRepository = new OrmLiteCreateRepository();
            _petapocorepository = new PetaPocoCreateRepository();
            _repoDbRepository = new RepoDbCreateRepository();
            _adressen = _EFCoreRepository.GetAdressen("Zottegem", 15557);
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
            _zzzProjectRepository.ZZZProjectsBulkInsert(_adressen);
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
            _dapperRepository.DapperPlus(_adressen);
        }
        #endregion

        #region Linq to DB
        [Benchmark]
        public void LinqToDbExecute()
        {
            _linqToDbRepository.CreateExecute(_adressen);
        }

        [Benchmark]
        public void LinqToDbBulkCopy()
        {
            _linqToDbRepository.CreateBulkCopy(_adressen);
        }
        #endregion

        #region NHibernate
        [Benchmark]
        public void NHibernateBatchRaw()
        {
            _nhibernateRepository.BatchRaw(_adressen);
        }
        #endregion

        #region Norm.NET
        [Benchmark]
        public void NormNetExecute()
        {
            _normNetRepository.CreateExecute(_adressen);
        }
        #endregion

        #region OrmLite
        [Benchmark]
        public void OrmLiteBulkInsert()
        {
            _ormLiteRepository.BulkInsert(_adressen);
        }

        [Benchmark]
        public void OrmLiteBulkInsertRaw()
        {
            _ormLiteRepository.BulkInsertRaw(_adressen);
        }
        #endregion

        #region PetaPoco
        [Benchmark]
        public void PetaPocoExecute()
        {
            _petapocorepository.PetaPocoExecute(_adressen);
        }
        #endregion

        #region RepoDB
        [Benchmark]
        public void RepoDbInsertAll()
        {
            _repoDbRepository.InsertAll(_adressen);
        }

        [Benchmark]
        public void RepoDbBulkInsert()
        {
            _repoDbRepository.InsertAll(_adressen);
        }
        #endregion

        [IterationCleanup]
        public void CleanupAfterIteration()
        {

        }
    }
}












