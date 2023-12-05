using NHibernate;
using NHibernate.Criterion;
using NHibernateBenchmarks.mappings;
using ServiceStack.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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

        public List<AdresX> CreateQueryHql(List<string> niscodes)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                List<AdresX> adressen = new List<AdresX>();

                List<List<string>> niscodebatches = SplitListIntoBatches(niscodes, 2098);

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


        public List<AdresX> QueryLinq(List<string> niscodes)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                List<AdresX> adressen = new List<AdresX>();

                List<List<string>> niscodebatches = SplitListIntoBatches(niscodes, 2098);

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

        public List<AdresX> CreateCriteria(List<string> niscodes)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                List<AdresX> adressen = new List<AdresX>();
                List<List<string>> niscodebatches = SplitListIntoBatches(niscodes, 2098);

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

        public List<AdresX> RawSql(List<string> niscodes) // werkt! dit is batch
        {
            string query = @"SELECT *
	                         FROM Adressen
		                     WHERE NIScode IN (SELECT CONVERT(nvarchar(80), value)
	     		                               FROM OPENJSON(:niscodes));";


            string niscodesJSON = JsonSerializer.Serialize(niscodes);

            using (var statelessSession = _sessionFactory.OpenStatelessSession())
            using (var transaction = statelessSession.BeginTransaction())
            {
                List<AdresX> adressen = statelessSession.CreateSQLQuery(query).AddEntity(typeof(AdresX)).SetParameter("niscodes", niscodesJSON).List<AdresX>().ToList();
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
        #endregion
    }
}
