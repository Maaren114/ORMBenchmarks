using PetaPocoBenchmarks.repositories;

namespace PetaPocoBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var updaterepo = new PetaPocoUpdateRepository();
            var createrepo = new PetaPocoCreateRepository();
            var deleterepo = new PetaPocoDeleteRepository();

            var adressen = createrepo.GetAdressen("Zottegem");


            deleterepo.PetaPocoExecute(adressen);

            //createrepo.PetaPocoExecute(adressen);
            //updaterepo.PetaPocoExecute(adressen);
        }
    }
}