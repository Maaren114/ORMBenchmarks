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
        public void EFBorisDjCreate()
        {
            _EFCoreRepository.EFBorisDjDelete(_adressen);
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
            _zzzProjectRepository.ZZZProjectsBulkDelete(_adressen);
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
            _linqToDbRepository.LinqToDbExecute(_adressen);
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
            _normNetRepository.DeleteExecute(_adressen);
           
        }
        #endregion

        #region OrmLite
        [Benchmark]
        public void OrmLiteBulkDelete()
        {
            _ormLiteRepository.ExecuteDeleteRaw(_adressen);
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
        public void RepoDbDeleteAll()
        {
            _repoDbRepository.DeleteAll(_adressen);
        }

        [Benchmark]
        public void RepoDbBulkDelete()
        {
            _repoDbRepository.BulkDelete(_adressen);
        }
        #endregion
    }
}
