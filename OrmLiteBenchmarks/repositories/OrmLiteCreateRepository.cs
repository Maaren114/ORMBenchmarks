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

        public void OrmLiteBulkInsert(List<AdresX> adressen)
        {
            var db = _factory.OpenDbConnection();

            db.BulkInsert(adressen, new BulkInsertConfig
            {
                BatchSize = 15000
            });
        }

        public void OrmLiteExecuteNonQuery(List<AdresX> adressen)
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

                db.ExecuteNonQuery(query, new { adressen = adressenJSON });
            }
        }

        #region 1 per 1
        public void InsertAll(List<StraatX> straten) // Voegt 1 per 1 toe. Daarom niet geïncludeerd in onderzoek.
        {
            var db = _factory.OpenDbConnection();
            db.InsertAll(straten);
        }

        public void Insert(List<StraatX> straten) // Voegt 1 per 1 toe. Daarom niet geïncludeerd in onderzoek.
        {
            var db = _factory.OpenDbConnection();

            foreach (var straat in straten)
            {
                db.Insert(straat);

            }
        }
        #endregion
    }
}
