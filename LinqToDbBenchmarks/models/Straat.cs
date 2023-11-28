using LinqToDB.Mapping;
using System;
using System.Collections.Generic;

namespace LinqToDbBenchmarks.models;

[Table("Straten")]
public class Straat
{
    [PrimaryKey, Identity]
    [Column(Name = "StraatID")]
    public int StraatID { get; set; }

    [Column(Name = "GemeenteID")]
    public int GemeenteID { get; set; }

    public string Straatnaam { get; set; } = null!;

    public virtual ICollection<Adres> Adressen { get; set; } = new List<Adres>();

    public virtual Gemeente Gemeente { get; set; } = null!;
}


