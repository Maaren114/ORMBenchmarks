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
            _connection.DeleteAll(adressen);
            _connection.Close();
        }

        public void RepoDbBulkDelete(List<AdresX> adressen)
        {
            _connection.Open();
            _connection.BulkDelete(adressen, batchSize: 15000);
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
    }
}
