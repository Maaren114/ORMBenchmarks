using LinqToDB.Mapping;
using System;
using System.Collections.Generic;


namespace LinqToDbBenchmarks.models;

[Table("Provincies")]
public class Provincie
{
    [PrimaryKey, Identity]
    public int ProvincieID { get; set; }
    
    [Column("Provincienaam"), NotNull]
    public string? Provincienaam { get; set; }

    public virtual List<Gemeente> Gemeentes { get; set; } = new List<Gemeente>();
}

