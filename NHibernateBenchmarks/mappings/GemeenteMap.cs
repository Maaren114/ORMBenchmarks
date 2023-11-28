using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateBenchmarks.mappings
{
    public class GemeenteMap : ClassMap<Gemeente>
    {
        public GemeenteMap()
        {
            Table("Gemeentes");
            Id(x => x.GemeenteId);
            Map(x => x.Gemeentenaam);
            Map(x => x.ProvincieId, "ProvincieID");
            References(x => x.Provincie).Column("ProvincieId");
            HasMany(x => x.Straten);
        }
    }
}


