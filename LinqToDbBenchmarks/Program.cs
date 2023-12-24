using DapperBenchmarks.repositories;
using LinqToDB.Data;
using LinqToDbBenchmarks.models;
using LinqToDbBenchmarks.repositories;
using Tools;

namespace LinqToDbBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dapperselect = new DapperSelectRepository();
            var updaterepo = new LinqToDbUpdateRepository();
            var createrepo = new LinqToDbCreateRepository();
            var deleterepo = new LinqToDbDeleteRepository();
            var selectrepo = new LinqToDbSelectRepository();

            var adressen = dapperselect.GetAdressen();

            createrepo.LinqToDbBulkCopy(adressen);
        }

    }
}


