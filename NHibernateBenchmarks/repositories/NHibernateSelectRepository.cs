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
                string hql = "FROM AdresX a WHERE a.NISCode IN (:niscodes)";
                List<AdresX> adressen = session.CreateQuery(hql)
                                               .SetParameterList("niscodes", niscodes)
                                               .List<AdresX>()
                                               .ToList();
                return adressen;
            }
        }

        public List<AdresX> QueryLinq(List<string> niscodes)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var adressen = session.Query<AdresX>()
                                      .Where(a => niscodes.Contains(a.NISCode))
                                      .ToList();
                return adressen;
            }
        }

        public List<AdresX> CreateCriteria(List<string> niscodes)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var criteria = session.CreateCriteria<AdresX>();
                criteria.Add(Restrictions.In("NISCode", niscodes.ToArray()));
                return criteria.List<AdresX>().ToList();
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
    }
}
