
using EFCore.BulkExtensions;
using EFCoreBenchmarks.models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
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

        public TestRepository()
        {
            this.Connectie = new SqlConnection(Toolkit.GetConnectionString());
        }

        private SqlConnection Connectie { get; set; }

        public void SqlBulkCopy(List<AdresX> adressen)
        {
            Connectie.Open();

            DataTable adressentabel = MaakDataTable(adressen);
            string doeltabel = "Adressen";

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(Connectie))
            {
                bulkCopy.DestinationTableName = doeltabel;
                bulkCopy.WriteToServer(adressentabel);
            }

            Connectie.Close();
        }

        private DataTable MaakDataTable(List<AdresX> adressen)
        {
            DataTable table = new DataTable();

            table.Columns.Add("AdresID", typeof(int));
            table.Columns.Add("StraatID", typeof(int));
            table.Columns.Add("Huisnummer", typeof(string));
            table.Columns.Add("Appartementnummer", typeof(string));
            table.Columns.Add("Busnummer", typeof(string));
            table.Columns.Add("NISCode", typeof(string));
            table.Columns.Add("Postcode", typeof(int));
            table.Columns.Add("Status", typeof(string));

            foreach (AdresX adres in adressen)
            {
                table.Rows.Add(adres.AdresID,
                               adres.StraatID,
                               adres.Huisnummer,
                               adres.Appartementnummer,
                               adres.Busnummer,
                               adres.NISCode,
                               adres.Postcode,
                               adres.Status);
            }

            return table;
        }
    }
}
