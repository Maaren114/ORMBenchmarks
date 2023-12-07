```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-MASCSP : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  MaxIterationCount=50  UnrollFactor=1  

```
| Method                  | Mean      | Error     | StdDev    | Median    | Rank | Gen0      | Gen1      | Allocated   |
|------------------------ |----------:|----------:|----------:|----------:|-----:|----------:|----------:|------------:|
| NormNetExecute          |        NA |        NA |        NA |        NA |    ? |        NA |        NA |          NA |
| OrmLiteBulkInsert       |        NA |        NA |        NA |        NA |    ? |        NA |        NA |          NA |
| OrmLiteBulkInsertRaw    |        NA |        NA |        NA |        NA |    ? |        NA |        NA |          NA |
| PetaPocoExecute         |        NA |        NA |        NA |        NA |    ? |        NA |        NA |          NA |
| RepoDbInsertAll         |        NA |        NA |        NA |        NA |    ? |        NA |        NA |          NA |
| RepoDbBulkInsert        |        NA |        NA |        NA |        NA |    ? |        NA |        NA |          NA |
| LinqToDbBulkCopy        |  31.62 ms |  3.344 ms |  6.199 ms |  28.81 ms |    1 |         - |         - |   382.19 KB |
| EFCoreZzzProjectsCreate |  55.12 ms |  4.637 ms |  8.934 ms |  52.87 ms |    2 |         - |         - |  1166.98 KB |
| DapperPlus              |  69.61 ms |  3.920 ms |  7.362 ms |  66.50 ms |    3 |         - |         - |  5709.38 KB |
| EFBorisDjCreate         |  79.53 ms |  5.774 ms | 10.703 ms |  74.47 ms |    4 | 2000.0000 | 1000.0000 | 14674.74 KB |
| NHibernateBatchRaw      | 213.01 ms |  5.870 ms | 10.881 ms | 211.00 ms |    5 |         - |         - | 14255.87 KB |
| EFCoreExecuteSqlRaw     | 214.76 ms |  4.149 ms |  4.940 ms | 214.48 ms |    5 |         - |         - |  6061.95 KB |
| DapperExecute           | 219.69 ms |  9.158 ms | 17.423 ms | 213.71 ms |    5 |         - |         - | 14232.98 KB |
| LinqToDbExecute         | 220.32 ms |  4.948 ms |  8.923 ms | 219.09 ms |    5 |         - |         - | 14229.39 KB |
| EFCoreExecuteSql        | 233.05 ms | 13.714 ms | 26.748 ms | 222.76 ms |    5 |         - |         - | 14242.11 KB |

Benchmarks with issues:
  CreateBenchmarks.NormNetExecute: Job-MASCSP(InvocationCount=1, MaxIterationCount=50, UnrollFactor=1)
  CreateBenchmarks.OrmLiteBulkInsert: Job-MASCSP(InvocationCount=1, MaxIterationCount=50, UnrollFactor=1)
  CreateBenchmarks.OrmLiteBulkInsertRaw: Job-MASCSP(InvocationCount=1, MaxIterationCount=50, UnrollFactor=1)
  CreateBenchmarks.PetaPocoExecute: Job-MASCSP(InvocationCount=1, MaxIterationCount=50, UnrollFactor=1)
  CreateBenchmarks.RepoDbInsertAll: Job-MASCSP(InvocationCount=1, MaxIterationCount=50, UnrollFactor=1)
  CreateBenchmarks.RepoDbBulkInsert: Job-MASCSP(InvocationCount=1, MaxIterationCount=50, UnrollFactor=1)
