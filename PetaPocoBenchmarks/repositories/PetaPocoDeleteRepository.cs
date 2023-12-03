using Microsoft.Data.SqlClient;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace PetaPocoBenchmarks.repositories
{
    public class PetaPocoDeleteRepository
    {
        private Database _database;
        public PetaPocoDeleteRepository()
        {
            _database = new Database(new SqlConnection(Toolkit.GetConnectionString()));
        }

        public void PetaPocoExecute(List<AdresX> adressen)
        {
            _database.Connection.Open();

            string query = $@"
                             DELETE FROM Adressen
                             WHERE AdresID IN (SELECT AdresID
                                               FROM OPENJSON(@adressen)
                                               WITH (AdresID int));";

            string adressenJSON = JsonSerializer.Serialize(adressen);

            _database.Execute(query, new { adressen = adressenJSON });

            _database.Connection.Close();
        }




    }
}
