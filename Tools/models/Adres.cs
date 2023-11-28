using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NHibernateBenchmarks;

public class Adres
{
    public Adres() { }

    public virtual int AdresId { get; set; }

    public virtual int StraatId { get; set; }

    public virtual string Huisnummer { get; set; }

    public virtual string? Appartementnummer { get; set; }

    public virtual string? Busnummer { get; set; }

    public virtual string Status { get; set; }
    public virtual string? NISCode { get; set; }
    public virtual string? Postcode { get; set; }
    public virtual Straat Straat { get; set; }

    public override string ToString()
    {
        return String.Format($"ADRES uit STRAAT {Straat?.Straatnaam} (AdresId: {AdresId}, StraatId: {StraatId}, Huisnummer: {Huisnummer}, Appartementnummer: {Appartementnummer}, Busnummer: {Busnummer}, Status: {Status})");
    }
}




