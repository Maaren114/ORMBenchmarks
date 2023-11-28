using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateBenchmarks.mappings
{
    public class AdresMap : ClassMap<Adres>
    {
        public AdresMap()
        {
            Table("Adressen");
            Id(x => x.AdresId);
            Map(x => x.Huisnummer);
            //Map(x => x.StraatId, "StraatID");
            Map(x => x.Appartementnummer);
            Map(x => x.Busnummer);
            Map(x => x.Status);
            Map(x => x.NISCode);
            //References(x => x.Straat).Column("StraatId");
            References(x => x.Straat, "StraatId");
        }
    }
}
