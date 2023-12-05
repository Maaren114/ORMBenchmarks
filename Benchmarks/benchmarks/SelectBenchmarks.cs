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
            var repo = new EFCoreCreateRepository();
            _niscodes = repo.GetNISCodes(15557);
        }

        #region EF Core
        [Benchmark]
        public void EFCoreSelect()
        {
            _EFCoreRepository.EFCoreSelect(_niscodes);
        }

        [Benchmark]
        public void EFCoreFromSql()
        {
            _EFCoreRepository.FromSql(_niscodes);
        }

        [Benchmark]
        public void EFCoreFromSqlRaw()
        {
            _EFCoreRepository.FromSqlRaw(_niscodes);
        }
        #endregion

        #region Dapper
        [Benchmark]
        public void DapperExecute()
        {
            _dapperRepository.DapperExecute(_niscodes);
        }
        #endregion

        #region Linq to DB
        [Benchmark]
        public void LinqToDbSelect()
        {
            _linqToDbRepository.Select(_niscodes);
        }
        #endregion

        #region NHibernate
        [Benchmark]
        public void NHibernateCreateQueryHql()
        {
            _nhibernateRepository.CreateQueryHql(_niscodes);
        }

        [Benchmark]
        public void NHibernateQueryLinq()
        {
            _nhibernateRepository.QueryLinq(_niscodes);
        }

        [Benchmark]
        public void NHibernateCreateCriteria()
        {
            _nhibernateRepository.CreateCriteria(_niscodes);
        }

        [Benchmark]
        public void NHibernateRawSql()
        {
            _nhibernateRepository.RawSql(_niscodes);
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
        public void OrmLiteSqlList()
        {
            _ormLiteRepository.SqlList(_niscodes);
        }

        [Benchmark]
        public void OrmLiteSelect()
        {
            _ormLiteRepository.Select(_niscodes);
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
        public void RepoDbQuery()
        {
            _repoDbRepository.Query(_niscodes);
        }

        [Benchmark]
        public void RepoDbExecuteQuery()
        {
            _repoDbRepository.ExecuteQuery(_niscodes);
        }
        #endregion
    }
}
