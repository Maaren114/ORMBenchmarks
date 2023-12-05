using LinqToDB.Data;
using LinqToDbBenchmarks.models;
using LinqToDbBenchmarks.repositories;
using Tools;

namespace LinqToDbBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var updaterepo = new LinqToDbUpdateRepository();
            var createrepo = new LinqToDbCreateRepository();
            var deleterepo = new LinqToDbDeleteRepository();
            var selectrepo = new LinqToDbSelectRepository();

            //var adressen = createrepo.GetAdressen("Zottegem");

            List<string> niscodes = new List<string>();
            niscodes.Add("2c4140d4-cff7-49be-a8c4-2375783344ee");
            niscodes.Add("2c4140d4-cff7-49be-a8c4-2375783344ee");
            niscodes.Add("9f5860cb-6c72-4dd3-9f03-c49a417a65ac");
            niscodes.Add("3bd7ed9e-2633-4f44-a583-1da61d50db95");
            niscodes.Add("6772fad9-c6ad-4943-9e40-06b99e335792");
            niscodes.Add("98154d7e-11be-4820-8447-7f181e3ee084");
            niscodes.Add("98154d7e-11be-4820-8447-7f181e3ee084");

            //var adressen = selectrepo.Select1(niscodes);
            var adressen = selectrepo.Select2(niscodes);

            Console.WriteLine();

            //deleterepo.LinqToDbExecute(adressen);
        }
    }
}


