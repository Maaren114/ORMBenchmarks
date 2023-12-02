using LinqToDB.Data;
using LinqToDbBenchmarks.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tools;

namespace LinqToDbBenchmarks.repositories
{
    public class LinqToDbUpdateRepository
    {

        private StratenRegisterConnection _connection;

        public LinqToDbUpdateRepository()
        {
            DataConnection.DefaultSettings = new MySettings();
            _connection = new StratenRegisterConnection();
        }

        public void X(List<AdresX> updates)
        {
            _connection.BulkCopy(BulkCopyOptions.)


        }




    }
}
