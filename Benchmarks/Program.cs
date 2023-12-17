using BenchmarkDotNet.Running;
using Benchmarks.benchmarks;
using EFCoreBenchmarks.repositories;
using NHibernateBenchmarks.repositories;
using OrmLiteBenchmarks.repositories;
using RepoDbBenchmarks.repositories;
using System.Reflection;
using Tools;

namespace Benchmarks
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary1 = BenchmarkRunner.Run<CreateBenchmarks>();


            //var repo = new EFCoreCreateRepository();
            //List<string> niscodes = repo.GetNISCodes(15557);


            //var ormliterepo = new OrmLiteSelectRepository();

            //List<AdresX> a1 = ormliterepo.SqlList(niscodes);



            //var repodbquery = new RepoDbSelectRepository();

            //List<AdresX> adressen = repodbquery.Query(niscodes);

        }
    }
}