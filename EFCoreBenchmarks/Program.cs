using EFCoreBenchmarks.models;
using Tools;

namespace EFCoreBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new CreateEFCoreRepository();
            List<AdresX> adressen = repo.GetAdressen("Zottegem");

            repo.EFBorisDjCreate(adressen);
            repo.ExecuteSqlRaw(adressen);
            repo.ExecuteSql(adressen);
        }
    }
}
