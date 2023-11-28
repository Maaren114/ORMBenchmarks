using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace NHibernateBenchmarks.mappings
{
    public class ProvincieMap : ClassMap<ProvincieX>
    {
        public ProvincieMap()
        {
            Table("Provincies");
            Id(x => x.ProvincieID);
            Map(x => x.Provincienaam);
            HasMany(x => x.Gemeentes);
        }
    }
}
