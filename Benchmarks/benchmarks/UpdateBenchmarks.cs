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
using Bogus.DataSets;
using Bogus;
using FluentNHibernate.MappingModel;

namespace Benchmarks.benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [CsvExporter]
    //[MaxIterationCount(1000)]
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
        private List<AdresX> _adressen = new List<AdresX>();
        private Faker<AdresX> _faker = new Faker<AdresX>()
        .RuleFor(a => a.Appartementnummer, f => f.Address.BuildingNumber())
        .RuleFor(a => a.Status, f => f.PickRandom(new[] { "Active", "Inactive", "Pending" }))
        .RuleFor(a => a.Busnummer, f => f.Address.BuildingNumber())
        .RuleFor(a => a.Huisnummer, f => f.Address.BuildingNumber())
        .RuleFor(a => a.Postcode, f => f.Random.Number(0, 10000))
        .RuleFor(a => a.NISCode, f => Guid.NewGuid().ToString());

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
            _adressen = _EFCoreRepository.GetAdressen();
            RandomizeAdresgegegevens();
        }

        #region EF Core
        [Benchmark]
        public void EFCore_Update()
        {
            _EFCoreRepository.EFCoreUpdate(_adressen);
        }

        [Benchmark]
        public void EFCore_UpdateRange()
        {
            _EFCoreRepository.EFCoreUpdateRange(_adressen);
        }

        [Benchmark]
        public void EFCore_BulkUpdate_BorisDj()
        {
            _EFCoreRepository.EFCoreBulkUpdate_BorisDj(_adressen);
        }

        [Benchmark]
        public void EFCore_ExecuteSqlRaw()
        {
            _EFCoreRepository.EFCoreExecuteSqlRaw(_adressen);
        }
        #endregion

        #region Dapper
        [Benchmark]
        public void Dapper_Execute()
        {
            _dapperRepository.DapperExecute(_adressen);
        }

        [Benchmark]
        public void Dapper_BulkUpdate_DapperPlus()
        {
            _dapperRepository.DapperBulkUpdate_DapperPlus(_adressen);
        }
        #endregion

        #region LINQ to DB
        [Benchmark]
        public void LinqToDbExecute()
        {
            _linqToDbRepository.LinqToDbExecute(_adressen);
        }
        #endregion

        #region NHibernate
        [Benchmark]
        public void NHibernate_Update()
        {
            _nhibernateRepository.NHibernate_Update(_adressen);
        }

        [Benchmark]
        public void NHibernate_CreateSqlQuery()
        {
            _nhibernateRepository.NHibernate_CreateSqlQuery(_adressen);
        }
        #endregion

        #region Norm.NET
        [Benchmark]
        public void NormNetUpdateExecute()
        {
            _normNetRepository.UpdateExecute(_adressen);
        }
        #endregion

        #region ormlite
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
        public void RepoDb_UpdateAll()
        {
            _repodbrepository.RepoDbUpdateAll(_adressen);
        }

        [Benchmark]
        public void RepoDb_BulkUpdate()
        {
            _repodbrepository.RepoDbBulkUpdate(_adressen);
        }

        [Benchmark]
        public void RepoDb_ExecuteNonQuery()
        {
            _repodbrepository.RepoDbExecuteNonQuery(_adressen);
        }
        #endregion

        #region ZZZProjects
        [Benchmark]
        public void ZZZProjectsBulkUpdate()
        {
            _zzzprojectsrepository.ZZZProjectsBulkUpdate(_adressen);
        }
        #endregion

        [IterationCleanup]
        public void CleanupAfterIteration()
        {
            RandomizeAdresgegegevens();
        }

        private void RandomizeAdresgegegevens()
        {
            _adressen.ForEach(a =>
            {
                var nieuweWaarden = _faker.Generate();
                a.Appartementnummer = nieuweWaarden.Appartementnummer;
                a.Status = nieuweWaarden.Status;
                a.Busnummer = nieuweWaarden.Busnummer;
                a.Huisnummer = nieuweWaarden.Huisnummer;
                a.Postcode = nieuweWaarden.Postcode;
                a.NISCode = nieuweWaarden.NISCode;
            });
        }
    }
}





