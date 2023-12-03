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
        public void EFCoreBorisDjUpdate()
        {
            _EFCoreRepository.EFBorisDjUpdate(_AdressenZottegem);
        }

        [Benchmark]
        public void EFCoreExecuteRaw()
        {
            _EFCoreRepository.ExecuteSqlRaw(_AdressenZottegem);
        }

        [Benchmark]
        public void EFCoreExecuteSql()
        {
            _EFCoreRepository.ExecuteSql(_AdressenZottegem);
        }

        [Benchmark]
        public void EFCoreUpdateRange()
        {
            _EFCoreRepository.UpdateRange(_AdressenZottegem);
        }
        #endregion

        #region Dapper
        [Benchmark]
        public void DapperExecute()
        {
            _dapperRepository.DapperExecute(_AdressenZottegem);
        }

        [Benchmark]
        public void DapperPlus()
        {
            _dapperRepository.DapperPlus(_AdressenZottegem);
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
        public void NHibernateBatch()
        {
            _nhibernateRepository.Batch(_AdressenZottegem);
        }

        [Benchmark]
        public void NHibernateBatchRaw()
        {
            _nhibernateRepository.BatchRaw(_AdressenZottegem);
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
        public void ormliteexecuteupdateraw()
        {
            _ormLiteRepository.ExecuteUpdateRaw(_AdressenZottegem);
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
        public void RepoDbUpdateAll()
        {
            _repodbrepository.UpdateAll(_AdressenZottegem);
        }

        [Benchmark]
        public void RepoDbBulkUpdate()
        {
            _repodbrepository.BulkUpdate(_AdressenZottegem);
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


