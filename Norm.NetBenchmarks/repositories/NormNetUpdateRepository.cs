using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace Norm.NetBenchmarks.repositories
{
    public class NormNetUpdateRepository
    {
        private SqlConnection _connection;
        public NormNetUpdateRepository()
        {
            _connection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public void UpdateExecute(List<AdresX> updates)
        {
            string adressenJSON = JsonSerializer.Serialize(updates);

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
                            INNER JOIN OPENJSON(@adressen) WITH
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

            _connection.Execute(query, new { adressen = adressenJSON });
        }
    }
}
