using Microsoft.Data.SqlClient;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace RepoDbBenchmarks.repositories
{
    public class RepoDbDeleteRepository
    {
        private SqlConnection _connection;
        public RepoDbDeleteRepository()
        {
            GlobalConfiguration.Setup().UseSqlServer();
            _connection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public void RepoDbDeleteAll(List<AdresX> adressen)
        {
            _connection.Open();
            List<List<AdresX>> adressenbatches = SplitListIntoBatches(adressen, 2098);
            foreach (var adressenbatch in adressenbatches)
            {
                _connection.DeleteAll(adressenbatch); // 262 gaat wel nog. 263 niet meer!!! (teveel parameters)
            }
            _connection.Close();
        }

        public void RepoDbBulkDelete(List<AdresX> adressen)
        {
            _connection.Open();
            _connection.BulkDelete(adressen, batchSize: 20000);
            _connection.Close();
        }

        public void RepoDbExecuteNonQuery(List<AdresX> adressen)
        {
            _connection.Open();

            string query = $@"
                             DELETE FROM Adressen
                             WHERE AdresID IN (SELECT AdresID
                                               FROM OPENJSON(@Adressen)
                                               WITH (AdresID int));";

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
