namespace NHibernateBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new NHibernateCreateRepository();

            var adressen = repo.GetAdressen("Zottegem");

            repo.BatchRaw(adressen);
            repo.Batch(adressen);

        }
    }
}