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
            var deleterepo = new DapperDeleteRepository();

            List<AdresX> adressen = createRepo.GetAddressen("Zottegem");


            deleterepo.DapperExecute(adressen);


            
            
            //updateRepo.DapperPlus(adressen);
            //createRepo.DapperPlus(adressen);
        }
    }
}