using System;
using System.Collections.Generic;

namespace Norm.NetBenchmarks.models;

public class Adres
{
    public Adres(string huisnummer, string? appartementnummer, string? busnummer, int niscode, int postcode, string status)
    {
        Huisnummer = huisnummer;
        Appartementnummer = appartementnummer;
        Busnummer = busnummer;
        Niscode = niscode;
        Postcode = postcode;
        Status = status;
    }

    public Adres(string huisnummer, int niscode, int postcode, string status)
    {
        Huisnummer = huisnummer;
        Niscode = niscode;
        Postcode = postcode;
        Status = status;
    }

    public int AdresId { get; set; }

    public int StraatId { get; set; }

    public string Huisnummer { get; set; } = null!;

    public string? Appartementnummer { get; set; }

    public string? Busnummer { get; set; }

    public int? Niscode { get; set; }

    public int? Postcode { get; set; }

    public string? Status { get; set; } = null!;

    public virtual Straat Straat { get; set; } = null!;
}


