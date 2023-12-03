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

        public void ExecuteDeleteRaw(List<AdresX> adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);

            using (var db = _factory.OpenDbConnection())
            {
                string query = $@"
                             DELETE FROM Adressen
                             WHERE AdresID IN (SELECT AdresID
                                               FROM OPENJSON(@adressen)
                                               WITH (AdresID int));";

                db.ExecuteSql(query, new { adressen = adressenJSON });
            }
        }









    }
}
