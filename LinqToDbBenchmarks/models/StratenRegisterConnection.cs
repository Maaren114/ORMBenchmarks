using LinqToDB;
using LinqToDB.Data;
using LinqToDbBenchmarks.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace LinqToDbBenchmarks.models
{
    public class StratenRegisterConnection : DataConnection
    {
        public StratenRegisterConnection() : base()
        {
        
        }

        public ITable<ProvincieX> Provincies => this.GetTable<ProvincieX>();
        public ITable<GemeenteX> Gemeentes => this.GetTable<GemeenteX>();
        public ITable<StraatX> Straten => this.GetTable<StraatX>();
        public ITable<AdresX> Adressen => this.GetTable<AdresX>();
    }
}



