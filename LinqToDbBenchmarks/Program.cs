using LinqToDB.Data;
using LinqToDbBenchmarks.models;

namespace LinqToDbBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataConnection.DefaultSettings = new MySettings();
            var repo = new LinqToDbRepository();
            var adressen = repo.GetAdressen("Zottegem");

            repo.CreateExecute(adressen);
            Console.WriteLine();
        }
    }
}