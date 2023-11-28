﻿using NHibernate;
using NHibernate.Impl;
using NHibernateBenchmarks.mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NHibernateBenchmarks
{
    public class Repository
    {
        private ISessionFactory _sessionFactory;

        public Repository()
        {
            _sessionFactory = NHibernateHelper.ConfigureNHibernate();
        }

        public List<Adres> GetAdressen(string gemeentenaam)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var adressen = session.Query<Adres>()
                    .Where(a => a.Straat.Gemeente.Gemeentenaam == gemeentenaam)
                    .Select(a => new Adres
                    {
                        AdresId = a.AdresId,
                        StraatId = a.Straat.StraatId,
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

        public void Batch(List<Adres> adressen) // werkt! dit is batch
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

        public void BatchRaw(List<Adres> adressen) // werkt! dit is batch
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
                               StraatId int,
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






