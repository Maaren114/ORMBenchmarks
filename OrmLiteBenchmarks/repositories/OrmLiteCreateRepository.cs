using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using OrmLiteBenchmarks.models;
using System.Text.Json;

namespace OrmLiteBenchmarks.repositories
{
    public class OrmLiteCreateRepository
    {
        private OrmLiteConnectionFactory _factory;

        public OrmLiteCreateRepository()
        {
            _factory = new OrmLiteConnectionFactory(Toolkit.GetConnectionString(), SqlServerDialect.Provider);
        }

        public List<AdresX> GetAdressen(string gemeentenaam)
        {
            var db = _factory.OpenDbConnection();

            var adressenInZottegem = db.Select(
                                     db.From<AdresX>()
                                       .Join<AdresX, StraatX>((a, s) => a.StraatID == s.StraatID)
                                       .Join<StraatX, GemeenteX>((s, g) => s.GemeenteID == g.GemeenteID)
                                       .Join<GemeenteX, ProvincieX>((g, p) => g.ProvincieID == p.ProvincieID)
                                       .Where<GemeenteX>(g => g.Gemeentenaam == gemeentenaam)
                                       .OrderBy(s => s.StraatID)
                                       .Limit(15000));


            // Eager loading (beperkt tot 1 niveau diep?)
            //var adressenInZottegem = db.LoadSelect<Adres>(
            //                         db.From<Adres>()
            //                        .Join<Adres, Straat>((a, s) => a.StraatId == s.StraatId)
            //                        .Join<Straat, Gemeente>((s, g) => s.GemeenteId == g.GemeenteId)
            //                        .Join<Gemeente, Provincie>((g, p) => g.ProvincieId == p.ProvincieID)
            //                        .Where<Gemeente>(g => g.Gemeentenaam == "Zottegem"));

            db.Dispose();
            return adressenInZottegem;
        }

        public void BulkInsert(List<AdresX> adressen)
        {
            var db = _factory.OpenDbConnection();

            db.BulkInsert(adressen, new BulkInsertConfig
            {
                BatchSize = 15000
            });
        }

        public void BulkInsertRaw(List<AdresX> adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);

            using (var db = _factory.OpenDbConnection())
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
                                SELECT StraatId, Huisnummer, Appartementnummer, Busnummer, NISCode, Postcode, Status
                                FROM OPENJSON(@adressen)
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

                db.ExecuteSql(query, new { adressen = adressenJSON });
            }
        }
    }
}
