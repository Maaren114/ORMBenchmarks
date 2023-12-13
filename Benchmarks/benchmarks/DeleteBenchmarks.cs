using BenchmarkDotNet.Attributes;
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
    public class DeleteBenchmarks
    {
        private static EFCoreDeleteRepository _EFCoreRepository = null!;
        private static ZZZProjectsDeleteRepository _zzzProjectRepository = null!;
        private static DapperDeleteRepository _dapperRepository = null!;
        private static LinqToDbDeleteRepository _linqToDbRepository = null!;
        private static NHibernateDeleteRepository _nhibernateRepository = null!;
        private static NormNetDeleteRepository _normNetRepository = null!;
        private static OrmLiteDeleteRepository _ormLiteRepository = null!;
        private static PetaPocoDeleteRepository _petapocorepository = null!;
        private static RepoDbDeleteRepository _repoDbRepository = null!;

        private List<AdresX> _adressen = new List<AdresX>();

        public DeleteBenchmarks()
        {
            _EFCoreRepository = new EFCoreDeleteRepository();
            _zzzProjectRepository = new ZZZProjectsDeleteRepository();
            _dapperRepository = new DapperDeleteRepository();
            _linqToDbRepository = new LinqToDbDeleteRepository();
            _nhibernateRepository = new NHibernateDeleteRepository();
            _normNetRepository = new NormNetDeleteRepository();
            _ormLiteRepository = new OrmLiteDeleteRepository();
            _petapocorepository = new PetaPocoDeleteRepository();
            _repoDbRepository = new RepoDbDeleteRepository();
            var repo = new EFCoreCreateRepository();
            _adressen = repo.GetAdressen("Zottegem", 15557);
        }

        #region EF Core
        [Benchmark]
        public void EFCore_Remove()
        {
            _EFCoreRepository.EFCoreRemove(_adressen);
        }

        [Benchmark]
        public void EFCore_RemoveRange()
        {
            _EFCoreRepository.EFCoreRemoveRange(_adressen);
        }

        [Benchmark]
        public void EFCore_BulkDelete_BorisDj()
        {
            _EFCoreRepository.EFCoreBulkDelete_BorisDj(_adressen);
        }

        [Benchmark]
        public void EFCore_ExecuteSqlRaw()
        {
            _EFCoreRepository.ExecuteSqlRaw(_adressen);
        }

        //[Benchmark]
        //public void EFCore_ExecuteSql()
        //{
        //    _EFCoreRepository.EFCoreExecuteSql(_adressen);
        //}

        [Benchmark]
        public void EFCore_BulkDelete_ZZZProjects()
        {
            _zzzProjectRepository.EFCoreBulkDelete_ZZZProjects(_adressen);
        }
        #endregion

        #region Dapper
        [Benchmark]
        public void Dapper_Execute()
        {
            _dapperRepository.DapperExecute(_adressen);
        }

        [Benchmark]
        public void Dapper_BulkDelete_DapperPlus()
        {
            _dapperRepository.DapperBulkDelete_DapperPlus(_adressen);
        }
        #endregion

        #region Linq to DB
        [Benchmark]
        public void LinqToDb_Delete()
        {
            _linqToDbRepository.LinqToDbDelete(_adressen);
        }

        [Benchmark]
        public void LinqToDb_Execute()
        {
            _linqToDbRepository.LinqToDbExecute(_adressen);
        }
        #endregion

        #region NHibernate
        [Benchmark]
        public void NHibernate_Delete()
        {
            _nhibernateRepository.NHibernateDelete(_adressen);
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
            _normNetRepository.DeleteExecute(_adressen);
           
        }
        #endregion

        #region OrmLite
        [Benchmark]
        public void OrmLite_DeleteAll()
        {
            _ormLiteRepository.OrmLiteDeleteAll(_adressen);
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
        public void RepoDb_DeleteAll()
        {
            _repoDbRepository.RepoDbDeleteAll(_adressen);
        }

        [Benchmark]
        public void RepoDb_BulkDelete()
        {
            _repoDbRepository.RepoDbBulkDelete(_adressen);
        }

        [Benchmark]
        public void RepoDb_ExecuteNonQuery()
        {
            _repoDbRepository.RepoDbExecuteNonQuery(_adressen);
        }
        #endregion
    }
}
