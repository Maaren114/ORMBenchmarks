using PetaPocoBenchmarks.repositories;

namespace PetaPocoBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var updaterepo = new PetaPocoUpdateRepository();
            var createrepo = new PetaPocoCreateRepository();
            var adressen = createrepo.GetAdressen("Zottegem");

            //createrepo.PetaPocoExecute(adressen);
            updaterepo.PetaPocoExecute(adressen);
        }
    }
}