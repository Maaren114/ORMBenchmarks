using DapperBenchmarks.models;

namespace DapperBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new DapperRepository();
            List<Adres> adressen = repo.GetAddressen("Zottegem");


            repo.DapperExecute(adressen);
        }
    }
}