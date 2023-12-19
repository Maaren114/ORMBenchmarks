using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;
using Tools;

namespace DapperBenchmarks.repositories
{
    public class DapperSelectRepository
    {
        private IDbConnection _dbConnection;
        public DapperSelectRepository()
        {
            _dbConnection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public IEnumerable<AdresX> DapperQuery(List<string> niscodes)
        {
            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            string query = @"SELECT *
	                         FROM Adressen
		                     WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
	     		                               FROM OPENJSON(@niscodes));";

            List<AdresX> adressen = _dbConnection.Query<AdresX>(query, new { niscodes = niscodesJSON }).ToList();
            return adressen;
        }

        #region helper methods
        public List<string> GetRandomNisCodes()
        {
            string query = $@"
                            SELECT TOP 15000 a.NisCode
                            FROM Adressen a
                            ORDER BY NEWID();";

            List<string> niscodes = _dbConnection.Query<string>(query).ToList();
            return niscodes;
        }

        public List<AdresX> GetAdressen()
        {
            string query = $@"
                            SELECT TOP 15000 *
                            FROM Adressen a;";

            List<AdresX> adressen = _dbConnection.Query<AdresX>(query).ToList();
            return adressen;
        }

        public List<AdresX> GetRandomAdressen()
        {
            string query = $@"
                            SELECT TOP 15000 *
                            FROM Adressen a;";

            List<AdresX> adressen = _dbConnection.Query<AdresX>(query).ToList();
            return adressen;
        }
        #endregion
    }
}




