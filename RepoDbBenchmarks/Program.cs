﻿using RepoDbBenchmarks.repositories;
using ServiceStack;
using Tools;

namespace RepoDbBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repoupdate = new RepoDbUpdateRepository();
            var repocreate = new RepoDbCreateRepository();
            var reposelect = new RepoDbSelectRepository();
            var repodelete = new RepoDbDeleteRepository();

            //var adressen = repocreate.GetAdressen("Zottegem");

            //repoupdate.BulkUpdate(adressen);
            //repoupdate.UpdateAll(adressen);

            //repocreate.BulkInsert(adressen);
            //repocreate.InsertAll(adressen);

            //List<string> niscodes = new List<string>();
            //niscodes.Add("2c4140d4-cff7-49be-a8c4-2375783344ee");
            //niscodes.Add("2c4140d4-cff7-49be-a8c4-2375783344ee");
            //niscodes.Add("9f5860cb-6c72-4dd3-9f03-c49a417a65ac");
            //niscodes.Add("3bd7ed9e-2633-4f44-a583-1da61d50db95");
            //niscodes.Add("6772fad9-c6ad-4943-9e40-06b99e335792");
            //niscodes.Add("98154d7e-11be-4820-8447-7f181e3ee084");
            //niscodes.Add("98154d7e-11be-4820-8447-7f181e3ee084");

            //List<AdresX> adressen = reposelect.Query(niscodes);

            var adressen = repocreate.GetAdressen("Zottegem");

            var straten = repocreate.GetStraten("Oost-Vlaanderen", 3);

            //repoupdate.UpdateAllStratenBouzekenBlous(straten);

            repodelete.DeleteAll(adressen);



        }
    }
}


