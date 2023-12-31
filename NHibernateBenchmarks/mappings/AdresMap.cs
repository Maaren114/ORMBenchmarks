﻿using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace NHibernateBenchmarks.mappings
{
    public class AdresMap : ClassMap<AdresX>
    {
        public AdresMap()
        {
            Table("Adressen");
            Id(x => x.AdresID);
            Map(x => x.Huisnummer);
            Map(x => x.Appartementnummer);
            Map(x => x.Busnummer);
            Map(x => x.Status);
            Map(x => x.NISCode);
            Map(x => x.Postcode);
            Map(x => x.StraatID).Column("StraatID");
            //References(x => x.Straat, "StraatID");
        }
    }
}
