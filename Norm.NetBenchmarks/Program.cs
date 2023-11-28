namespace Norm.NetBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new NormNetRepository();

            var adressen = repo.GetAdressen("Zottegem");

            repo.CreateExecute(adressen);
        }
    }
}