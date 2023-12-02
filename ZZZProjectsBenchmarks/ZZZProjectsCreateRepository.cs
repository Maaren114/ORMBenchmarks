using ZZZProjectsBenchmarks.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace ZZZProjectsBenchmarks
{
    public class ZZZProjectsCreateRepository
    {
        private StratenregisterContext _context;
        public ZZZProjectsCreateRepository()
        {
            _context = new StratenregisterContext();
        }

        public List<AdresX> GetAdressen(string gemeentenaam)
        {
            List<AdresX> adressen = _context.Adressen.Where(adres => adres.Straat.Gemeente.Gemeentenaam == gemeentenaam).Take(15557).ToList();
            return adressen;
        }

        public void Create1(List<AdresX> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {
            _context.BulkInsert(adressen, options =>
            {
                options.BatchSize = 16000;
                options.AutoMapOutputDirection = false;
            });
        }
    }
}
