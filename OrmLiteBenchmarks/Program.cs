namespace OrmLiteBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new OrmLiteCreateRepository();
            
            var adressen = repo.GetAdressen("Zottegem");

            //repo.BulkInsert(adressen);
            repo.BulkInsertRaw(adressen);
        }
    }
}

