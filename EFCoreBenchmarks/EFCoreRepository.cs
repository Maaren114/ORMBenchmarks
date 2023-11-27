using EFCore.BulkExtensions;
using EFCoreBenchmarks.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreBenchmarks
{
    public class EFCoreRepository
    {
        private StratenregisterContext _context;
        public EFCoreRepository()
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
            _context.BulkInsert(adressen, options => options.BatchSize = 16000);
        }

        public void Create2(List<Adres> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {


        }

        public void Create3(List<Adres> adressen) // vraag hiervoor alle adressen van Zottegem op (15.575 adressen)
        {

        }












    }
}
