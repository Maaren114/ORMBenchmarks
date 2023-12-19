using NHibernate.Criterion;
using NHibernateBenchmarks.mappings;
using System.Text.Json;
using Tools;

namespace NHibernateBenchmarks.repositories
{
    public class NHibernateSelectRepository
    {
        private NHibernate.ISessionFactory _sessionFactory;

        public NHibernateSelectRepository()
        {
            _sessionFactory = NHibernateHelper.ConfigureNHibernate();
        }

        public List<AdresX> NHibernate_CreateQuery_Hql(List<string> niscodes)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                List<AdresX> adressen = new List<AdresX>();

                List<List<string>> niscodebatches = SplitListIntoBatches(niscodes, 2098); // 2098 gaat nog, 2099 niet! (teveel parameters)

                foreach (var niscodebatch in niscodebatches)
                {
                    string hql = "FROM AdresX a WHERE a.NISCode IN (:niscodes)";
                    List<AdresX> adressenFrombatch = session.CreateQuery(hql)
                                                   .SetParameterList("niscodes", niscodebatch)
                                                   .List<AdresX>()
                                                   .ToList();

                    adressen.AddRange(adressenFrombatch);
                }
                return adressen;
            }
        }

        public List<AdresX> NHibernate_Query_Linq(List<string> niscodes)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                List<AdresX> adressen = new List<AdresX>();

                List<List<string>> niscodebatches = SplitListIntoBatches(niscodes, 2098); // 2098 gaat nog, 2099 niet! (teveel parameters)

                foreach (var niscodebatch in niscodebatches)
                {
                    var adressenFrombatch = session.Query<AdresX>()
                                                   .Where(a => niscodebatch.Contains(a.NISCode))
                                                   .ToList();

                    adressen.AddRange(adressenFrombatch);
                }
                return adressen;
            }
        }

        public List<AdresX> NHibernate_CreateCriteria(List<string> niscodes)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                List<AdresX> adressen = new List<AdresX>();
                List<List<string>> niscodebatches = SplitListIntoBatches(niscodes, 2098); // 2098 gaat nog, 2099 niet! (teveel parameters)

                foreach (var niscodebatch in niscodebatches)
                {
                    var criteria = session.CreateCriteria<AdresX>();
                    criteria.Add(Restrictions.In("NISCode", niscodebatch.ToArray()));
                    List<AdresX> adressenFromBatch = criteria.List<AdresX>().ToList();
                    adressen.AddRange(adressenFromBatch);
                }
                return adressen;
            }
        }

        public List<AdresX> NHibernateCreateSqlQuery(List<string> niscodes)
        {
            string query = @"SELECT *
	                         FROM Adressen
		                     WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
	     		                               FROM OPENJSON(:niscodes));";


            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            using (var statelessSession = _sessionFactory.OpenStatelessSession())
            {
                List<AdresX> adressen = statelessSession.CreateSQLQuery(query)
                                                        .AddEntity(typeof(AdresX))
                                                        .SetParameter("niscodes", niscodesJSON)
                                                        .List<AdresX>()
                                                        .ToList();
                return adressen;
            }
        }


        #region helper methods
        public List<AdresX> GetAdressen(string gemeentenaam)
        {
            using (var session = _sessionFactory.OpenStatelessSession())
            {
                var adressen = session.Query<AdresX>()
                    .Where(a => a.Straat.Gemeente.Gemeentenaam == gemeentenaam)
                    .Select(a => new AdresX
                    {
                        AdresID = a.AdresID,
                        StraatID = a.Straat.StraatID,
                        Huisnummer = a.Huisnummer,
                        Appartementnummer = a.Appartementnummer,
                        Busnummer = a.Busnummer,
                        NISCode = a.NISCode,
                        Postcode = a.Postcode,
                        Status = a.Status
                    })
                    .Take(15000)
                    .ToList();
                return adressen;
            }
        }

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
        #endregion
    }
}
