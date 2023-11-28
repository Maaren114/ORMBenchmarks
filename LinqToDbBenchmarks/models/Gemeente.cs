using LinqToDB.Mapping;
using System;
using System.Collections.Generic;

namespace LinqToDbBenchmarks.models;

[Table("Gemeentes")]
public class Gemeente
{
    [Column("GemeenteID"), NotNull]
    [PrimaryKey, Identity]
    public int GemeenteID { get; set; }

    [Column("Gemeentenaam"), NotNull]
    public string Gemeentenaam { get; set; } = null!;

    [Column("ProvincieID"), NotNull]
    public int? ProvincieID { get; set; }

    public virtual Provincie? Provincie { get; set; }

    public virtual List<Straat> Straten { get; set; } = new List<Straat>();
}
