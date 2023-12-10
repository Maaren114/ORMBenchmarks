using LinqToDB.Mapping;
using RepoDb.Attributes;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Tools;

[Table("Straten")]
[ServiceStack.DataAnnotations.Alias("Straten")]
[Map("Straten")]
public class StraatX
{
    [LinqToDB.Mapping.PrimaryKey, LinqToDB.Mapping.Identity]
    [Column(Name = "StraatID")]
    public virtual int StraatID { get; set; }
    [Column(Name = "GemeenteID")]
    public virtual int GemeenteID { get; set; }
    [Column(Name = "Straatnaam")]
    public virtual string? Straatnaam { get; set; }
    [Reference]
    public virtual GemeenteX? Gemeente { get; set; }
    [Reference]
    public virtual ISet<AdresX> Adressen { get; set; } = new HashSet<AdresX>();

    public override string ToString()
    {
        return String.Format($"STRAAT UIT GEMEENTE {Gemeente.Gemeentenaam} (StraatId: {StraatID}, GemeenteId: {0}, Straatnaam: {Straatnaam})");
    }
}











