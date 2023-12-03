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
            var adressen = createrepo.GetAdressen("Zottegem");

            updaterepo.LinqToDbExecute(adressen);
        }
    }
}