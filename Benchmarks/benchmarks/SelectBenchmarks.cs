using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DapperBenchmarks.repositories;
using EFCoreBenchmarks.repositories;
using LinqToDB.Data;
using LinqToDbBenchmarks.models;
using LinqToDbBenchmarks.repositories;
using NHibernateBenchmarks.repositories;
using Norm.NetBenchmarks.repositories;
using OrmLiteBenchmarks.repositories;
using PetaPocoBenchmarks.repositories;
using RepoDbBenchmarks.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using ZZZProjectsBenchmarks.repositories;

namespace Benchmarks.benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [CsvExporter]
    [MaxIterationCount(100)]
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
            _niscodes = _EFCoreRepository.GetNISCodes(15557);
        }

        #region EF Core
        //[Benchmark]
        //public void EFCore_FromSql()
        //{
        //    _EFCoreRepository.EFCoreFromSql(_niscodes);
        //}

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
        public void Dapper_Execute()
        {
            _dapperRepository.DapperExecute(_niscodes);
        }
        #endregion

        #region Linq to DB
        [Benchmark]
        public void LinqToDbSelect()
        {
            _linqToDbRepository.LinqToDbSelect(_niscodes);
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
        public void NormNetRead()
        {
            _normNetRepository.Read(_niscodes);

        }
        #endregion

        #region OrmLite
        [Benchmark]
        public void OrmLite_SqlList()
        {
            _ormLiteRepository.OrmLiteSqlList(_niscodes);
        }

        [Benchmark]
        public void OrmLite_Select()
        {
            _ormLiteRepository.OrmLiteSelect(_niscodes);
        }
        #endregion

        #region PetaPoco
        [Benchmark]
        public void PetaPocoFetch()
        {
            _petapocorepository.Fetch(_niscodes);
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
    }
}




