using System;
using System.Collections.Generic;

namespace NHibernateBenchmarks;

public class Provincie
{
    public virtual int ProvincieId { get; set; }

    public virtual string? Provincienaam { get; set; }

    public virtual ISet<Gemeente> Gemeentes { get; set; } = new HashSet<Gemeente>();

    public override string ToString()
    {
        return String.Format($"(ProvincieId: {ProvincieId}, Provincienaam: {Provincienaam})");
    }
}



