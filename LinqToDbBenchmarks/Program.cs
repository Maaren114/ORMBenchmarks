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
            var updaterepo = new LinqToDbUpdateRepository();
            var createrepo = new LinqToDbCreateRepository();
            var deleterepo = new LinqToDbDeleteRepository();

            var adressen = createrepo.GetAdressen("Zottegem");

            deleterepo.LinqToDbExecute(adressen);
        }
    }
}