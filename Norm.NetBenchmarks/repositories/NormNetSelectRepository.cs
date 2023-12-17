using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace Norm.NetBenchmarks.repositories
{
    public class NormNetSelectRepository
    {
        private SqlConnection _connection;
        public NormNetSelectRepository()
        {
            _connection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public List<AdresX> NormNetRead(List<string> niscodes)
        {
            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            string query = @"SELECT *
	                         FROM Adressen
		                     WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
	     		                               FROM OPENJSON(@niscodes));";

            var adressen = _connection.Read<AdresX>(query, new { niscodes = niscodesJSON }).ToList();
            return adressen;
        }
    }
}


