using EFCoreBenchmarks.models;

namespace EFCoreBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new TestRepository();
            repo.MethodeA();
            IEnumerable<Straat> straten = repo.GetBulk();
            //repo.BulkAdd(straten);
        }
    }
}
