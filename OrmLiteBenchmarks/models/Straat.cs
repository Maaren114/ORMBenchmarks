using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace OrmLiteBenchmarks.models;

[Alias("Straten")]
public class Straat
{
    public int StraatId { get; set; }

    public int GemeenteId { get; set; }

    public string Straatnaam { get; set; } = null!;

    [Reference]
    public virtual ICollection<Adres> Adressen { get; set; } = new List<Adres>();

    [Reference]
    public virtual Gemeente Gemeente { get; set; } = null!;
}




