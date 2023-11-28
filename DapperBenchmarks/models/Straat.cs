using System;
using System.Collections.Generic;

namespace DapperBenchmarks.models;

public class Straat
{
    public int Id { get; set; }

    public int StraatId { get; set; }

    public int GemeenteId { get; set; }

    public string Straatnaam { get; set; }

    public ICollection<Adres> Adressen { get; set; } = new List<Adres>();
}


