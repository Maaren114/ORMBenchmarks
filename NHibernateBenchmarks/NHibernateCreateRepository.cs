using NHibernate;
using NHibernate.Impl;
using NHibernateBenchmarks.mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace NHibernateBenchmarks
{
    public class NHibernateCreateRepository
    {
        private ISessionFactory _sessionFactory;

        public NHibernateCreateRepository()
        {
            _sessionFactory = NHibernateHelper.ConfigureNHibernate();
        }

        public List<AdresX> GetAdressen(string gemeentenaam)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var adressen = session.Query<AdresX>()
                    .Where(a => a.Straat.Gemeente.Gemeentenaam == gemeentenaam)
                    .Select(a => new AdresX
                    {
                        AdresID = a.AdresID,
                        StraatID = a.Straat.StraatID,
                        Huisnummer = a.Huisnummer,
                        Appartementnummer = a.Appartementnummer,
                        Busnummer = a.Busnummer,
                        NISCode = a.NISCode,
                        Postcode = a.Postcode,
                        Status = a.Status
                    })
                    .Take(15557)
                    .ToList();
                return adressen;
            }
        }

        public void Batch(List<AdresX> adressen) // werkt! dit is batch
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                foreach (var adres in adressen)
                {
                    session.Save(adres);
                }
                transaction.Commit();
            }
        }

        public void BatchRaw(List<AdresX> adressen) // werkt! dit is batch
        {
            string query = $@"
                            INSERT INTO Adressen
                            (
                                StraatID,
                                Huisnummer,
                                Appartementnummer,
                                Busnummer,
                                NISCode,
                                Postcode,
                                Status
                            )
                            SELECT StraatID, Huisnummer, Appartementnummer, Busnummer, NISCode, Postcode, Status
                            FROM OPENJSON(:adressen)
                            WITH
                            (
                               StraatID int,
                               Huisnummer nvarchar(80),
                               Appartementnummer nvarchar(80),
                               Busnummer nvarchar(80),
                               NISCode int,
                               Postcode int,
                               Status nvarchar(80)
                            )";


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







