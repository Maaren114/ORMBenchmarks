using System;
using System.Collections.Generic;

namespace DapperBenchmarks.models;

public class Adres
{
    public Adres() { }

    public int AdresId { get; set; }

    public int StraatId { get; set; }

    public string Huisnummer { get; set; }

    public string? Appartementnummer { get; set; }

    public string? Busnummer { get; set; }

    public string Status { get; set; }

    public Straat Straat { get; set; }
}


