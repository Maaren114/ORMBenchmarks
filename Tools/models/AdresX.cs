using LinqToDB.Mapping;
using RepoDb.Attributes;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ServiceStack.Diagnostics.Events;

namespace Tools;

[Table("Adressen")]
[Alias("Adressen")]
[Map("[Adressen]")]
public class AdresX
{
    public AdresX() { }

    [LinqToDB.Mapping.PrimaryKey, LinqToDB.Mapping.Identity]
    public virtual int AdresID { get; set; }
    [Column(Name = "StraatID")]
    public virtual int StraatID { get; set; }
    [Column(Name = "Huisnummer")]
    public virtual string? Huisnummer { get; set; }
    [Column(Name = "Appartementnummer")]
    public virtual string? Appartementnummer { get; set; }
    [Column(Name = "Busnummer")]
    public virtual string? Busnummer { get; set; }
    [Column(Name = "Status")]
    public virtual string Status { get; set; }
    [Column(Name = "NISCode")]
    public virtual string? NISCode { get; set; }
    [Column(Name = "Postcode")]
    public virtual int? Postcode { get; set; }
    [ServiceStack.DataAnnotations.Ignore]
    public virtual StraatX Straat { get; set; }

    public override string ToString()
    {
        return String.Format($"ADRES uit STRAAT {Straat?.Straatnaam} (AdresId: {AdresID}, StraatId: {StraatID}, Huisnummer: {Huisnummer}, Appartementnummer: {Appartementnummer}, Busnummer: {Busnummer}, Status: {Status})");
    }
}




