using LinqToDB.Data;
using LinqToDbBenchmarks.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tools;

namespace LinqToDbBenchmarks.repositories
{
    public class LinqToDbUpdateRepository
    {

        private StratenRegisterConnection _connection;

        public LinqToDbUpdateRepository()
        {
            DataConnection.DefaultSettings = new MySettings();
            _connection = new StratenRegisterConnection();
        }

        public void LinqToDbExecute(List<AdresX> updates)
        {
            string adressenJSON = JsonSerializer.Serialize(updates);

            string query = $@"
                            INSERT INTO Adressen
                            (
                                StraatID,
                                Huisnummer,
                                Appartementnummer,
                                Busnummer,
                                NISCode,
                                Postcode,
                                Status
                            )
                            SELECT StraatID, Huisnummer, Appartementnummer, Busnummer, NISCode, Postcode, Status
                            FROM OPENJSON(@updates)
                            WITH
                            (
                                StraatID int,
                                Huisnummer nvarchar(80),
                                Appartementnummer nvarchar(80),
                                Busnummer nvarchar(80),
                                NISCode int,
                                Postcode int,
                                Status nvarchar(80)
                            )";

            _connection.Execute(query, new { updates = adressenJSON });
        }
    }
}
