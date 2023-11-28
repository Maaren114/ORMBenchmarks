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
        private static EFCoreRepository _EFCoreRepository = null!;
        private static ZZZProjectsRepository _zzzProjectRepository = null!;
        private static DapperRepository _dapperRepository = null!;
        private static LinqToDbRepository _linqToDbRepository = null!;
        private static NHibernateRepository _nhibernateRepository = null!;
        private static NormNetRepository _normNetRepository = null!;
        private static OrmLiteRepository _ormLiteRepository = null!;
        private static PetaPocoRepository _petapocorepository = null!;
        private static RepoDbRepository _repoDbRepository = null!;

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
        public void NHibernateBatch()
        {
            _nhibernateRepository.Batch(_adressen);
        }

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












