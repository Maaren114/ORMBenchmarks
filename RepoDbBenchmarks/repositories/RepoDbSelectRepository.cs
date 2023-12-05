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
            List<AdresX> adressen = _connection.Query<AdresX>(a => niscodes.Contains(a.NISCode)).ToList();
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
    }
}




