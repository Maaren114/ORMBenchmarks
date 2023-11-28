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

        public ITable<Provincie> Provincies => this.GetTable<Provincie>();
        public ITable<Gemeente> Gemeentes => this.GetTable<Gemeente>();
        public ITable<Straat> Straten => this.GetTable<Straat>();
        public ITable<Adres> Adressen => this.GetTable<Adres>();
    }
}



