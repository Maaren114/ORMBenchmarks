namespace OrmLiteBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new Repository();
            var adressen = repo.GetAdressen("Zottegem");
            repo.BulkInsertRaw(adressen);
        }
    }
}

