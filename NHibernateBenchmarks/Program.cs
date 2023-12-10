﻿using DapperBenchmarks.repositories;
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
            var dappercreaterepo = new DapperCreateRepository();
            var updaterepo = new NHibernateUpdateRepository();
            var createrepo = new NHibernateCreateRepository();
            var deleterepo = new NHibernateDeleteRepository();
            var selectrepo = new NHibernateSelectRepository();


            //var adressen = dappercreaterepo.GetAddressen("Zottegem");

            List<AdresX> adressen = new List<AdresX>();

            for (int i = 0; i < 15000; i++)
            {
                adressen.Add(new AdresX { Busnummer = "yoo", StraatID = 10 });
            }

            createrepo.Batch(adressen);



            //var adressen = createrepo.GetAdressen("Zottegem");

            //var adressen = new List<AdresX>();

            //for (int i = 0; i < 15000; i++)
            //{
            //    adressen.Add(new AdresX { AdresID = i + 1, StraatID = 1 });
            //}

            //deleterepo.Batch(adressen);
            //deleterepo.BatchRaw(adressen);

            //List<string> niscodes = new List<string>();
            //niscodes.Add("2c4140d4-cff7-49be-a8c4-2375783344ee");
            //niscodes.Add("2c4140d4-cff7-49be-a8c4-2375783344ee");
            //niscodes.Add("9f5860cb-6c72-4dd3-9f03-c49a417a65ac");
            //niscodes.Add("3bd7ed9e-2633-4f44-a583-1da61d50db95");
            //niscodes.Add("6772fad9-c6ad-4943-9e40-06b99e335792");
            //niscodes.Add("98154d7e-11be-4820-8447-7f181e3ee084");
            //niscodes.Add("98154d7e-11be-4820-8447-7f181e3ee084");

            //var adressen = selectrepo.RawSql(niscodes);
        }
    }
}