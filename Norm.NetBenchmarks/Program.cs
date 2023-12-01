namespace Norm.NetBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new NormNetCreateRepository();

            var adressen = repo.GetAdressen("Zottegem");

            repo.CreateExecute(adressen);
        }
    }
}