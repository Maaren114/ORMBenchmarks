using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using DapperBenchmarks.models;
using Dapper;
using System.Text.Json;
using Z.Dapper.Plus;

namespace DapperBenchmarks.repositories
{
    public class DapperCreateRepository
    {
        private IDbConnection _dbConnection;
        public DapperCreateRepository()
        {
            _dbConnection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public List<AdresX> GetAddressen(string gemeentenaam)
        {
            string query = $@"
                            SELECT TOP 15557 a.*
                            FROM Adressen a
                            INNER JOIN Straten s ON a.StraatID = s.StraatID
                            INNER JOIN Gemeentes g ON g.GemeenteID = s.GemeenteID
                            WHERE g.Gemeentenaam = @Gemeentenaam
                            ORDER BY a.StraatID;";

            List<AdresX> adressen = _dbConnection.Query<AdresX>(query, new { Gemeentenaam = gemeentenaam }).ToList();
            return adressen;
        }


        public void DapperExecute(List<AdresX> adressen)
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

            string adressenJSON = JsonSerializer.Serialize(adressen);
            int result = _dbConnection.Execute(query, new { adressen = adressenJSON });
        }

        public void DapperPlus(List<AdresX> adressen)
        {
            _dbConnection.UseBulkOptions(options =>
            {
                options.BatchSize = 16000;
                options.AutoMapOutputDirection = false;
                options.DestinationTableName = "Adressen";
            }).BulkUpdate(adressen);
        }
    }
}



