using System;
using System.Collections.Generic;

namespace ZZZProjectsBenchmarks.models;

public partial class Straat
{
    public int StraatId { get; set; }

    public int GemeenteId { get; set; }

    public string Straatnaam { get; set; } = null!;

    public virtual ICollection<Adres> Adressen { get; set; } = new List<Adres>();

    public virtual Gemeente Gemeente { get; set; } = null!;
}
