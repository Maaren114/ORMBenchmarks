using System;
using System.Collections.Generic;

namespace EFCoreBenchmarks.models;

public partial class Adres
{
    public int AdresId { get; set; }

    public int StraatId { get; set; }

    public string Huisnummer { get; set; } = null!;

    public string? Appartementnummer { get; set; }

    public string? Busnummer { get; set; }

    public int? Niscode { get; set; }

    public int? Postcode { get; set; }

    public string Status { get; set; } = null!;

    public virtual Straat Straat { get; set; } = null!;
}
