using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DapperBenchmarks.repositories;
using EFCoreBenchmarks.repositories;
using LinqToDbBenchmarks.repositories;
using NHibernateBenchmarks.repositories;
using Norm.NetBenchmarks.repositories;
using OrmLiteBenchmarks.repositories;
using PetaPocoBenchmarks.repositories;
using RepoDbBenchmarks.repositories;


namespace Benchmarks.benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [CsvExporter]
    //[MaxIterationCount(1000)]
    public class SelectBenchmarks
    {
        private static EFCoreSelectRepository _EFCoreRepository = null!;
        private static DapperSelectRepository _dapperRepository = null!;
        private static LinqToDbSelectRepository _linqToDbRepository = null!;
        private static NHibernateSelectRepository _nhibernateRepository = null!;
        private static NormNetSelectRepository _normNetRepository = null!;
        private static OrmLiteSelectRepository _ormLiteRepository = null!;
        private static PetaPocoSelectRepository _petapocorepository = null!;
        private static RepoDbSelectRepository _repoDbRepository = null!;
        private List<string> _niscodes = new List<string>();

        public SelectBenchmarks()
        {
            _EFCoreRepository = new EFCoreSelectRepository();
            _dapperRepository = new DapperSelectRepository();
            _linqToDbRepository = new LinqToDbSelectRepository();
            _nhibernateRepository = new NHibernateSelectRepository();
            _normNetRepository = new NormNetSelectRepository();
            _ormLiteRepository = new OrmLiteSelectRepository();
            _petapocorepository = new PetaPocoSelectRepository();
            _repoDbRepository = new RepoDbSelectRepository();
            _niscodes = _dapperRepository.GetRandomNisCodes();
        }

        #region EF Core
        [Benchmark]
        public void EFCore_FromSqlRaw()
        {
            _EFCoreRepository.EFCoreFromSqlRaw(_niscodes);
        }

        [Benchmark]
        public void EFCore_Where()
        {
            _EFCoreRepository.EFCoreWhere(_niscodes);
        }
        #endregion

        #region Dapper
        [Benchmark]
        public void Dapper_Query()
        {
            _dapperRepository.DapperQuery(_niscodes);
        }
        #endregion

        #region Linq to DB
        [Benchmark]
        public void LinqToDb_Where()
        {
            _linqToDbRepository.LinqToDb_Where(_niscodes);
        }
        #endregion

        #region NHibernate
        [Benchmark]
        public void NHibernate_CreateQuery_Hql()
        {
            _nhibernateRepository.NHibernate_CreateQuery_Hql(_niscodes);
        }

        [Benchmark]
        public void NHibernate_Query_Linq()
        {
            _nhibernateRepository.NHibernate_Query_Linq(_niscodes);
        }

        [Benchmark]
        public void NHibernate_CreateCriteria()
        {
            _nhibernateRepository.NHibernate_CreateCriteria(_niscodes);
        }

        [Benchmark]
        public void NHibernate_CreateSqlQuery()
        {
            _nhibernateRepository.NHibernateCreateSqlQuery(_niscodes);
        }
        #endregion

        #region Norm.NET
        [Benchmark]
        public void NormNet_Read()
        {
            _normNetRepository.NormNetRead(_niscodes);

        }
        #endregion

        #region OrmLite
        //[Benchmark]
        //public void OrmLite_SqlList()
        //{
        //    _ormLiteRepository.OrmLiteSqlList(_niscodes);
        //}

        [Benchmark]
        public void OrmLite_Select()
        {
            _ormLiteRepository.OrmLiteSelect(_niscodes);
        }
        #endregion

        #region PetaPoco
        [Benchmark]
        public void PetaPoco_Fetch()
        {
            _petapocorepository.PetaPoco_Fetch(_niscodes);
        }
        #endregion

        #region RepoDB
        [Benchmark]
        public void RepoDb_Query()
        {
            _repoDbRepository.RepoDbQuery(_niscodes);
        }
        [Benchmark]
        public void RepoDb_BatchQuery()
        {
            _repoDbRepository.RepoDbBatchQuery(_niscodes);
        }

        [Benchmark]
        public void RepoDb_ExecuteQuery()
        {
            _repoDbRepository.RepoDbExecuteQuery(_niscodes);
        }
        #endregion

        [IterationCleanup]
        public void CleanupAfterIteration()
        {
            _niscodes = _dapperRepository.GetRandomNisCodes();
        }
    }
}




