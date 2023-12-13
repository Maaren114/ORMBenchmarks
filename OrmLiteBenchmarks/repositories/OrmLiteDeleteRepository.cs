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
    public class OrmLiteDeleteRepository
    {
        private OrmLiteConnectionFactory _factory;

        public OrmLiteDeleteRepository()
        {
            _factory = new OrmLiteConnectionFactory(Toolkit.GetConnectionString(), SqlServerDialect.Provider);
        }

        public void OrmLiteExecuteNonQuery(List<AdresX> adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);

            using (var db = _factory.OpenDbConnection())
            {
                string query = $@"
                             DELETE FROM Adressen
                             WHERE AdresID IN (SELECT AdresID
                                               FROM OPENJSON(@adressen)
                                               WITH (AdresID int));";

                db.ExecuteNonQuery(query, new { adressen = adressenJSON });
            }
        }

        public void OrmLiteDeleteAll(List<AdresX> adressen)
        {
            using (var db = _factory.OpenDbConnection())
            {
                List<List<AdresX>> adressenbatches = SplitListIntoBatches<AdresX>(adressen, 2098);

                foreach (var adressenbatch in adressenbatches)
                {
                    db.DeleteAll(adressenbatch);
                }
            }
        }

        #region helper methods
        public List<List<T>> SplitListIntoBatches<T>(List<T> sourceList, int batchSize)
        {
            List<List<T>> batches = new List<List<T>>();

            for (int i = 0; i < sourceList.Count; i += batchSize)
            {
                List<T> batch = sourceList.Skip(i).Take(batchSize).ToList();
                batches.Add(batch);
            }

            return batches;
        }
        #endregion
    }
}
