using LinqToDB.Data;
using LinqToDbBenchmarks.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinqToDbBenchmarks
{
    public class LinqToDbRepository
    {
        private StratenRegisterConnection _connection;

        public LinqToDbRepository()
        {
            DataConnection.DefaultSettings = new MySettings();
            _connection = new StratenRegisterConnection();
        }

        public List<Adres> GetAdressen(string gemeentenaam)
        {
            var query = from a in _connection.Adressen
                        join s in _connection.Straten on a.StraatID equals s.StraatID
                        join g in _connection.Gemeentes on s.GemeenteID equals g.GemeenteID
                        where g.Gemeentenaam == gemeentenaam
                        orderby a.StraatID
                        select a;

            var result = query.Take(15557).ToList();
            return result;
        }

        public void CreateBulkCopy(List<Adres> adressen)
        {
            _connection.BulkCopy(adressen);
        }

        public void CreateExecute(List<Adres> adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);

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
                            FROM OPENJSON(@adressen)
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

            _connection.Execute(query, new { adressen = adressenJSON });
        }





    }
}
