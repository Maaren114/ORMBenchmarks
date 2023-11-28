using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace OrmLiteBenchmarks.models;


[Alias("Gemeentes")]
public class Gemeente
{
    public int GemeenteId { get; set; }

    public string Gemeentenaam { get; set; } = null!;

    public int? ProvincieId { get; set; }

    [Reference]
    public virtual Provincie? Provincie { get; set; }

    [Reference]
    public virtual List<Straat> Straten { get; set; } = new List<Straat>();

    [Reference]
    public virtual List<Adres> Adressen { get; set; } = new List<Adres>(); // Voeg deze lijn toe als 'Gemeentenaam' in de 'Adressen'-tabel staat
}
