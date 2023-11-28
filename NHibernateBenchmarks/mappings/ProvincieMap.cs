using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateBenchmarks.mappings
{
    public class ProvincieMap : ClassMap<Provincie>
    {
        public ProvincieMap()
        {
            Table("Provincies");
            Id(x => x.ProvincieId);
            Map(x => x.Provincienaam);
            HasMany(x => x.Gemeentes);
        }
    }
}
