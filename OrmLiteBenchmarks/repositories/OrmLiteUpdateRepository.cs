using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace OrmLiteBenchmarks.repositories
{
    public class OrmLiteUpdateRepository
    {
        private OrmLiteConnectionFactory _factory;

        public OrmLiteUpdateRepository()
        {
            _factory = new OrmLiteConnectionFactory(Toolkit.GetConnectionString(), SqlServerDialect.Provider);
        }

        public void ExecuteUpdateRaw(List<AdresX> adressen)
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