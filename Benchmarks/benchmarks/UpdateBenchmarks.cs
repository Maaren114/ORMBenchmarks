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
        private List<AdresX> _adressenAntwerpen = new List<AdresX>();
        private List<AdresX> _adressenGent = new List<AdresX>();
        private List<AdresX> _adressenLeuven = new List<AdresX>();
        private List<AdresX> _adressenBrugge = new List<AdresX>();
        private List<AdresX> _adressenOostende = new List<AdresX>();
        private List<AdresX> _adressenKnokkeHeist = new List<AdresX>();
        private List<AdresX> _adressenHasselt = new List<AdresX>();
        private List<AdresX> _adressenAalst = new List<AdresX>();
        private List<AdresX> _adressenMechelen = new List<AdresX>();
        private List<AdresX> _adressenKortrijk = new List<AdresX>();
        private List<AdresX> _adressenSintNiklaas = new List<AdresX>();
        private List<AdresX> _adressenRoeselare = new List<AdresX>();
        private List<AdresX> _adressenGenk = new List<AdresX>();



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
            //_adressenAntwerpen = efcorerepo.GetAdressen("Antwerpen", 15557);
            //_adressenGent = efcorerepo.GetAdressen("Gent", 15557);
            //_adressenLeuven = efcorerepo.GetAdressen("Leuven", 15557);
            //_adressenBrugge = efcorerepo.GetAdressen("Brugge", 15557);
            //_adressenOostende = efcorerepo.GetAdressen("Oostende", 15557);
            //_adressenKnokkeHeist = efcorerepo.GetAdressen("Knokke-Heist", 15557);
            //_adressenHasselt = efcorerepo.GetAdressen("Hasselt", 15557);
            //_adressenAalst = efcorerepo.GetAdressen("Aalst", 15557);


            //_adressenMechelen = efcorerepo.GetAdressen("Mechelen", 15557);
            //_adressenKortrijk = efcorerepo.GetAdressen("Kortrijk", 15557);
            //_adressenSintNiklaas = efcorerepo.GetAdressen("Sint-Niklaas", 15557);
            //_adressenRoeselare = efcorerepo.GetAdressen("Roeselare", 15557);
            //_adressenGenk = efcorerepo.GetAdressen("Genk", 15557);



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


