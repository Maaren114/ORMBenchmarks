namespace ZZZProjectsBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new ZZZProjectsCreateRepository();

            var adressen = repo.GetAdressen("Zottegem");

            repo.Create1(adressen);
        }
    }
}