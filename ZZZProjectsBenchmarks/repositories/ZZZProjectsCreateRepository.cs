using ZZZProjectsBenchmarks.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace ZZZProjectsBenchmarks.repositories
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
            List<AdresX> adressen = _context.Adressen.Where(adres => adres.Straat.Gemeente.Gemeentenaam == gemeentenaam).Take(15000).ToList();
            return adressen;
        }

        public void EFCoreBulkInsert_ZZZProjects(List<AdresX> adressen)
        {
            _context.BulkInsert(adressen, options =>
            {
                options.BatchSize = 15000;
                options.AutoMapOutputDirection = false;
            });
        }
    }
}



