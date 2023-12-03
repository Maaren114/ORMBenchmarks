using LinqToDB;
using LinqToDB.Data;
using LinqToDbBenchmarks.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace LinqToDbBenchmarks.repositories
{
    public class LinqToDbDeleteRepository
    {
        private StratenRegisterConnection _connection;

        public LinqToDbDeleteRepository()
        {
            DataConnection.DefaultSettings = new MySettings();
            _connection = new StratenRegisterConnection();
        }

        public void LinqToDbExecute(List<AdresX> updates)
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
