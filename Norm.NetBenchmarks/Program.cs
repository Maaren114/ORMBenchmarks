using Norm.NetBenchmarks.repositories;

namespace Norm.NetBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repoupdate = new NormNetUpdateRepository();
            var repocreate = new NormNetCreateRepository();

            var adressen = repocreate.GetAdressen("Zottegem");

            repoupdate.UpdateExecute(adressen);
            //repocreate.CreateExecute(adressen);
        }
    }
}