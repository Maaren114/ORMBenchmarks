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
            var selectrepo = new EFCoreSelectRepository();


            List<string> niscodes = new List<string>();
            niscodes.Add("2c4140d4-cff7-49be-a8c4-2375783344ee");
            niscodes.Add("2c4140d4-cff7-49be-a8c4-2375783344ee");
            niscodes.Add("9f5860cb-6c72-4dd3-9f03-c49a417a65ac");
            niscodes.Add("3bd7ed9e-2633-4f44-a583-1da61d50db95");
            niscodes.Add("6772fad9-c6ad-4943-9e40-06b99e335792");
            niscodes.Add("98154d7e-11be-4820-8447-7f181e3ee084");
            niscodes.Add("98154d7e-11be-4820-8447-7f181e3ee084");

            //var adressen = selectrepo.EFCoreSelect(niscodes);
            var adressen = selectrepo.FromSql(niscodes);
            //var adressen = selectrepo.ExecuteSqlRaw(niscodes);


            //var niscodes = createRepo.GetNISCodes(50);
            //createRepo.TestMethode(niscodes);

            //List<AdresX> adressen = createRepo.GetAdressen("Zottegem", 15557);




            //deleterepo.EFBorisDjDelete(adressen);

            //deleterepo.RemoveRange(adressen);

            //deleterepo.ExecuteSqlRaw(adressen);

            //deleterepo.ExecuteSql(adressen);


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

