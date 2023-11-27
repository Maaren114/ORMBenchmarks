using ZZZProjectsBenchmarks.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZZProjectsBenchmarks
{
    public class ZZZProjectsRepository
    {
        private StratenregisterContext _context;
        public ZZZProjectsRepository()
        {
            _context = new StratenregisterContext();
        }

        public List<Adres> GetAdressen(string gemeentenaam)
        {
            List<Adres> adressen = _context.Adressen.Where(adres => adres.Straat.Gemeente.Gemeentenaam == gemeentenaam).Take(15557).ToList();
            return adressen;
        }

        public void Create1(List<Adres> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {
            _context.BulkInsert(adressen, options =>
            {
                options.BatchSize = 16000;
                options.AutoMapOutputDirection = false;
            });
        }
    }
}
