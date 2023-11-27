using EFCoreBenchmarks.models;

namespace EFCoreBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new EFCoreRepository();
            List<Adres> adressen = repo.GetAdressen("Zottegem");
            repo.Create3(adressen);
        }
    }
}
