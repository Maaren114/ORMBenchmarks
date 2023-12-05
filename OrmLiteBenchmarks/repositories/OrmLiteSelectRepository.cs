using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace OrmLiteBenchmarks.repositories
{
    public class OrmLiteSelectRepository
    {
        private OrmLiteConnectionFactory _factory;

        public OrmLiteSelectRepository()
        {
            _factory = new OrmLiteConnectionFactory(Toolkit.GetConnectionString(), SqlServerDialect.Provider);
        }

        public List<AdresX> SqlList(List<string> niscodes)
        {
            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            using (var db = _factory.OpenDbConnection())
            {
                string query = @"SELECT *
                         FROM Adressen
                         WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
                                           FROM OPENJSON(@niscodes))";

                var adressen = db.SqlList<AdresX>(query, new { niscodes = niscodesJSON });
                return adressen;
            }
        }

        public List<AdresX> Select(List<string> niscodes)
        {
            using (var db = _factory.OpenDbConnection())
            {
                List<AdresX> adressen = new List<AdresX>();
                List<List<string>> niscodebatches = SplitListIntoBatches(niscodes, 2098);

                foreach (var niscodebatch in niscodebatches)
                {
                    List<AdresX> adressenFromBatch = db.Select<AdresX>(a => niscodebatch.Contains(a.NISCode));
                    adressen.AddRange(adressenFromBatch);
                }
                return adressen;
            }
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
        #endregion
    }
}




