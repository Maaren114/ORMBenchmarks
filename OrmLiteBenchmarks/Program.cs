using DapperBenchmarks.repositories;
using OrmLiteBenchmarks.repositories;
using Tools;

namespace OrmLiteBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dapperselect = new DapperSelectRepository();
            var repoupdate = new OrmLiteUpdateRepository();
            var repocreate = new OrmLiteCreateRepository();
            var repodelete = new OrmLiteDeleteRepository();
            var reposelect = new OrmLiteSelectRepository();

            var adressen = dapperselect.GetAdressen();

            repodelete.OrmLiteDeleteAll(adressen);
        }
    }
}

