using LinqToDB.Mapping;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using PrimaryKeyAttribute = LinqToDB.Mapping.PrimaryKeyAttribute;

namespace Tools;


[Table("Provincies")]
[Alias("Provincies")]
public class ProvincieX
{
    [PrimaryKey, Identity]
    public virtual int ProvincieID { get; set; }

    [Column("Provincienaam"), NotNull]
    public virtual string? Provincienaam { get; set; }

    [Reference]
    public virtual ISet<GemeenteX> Gemeentes { get; set; } = new HashSet<GemeenteX>();

    public override string ToString()
    {
        return String.Format($"(ProvincieId: {ProvincieID}, Provincienaam: {Provincienaam})");
    }
}



