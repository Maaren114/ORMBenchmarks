using NHibernate.Engine;
using System;
using System.Collections.Generic;

namespace NHibernateBenchmarks;

public class Straat
{
    public virtual int StraatId { get; set; }

    //public virtual int GemeenteId { get; set; }

    public virtual string Straatnaam { get; set; }
    public virtual Gemeente Gemeente { get; set; }
    public virtual ISet<Adres> Adressen { get; set; } = new HashSet<Adres>();

    public override string ToString()
    {
        return String.Format($"STRAAT UIT GEMEENTE {Gemeente.Gemeentenaam} (StraatId: {StraatId}, GemeenteId: {0}, Straatnaam: {Straatnaam})");
    }
}










