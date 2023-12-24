using EFCore.BulkExtensions;
using EFCoreBenchmarks.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;
using Microsoft.Data.SqlClient;

namespace EFCoreBenchmarks.repositories
{
    public class EFCoreUpdateRepository
    {
        private StratenregisterContext _context;
        public EFCoreUpdateRepository()
        {
            _context = new StratenregisterContext();
        }

        public void EFCoreUpdate(List<AdresX> adressen)
        {
            foreach (AdresX adres in adressen)
            {
                _context.Adressen.Update(adres);
            }
            _context.SaveChanges();
        }

        public void EFCoreUpdateRange(List<AdresX> updates)
        {
            _context.Adressen.UpdateRange(updates);
            _context.SaveChanges();
        }

        public void EFCoreBulkUpdate_BorisDj(List<AdresX> updates)
        {
            _context.BulkUpdate(updates, options => options.BatchSize = 15000);
        }

        public void EFCoreExecuteSqlRaw(List<AdresX> updates)
        {
            string updatesJSON = JsonSerializer.Serialize(updates);

            string query = $@"
                            UPDATE adr
                            SET
	                            adr.StraatID = adru.StraatID,
	                            adr.Huisnummer = adru.Huisnummer,
	                            adr.Appartementnummer = adru.Appartementnummer,
	                            adr.Busnummer = adru.Busnummer,
	                            adr.Postcode = adru.Postcode,
	                            adr.Status = adru.Status,
                                adr.NISCode = adru.NISCode
                            FROM Adressen adr
                            INNER JOIN OPENJSON(@updates) WITH
                            (
	                            AdresID int,
	                            StraatID int,
	                            Huisnummer nvarchar(80),
	                            Appartementnummer nvarchar(80),
	                            Busnummer nvarchar(80),
	                            Postcode int,
                                NISCode nvarchar(80),
	                            Status nvarchar(80)
                            ) adru
                            ON adr.AdresID = adru.AdresID;";

            _context.Database.ExecuteSqlRaw(query, new SqlParameter("@updates", updatesJSON));
        }

        public void EFCoreExecuteSql(List<AdresX> updates)
        {
            string updatesJSON = JsonSerializer.Serialize(updates);

            FormattableString query = $@"
                            UPDATE adr
                            SET
	                            adr.StraatID = adru.StraatID,
	                            adr.Huisnummer = adru.Huisnummer,
	                            adr.Appartementnummer = adru.Appartementnummer,
	                            adr.Busnummer = adru.Busnummer,
	                            adr.Postcode = adru.Postcode,
	                            adr.Status = adru.Status,
                                adr.NISCode = adru.NISCode
                            FROM Adressen adr
                            INNER JOIN OPENJSON({updatesJSON}) WITH
                            (
	                            AdresID int,
	                            StraatID int,
	                            Huisnummer nvarchar(80),
	                            Appartementnummer nvarchar(80),
	                            Busnummer nvarchar(80),
	                            Postcode int,
                                NISCode nvarchar(80),
	                            Status nvarchar(80)
                            ) adru
                            ON adr.AdresID = adru.AdresID;";

            _context.Database.ExecuteSql(query);
        }

        #region helper methods
        public List<AdresX> GetAdressen()
        {
            string query = $@"
                            SELECT TOP 15000 *
                            FROM Adressen a;";

            List<AdresX> adressen = _context.Adressen.FromSqlRaw(query).ToList();
            return adressen;
        }

        public List<StraatX> GetStraten()
        {
            string query = $@"
                            SELECT TOP 15000 *
                            FROM Straten s;";

            List<StraatX> straten = _context.Straten.FromSqlRaw(query).ToList();
            return straten;
        }

        public void EFCoreUpdateRangeStraten(List<StraatX> updates)
        {
            _context.Straten.UpdateRange(updates);
            _context.SaveChanges();
        }
        #endregion
    }
}











