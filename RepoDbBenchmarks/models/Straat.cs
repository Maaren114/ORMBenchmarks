using RepoDb.Attributes;
using System;
using System.Collections.Generic;

namespace RepoDbBenchmarks;

[Map("Straten")]
public class Straat
{
    public int Id { get; set; }

    public int StraatId { get; set; }

    public int GemeenteId { get; set; }

    public string Straatnaam { get; set; } = null!;

    public virtual ICollection<Adres> Adressen { get; set; } = new List<Adres>();

    public virtual Gemeente Gemeente { get; set; } = null!;
}




