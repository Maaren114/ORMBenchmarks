﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using ZZZProjectsBenchmarks.models;

namespace ZZZProjectsBenchmarks.repositories
{
    public class ZZZProjectsUpdateRepository
    {
        private StratenregisterContext _context;
        public ZZZProjectsUpdateRepository()
        {
            _context = new StratenregisterContext();
        }

        public void ZZZProjectsBulkUpdate(List<AdresX> adressen)
        {
            _context.BulkUpdate(adressen, options =>
            {
                options.BatchSize = 15000;
                options.AutoMapOutputDirection = false;
            });
        }
    }
}
