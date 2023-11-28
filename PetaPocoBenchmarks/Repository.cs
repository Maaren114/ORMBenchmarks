﻿using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace PetaPocoBenchmarks
{
    public class Repository
    {
        private Database _database;
        public Repository()
        {
            _database = new PetaPoco.Database(new SqlConnection(Toolkit.GetConnectionString()));
        }

        public List<Adres> GetAdressen(string gemeentenaam)
        {
            _database.Connection.Open();

            string query = $@"
                            SELECT TOP 15557 a.*
                            FROM Adressen a
                            INNER JOIN Straten s ON a.StraatID = s.StraatID
                            INNER JOIN Gemeentes g ON g.GemeenteID = s.GemeenteID
                            WHERE g.Gemeentenaam = @Gemeentenaam
                            ORDER BY a.StraatID;";

            List<Adres> adressen = _database.Fetch<Adres>(query, new { Gemeentenaam = gemeentenaam }).ToList();

            _database.Connection.Close();   

            return adressen;
        }

        public void PetaPocoExecute(List<Adres> adressen)
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
                StraatId int,
                Huisnummer nvarchar(80),
                Appartementnummer nvarchar(80),
                Busnummer nvarchar(80),
                NISCode int,
                Postcode int,
                Status nvarchar(80)
            )";

            string adressenJSON = JsonSerializer.Serialize(adressen);

            int result = _database.Execute(query, new { adressen = adressenJSON });

            _database.Connection.Close();
        }



    }
}
