namespace PetaPocoBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new PetaPocoCreateRepository();
            var adressen = repo.GetAdressen("Zottegem");

            repo.PetaPocoExecute(adressen);

        }
    }
}