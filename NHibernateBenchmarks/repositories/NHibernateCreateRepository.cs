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

        public void NHibernateSave(List<AdresX> adressen)
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

        public void NHibernateCreateSqlQuery(List<AdresX> adressen)
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
                               NISCode nvarchar(80),
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









