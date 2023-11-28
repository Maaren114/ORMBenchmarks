using LinqToDB.Data;
using LinqToDbBenchmarks.models;
using Tools;

namespace LinqToDbBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new LinqToDbRepository();
            var adressen = repo.GetAdressen("Zottegem");

            repo.CreateExecute(adressen);
            repo.CreateBulkCopy(adressen);
        }
    }
}