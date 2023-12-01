```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-UJAVGW : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  MaxIterationCount=100  UnrollFactor=1  

```
| Method                  | Mean      | Error    | StdDev    | Median    | Rank | Gen0      | Gen1      | Gen2      | Allocated   |
|------------------------ |----------:|---------:|----------:|----------:|-----:|----------:|----------:|----------:|------------:|
| EFBorisDjCreate         |        NA |       NA |        NA |        NA |    ? |        NA |        NA |        NA |          NA |
| RepoDbInsertAll         |        NA |       NA |        NA |        NA |    ? |        NA |        NA |        NA |          NA |
| LinqToDbBulkCopy        |  29.77 ms | 2.688 ms |  7.404 ms |  24.74 ms |    1 |         - |         - |         - |    381.1 KB |
| DapperPlus              |  44.43 ms | 2.429 ms |  6.566 ms |  41.67 ms |    2 |         - |         - |         - |   4587.4 KB |
| EFCoreZzzProjectsCreate |  46.59 ms | 3.420 ms |  9.246 ms |  41.90 ms |    2 |         - |         - |         - |  1289.52 KB |
| OrmLiteBulkInsert       |  61.33 ms | 3.995 ms | 10.732 ms |  56.94 ms |    3 | 1000.0000 |         - |         - |   8196.4 KB |
| DapperExecute           | 176.53 ms | 3.316 ms |  2.769 ms | 175.58 ms |    4 |         - |         - |         - |  5034.34 KB |
| NHibernateBatchRaw      | 181.66 ms | 3.447 ms |  4.233 ms | 180.71 ms |    5 |         - |         - |         - |  5057.03 KB |
| NormNetExecute          | 186.05 ms | 3.649 ms |  6.096 ms | 184.90 ms |    5 |         - |         - |         - |  5032.88 KB |
| PetaPocoExecute         | 189.05 ms | 3.755 ms |  7.756 ms | 186.79 ms |    5 |         - |         - |         - | 13217.91 KB |
| EFCoreExecuteSqlRaw     | 191.09 ms | 3.821 ms |  5.719 ms | 190.58 ms |    5 |         - |         - |         - |  5039.34 KB |
| LinqToDbExecute         | 191.17 ms | 3.672 ms |  4.901 ms | 190.48 ms |    5 |         - |         - |         - |  5030.29 KB |
| EFCoreExecuteSql        | 191.47 ms | 3.791 ms |  7.303 ms | 189.76 ms |    5 |         - |         - |         - |  5039.48 KB |
| OrmLiteBulkInsertRaw    | 197.96 ms | 3.866 ms |  3.228 ms | 196.90 ms |    6 | 1000.0000 | 1000.0000 | 1000.0000 | 25781.89 KB |
| RepoDbBulkInsert        | 642.45 ms | 5.632 ms |  4.703 ms | 641.18 ms |    7 | 8000.0000 |         - |         - | 49862.02 KB |

Benchmarks with issues:
  Benchmarks.EFBorisDjCreate: Job-UJAVGW(InvocationCount=1, MaxIterationCount=100, UnrollFactor=1)
  Benchmarks.RepoDbInsertAll: Job-UJAVGW(InvocationCount=1, MaxIterationCount=100, UnrollFactor=1)
