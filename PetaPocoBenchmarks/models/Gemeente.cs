using PetaPoco;
using System;
using System.Collections.Generic;

namespace PetaPocoBenchmarks;

[PetaPoco.TableName("Gemeentes")]
[PetaPoco.PrimaryKey("GemeenteID")]
public class Gemeente
{
    public int Id { get; set; }

    public int GemeenteId { get; set; }

    public string Gemeentenaam { get; set; } = null!;

    public int? ProvincieId { get; set; }

    [ResultColumn]
    public Provincie Provincie { get; set; }
    public List<Straat> GetStraten()
    {
        return null;
        // Haal Straten op basis van GemeenteId
        // Implementeer deze methode op basis van je vereisten
        // Return een lijst van Straten
    }
}
