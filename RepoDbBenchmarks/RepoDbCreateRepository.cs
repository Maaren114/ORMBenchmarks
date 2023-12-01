using Microsoft.Data.SqlClient;
using RepoDb;
using System;
using System.Data;
using System.Data.Common;
using Tools;

namespace RepoDbBenchmarks
{
    public class CreateRepoDbRepository
    {
        private SqlConnection _connection;
        public CreateRepoDbRepository()
        {
            GlobalConfiguration.Setup().UseSqlServer();

            _connection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public List<AdresX> GetAdressen(string gemeentenaam)
        {
            _connection.Open();

            string query = $@"
                            SELECT TOP 15557 a.AdresID, a.StraatID, a.Huisnummer, a.Postcode, a.Appartementnummer, a.Busnummer, a.NISCode, a.Status
                            FROM Adressen a
                            INNER JOIN Straten s ON a.StraatID = s.StraatID
                            INNER JOIN Gemeentes g ON g.GemeenteID = s.GemeenteID
                            WHERE g.Gemeentenaam = @Gemeentenaam
                            ORDER BY a.StraatID;";

            var adressen = _connection.ExecuteQuery<AdresX>(query, new { GemeenteNaam = "Zottegem" }).ToList();

            _connection.Close();

            return adressen;
        }

        public void InsertAll(List<AdresX> adressen)
        {
            _connection.Open();
            _connection.InsertAll<AdresX>(adressen);
            _connection.Close();
        }

        public void BulkInsert(List<AdresX> adressen)
        {
            _connection.Open();
            _connection.BulkInsert(adressen, batchSize: 16000);
            _connection.Close();
        }
    }
}
