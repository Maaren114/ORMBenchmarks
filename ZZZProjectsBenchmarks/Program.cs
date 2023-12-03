using ZZZProjectsBenchmarks.repositories;

namespace ZZZProjectsBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var repoupdate = new ZZZProjectsUpdateRepository();
            var repocreate = new ZZZProjectsCreateRepository();

            var adressen = repocreate.GetAdressen("Zottegem");

            adressen.ForEach(x =>
            {
                x.Status = ":)";
            
            });

            repoupdate.ZZZProjectsBulkUpdate(adressen);
            //repocreate.ZZZProjectsBulkInsert(adressen);
        }
    }
}