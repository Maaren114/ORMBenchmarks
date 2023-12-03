using OrmLiteBenchmarks.repositories;

namespace OrmLiteBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repoupdate = new OrmLiteUpdateRepository();
            var repocreate = new OrmLiteCreateRepository();
            var repodelete = new OrmLiteDeleteRepository();
            
            var adressen = repocreate.GetAdressen("Zottegem");

            repodelete.ExecuteDeleteRaw(adressen);

            //repoupdate.ExecuteUpdateRaw(adressen);
            //repo.BulkInsert(adressen);
            //repocreate.BulkInsertRaw(adressen);
        }
    }
}

