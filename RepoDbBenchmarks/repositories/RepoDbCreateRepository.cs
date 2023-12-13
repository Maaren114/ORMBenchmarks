using Microsoft.Data.SqlClient;
using RepoDb;
using System;
using System.Data;
using System.Data.Common;
using System.Text.Json;
using Tools;

namespace RepoDbBenchmarks.repositories
{
    public class RepoDbCreateRepository
    {
        private SqlConnection _connection;
        public RepoDbCreateRepository()
        {
            GlobalConfiguration.Setup().UseSqlServer();

            _connection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public void RepoDbInsertAll(List<AdresX> adressen)
        {
            _connection.Open();
            List<List<AdresX>> adressenbatches = SplitListIntoBatches(adressen, 2098);
            foreach (var adressenbatch in adressenbatches)
            {
                _connection.InsertAll(adressenbatch, batchSize: 262); // 262 gaat wel nog. 263 niet meer!!! (teveel parameters)
            }
            _connection.Close();
        }

        public void RepoDbBulkInsert(List<AdresX> adressen)
        {
            _connection.Open();
            _connection.BulkInsert(adressen, batchSize: 15000);
            _connection.Close();
        }

        public void RepoDbExecuteNonQuery(List<AdresX> adressen)
        {
            _connection.Open();

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
                            FROM OPENJSON(@Adressen)
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

            string adressenJSON = JsonSerializer.Serialize(adressen);

            _connection.ExecuteNonQuery(query, new { Adressen = adressenJSON });
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





