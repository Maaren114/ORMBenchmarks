using Bogus;
using EFCoreBenchmarks.models;
using EFCoreBenchmarks.repositories;
using Tools;

namespace EFCoreBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var updateRepo = new EFCoreUpdateRepository();
            var createRepo = new EFCoreCreateRepository();
            var deleterepo = new EFCoreDeleteRepository();
            var selectrepo = new EFCoreSelectRepository();
            var testrepo = new TestRepository();

            var adressen = updateRepo.GetAdressen();




            deleterepo.EFCoreRemove(adressen);


        }
    }
}





