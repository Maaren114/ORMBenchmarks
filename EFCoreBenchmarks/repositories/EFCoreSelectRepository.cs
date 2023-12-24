using EFCoreBenchmarks.models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
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

        public List<AdresX> EFCoreWhere(List<string> niscodes)
        {
            List<AdresX> adressen = _context.Adressen.Where(a => niscodes.Contains(a.NISCode)).ToList();
            return adressen;
        }

        public List<AdresX> EFCoreFromSql(List<string> niscodes)
        {
            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            FormattableString query = $@"SELECT *
	                         FROM Adressen
		                     WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
	     		                               FROM OPENJSON({niscodesJSON}));";

            List<AdresX> adressen = _context.Adressen.FromSql(query).ToList();
            return adressen;
        }

        public List<AdresX> EFCoreFromSqlRaw(List<string> niscodes)
        {
            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            string query = @"SELECT *
	                         FROM Adressen
		                     WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
	     		                               FROM OPENJSON(@niscodes));";

            List<AdresX> adressen = _context.Adressen.FromSqlRaw(query, new SqlParameter("@niscodes", niscodesJSON)).ToList();
            return adressen;
        }

        #region Helper methods
        public List<StraatX> SelectStraten(int amount)
        {
            return _context.Straten.Where(s => s.Gemeente.Provincie.Provincienaam == "Oost-Vlaanderen").Take(amount).ToList();
        }

        public List<string> GetNISCodes(int amount)
        {
            return _context.Adressen.Map(a => a.NISCode).Take(amount).ToList();
        }

        public AdresX GetAdres(int adresID)
        {
            var adres = _context.Adressen.FirstOrDefault(a => a.AdresID == adresID);
            return adres;
        }

        public AdresX GetAdresAdoNet(int adresID)
        {
            using (SqlConnection connection = new SqlConnection(Toolkit.GetConnectionString()))
            {
                connection.Open();

                string query = "SELECT * FROM Adressen WHERE AdresID = @AdresID";
                using (SqlCommand commando = new SqlCommand(query, connection))
                {
                    commando.Parameters.Add(new SqlParameter("@AdresID", adresID));

                    using (SqlDataReader reader = commando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            AdresX adres = new AdresX
                            {
                                AdresID = (int)reader["AdresID"],
                                StraatID = (int)reader["StraatID"],
                                Huisnummer = (string)reader["Huisnummer"],
                                Appartementnummer = (string)reader["Appartementnummer"],
                                Busnummer = (string)reader["Busnummer"],
                                Status = (string)reader["Status"],
                                NISCode = (string)reader["NISCode"],
                                Postcode = (int)reader["Postcode"]
                            };

                            return adres;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        #endregion
    }
}

