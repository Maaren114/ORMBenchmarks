using NHibernate;
using NHibernateBenchmarks.mappings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace NHibernateBenchmarks.repositories
{
    public class NHibernateDeleteRepository
    {
        private ISessionFactory _sessionFactory;

        public NHibernateDeleteRepository()
        {
            _sessionFactory = NHibernateHelper.ConfigureNHibernate();
        }

        public void NHibernateDelete(List<AdresX> adressen)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                foreach (var adres in adressen)
                {
                    session.Delete(adres);
                }
                transaction.Commit();
            }
        }

        public void NHibernateCreateSqlQuery(List<AdresX> adressen)
        {
            string query = $@"
                             DELETE FROM Adressen
                             WHERE AdresID IN (SELECT AdresID
                                               FROM OPENJSON(:adressen)
                                               WITH (AdresID int));";


            string adressenJSON = JsonSerializer.Serialize(adressen);

            using (var statelessSession = _sessionFactory.OpenStatelessSession())
            using (var transaction = statelessSession.BeginTransaction())
            {
                statelessSession.CreateSQLQuery(query).SetParameter("adressen", adressenJSON).ExecuteUpdate();
                transaction.Commit();
            }
        }
    }
}
