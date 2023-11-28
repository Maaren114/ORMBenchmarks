using System;
using System.Collections.Generic;

namespace Norm.NetBenchmarks.models;

public class Provincie
{
    public int ProvincieID { get; set; }

    public string Provincienaam { get; set; }
    public virtual List<Gemeente> Gemeentes { get; set; } = new List<Gemeente>();
}

