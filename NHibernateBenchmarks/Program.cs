using DapperBenchmarks.repositories;
using NHibernate;
using NHibernateBenchmarks.repositories;
using ServiceStack;
using System.Xml;
using Tools;

namespace NHibernateBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dapperselect = new DapperSelectRepository();
            var updaterepo = new NHibernateUpdateRepository();
            var createrepo = new NHibernateCreateRepository();
            var deleterepo = new NHibernateDeleteRepository();
            var selectrepo = new NHibernateSelectRepository();

            var adressen = dapperselect.GetAdressen();

            deleterepo.NHibernateDelete(adressen);

        }
    }
}