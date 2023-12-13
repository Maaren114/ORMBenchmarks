using RepoDb;
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

        public List<AdresX> OrmLiteSqlList(List<string> niscodes)
        {
            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            using (var db = _factory.OpenDbConnection())
            {
                string query = @"SELECT *
                         FROM Adressen
                         WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
                                           FROM OPENJSON(@niscodes))";

                var adressen = db.SqlList<AdresX>(query, new { niscodes = niscodesJSON });
                return adressen;
            }
        }

        public List<AdresX> OrmLiteSelect(List<string> niscodes)
        {
            using (var db = _factory.OpenDbConnection())
            {
                List<AdresX> adressen = new List<AdresX>();
                List<List<string>> niscodebatches = SplitListIntoBatches(niscodes, 2098);

                foreach (var niscodebatch in niscodebatches)
                {
                    List<AdresX> adressenFromBatch = db.Select<AdresX>(a => niscodebatch.Contains(a.NISCode));
                    adressen.AddRange(adressenFromBatch);
                }
                return adressen;
            }
        }

        #region helper methods
        public List<List<string>> SplitListIntoBatches(List<string> sourceList, int batchSize)
        {
            List<List<string>> batches = new List<List<string>>();

            for (int i = 0; i < sourceList.Count; i += batchSize)
            {
                List<string> batch = sourceList.Skip(i).Take(batchSize).ToList();
                batches.Add(batch);
            }

            return batches;
        }

        public List<StraatX> GetStraten(int aantal)
        {
            var db = _factory.OpenDbConnection();

            var straten = db.Select(
                                     db.From<StraatX>()
                                       .Join<StraatX, GemeenteX>((s, g) => s.GemeenteID == g.GemeenteID)
                                       .Join<GemeenteX, ProvincieX>((g, p) => g.ProvincieID == p.ProvincieID)
                                       .Where<ProvincieX>(p => p.Provincienaam == "Oost-Vlaanderen")
                                       .OrderBy(s => s.StraatID)
                                       .Limit(aantal));

            return straten;
        }

        public List<string> GetNisCodes(int aantal)
        {
            var db = _factory.OpenDbConnection();
            var niscodes = db.Select(db.From<AdresX>().Limit(aantal)).Select(a => a.NISCode).ToList();
            return niscodes;
        }

        public List<AdresX> GetAdressen(string gemeentenaam)
        {
            var db = _factory.OpenDbConnection();

            var adressenInZottegem = db.Select(
                                     db.From<AdresX>()
                                       .Join<AdresX, StraatX>((a, s) => a.StraatID == s.StraatID)
                                       .Join<StraatX, GemeenteX>((s, g) => s.GemeenteID == g.GemeenteID)
                                       .Join<GemeenteX, ProvincieX>((g, p) => g.ProvincieID == p.ProvincieID)
                                       .Where<GemeenteX>(g => g.Gemeentenaam == gemeentenaam)
                                       .OrderBy(s => s.StraatID)
                                       .Limit(15000));


            // Eager loading (beperkt tot 1 niveau diep?)
            //var adressenInZottegem = db.LoadSelect<Adres>(
            //                         db.From<Adres>()
            //                        .Join<Adres, Straat>((a, s) => a.StraatId == s.StraatId)
            //                        .Join<Straat, Gemeente>((s, g) => s.GemeenteId == g.GemeenteId)
            //                        .Join<Gemeente, Provincie>((g, p) => g.ProvincieId == p.ProvincieID)
            //                        .Where<Gemeente>(g => g.Gemeentenaam == "Zottegem"));

            db.Dispose();
            return adressenInZottegem;
        }
        #endregion
    }
}




