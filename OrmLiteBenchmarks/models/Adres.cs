using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace OrmLiteBenchmarks.models;

[Alias("Adressen")]
public class Adres
{
    public Adres(string huisnummer, string? appartementnummer, string? busnummer, int niscode, int postcode, string status)
    {
        Huisnummer = huisnummer;
        Appartementnummer = appartementnummer;
        Busnummer = busnummer;
        NISCode = niscode;
        Postcode = postcode;
        Status = status;
    }

    public Adres(string huisnummer, int niscode, int postcode, string status)
    {
        Huisnummer = huisnummer;
        NISCode = niscode;
        Postcode = postcode;
        Status = status;
    }

    public int AdresID { get; set; }

    public int StraatID { get; set; }

    public string Huisnummer { get; set; } = null!;

    public string? Appartementnummer { get; set; }

    public string? Busnummer { get; set; }

    public int? NISCode { get; set; }

    public int? Postcode { get; set; }

    public string Status { get; set; } = null!;

    [Reference]
    public virtual Straat Straat { get; set; } = null!;
}


