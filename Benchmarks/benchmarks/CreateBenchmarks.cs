using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Bogus;
using DapperBenchmarks.repositories;
using EFCoreBenchmarks.repositories;
using LinqToDbBenchmarks.repositories;
using NHibernateBenchmarks;
using NHibernateBenchmarks.repositories;
using Norm.NetBenchmarks.repositories;
using OrmLiteBenchmarks.repositories;
using PetaPocoBenchmarks.repositories;
using RepoDbBenchmarks.repositories;
using Tools;
using ZZZProjectsBenchmarks.repositories;

namespace Benchmarks.benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [CsvExporter]
    //[MaxIterationCount(100)]
    public class CreateBenchmarks
    {
        private static EFCoreUpdateRepository _EFCoreUpdateRepository = null!;




        private static EFCoreCreateRepository _EFCoreRepository = null!;
        private static ZZZProjectsCreateRepository _zzzProjectRepository = null!;
        private static DapperCreateRepository _dapperRepository = null!;
        private static LinqToDbCreateRepository _linqToDbRepository = null!;
        private static NHibernateCreateRepository _nhibernateRepository = null!;
        private static NormNetCreateRepository _normNetRepository = null!;
        private static OrmLiteCreateRepository _ormLiteRepository = null!;
        private static PetaPocoCreateRepository _petapocorepository = null!;
        private static RepoDbCreateRepository _repoDbRepository = null!;
        private List<AdresX> _adressen = new List<AdresX>();
        private Faker<AdresX> _faker = new Faker<AdresX>()
        .RuleFor(a => a.Appartementnummer, f => f.Address.BuildingNumber())
        .RuleFor(a => a.Status, f => f.PickRandom(new[] { "Active", "Inactive", "Pending" }))
        .RuleFor(a => a.Busnummer, f => f.Address.BuildingNumber())
        .RuleFor(a => a.Huisnummer, f => f.Address.BuildingNumber())
        .RuleFor(a => a.Postcode, f => f.Random.Number(0, 10000))
        .RuleFor(a => a.NISCode, f => Guid.NewGuid().ToString());

        public CreateBenchmarks()
        {
            _EFCoreRepository = new EFCoreCreateRepository();
            _zzzProjectRepository = new ZZZProjectsCreateRepository();
            _dapperRepository = new DapperCreateRepository();
            _linqToDbRepository = new LinqToDbCreateRepository();
            _nhibernateRepository = new NHibernateCreateRepository();
            _normNetRepository = new NormNetCreateRepository();
            _ormLiteRepository = new OrmLiteCreateRepository();
            _petapocorepository = new PetaPocoCreateRepository();
            _repoDbRepository = new RepoDbCreateRepository();

            _EFCoreUpdateRepository = new EFCoreUpdateRepository();
            _adressen = _EFCoreUpdateRepository.GetAdressen();
            RandomizeAdresgegegevens();
        }

        #region EF Core
        [Benchmark]
        public void EFCore_Add()
        {
            _EFCoreRepository.EFCoreAdd(_adressen);
        }

        [Benchmark]
        public void EFCore_AddRange()
        {
            _EFCoreRepository.EFCoreAddRange(_adressen);
        }

        [Benchmark]
        public void EFCore_BulkInsert_BorisDj()
        {
            _EFCoreRepository.EFCoreBulkInsert_BorisDj(_adressen);
        }

        [Benchmark]
        public void EFCore_ExecuteSqlRaw()
        {
            _EFCoreRepository.EFCoreExecuteSqlRaw(_adressen);
        }

        [Benchmark]
        public void EFCore_BulkInsert_ZZZProjects()
        {
            _zzzProjectRepository.EFCoreBulkInsert_ZZZProjects(_adressen);
        }
        #endregion

        #region Dapper
        [Benchmark]
        public void Dapper_Execute()
        {
            _dapperRepository.DapperExecute(_adressen);
        }

        [Benchmark]
        public void Dapper_BulkInsert_DapperPlus()
        {
            _dapperRepository.DapperBulkInsert_DapperPlus(_adressen);
        }
        #endregion

        #region Linq to DB
        [Benchmark]
        public void LinqToDb_Execute()
        {
            _linqToDbRepository.LinqToDbExecute(_adressen);
        }

        [Benchmark]
        public void LinqToDb_BulkCopy()
        {
            _linqToDbRepository.LinqToDbBulkCopy(_adressen);
        }
        #endregion

        #region NHibernate
        [Benchmark]
        public void NHibernate_Save()
        {
            _nhibernateRepository.NHibernateSave(_adressen);
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
            _normNetRepository.CreateExecute(_adressen);
        }
        #endregion

        #region OrmLite
        [Benchmark]
        public void OrmLite_BulkInsert()
        {
            _ormLiteRepository.OrmLiteBulkInsert(_adressen);
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
        public void RepoDb_InsertAll()
        {
            _repoDbRepository.RepoDbInsertAll(_adressen);
        }

        [Benchmark]
        public void RepoDb_BulkInsert()
        {
            _repoDbRepository.RepoDbBulkInsert(_adressen);
        }

        [Benchmark]
        public void RepoDb_ExecuteNonQuery()
        {
            _repoDbRepository.RepoDbExecuteNonQuery(_adressen);
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
                a.AdresID = 0;
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












