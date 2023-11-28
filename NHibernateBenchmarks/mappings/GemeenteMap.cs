using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace NHibernateBenchmarks.mappings
{
    public class GemeenteMap : ClassMap<GemeenteX>
    {
        public GemeenteMap()
        {
            Table("Gemeentes");
            Id(x => x.GemeenteID);
            Map(x => x.Gemeentenaam);
            Map(x => x.ProvincieID, "ProvincieID");
            References(x => x.Provincie).Column("ProvincieId");
            HasMany(x => x.Straten);
        }
    }
}


