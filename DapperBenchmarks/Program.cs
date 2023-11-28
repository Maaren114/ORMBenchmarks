using DapperBenchmarks.models;
using Tools;

namespace DapperBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new DapperRepository();
            List<AdresX> adressen = repo.GetAddressen("Zottegem");

            repo.DapperExecute(adressen);
            repo.DapperPlus(adressen);
        }
    }
}