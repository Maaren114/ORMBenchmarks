namespace RepoDbBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new RepoDbCreateRepository();
            var adressen = repo.GetAdressen("Zottegem");

            repo.BulkInsert(adressen);
            repo.InsertAll(adressen);
        }
    }
}