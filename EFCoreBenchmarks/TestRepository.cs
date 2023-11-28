
using EFCore.BulkExtensions;
using EFCoreBenchmarks.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tools;

namespace EFCoreBenchmarks
{
    public class TestRepository
    {
        private StratenregisterContext _context;
        public TestRepository()
        {
            _context = new StratenregisterContext();
        }

        public async void BulkAdd(IEnumerable<StraatX> straten)
        {
            ProvincieX oostVlaanderen = _context.Provincies.Single(provincie => provincie.Provincienaam == "Oost-Vlaanderen");



            Expression<Func<ProvincieX, bool>> f = provincie => provincie.Provincienaam == "Oost-Vlaanderen";




            List<ProvincieX> provincies = new List<ProvincieX>() { new ProvincieX(), new ProvincieX() };

            provincies.Single(provincie => provincie.Provincienaam == "Oost-Vlaanderen");


            _context.Entry(oostVlaanderen).Collection(provincie => provincie.Gemeentes).Load();

            foreach (GemeenteX gemeente in oostVlaanderen.Gemeentes)
            {
                Console.WriteLine(gemeente);
                _context.Entry(gemeente).Collection(gem => gem.Straten).Load();

                foreach (StraatX straat in gemeente.Straten)
                {
                    Console.WriteLine(gemeente);
                    _context.Entry(straat).Collection(str => str.Adressen).Load();

                    foreach (AdresX adres in straat.Adressen)
                    {
                        Console.WriteLine(adres);
                    }
                }
            }

            Console.WriteLine();


            //    .Single(b => b.Url == "http://someblog.microsoft.com");
            //blog.Url = "http://someotherblog.microsoft.com";
            //context.Add(new Blog { Url = "http://newblog1.microsoft.com" });
            //context.Add(new Blog { Url = "http://newblog2.microsoft.com" });
            //context.SaveChanges();




            //foreach (Straat s in straten)
            //{
            //    _context.Straten.Add(s);
            //}

            //_context.SaveChanges();


            //_context.BulkInsert(straten);
            //_context.BulkUpdate(straten);
            //_context.BulkDeleteAsync(straten);
            //_context.Straten.Where(straat => straat.Gemeente.Gemeentenaam == "Zottegem").ExecuteDeleteAsync();

            //_context.BulkUpdate(straten);
            //_context.SaveChanges();
        }

        public IEnumerable<StraatX> GetBulk()
        {
            var straten = _context.Straten.Where(straat => straat.Gemeente.Gemeentenaam == "Boechout");

            foreach (var straat in straten)
            {
                Console.WriteLine(straat.Straatnaam);
                //straat.Id = 0;
            }

            return straten;
        }

        public void MethodeA()
        {
            //var aantalInwoners = _context.Gemeentes.Where(g => g.Provincie.Provincienaam == "Oost-Vlaanderen").Sum(e => e.AantalInwoners);
            //Console.WriteLine(aantalInwoners);
        }
    }
}
