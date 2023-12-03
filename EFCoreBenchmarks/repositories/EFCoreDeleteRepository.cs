using EFCore.BulkExtensions;
using EFCoreBenchmarks.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;

namespace EFCoreBenchmarks.repositories
{
    public class EFCoreDeleteRepository
    {
        private StratenregisterContext _context;
        public EFCoreDeleteRepository()
        {
            _context = new StratenregisterContext();
        }
        public void EFBorisDjDelete(List<AdresX> adressen)
        {
            _context.BulkDelete(adressen, options => options.BatchSize = 16000);
        }

        public void RemoveRange(List<AdresX> deletes)
        {
            _context.Adressen.RemoveRange(deletes);
        }

        public void ExecuteSqlRaw(List<AdresX> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);

            string query = $@"
                             DELETE FROM Adressen
                             WHERE AdresID IN (SELECT AdresID
                                               FROM OPENJSON(@adressenJSON)
                                               WITH (AdresID int));";


            _context.Database.ExecuteSqlRaw(query, new SqlParameter("@adressenJSON", adressenJSON));
        }

        public void ExecuteSql(List<AdresX> adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);

            FormattableString query = $@"
                             DELETE FROM Adressen
                             WHERE AdresID IN (SELECT AdresID
                                               FROM OPENJSON({adressenJSON})
                                               WITH (AdresID int));";

            _context.Database.ExecuteSql(query);
        }
    }
}
