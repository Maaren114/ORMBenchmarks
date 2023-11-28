using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.models
{
    public interface IStraat
    {
        int StraatId { get; set; }

        int GemeenteId { get; set; }

        string Straatnaam { get; set; }

        ICollection<IAdres> Adressen { get; set; }

        IGemeente Gemeente { get; set; }
    }

}
