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
            _adressen.ForEach(a => a.AdresID = 0);
        }

        #region EF Core
        [Benchmark]
        public void EFCore_Add()
        {
            _EFCoreRepository.EFCoreAdd(_adressen);
        }

        [Benchmark]
        public void EFCore_AddRange()
        {
            _EFCoreRepository.EFCoreAddRange(_adressen);
        }

        [Benchmark]
        public void EFCore_BulkInsert_BorisDj()
        {
            _EFCoreRepository.EFCoreBulkInsert_BorisDj(_adressen);
        }

        [Benchmark]
        public void EFCore_ExecuteSqlRaw()
        {
            _EFCoreRepository.EFCoreExecuteSqlRaw(_adressen);
        }

        //[Benchmark]
        //public void EFCore_ExecuteSql()
        //{
        //    _EFCoreRepository.EFCoreExecuteSql(_adressen);
        //}

        [Benchmark]
        public void EFCore_BulkInsert_ZZZProjects()
        {
            _zzzProjectRepository.EFCoreBulkInsert_ZZZProjects(_adressen);
        }
        #endregion

        #region Dapper
        [Benchmark]
        public void Dapper_Execute()
        {
            _dapperRepository.DapperExecute(_adressen);
        }

        [Benchmark]
        public void Dapper_BulkInsert_DapperPlus()
        {
            _dapperRepository.DapperBulkInsert_DapperPlus(_adressen);
        }
        #endregion

        #region Linq to DB
        [Benchmark]
        public void LinqToDb_Execute()
        {
            _linqToDbRepository.LinqToDbExecute(_adressen);
        }

        [Benchmark]
        public void LinqToDb_BulkCopy()
        {
            _linqToDbRepository.LinqToDbBulkCopy(_adressen);
        }
        #endregion

        #region NHibernate
        [Benchmark]
        public void NHibernate_Save()
        {
            _nhibernateRepository.NHibernateSave(_adressen);
        }

        [Benchmark]
        public void NHibernate_CreateSqlQuery()
        {
            _nhibernateRepository.NHibernateCreateSqlQuery(_adressen);
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
        public void OrmLite_BulkInsert()
        {
            _ormLiteRepository.OrmLiteBulkInsert(_adressen);
        }

        [Benchmark]
        public void OrmLite_ExecuteNonQuery()
        {
            _ormLiteRepository.OrmLiteExecuteNonQuery(_adressen);
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
        public void RepoDb_InsertAll()
        {
            _repoDbRepository.RepoDbInsertAll(_adressen);
        }

        [Benchmark]
        public void RepoDb_BulkInsert()
        {
            _repoDbRepository.RepoDbBulkInsert(_adressen);
        }

        [Benchmark]
        public void RepoDb_ExecuteNonQuery()
        {
            _repoDbRepository.RepoDbExecuteNonQuery(_adressen);
        }
        #endregion

        [IterationCleanup]
        public void CleanupAfterIteration()
        {
            _EFCoreRepository = new EFCoreCreateRepository();
            _adressen = _EFCoreRepository.GetAdressen("Zottegem", 15557);
            _adressen.ForEach(a => a.AdresID = 0);
        }
    }
}












