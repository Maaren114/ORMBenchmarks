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

        public void OrmLiteExecuteNonQuery(List<AdresX> adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);

            using (var db = _factory.OpenDbConnection())
            {
                string query = $@"
                            UPDATE adr
                            SET
	                            adr.StraatID = adru.StraatID,
	                            adr.Huisnummer = adru.Huisnummer,
	                            adr.Appartementnummer = adru.Appartementnummer,
	                            adr.Busnummer = adru.Busnummer,
	                            adr.Postcode = adru.Postcode,
	                            adr.Status = adru.Status,
                                adr.NISCode = adru.NISCode
                            FROM Adressen adr
                            INNER JOIN OPENJSON(@Adressen) WITH
                            (
	                            AdresID int,
	                            StraatID int,
	                            Huisnummer nvarchar(80),
	                            Appartementnummer nvarchar(80),
	                            Busnummer nvarchar(80),
	                            Postcode int,
                                NISCode nvarchar(80),
	                            Status nvarchar(80)
                            ) adru
                            ON adr.AdresID = adru.AdresID;";

                db.ExecuteNonQuery(query, new { Adressen = adressenJSON });
            }
        }

        #region 1 per 1
        public void OrmLiteUpdateAll(List<AdresX> adressen) // Voegt 1 per 1 toe. Daarom niet geïncludeerd in onderzoek.
        {
            using (var db = _factory.OpenDbConnection())
            {
                db.UpdateAll(adressen);
            }
        }

        public void OrmLiteUpdate(List<AdresX> adressen) // Voegt 1 per 1 toe. Daarom niet geïncludeerd in onderzoek.
        {
            using (var db = _factory.OpenDbConnection())
            {
                foreach (var adres in adressen)
                {
                    db.Update(adres);
                }
            }
        }
        #endregion
    }
}