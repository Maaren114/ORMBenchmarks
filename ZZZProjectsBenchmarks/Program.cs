namespace ZZZProjectsBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new ZZZProjectsRepository();
            var adressen = repo.GetAdressen("Zottegem");
            repo.Create1(adressen);
        }
    }
}