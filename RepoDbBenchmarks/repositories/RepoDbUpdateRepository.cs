using RepoDb;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using System.Text.Json;

namespace RepoDbBenchmarks.repositories
{
    public class RepoDbUpdateRepository
    {
        private SqlConnection _connection;
        public RepoDbUpdateRepository()
        {
            GlobalConfiguration.Setup().UseSqlServer();
            _connection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public void RepoDbUpdateAll(List<AdresX> adressen)
        {
            _connection.Open();
            List<List<AdresX>> adressenbatches = SplitListIntoBatches(adressen, 2098);
            foreach (var adressenbatch in adressenbatches)
            {
                _connection.UpdateAll(adressenbatch, batchSize: 262); // 262 gaat wel nog. 263 niet meer!!! (teveel parameters)
            }
            _connection.Close();
        }

        public void RepoDbBulkUpdate(List<AdresX> adressen)
        {
            _connection.Open();
            _connection.BulkUpdate(adressen, batchSize: 16000);
            _connection.Close();
        }

        public void RepoDbExecuteNonQuery(List<AdresX> adressen)
        {
            _connection.Open();

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
                            INNER JOIN OPENJSON(@Updates) WITH
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

            string adressenJSON = JsonSerializer.Serialize(adressen);

            _connection.ExecuteNonQuery(query, new { Updates = adressenJSON });
            _connection.Close();
        }

        #region helper methods
        public List<List<T>> SplitListIntoBatches<T>(List<T> sourceList, int batchSize)
        {
            List<List<T>> batches = new List<List<T>>();

            for (int i = 0; i < sourceList.Count; i += batchSize)
            {
                List<T> batch = sourceList.Skip(i).Take(batchSize).ToList();
                batches.Add(batch);
            }
            return batches;
        }
        #endregion
    }
}
