using DapperBenchmarks.models;
using DapperBenchmarks.repositories;
using Tools;

namespace DapperBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var updateRepo = new DapperUpdateRepository();
            var createRepo = new DapperCreateRepository();
            List<AdresX> adressen = createRepo.GetAddressen("Zottegem");

            adressen.ForEach(adres =>
            {
                adres.Status = "HABIBI <3";
            });

            updateRepo.DapperPlus(adressen);
            //createRepo.DapperPlus(adressen);
        }
    }
}