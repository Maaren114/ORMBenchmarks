using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace OrmLiteBenchmarks.models;

[Alias("Provincies")]
public class Provincie
{
    public int ProvincieID { get; set; }

    public string Provincienaam { get; set; }

    [Reference]
    public virtual List<Gemeente> Gemeentes { get; set; } = new List<Gemeente>();
}

