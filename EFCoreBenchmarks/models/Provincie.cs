using System;
using System.Collections.Generic;

namespace EFCoreBenchmarks.models;

public partial class Provincie
{
    public int ProvincieId { get; set; }

    public string? Provincienaam { get; set; }

    public virtual ICollection<Gemeente> Gemeentes { get; set; } = new List<Gemeente>();
}
