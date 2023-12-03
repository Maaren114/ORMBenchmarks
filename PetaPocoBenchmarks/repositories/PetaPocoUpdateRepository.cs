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
    public class PetaPocoUpdateRepository
    {
        private Database _database;
        public PetaPocoUpdateRepository()
        {
            _database = new Database(new SqlConnection(Toolkit.GetConnectionString()));
        }

        public void PetaPocoExecute(List<AdresX> adressen)
        {
            _database.Connection.Open();


            string query = $@"
                            UPDATE adr
                            SET
	                            adr.StraatID = adru.StraatID,
	                            adr.Huisnummer = adru.Huisnummer,
	                            adr.Appartementnummer = adru.Appartementnummer,
	                            adr.Busnummer = adru.Busnummer,
	                            adr.Postcode = adru.Postcode,
	                            adr.Status = adru.Status,
                                adr.NISCode = adru.NISCode
                            FROM Adressen adr
                            INNER JOIN OPENJSON(@updates) WITH
                            (
	                            AdresID int,
	                            StraatID int,
	                            Huisnummer nvarchar(80),
	                            Appartementnummer nvarchar(80),
	                            Busnummer nvarchar(80),
	                            Postcode int,
	                            Status nvarchar(80),
                                NISCode nvarchar(80)
                            ) adru
                            ON adr.AdresID = adru.AdresID;";

            string adressenJSON = JsonSerializer.Serialize(adressen);

            int result = _database.Execute(query, new { updates = adressenJSON });

            _database.Connection.Close();
        }
    }
}


