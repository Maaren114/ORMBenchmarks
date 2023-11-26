using BenchmarkDotNet.Running;
using System.Reflection;

namespace Benchmarks
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();

            // Iteraties per testmethode weergeven
            foreach (var report in summary.Reports)
            {
                var benchmarkCase = report.BenchmarkCase;
                var methodName = benchmarkCase.Descriptor.WorkloadMethod.Name;
                var iterationCount = report.GetResultRuns().Count;
                Console.WriteLine($"{methodName} werd {iterationCount} keer uitgevoerd.");
            }
        }
    }
}