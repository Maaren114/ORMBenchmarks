using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Configuration;
using LinqToDB;
using Tools;

namespace LinqToDbBenchmarks.models
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }

    public class MySettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders
            => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "SqlServer";
        public string DefaultDataProvider => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "Stratenregister",
                        ProviderName = ProviderName.SqlServer,
                        ConnectionString = Toolkit.GetConnectionString()
                    };
            }
        }
    }
}
