using Microsoft.Data.SqlClient;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace RepoDbBenchmarks.repositories
{
    public class RepoDbDeleteRepository
    {
        private SqlConnection _connection;
        public RepoDbDeleteRepository()
        {
            GlobalConfiguration.Setup().UseSqlServer();
            _connection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public void DeleteAll(List<AdresX> adressen)
        {
            _connection.Open();
            _connection.DeleteAll(adressen); // 262 gaat wel nog. 263 niet meer!!! (teveel parameters)
            _connection.Close();
        }

        public void BulkDelete(List<AdresX> adressen)
        {
            _connection.Open();
            _connection.BulkDelete(adressen, batchSize: 20000);
            _connection.Close();
        }

        //public void BulkDeleteBouzekenBlous(List<StraatX> straten)
        //{
        //    _connection.Open();
        //    _connection.DeleteAll(straten);
        //    _connection.Close();
        //}
    }
}
