using System;
using System.Collections.Generic;

namespace ZZZProjectsBenchmarks.models;

public partial class Gemeente
{
    public int GemeenteId { get; set; }

    public string Gemeentenaam { get; set; } = null!;

    public int? ProvincieId { get; set; }

    public virtual Provincie? Provincie { get; set; }

    public virtual ICollection<Straat> Straten { get; set; } = new List<Straat>();
}
