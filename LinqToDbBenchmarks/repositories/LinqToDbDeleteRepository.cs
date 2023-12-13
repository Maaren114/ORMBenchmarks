using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SQLite;
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

        public void LinqToDbExecute(List<AdresX> deletes)
        {
            string adressenJSON = JsonSerializer.Serialize(deletes);

            string query = $@"
                             DELETE FROM Adressen
                             WHERE AdresID IN (SELECT AdresID
                                               FROM OPENJSON(@Adressen)
                                               WITH (AdresID int));";

            _connection.Execute(query, new { Adressen = adressenJSON });
        }

        public void LinqToDbDelete(List<AdresX> deletes)
        {
            _connection.Adressen.Where(adres => deletes.Contains(adres)).Delete();
        }
    }
}




