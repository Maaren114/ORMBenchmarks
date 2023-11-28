using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.models
{
    public interface IGemeente
    {
        int GemeenteId { get; set; }

        string Gemeentenaam { get; set; }

        int? ProvincieId { get; set; }

        IProvincie? Provincie { get; set; }

        ICollection<IStraat> Straten { get; set; }
    }

}
