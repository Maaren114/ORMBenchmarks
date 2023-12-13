using Microsoft.Data.SqlClient;
using RepoDb;
using RepoDb.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace RepoDbBenchmarks.repositories
{
    public class RepoDbSelectRepository
    {
        private SqlConnection _connection;
        public RepoDbSelectRepository()
        {
            GlobalConfiguration.Setup().UseSqlServer();
            _connection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public List<AdresX> RepoDbQuery(List<string> niscodes)
        {
            _connection.Open();
            List<AdresX> adressen = new List<AdresX>();
            List<List<string>> niscodebatches = SplitListIntoBatches(niscodes, 2098);

            foreach (var niscodebatch in niscodebatches)
            {
                List<AdresX> adressenFromBatch = _connection.Query<AdresX>(a => niscodebatch.Contains(a.NISCode)).ToList();
                adressen.AddRange(adressenFromBatch);
            }

            _connection.Close();
            return adressen;
        }

        public List<AdresX> RepoDbBatchQuery(List<string> niscodes)
        {
            _connection.Open();
            List<AdresX> adressen = new List<AdresX>();
            List<List<string>> niscodebatches = SplitListIntoBatches(niscodes, 2098);

            foreach (var niscodebatch in niscodebatches)
            {
                var orderBy = OrderField.Parse(new { AdresID = Order.Descending });
                var page = 0;
                var rowsPerBatch = 2100;
                var adressenFromBatch = _connection.BatchQuery<AdresX>(page: page,
                    rowsPerBatch: rowsPerBatch,
                    orderBy: orderBy,
                    where: a => niscodebatch.Contains(a.NISCode)).ToList();
                adressen.AddRange(adressenFromBatch);
            }
            _connection.Close();
            return adressen;
        }

        public List<AdresX> RepoDbExecuteQuery(List<string> niscodes)
        {
            _connection.Open();

            string query = @"SELECT *
	                             FROM Adressen
		                         WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
	     		                                   FROM OPENJSON(@Niscodes));";

            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            var adressen = _connection.ExecuteQuery<AdresX>(query, new { Niscodes = niscodesJSON }).ToList();

            _connection.Close();

            return adressen;
        }

        #region helper methods
        public List<List<string>> SplitListIntoBatches(List<string> sourceList, int batchSize)
        {
            List<List<string>> batches = new List<List<string>>();

            for (int i = 0; i < sourceList.Count; i += batchSize)
            {
                List<string> batch = sourceList.Skip(i).Take(batchSize).ToList();
                batches.Add(batch);
            }

            return batches;
        }

        public List<string> GetNisCodes(int amount) // nog niet opgenomen in thesis!
        {
            _connection.Open();
            List<string> niscodes = _connection.QueryAll<AdresX>().Select(a => a.NISCode).Take(amount).ToList();
            _connection.Close();
            return niscodes;
        }

        public List<AdresX> GetAdressen(string gemeentenaam)
        {
            _connection.Open();

            string query = $@"
                            SELECT TOP 20000 a.AdresID, a.StraatID, a.Huisnummer, a.Postcode, a.Appartementnummer, a.Busnummer, a.NISCode, a.Status
                            FROM Adressen a
                            INNER JOIN Straten s ON a.StraatID = s.StraatID
                            INNER JOIN Gemeentes g ON g.GemeenteID = s.GemeenteID
                            WHERE g.Gemeentenaam = @Gemeentenaam
                            ORDER BY a.StraatID;";

            var adressen = _connection.ExecuteQuery<AdresX>(query, new { GemeenteNaam = gemeentenaam }).ToList();

            _connection.Close();

            return adressen;
        }

        public List<StraatX> GetStraten(string provincienaam, int aantal)
        {
            _connection.Open();
            string query = @"SELECT TOP " + aantal + @" s.* FROM Straten s
                             INNER JOIN Gemeentes g ON g.GemeenteID = s.GemeenteID
                             INNER JOIN Provincies p ON p.ProvincieID = g.ProvincieID
                             WHERE p.Provincienaam = @Provincienaam;";

            var straten = _connection.ExecuteQuery<StraatX>(query, new { Provincienaam = provincienaam }).ToList();
            _connection.Close();
            return straten;
        }
        #endregion

    }
}






