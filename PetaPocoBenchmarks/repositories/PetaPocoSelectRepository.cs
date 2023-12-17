using Microsoft.Data.SqlClient;
using PetaPoco;
using System.Text.Json;
using Tools;

namespace PetaPocoBenchmarks.repositories
{
    public class PetaPocoSelectRepository
    {
        private Database _database;
        public PetaPocoSelectRepository()
        {
            _database = new Database(new SqlConnection(Toolkit.GetConnectionString()));
        }

        public List<AdresX> PetaPoco_Fetch(List<string> niscodes)
        {
            _database.Connection.Open();

            string query = @"SELECT *
	                         FROM Adressen
		                     WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
	     		                               FROM OPENJSON(@niscodes));";

            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            List<AdresX> adressen = _database.Fetch<AdresX>(query, new { niscodes = niscodesJSON });

            _database.Connection.Close();
            return adressen;
        }
    }
}












