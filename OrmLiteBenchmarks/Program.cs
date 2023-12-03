using OrmLiteBenchmarks.repositories;

namespace OrmLiteBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repoupdate = new OrmLiteUpdateRepository();
            var repocreate = new OrmLiteCreateRepository();
            
            var adressen = repocreate.GetAdressen("Zottegem");

            repoupdate.ExecuteUpdateRaw(adressen);
            //repo.BulkInsert(adressen);
            repocreate.BulkInsertRaw(adressen);
        }
    }
}

