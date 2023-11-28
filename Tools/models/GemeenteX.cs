using LinqToDB.Mapping;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Tools;

[Alias("Gemeentes")]
[Table("Gemeentes")]
public class GemeenteX
{
    [Column("GemeenteID"), NotNull]
    [LinqToDB.Mapping.PrimaryKey, Identity]
    public virtual int GemeenteID { get; set; }

    [Column("Gemeentenaam"), NotNull]
    public virtual string Gemeentenaam { get; set; } = null!;

    public virtual int? ProvincieID { get; set; }

    public virtual ProvincieX? Provincie { get; set; }

    public virtual ISet<StraatX> Straten { get; set; } = new HashSet<StraatX>();

    public override string ToString()
    {
        return String.Format($"GEMEENTE UIT PROVINCIE {Provincie.Provincienaam}, GemeenteId: {GemeenteID}, Gemeentenaam: {Gemeentenaam}, ProvincieId: {ProvincieID})");
    }
}


