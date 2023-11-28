using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.models
{
    public interface IProvincie
    {
        int ProvincieId { get; set; }

        string? Provincienaam { get; set; }

        ICollection<IGemeente> Gemeentes { get; set; }
    }
}