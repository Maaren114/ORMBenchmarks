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

            _connection.Execute(query, new { adressen = adressenJSON });
        }
    }
}
