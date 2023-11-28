using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace NHibernateBenchmarks.mappings
{
    public class StraatMap : ClassMap<StraatX>
    {
        public StraatMap()
        {
            Table("Straten");
            Id(x => x.StraatID).GeneratedBy.Native();
            //Id(x => x.StraatId).Generated.Always();
            //Map(x => x.GemeenteId, "GemeenteID");
            Map(x => x.Straatnaam);
            References(x => x.Gemeente).Column("GemeenteId").Not.Insert();
            HasMany(x => x.Adressen);
        }
    }
}
