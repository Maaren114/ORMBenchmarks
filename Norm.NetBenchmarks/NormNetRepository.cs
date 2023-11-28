using Norm.NetBenchmarks.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace Norm.NetBenchmarks
{
    public class NormNetRepository
    {
        private SqlConnection _connection;
        public NormNetRepository()
        {
            _connection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public List<AdresX> GetAdressen(string gemeentenaam)
        {
            string query = $@"
                            SELECT TOP 15557 a.*
                            FROM Adressen a
                            INNER JOIN Straten s ON a.StraatID = s.StraatID
                            INNER JOIN Gemeentes g ON g.GemeenteID = s.GemeenteID
                            WHERE g.Gemeentenaam = @Gemeentenaam
                            ORDER BY a.StraatID;";

            List<AdresX> adressen = _connection.Read<AdresX>(query, new { Gemeentenaam = gemeentenaam }).ToList();
            return adressen;
        }

        public void CreateExecute(List<AdresX> adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);

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
