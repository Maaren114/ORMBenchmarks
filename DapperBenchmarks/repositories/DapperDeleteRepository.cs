using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;
using Z.Dapper.Plus;
using static LinqToDB.Reflection.Methods.LinqToDB;

namespace DapperBenchmarks.repositories
{
    public class DapperDeleteRepository
    {
        private IDbConnection _dbConnection;
        public DapperDeleteRepository()
        {
            _dbConnection = new SqlConnection(Toolkit.GetConnectionString());
        }

        public void DapperExecute(List<AdresX> deletes)
        {
            string query = $@"
                             DELETE FROM Adressen
                             WHERE AdresID IN (SELECT AdresID
                                               FROM OPENJSON(@adressen)
                                               WITH (AdresID int));";

            string deletesJSON = JsonSerializer.Serialize(deletes);
            _dbConnection.Execute(query, new { adressen = deletesJSON });
        }

        public void DapperPlus(List<AdresX> adressen)
        {
            _dbConnection.UseBulkOptions(options =>
            {
                options.BatchSize = 16000;
                options.AutoMapOutputDirection = false;
                options.DestinationTableName = "Adressen";
            }).BulkDelete(adressen);
        }

        public void Test(List<string> nisCodes)
        {
            //DapperPlusManager.Entity<AdresX>().Key(order => order.NISCode);


            //_dbConnection.UseBulkOptions(options =>
            //{
            //    options.BatchSize = 16000;
            //    options.AutoMapOutputDirection = false;
            //    options.DestinationTableName = "Adressen";
            //}).BulkDelete<AdresX>(adressen => nisCodes.Contains(adressen.NisCode));
        }


    }
}
