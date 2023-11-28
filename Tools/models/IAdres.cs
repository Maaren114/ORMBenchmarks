using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.models
{
    public interface IAdres
    {
        int AdresId { get; set; }

        int StraatId { get; set; }

        string Huisnummer { get; set; }

        string? Appartementnummer { get; set; }

        string? Busnummer { get; set; }
        public int? Niscode { get; set; }
        string Status { get; set; }

        IStraat? Straat { get; set; }
    }
}
