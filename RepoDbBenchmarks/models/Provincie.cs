using RepoDb.Attributes;
using System;
using System.Collections.Generic;

namespace RepoDbBenchmarks;

[Map("Provincies")]
public class Provincie
{
    public int ProvincieId { get; set; }

    public string? Provincienaam { get; set; }

    public virtual List<Gemeente> Gemeentes { get; set; } = new List<Gemeente>();
}

