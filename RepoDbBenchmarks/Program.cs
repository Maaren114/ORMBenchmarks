using RepoDbBenchmarks.repositories;

namespace RepoDbBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repoupdate = new RepoDbUpdateRepository();
            var repocreate = new RepoDbCreateRepository();
            var adressen = repocreate.GetAdressen("Zottegem");

            //repoupdate.BulkUpdate(adressen);
            //repoupdate.UpdateAll(adressen);

            //repocreate.BulkInsert(adressen);
            //repocreate.InsertAll(adressen);



        }
    }
}