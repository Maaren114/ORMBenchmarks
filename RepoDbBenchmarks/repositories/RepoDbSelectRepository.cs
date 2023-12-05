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
    public class RepoDbSelectRepository
    {
        private SqlConnection _connection;
        public RepoDbSelectRepository()
        {
            GlobalConfiguration.Setup().UseSqlServer();
            _connection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public List<AdresX> Query(List<string> niscodes)
        {
            _connection.Open();

            List<AdresX> adressen = new List<AdresX>();
            List<List<string>> niscodebatches = SplitListIntoBatches(niscodes, 2098);

            foreach (var niscodebatch in niscodebatches)
            {
                List<AdresX> adressenFromBatch = _connection.Query<AdresX>(a => niscodebatch.Contains(a.NISCode)).ToList();
                adressen.AddRange(adressenFromBatch);
            }
            
            _connection.Close();
            return adressen;
        }

        public List<AdresX> ExecuteQuery(List<string> niscodes)
        {
            _connection.Open();

            string query = @"SELECT *
	                             FROM Adressen
		                         WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
	     		                                   FROM OPENJSON(@niscodes));";

            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            var adressen = _connection.ExecuteQuery<AdresX>(query, new { niscodes = niscodesJSON }).ToList();

            _connection.Close();

            return adressen;
        }

        #region helper methods
        public List<List<string>> SplitListIntoBatches(List<string> sourceList, int batchSize)
        {
            List<List<string>> batches = new List<List<string>>();

            for (int i = 0; i < sourceList.Count; i += batchSize)
            {
                List<string> batch = sourceList.Skip(i).Take(batchSize).ToList();
                batches.Add(batch);
            }

            return batches;
        }
        #endregion
    }
}






