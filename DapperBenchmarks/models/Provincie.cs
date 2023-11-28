using System;
using System.Collections.Generic;

namespace DapperBenchmarks.models;

public class Provincie
{
    public int ProvincieId { get; set; }

    public string? Provincienaam { get; set; }

    public virtual List<Gemeente> Gemeentes { get; set; } = new List<Gemeente>();
}

