using EFCoreBenchmarks.models;

namespace EFCoreBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new EFCoreRepository();
            List<Adres> adressen = repo.GetAdressen("Zottegem");
            
            adressen.ForEach(adres => adres.AdresId = 0);

            //repo.ExecuteSql(adressen);
            repo.ExecuteSqlRaw(adressen);

        }
    }
}
