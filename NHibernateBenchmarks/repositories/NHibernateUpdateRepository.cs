using NHibernate;
using NHibernateBenchmarks.mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace NHibernateBenchmarks.repositories
{
    public class NHibernateUpdateRepository
    {
        private ISessionFactory _sessionFactory;

        public NHibernateUpdateRepository()
        {
            _sessionFactory = NHibernateHelper.ConfigureNHibernate();
        }

        public void Batch(List<AdresX> adressen) // werkt enkel wanneer adressen niet initieel werden opgevraagd door NHibnernate.
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                foreach (var adres in adressen)
                {
                    session.Update(adres);
                }
                transaction.Commit();
            }
        }

        public void BatchRaw(List<AdresX> updates)  // werkt enkel wanneer adressen niet initieel werden opgevraagd door NHibnernate.
        {
            string query = $@"
                            UPDATE adr
                            SET
	                            adr.StraatID = adru.StraatID,
	                            adr.Huisnummer = adru.Huisnummer,
	                            adr.Appartementnummer = adru.Appartementnummer,
	                            adr.Busnummer = adru.Busnummer,
	                            adr.Postcode = adru.Postcode,
	                            adr.Status = adru.Status
                            FROM Adressen adr
                            INNER JOIN OPENJSON(:updates) WITH
                            (
	                            AdresID int,
	                            StraatID int,
	                            Huisnummer nvarchar(80),
	                            Appartementnummer nvarchar(80),
	                            Busnummer nvarchar(80),
	                            Postcode int,
	                            Status nvarchar(80)
                            ) adru
                            ON adr.AdresID = adru.AdresID;";

            string adressenJSON = JsonSerializer.Serialize(updates);

            using (var statelessSession = _sessionFactory.OpenStatelessSession())
            using (var transaction = statelessSession.BeginTransaction())
            {
                statelessSession.CreateSQLQuery(query).SetParameter("updates", adressenJSON).ExecuteUpdate();
                transaction.Commit();
            }
        }
    }
}




