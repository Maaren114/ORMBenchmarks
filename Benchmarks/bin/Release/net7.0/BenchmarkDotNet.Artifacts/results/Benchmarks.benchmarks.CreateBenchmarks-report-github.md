```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-BJJSIS : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  MaxIterationCount=100  UnrollFactor=1  

```
| Method                  | Mean      | Error    | StdDev   | Median    | Rank | Gen0      | Gen1      | Allocated   |
|------------------------ |----------:|---------:|---------:|----------:|-----:|----------:|----------:|------------:|
| OrmLiteBulkInsertRaw    |        NA |       NA |       NA |        NA |    ? |        NA |        NA |          NA |
| PetaPocoExecute         |        NA |       NA |       NA |        NA |    ? |        NA |        NA |          NA |
| RepoDbInsertAll         |        NA |       NA |       NA |        NA |    ? |        NA |        NA |          NA |
| RepoDbBulkInsert        |        NA |       NA |       NA |        NA |    ? |        NA |        NA |          NA |
| LinqToDbBulkCopy        |  43.91 ms | 5.126 ms | 14.37 ms |  44.62 ms |    1 |         - |         - |   382.19 KB |
| EFCoreZzzProjectsCreate |  54.99 ms | 5.109 ms | 13.90 ms |  47.59 ms |    2 |         - |         - |  1166.98 KB |
| EFBorisDjCreate         |  79.27 ms | 4.425 ms | 12.41 ms |  75.83 ms |    3 | 2000.0000 | 1000.0000 | 14321.38 KB |
| OrmLiteBulkInsert       |  80.78 ms | 8.705 ms | 23.83 ms |  75.14 ms |    3 | 1000.0000 |         - |  8314.82 KB |
| DapperPlus              | 146.56 ms | 3.989 ms | 11.70 ms | 150.82 ms |    4 |         - |         - |  5709.39 KB |
| NHibernateBatchRaw      | 225.58 ms | 5.298 ms | 14.59 ms | 222.22 ms |    5 |         - |         - | 14438.38 KB |
| NormNetExecute          | 227.76 ms | 6.812 ms | 18.65 ms | 224.97 ms |    5 |         - |         - |  14414.2 KB |
| DapperExecute           | 232.97 ms | 6.668 ms | 18.70 ms | 227.18 ms |    5 |         - |         - | 14415.48 KB |
| EFCoreExecuteSqlRaw     | 236.01 ms | 6.620 ms | 18.78 ms | 236.18 ms |    5 |         - |         - | 14424.72 KB |
| LinqToDbExecute         | 237.67 ms | 8.544 ms | 23.96 ms | 229.50 ms |    5 |         - |         - | 14411.59 KB |
| EFCoreExecuteSql        | 241.80 ms | 5.572 ms | 15.44 ms | 238.18 ms |    6 |         - |         - | 14424.81 KB |

Benchmarks with issues:
  CreateBenchmarks.OrmLiteBulkInsertRaw: Job-BJJSIS(InvocationCount=1, MaxIterationCount=100, UnrollFactor=1)
  CreateBenchmarks.PetaPocoExecute: Job-BJJSIS(InvocationCount=1, MaxIterationCount=100, UnrollFactor=1)
  CreateBenchmarks.RepoDbInsertAll: Job-BJJSIS(InvocationCount=1, MaxIterationCount=100, UnrollFactor=1)
  CreateBenchmarks.RepoDbBulkInsert: Job-BJJSIS(InvocationCount=1, MaxIterationCount=100, UnrollFactor=1)
