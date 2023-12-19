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

        public void EFCoreRemove(List<AdresX> deletes)
        {
            foreach (var adres in deletes)
            {
                _context.Adressen.Remove(adres);
            }
            _context.SaveChanges();
        }

        public void EFCoreRemoveRange(List<AdresX> deletes)
        {
            _context.Adressen.RemoveRange(deletes);
            _context.SaveChanges();
        }

        public void EFCoreBulkDelete_BorisDj(List<AdresX> adressen)
        {
            _context.BulkDelete(adressen, options => options.BatchSize = 15000);
        }

        public void ExecuteSqlRaw(List<AdresX> adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);

            string query = $@"
                             DELETE FROM Adressen
                             WHERE AdresID IN (SELECT AdresID
                                               FROM OPENJSON(@adressenJSON)
                                               WITH (AdresID int));";


            _context.Database.ExecuteSqlRaw(query, new SqlParameter("@adressenJSON", adressenJSON));
        }

        public void EFCoreExecuteSql(List<AdresX> adressen)
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
