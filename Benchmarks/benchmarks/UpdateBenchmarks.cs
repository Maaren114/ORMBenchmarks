using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using LinqToDbBenchmarks;
using NHibernateBenchmarks;
using Norm.NetBenchmarks;
using OrmLiteBenchmarks;
using PetaPocoBenchmarks;
using RepoDbBenchmarks;
using Tools;
using EFCoreBenchmarks.repositories;
using DapperBenchmarks.repositories;
using LinqToDbBenchmarks.repositories;
using NHibernateBenchmarks.repositories;
using Norm.NetBenchmarks.repositories;
using OrmLiteBenchmarks.repositories;
using PetaPocoBenchmarks.repositories;
using RepoDbBenchmarks.repositories;
using ZZZProjectsBenchmarks.repositories;

namespace Benchmarks.benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [CsvExporter]
    [MaxIterationCount(100)]
    public class UpdateBenchmarks
    {
        private static EFCoreUpdateRepository _EFCoreRepository = null!;
        private static DapperUpdateRepository _dapperRepository = null!;
        private static LinqToDbUpdateRepository _linqToDbRepository = null!;
        private static NHibernateUpdateRepository _nhibernateRepository = null!;
        private static NormNetUpdateRepository _normNetRepository = null!;
        private static OrmLiteUpdateRepository _ormLiteRepository = null!;
        private static PetaPocoUpdateRepository _petapocorepository = null!;
        private static RepoDbUpdateRepository _repodbrepository = null!;
        private static ZZZProjectsUpdateRepository _zzzprojectsrepository = null!;
        private List<AdresX> _AdressenZottegem = new List<AdresX>();

        public UpdateBenchmarks()
        {
            _EFCoreRepository = new EFCoreUpdateRepository();
            _dapperRepository = new DapperUpdateRepository();
            _linqToDbRepository = new LinqToDbUpdateRepository();
            _nhibernateRepository = new NHibernateUpdateRepository();
            _normNetRepository = new NormNetUpdateRepository();
            _ormLiteRepository = new OrmLiteUpdateRepository();
            _petapocorepository = new PetaPocoUpdateRepository();
            _repodbrepository = new RepoDbUpdateRepository();
            _zzzprojectsrepository = new ZZZProjectsUpdateRepository();

            var efcorerepo = new EFCoreCreateRepository();

            _AdressenZottegem = efcorerepo.GetAdressen("Zottegem", 15557);

            _AdressenZottegem.ForEach(a =>
            {
                a.Status = "CHANGED";
            });
        }

        #region EF Core
        [Benchmark]
        public void EFCore_Update()
        {
            _EFCoreRepository.EFCoreUpdate(_AdressenZottegem);
        }

        [Benchmark]
        public void EFCore_UpdateRange()
        {
            _EFCoreRepository.EFCoreUpdateRange(_AdressenZottegem);
        }

        [Benchmark]
        public void EFCore_BulkUpdate_BorisDj()
        {
            _EFCoreRepository.EFCoreBulkUpdate_BorisDj(_AdressenZottegem);
        }

        [Benchmark]
        public void EFCore_ExecuteRaw()
        {
            _EFCoreRepository.EFCoreExecuteSqlRaw(_AdressenZottegem);
        }

        //[Benchmark]
        //public void EFCore_ExecuteSql()
        //{
        //    _EFCoreRepository.EFCoreExecuteSql(_AdressenZottegem);
        //}
        #endregion

        #region Dapper
        [Benchmark]
        public void Dapper_Execute()
        {
            _dapperRepository.DapperExecute(_AdressenZottegem);
        }

        [Benchmark]
        public void Dapper_BulkUpdate_DapperPlus()
        {
            _dapperRepository.DapperBulkUpdate_DapperPlus(_AdressenZottegem);
        }
        #endregion

        #region LINQ to DB
        [Benchmark]
        public void LinqToDbExecute()
        {
            _linqToDbRepository.LinqToDbExecute(_AdressenZottegem);
        }
        #endregion

        #region NHibernate
        [Benchmark]
        public void NHibernate_Update()
        {
            _nhibernateRepository.NHibernate_Update(_AdressenZottegem);
        }

        [Benchmark]
        public void NHibernate_CreateSqlQuery()
        {
            _nhibernateRepository.NHibernate_CreateSqlQuery(_AdressenZottegem);
        }
        #endregion

        #region Norm.NET
        [Benchmark]
        public void NormNetUpdateExecute()
        {
            _normNetRepository.UpdateExecute(_AdressenZottegem);
        }
        #endregion

        #region ormlite
        [Benchmark]
        public void OrmLite_ExecuteNonQuery()
        {
            _ormLiteRepository.OrmLiteExecuteNonQuery(_AdressenZottegem);
        }
        #endregion

        #region PetaPoco
        [Benchmark]
        public void PetaPocoExecute()
        {
            _petapocorepository.PetaPocoExecute(_AdressenZottegem);
        }
        #endregion

        #region RepoDB
        [Benchmark]
        public void RepoDb_UpdateAll()
        {
            _repodbrepository.RepoDbUpdateAll(_AdressenZottegem);
        }

        [Benchmark]
        public void RepoDb_BulkUpdate()
        {
            _repodbrepository.RepoDbBulkUpdate(_AdressenZottegem);
        }

        [Benchmark]
        public void RepoDb_ExecuteNonQuery()
        {
            _repodbrepository.RepoDbExecuteNonQuery(_AdressenZottegem);
        }
        #endregion

        #region ZZZProjects
        [Benchmark]
        public void ZZZProjectsBulkUpdate()
        {
            _zzzprojectsrepository.ZZZProjectsBulkUpdate(_AdressenZottegem);
        }
        #endregion

    }
}


