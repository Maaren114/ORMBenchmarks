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
    public class EFCoreCreateRepository
    {
        private StratenregisterContext _context;
        public EFCoreCreateRepository()
        {
            _context = new StratenregisterContext();
        }

        public List<AdresX> GetAdressen(string gemeentenaam)
        {
            List<AdresX> adressen = _context.Adressen.Where(adres => adres.Straat.Gemeente.Gemeentenaam == gemeentenaam).OrderBy(a => a.StraatID).Take(15557).ToList();
            //adressen.ForEach(a => a.AdresID = 0);
            return adressen;
        }

        public void EFBorisDjCreate(List<AdresX> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {
            _context.BulkInsert(adressen, options => options.BatchSize = 16000);
        }

        //public void AddRange(List<AdresX> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        //{
        //    _context.Adressen.AddRange(adressen);
        //    _context.SaveChanges();
        //}

        public void ExecuteSqlRaw(List<AdresX> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);

            string query = $@"
                            INSERT INTO Adressen
                            (
                                StraatID,
                                Huisnummer,
                                Appartementnummer,
                                Busnummer,
                                NISCode,
                                Postcode,
                                Status
                            )
                            SELECT StraatID, Huisnummer, Appartementnummer, Busnummer, NISCode, Postcode, Status
                            FROM OPENJSON(@adressenJSON)
                            WITH
                            (
                               StraatID int,
                               Huisnummer nvarchar(80),
                               Appartementnummer nvarchar(80),
                               Busnummer nvarchar(80),
                               NISCode int,
                               Postcode int,
                               Status nvarchar(80)
                            )";


            _context.Database.ExecuteSqlRaw(query, new SqlParameter("@adressenJSON", adressenJSON));
        }

        public void ExecuteSql(List<AdresX> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);

            FormattableString query = $@"
                            INSERT INTO Adressen
                            (
                                StraatID,
                                Huisnummer,
                                Appartementnummer,
                                Busnummer,
                                NISCode,
                                Postcode,
                                Status
                            )
                            SELECT StraatID, Huisnummer, Appartementnummer, Busnummer, NISCode, Postcode, Status
                            FROM OPENJSON({adressenJSON})
                            WITH
                            (
                               StraatID int,
                               Huisnummer nvarchar(80),
                               Appartementnummer nvarchar(80),
                               Busnummer nvarchar(80),
                               NISCode int,
                               Postcode int,
                               Status nvarchar(80)
                            )";

            _context.Database.ExecuteSql(query);
        }






    }
}
