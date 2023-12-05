using EFCoreBenchmarks.models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace EFCoreBenchmarks.repositories
{
    public class EFCoreSelectRepository
    {
        private StratenregisterContext _context;
        public EFCoreSelectRepository()
        {
            _context = new StratenregisterContext();
        }

        public List<AdresX> EFCoreSelect(List<string> niscodes)
        {
            List<AdresX> adressen = _context.Adressen.Where(a => niscodes.Contains(a.NISCode)).ToList();
            return adressen;
        }

        public List<AdresX> FromSql(List<string> niscodes)
        {
            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            FormattableString query = $@"SELECT *
	                         FROM Adressen
		                     WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
	     		                               FROM OPENJSON({niscodesJSON}));";

            List<AdresX> adressen = _context.Adressen.FromSql(query).ToList();
            return adressen;
        }

        public List<AdresX> FromSqlRaw(List<string> niscodes)
        {
            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            string query = @"SELECT *
	                         FROM Adressen
		                     WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
	     		                               FROM OPENJSON(@niscodes));";

            List<AdresX> adressen = _context.Adressen.FromSqlRaw(query, new SqlParameter("@niscodes", niscodesJSON)).ToList();
            return adressen;
        }
    }
}

