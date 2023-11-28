using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernateBenchmarks.mappings;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;

namespace NHibernateBenchmarks.mappings
{
    public class NHibernateHelper
    {
        public static ISessionFactory ConfigureNHibernate()
        {
            return Fluently.Configure()
                .ExposeConfiguration(cfg => cfg.SetProperty("adonet.batch_size", "16000"))
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=DESKTOP-PK0VPN9;Initial Catalog=Stratenregister;Integrated Security=True; TrustServerCertificate=True;"))
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<AdresMap>();
                    m.FluentMappings.AddFromAssemblyOf<StraatMap>();
                    m.FluentMappings.AddFromAssemblyOf<GemeenteMap>();
                    m.FluentMappings.AddFromAssemblyOf<ProvincieMap>();
                })
                .BuildSessionFactory();
        }
    }
}
