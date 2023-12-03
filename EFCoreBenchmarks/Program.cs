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
            var deleterepo = new EFCoreDeleteRepository();

            List<AdresX> adressen = createRepo.GetAdressen("Zottegem", 15557);

            deleterepo.EFBorisDjDelete(adressen);

            deleterepo.RemoveRange(adressen);

            deleterepo.ExecuteSqlRaw(adressen);

            deleterepo.ExecuteSql(adressen);


            //adressen.ForEach(x =>
            //{
            //    x.Status = "XDDD";
            //});


            //updateRepo.ExecuteSqlRaw(adressen); 
            //updateRepo.UpdateRange(adressen);

            //repo.EFBorisDjCreate(adressen);
            //repo.ExecuteSqlRaw(adressen);
            //repo.ExecuteSql(adressen);
        }
    }
}

