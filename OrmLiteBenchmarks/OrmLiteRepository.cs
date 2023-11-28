using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using OrmLiteBenchmarks.models;
using System.Text.Json;

namespace OrmLiteBenchmarks
{
    public class Repository
    {
        private OrmLiteConnectionFactory _factory;

        public Repository()
        {
            _factory = new OrmLiteConnectionFactory(Toolkit.GetConnectionString(), SqlServerDialect.Provider);
        }

        public List<Adres> GetAdressen(string gemeentenaam)
        {
            var db = _factory.OpenDbConnection();

            var adressenInZottegem = db.Select<Adres>(
                                     db.From<Adres>()
                                       .Join<Adres, Straat>((a, s) => a.StraatID == s.StraatId)
                                       .Join<Straat, Gemeente>((s, g) => s.GemeenteId == g.GemeenteId)
                                       .Join<Gemeente, Provincie>((g, p) => g.ProvincieId == p.ProvincieID)
                                       .Where<Gemeente>(g => g.Gemeentenaam == gemeentenaam)
                                       .OrderBy(s => s.StraatID)
                                       .Limit(16000));


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

        public void BulkInsert(List<Adres> adressen)
        {
            var db = _factory.OpenDbConnection();

            db.BulkInsert(adressen, new BulkInsertConfig
            {
                BatchSize = 16000
            });
        }

        public void BulkInsertRaw(List<Adres> adressen)
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
                                    NISCode int,
                                    Postcode int,
                                    Status nvarchar(80)
                                )";

                db.ExecuteSql(query, new { adressen = adressenJSON });
            }
        }
    }
}
