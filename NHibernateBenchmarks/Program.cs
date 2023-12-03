using NHibernate;
using NHibernateBenchmarks.repositories;
using ServiceStack;

namespace NHibernateBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var updaterepo = new NHibernateUpdateRepository();
            var createrepo = new NHibernateCreateRepository();

            var adressen = createrepo.GetAdressen("Zottegem");

            adressen.ForEach(x =>
            {
                x.Status = "XDDD";
            });



            //updaterepo.Batch(adressen);
            updaterepo.BatchRaw(adressen);
        }
    }
}