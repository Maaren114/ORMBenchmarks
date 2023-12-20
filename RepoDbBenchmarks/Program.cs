using DapperBenchmarks.repositories;
using RepoDbBenchmarks.repositories;
using ServiceStack;
using Tools;

namespace RepoDbBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DapperSelectRepository dapperselect = new DapperSelectRepository();
            var repoupdate = new RepoDbUpdateRepository();
            var repocreate = new RepoDbCreateRepository();
            var reposelect = new RepoDbSelectRepository();
            var repodelete = new RepoDbDeleteRepository();


            var adressen = dapperselect.GetAdressen();

            repodelete.RepoDbDeleteAll(adressen);

        }
    }
}


