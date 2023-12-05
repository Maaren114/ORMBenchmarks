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
	     		                                   FROM OPENJSON(@niscodes));";

                var adressen = db.SqlList<AdresX>(query, new { niscodes = niscodesJSON });
                return adressen;
            }
        }

        public List<AdresX> Select(List<string> niscodes)
        {
            using (var db = _factory.OpenDbConnection())
            {
                List<AdresX> adressen = db.Select<AdresX>(a => niscodes.Contains(a.NISCode));
                return adressen;
            }
        }
    }
}




