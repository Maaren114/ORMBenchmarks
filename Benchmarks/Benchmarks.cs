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
        private static CreateEFCoreRepository _EFCoreRepository = null!;
        private static CreateZZZProjectsRepository _zzzProjectRepository = null!;
        private static CreateDapperRepository _dapperRepository = null!;
        private static CreateLinqToDbRepository _linqToDbRepository = null!;
        private static CreateNHibernateRepository _nhibernateRepository = null!;
        private static CreateNormNetRepository _normNetRepository = null!;
        private static CreateOrmLiteRepository _ormLiteRepository = null!;
        private static CreatePetaPocoRepository _petapocorepository = null!;
        private static CreateRepoDbRepository _repoDbRepository = null!;

        private List<AdresX> _adressen = new List<AdresX>();

        public Benchmarks()
        {
            _EFCoreRepository = new CreateEFCoreRepository();
            _zzzProjectRepository = new CreateZZZProjectsRepository();
            _dapperRepository = new CreateDapperRepository();
            _linqToDbRepository = new CreateLinqToDbRepository();
            _nhibernateRepository = new CreateNHibernateRepository();
            _normNetRepository = new CreateNormNetRepository();
            _ormLiteRepository = new CreateOrmLiteRepository();
            _petapocorepository = new CreatePetaPocoRepository();
            _repoDbRepository = new CreateRepoDbRepository();
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












