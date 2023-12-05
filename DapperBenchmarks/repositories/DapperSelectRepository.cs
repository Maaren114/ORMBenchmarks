using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;
using Z.Dapper.Plus;

namespace DapperBenchmarks.repositories
{
    public class DapperSelectRepository
    {
        private IDbConnection _dbConnection;
        public DapperSelectRepository()
        {
            _dbConnection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public IEnumerable<AdresX> DapperExecute(List<string> niscodes)
        {
            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            string query = @"SELECT *
	                         FROM Adressen
		                     WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
	     		                               FROM OPENJSON(@niscodes));";

            List<AdresX> adressen = _dbConnection.Query<AdresX>(query, new { niscodes = niscodesJSON }).ToList();
            return adressen;
        }
    }
}
