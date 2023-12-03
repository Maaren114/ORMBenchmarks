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
    public class NormNetDeleteRepository
    {
        private SqlConnection _connection;
        public NormNetDeleteRepository()
        {
            _connection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public void UpdateExecute(List<AdresX> updates)
        {
            string adressenJSON = JsonSerializer.Serialize(updates);

            string query = $@"
                             DELETE FROM Adressen
                             WHERE AdresID IN (SELECT AdresID
                                               FROM OPENJSON(@adressen)
                                               WITH (AdresID int));";

            _connection.Execute(query, new { adressen = adressenJSON });
        }
    }
}
