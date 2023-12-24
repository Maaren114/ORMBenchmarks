using Bogus;
using DapperBenchmarks.models;
using DapperBenchmarks.repositories;
using System;
using System.Collections.Generic;
using Tools;

namespace DapperBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var updateRepo = new DapperUpdateRepository();
            var createRepo = new DapperCreateRepository();
            var deleterepo = new DapperDeleteRepository();
            var selectrepo = new DapperSelectRepository();

            var adressen = selectrepo.GetAdressen();

            createRepo.DapperBulkInsert_DapperPlus(adressen);





        }
    }
}