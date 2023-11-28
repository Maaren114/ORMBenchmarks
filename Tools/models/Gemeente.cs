using NHibernate.Engine;
using NHibernateBenchmarks.mappings;
using System;
using System.Collections.Generic;

namespace NHibernateBenchmarks;

public class Gemeente
{
    public virtual int GemeenteId { get; set; }

    public virtual string Gemeentenaam { get; set; } = null!;

    public virtual int? ProvincieId { get; set; }

    public virtual Provincie? Provincie { get; set; }

    public virtual ISet<Straat> Straten { get; set; } = new HashSet<Straat>();

    public override string ToString()
    {
        return String.Format($"GEMEENTE UIT PROVINCIE {Provincie.Provincienaam}, GemeenteId: {GemeenteId}, Gemeentenaam: {Gemeentenaam}, ProvincieId: {ProvincieId})");
    }
}


