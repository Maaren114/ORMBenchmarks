namespace RepoDbBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new Repository();
            var adressen = repo.GetAdressen("Zottegem");
            repo.BulkInsert(adressen);
        }
    }
}