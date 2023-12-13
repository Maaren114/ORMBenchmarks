using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using ZZZProjectsBenchmarks.models;

namespace ZZZProjectsBenchmarks.repositories
{
    public class ZZZProjectsDeleteRepository
    {
        private StratenregisterContext _context;
        public ZZZProjectsDeleteRepository()
        {
            _context = new StratenregisterContext();
        }

        public void EFCoreBulkDelete_ZZZProjects(List<AdresX> adressen)
        {
            _context.BulkDelete(adressen, options =>
            {
                options.BatchSize = 16000;
                options.AutoMapOutputDirection = false;
            });
        }
        public void Test(List<AdresX> adressenToDelete)
        {
            _context.BulkDelete(adressenToDelete, options => options.ColumnPrimaryKeyExpression = adres => adres.NISCode);
        }
    }
}
