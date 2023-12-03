using NHibernate;
using NHibernateBenchmarks.repositories;
using ServiceStack;
using Tools;

namespace NHibernateBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var updaterepo = new NHibernateUpdateRepository();
            var createrepo = new NHibernateCreateRepository();
            var deleterepo = new NHibernateDeleteRepository();

            //var adressen = createrepo.GetAdressen("Zottegem");

            var adressen = new List<AdresX>();

            for (int i = 0; i < 15000; i++)
            {
                adressen.Add(new AdresX { AdresID = i + 1, StraatID = 1 });
            }

            //deleterepo.Batch(adressen);
            deleterepo.BatchRaw(adressen);
        }
    }
}