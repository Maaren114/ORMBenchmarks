using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetaPocoBenchmarks;

[PetaPoco.TableName("Provincies")]
[PetaPoco.PrimaryKey("ProvincieID")]
public class Provincie
{
    public int ProvincieId { get; set; }

    public string? Provincienaam { get; set; }

    public virtual List<Gemeente> Gemeentes { get; set; } = new List<Gemeente>();
}

