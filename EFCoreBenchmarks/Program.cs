using Bogus;
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
            var testrepo = new TestRepository();

            //List<AdresX> adressen = createRepo.GetAdressen("Zottegem", 15000);
            //adressen.ForEach(a => a.AdresID = 0);


            //updateRepo.EFBorisDjUpdate(adressen);


            //deleterepo.EFBorisDjDelete(adressen);



            //createRepo.AddRange(adressen);

            //createRepo.EFBorisDjCreate(adressen);

            //testrepo.SqlBulkCopy(adressen);
            //createRepo.Klassieke1per1Methode(adressen);



            //List<string> niscodes = new List<string>();
            //niscodes.Add("2c4140d4-cff7-49be-a8c4-2375783344ee");
            //niscodes.Add("2c4140d4-cff7-49be-a8c4-2375783344ee");
            //niscodes.Add("9f5860cb-6c72-4dd3-9f03-c49a417a65ac");
            //niscodes.Add("3bd7ed9e-2633-4f44-a583-1da61d50db95");
            //niscodes.Add("6772fad9-c6ad-4943-9e40-06b99e335792");
            //niscodes.Add("98154d7e-11be-4820-8447-7f181e3ee084");
            //niscodes.Add("98154d7e-11be-4820-8447-7f181e3ee084");

            //var adressen = selectrepo.EFCoreSelect(niscodes);
            //var adressen = selectrepo.FromSql(niscodes);
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
            //    x.Status = "x";
            //});


            //updateRepo.ExecuteSqlRaw(adressen); 
            //updateRepo.UpdateRange(adressen);

            //repo.EFBorisDjCreate(adressen);
            //repo.ExecuteSqlRaw(adressen);
            //repo.ExecuteSql(adressen);

            //var niscodes = createRepo.GetNISCodes(2200);
            //var adressen = selectrepo.EFCoreSelect(niscodes);

            //createRepo.EFCoreBulkInsert_BorisDj(adressen);



            //List<StraatX> straten = selectrepo.SelectStraten(15000);
            //updateRepo.Update(straten);


            var niscodes = selectrepo.GetNISCodes(5);

            var adressen = selectrepo.EFCoreWhere(niscodes);



            //deleterepo.Remove(adressen);
        }
        public static List<AdresX> GetBogusAdressen()
        {
            var faker = new Faker<AdresX>()
           .RuleFor(a => a.StraatID, f => 1)
           .RuleFor(a => a.Huisnummer, f => f.Address.BuildingNumber())
           .RuleFor(a => a.Appartementnummer, f => f.Random.AlphaNumeric(3))
           .RuleFor(a => a.Busnummer, f => f.Random.AlphaNumeric(3))
           .RuleFor(a => a.Status, f => f.PickRandomParam("Actief", "Inactief"))
           .RuleFor(a => a.NISCode, f => f.Random.Guid().ToString())
           .RuleFor(a => a.Postcode, f => 9620);
           //.RuleFor(a => a.Straat, (f, a) => new StraatX { StraatID = a.StraatID, Straatnaam = "Kerkstraat" });
            return faker.Generate(10);
        }
    }
}





