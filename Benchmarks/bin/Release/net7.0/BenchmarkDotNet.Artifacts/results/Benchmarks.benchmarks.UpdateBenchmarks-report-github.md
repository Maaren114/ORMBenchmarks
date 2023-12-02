```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-ARHESY : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

MaxIterationCount=100  

```
| Method              | Mean       | Error    | StdDev   | Rank | Gen0       | Gen1       | Gen2      | Allocated |
|-------------------- |-----------:|---------:|---------:|-----:|-----------:|-----------:|----------:|----------:|
| EFCoreExecuteRaw    |         NA |       NA |       NA |    ? |         NA |         NA |        NA |        NA |
| EFCoreExecuteSql    |   128.7 ms |  2.57 ms |  5.42 ms |    1 |   250.0000 |   250.0000 |  250.0000 |   6.92 MB |
| EFCoreBorisDjUpdate |   191.2 ms |  3.75 ms |  8.22 ms |    2 |  2666.6667 |  1000.0000 |  333.3333 |   16.4 MB |
| EFCoreUpdateRange   | 1,065.8 ms | 20.81 ms | 27.05 ms |    3 | 33000.0000 | 10000.0000 | 4000.0000 | 177.98 MB |

Benchmarks with issues:
  UpdateBenchmarks.EFCoreExecuteRaw: Job-ARHESY(MaxIterationCount=100)
