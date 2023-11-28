using System;
using System.Collections.Generic;

namespace Norm.NetBenchmarks.models;


public class Gemeente
{
    public int Id { get; set; }

    public int GemeenteId { get; set; }

    public string Gemeentenaam { get; set; } = null!;
    public int? ProvincieId { get; set; }
    public virtual Provincie? Provincie { get; set; }
    public virtual List<Straat> Straten { get; set; } = new List<Straat>();
}
