using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;
using Z.Dapper.Plus;

namespace DapperBenchmarks.repositories
{
    public class DapperUpdateRepository
    {
        private IDbConnection _dbConnection;
        public DapperUpdateRepository()
        {
            _dbConnection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public void DapperExecute(List<AdresX> adresUpdates)
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
                            INNER JOIN OPENJSON(@updates) WITH
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

            string adresUpdatesJSON = JsonSerializer.Serialize(adresUpdates);
            int result = _dbConnection.Execute(query, new { updates = adresUpdatesJSON });
        }

        public void DapperBulkUpdate_DapperPlus(List<AdresX> adressen)
        {
            _dbConnection.UseBulkOptions(options =>
            {
                options.BatchSize = 20000;
                options.AutoMapOutputDirection = false;
                options.DestinationTableName = "Adressen";
            }).BulkUpdate(adressen);
        }
    }
}


