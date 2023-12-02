using EFCoreBenchmarks.models;
using EFCoreBenchmarks.repositories;
using Tools;

namespace EFCoreBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var updateRepo = new EFCoreUpdateRepository();
            var createRepo = new EFCoreCreateRepository();
            List<AdresX> adressen = createRepo.GetAdressen("Zottegem");

            updateRepo.ExecuteSqlRaw(adressen); 
            //updateRepo.UpdateRange(adressen);

            //repo.EFBorisDjCreate(adressen);
            //repo.ExecuteSqlRaw(adressen);
            //repo.ExecuteSql(adressen);
        }
    }
}
