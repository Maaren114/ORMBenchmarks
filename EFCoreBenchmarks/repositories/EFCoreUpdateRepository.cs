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

        public void EFBorisDjUpdate(List<AdresX> updates)
        {
            _context.BulkUpdate(updates);
        }

        public void ExecuteSqlRaw(List<AdresX> updates)
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


        public void ExecuteSql(List<AdresX> updates)
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

        public void UpdateRange(List<AdresX> updates)
        {
            _context.Adressen.UpdateRange(updates);
            _context.SaveChanges();
        }
    }
}
