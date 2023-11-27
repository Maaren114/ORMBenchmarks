using EFCore.BulkExtensions;
using EFCoreBenchmarks.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EFCoreBenchmarks
{
    public class EFCoreRepository
    {
        private StratenregisterContext _context;
        public EFCoreRepository()
        {
            _context = new StratenregisterContext();
        }

        public List<Adres> GetAdressen(string gemeentenaam)
        {
            List<Adres> adressen = _context.Adressen.Where(adres => adres.Straat.Gemeente.Gemeentenaam == gemeentenaam).Take(15557).ToList();
            return adressen;
        }

        public void EFBorisDjCreate(List<Adres> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {
            _context.BulkInsert(adressen, options => options.BatchSize = 16000);
        }

        public void Create2(List<Adres> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {
            _context.Adressen.AddRange(adressen);
        }

        public void Create3(List<Adres> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);


            string query = @"
                            INSERT INTO Straten
                            (
                                StraatID,
                                GemeenteID,
                                Straatnaam
                            )
                            SELECT StraatID, GemeenteID, Straatnaam
                            FROM OPENJSON(@adressen) WITH
                            (
                                StraatID int, 
                                GemeenteID int, 
                                Straatnaam nvarchar(80)
                            );";

            _context.Database.ExecuteSqlRaw(query, new SqlParameter("@adressen", adressenJSON));
        }

        public void Create4(List<Adres> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);

            string query = @"
                INSERT INTO Straten
                (
                    StraatID,
                    GemeenteID,
                    Straatnaam
                )
                SELECT StraatID, GemeenteID, Straatnaam
                FROM OPENJSON(@adressen) WITH
                (
                    StraatID int, 
                    GemeenteID int, 
                    Straatnaam nvarchar(80)
                );";

            _context.Database.ExecuteSqlRaw(query, new SqlParameter("@adressen", adressenJSON));
        }

        public void Create5(List<Adres> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {
            string adressenJSON = JsonSerializer.Serialize(adressen);

            FormattableString query = $@"
                                        INSERT INTO Straten
                                        (
                                            StraatID,
                                            GemeenteID,
                                            Straatnaam
                                        )
                                        SELECT StraatID, GemeenteID, Straatnaam
                                        FROM OPENJSON({adressenJSON}) WITH
                                        (
                                            StraatID int, 
                                            GemeenteID int, 
                                            Straatnaam nvarchar(80)
                                        );";

            _context.Database.ExecuteSql(query);
        }














    }
}
