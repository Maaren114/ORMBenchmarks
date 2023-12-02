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
        private List<AdresX> _adressen = new List<AdresX>();

        public UpdateBenchmarks()
        {
            _EFCoreRepository = new EFCoreUpdateRepository();
            _dapperRepository = new DapperUpdateRepository();
            _adressen = new EFCoreCreateRepository().GetAdressen("Zottegem");
        }

        #region EF Core
        [Benchmark]
        public void EFCoreBorisDjUpdate()
        {
            _EFCoreRepository.EFBorisDjUpdate(_adressen);
        }

        [Benchmark]
        public void EFCoreExecuteRaw()
        {
            _EFCoreRepository.ExecuteSqlRaw(_adressen);
        }

        [Benchmark]
        public void EFCoreExecuteSql()
        {
            _EFCoreRepository.ExecuteSql(_adressen);
        }

        [Benchmark]
        public void EFCoreUpdateRange()
        {
            _EFCoreRepository.UpdateRange(_adressen);
        }
        #endregion
    }

}


