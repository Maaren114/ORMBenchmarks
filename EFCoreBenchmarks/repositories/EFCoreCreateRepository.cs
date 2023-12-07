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
using ServiceStack;
using Microsoft.EntityFrameworkCore.Storage;

namespace EFCoreBenchmarks.repositories
{
    public class EFCoreCreateRepository
    {
        private StratenregisterContext _context;
        public EFCoreCreateRepository()
        {
            _context = new StratenregisterContext();
        }

        public void Test()
        {
            StraatX straat = _context.Straten.First(s => s.Straatnaam == "Boomsesteenweg");
            straat.Straatnaam = "CHANGED!";
            _context.SaveChanges();
        }

        public List<string> GetNISCodes(int amount)
        {
            return _context.Adressen.Map(a => a.NISCode).Take(amount).ToList();
        }

        public async void TestMethode(List<string> niscodes)
        {
            IExecutionStrategy strategie = _context.Database.CreateExecutionStrategy();

            await strategie.ExecuteAsync(async delegate
            {
                using var transactie = _context.Database.BeginTransaction();

                ProvincieX oostVlaanderen = new ProvincieX { Provincienaam = "Voorbeeldprovincie" };
                _context.Provincies.Add(oostVlaanderen);

                GemeenteX zottegem = new GemeenteX { Gemeentenaam = "Zottegem", Provincie = oostVlaanderen };
                _context.Gemeentes.Add(zottegem);

                transactie.Commit();
            });
        }

        public void Klassieke1per1Methode(List<AdresX> adressen)
        {
            foreach (var adres in adressen)
            {
                _context.Adressen.Add(adres);
            }
            _context.SaveChanges();
        }

        public List<AdresX> GetAdressen(string gemeentenaam, int aantal)
        {
            List<AdresX> adressen = _context.Adressen.Where(adres => adres.Straat.Gemeente.Gemeentenaam == gemeentenaam).OrderBy(a => a.StraatID).Take(aantal).AsNoTracking().ToList();
            return adressen;
        }

        public void EFBorisDjCreate(List<AdresX> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {
            _context.BulkInsert(adressen, options => options.BatchSize = 16000);
        }

        public void AddRange(List<AdresX> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {
            _context.Adressen.AddRange(adressen);
            _context.SaveChanges();
        }

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
                            SELECT *
                            FROM OPENJSON(@adressenJSON)
                            WITH
                            (
                               StraatID int,
                               Huisnummer nvarchar(80),
                               Appartementnummer nvarchar(80),
                               Busnummer nvarchar(80),
                               NISCode nvarchar(80),
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
                               NISCode nvarchar(80),
                               Postcode int,
                               Status nvarchar(80)
                            )";

            _context.Database.ExecuteSql(query);
        }






    }
}
