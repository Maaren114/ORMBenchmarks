using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace PetaPocoBenchmarks.repositories
{
    public class PetaPocoCreateRepository
    {
        private Database _database;
        public PetaPocoCreateRepository()
        {
            _database = new Database(new SqlConnection(Toolkit.GetConnectionString()));
        }

        public List<AdresX> GetAdressen(string gemeentenaam)
        {
            _database.Connection.Open();

            string query = $@"
                            SELECT TOP 15557 a.*
                            FROM Adressen a
                            INNER JOIN Straten s ON a.StraatID = s.StraatID
                            INNER JOIN Gemeentes g ON g.GemeenteID = s.GemeenteID
                            WHERE g.Gemeentenaam = @Gemeentenaam
                            ORDER BY a.StraatID;";

            List<AdresX> adressen = _database.Fetch<AdresX>(query, new { Gemeentenaam = gemeentenaam }).ToList();

            _database.Connection.Close();

            return adressen;
        }

        public List<StraatX> GetStraten(string provincienaam, int aantal)
        {
            _database.Connection.Open();

            string query = @"SELECT TOP " + aantal +  @" s.* FROM Straten s
                             INNER JOIN Gemeentes g ON g.GemeenteID = s.GemeenteID
                             INNER JOIN Provincies p ON p.ProvincieID = g.ProvincieID
                             WHERE p.Provincienaam = @0;";

            List<StraatX> straten = _database.Fetch<StraatX>(query, provincienaam).ToList();

            _database.Connection.Close();
            return straten;

        }

        public void PetaPocoExecute(List<AdresX> adressen)
        {
            _database.Connection.Open();


            string query = @"
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
                NISCode nvarchar(80),
                Postcode int,
                Status nvarchar(80)
            )";

            string adressenJSON = JsonSerializer.Serialize(adressen);

            int result = _database.Execute(query, new { adressen = adressenJSON });

            _database.Connection.Close();
        }

        public void PetaPocoExecuteStratenBous(List<StraatX> straten)
        {
            _database.Connection.Open();


            string query = @"
                            INSERT INTO Straten
                            (
                                GemeenteID,
                                Straatnaam
                            )
                            SELECT GemeenteID, Straatnaam
                            FROM OPENJSON(@straten)
                            WITH
                            (
                                StraatID int,
                                GemeenteID int,
                                Straatnaam nvarchar(80)
                            )";

            string stratenJSON = JsonSerializer.Serialize(straten);

            _database.Execute(query, new { straten = stratenJSON });

            _database.Connection.Close();
        }



    }
}
