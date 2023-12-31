﻿using LinqToDB.Data;
using LinqToDbBenchmarks.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace LinqToDbBenchmarks.repositories
{
    public class LinqToDbSelectRepository
    {
        private StratenRegisterConnection _connection;
        public LinqToDbSelectRepository()
        {
            DataConnection.DefaultSettings = new MySettings();
            _connection = new StratenRegisterConnection();
        }

        public List<AdresX> LinqToDb_Where(List<string> niscodes)
        {
            List<AdresX> adressen = _connection.Adressen.Where(a => niscodes.Contains(a.NISCode)).ToList();
            return adressen;
        }

        #region Helper methods
        public List<AdresX> LinqToDbSelect2(List<string> niscodes)
        {
            List<AdresX> adressen = (from a in _connection.Adressen
                                     join n in niscodes on a.NISCode equals n
                                     select a).Distinct().ToList();

            return adressen;
        }

        public List<string> GetNisCodes(int aantal)
        {
            return _connection.Adressen.Select(a => a.NISCode).Take(aantal).ToList();
        }
        #endregion
    }
}





