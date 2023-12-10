using RepoDb;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace RepoDbBenchmarks.repositories
{
    public class RepoDbUpdateRepository
    {
        private SqlConnection _connection;
        public RepoDbUpdateRepository()
        {
            GlobalConfiguration.Setup().UseSqlServer();
            _connection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public void UpdateAll(List<AdresX> adressen)
        {
            _connection.Open();
            _connection.UpdateAll(adressen, batchSize: 262); // 262 gaat wel nog. 263 niet meer!!! (teveel parameters)
            _connection.Close();
        }

        public void UpdateAllStratenBouzekenBlous(List<StraatX> straten)
        {
            _connection.Open();
            _connection.UpdateAll(straten, batchSize: 699); // 699 gaat wel nog. 700 niet meer!!! (teveel parameters)
            _connection.Close();
        }

        public void BulkUpdate(List<AdresX> adressen)
        {
            _connection.Open();
            _connection.BulkUpdate(adressen, batchSize: 16000);
            _connection.ExecuteNonQuery("");
            _connection.Close();
        }
    }
}
