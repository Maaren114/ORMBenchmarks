```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-NCNBNU : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  MaxIterationCount=100  UnrollFactor=1  

```
| Method                  | Mean      | Error     | StdDev    | Median    | Rank | Gen0      | Gen1      | Allocated   |
|------------------------ |----------:|----------:|----------:|----------:|-----:|----------:|----------:|------------:|
| LinqToDbBulkCopy        |  33.47 ms |  3.304 ms |  9.210 ms |  29.07 ms |    1 |         - |         - |    381.1 KB |
| DapperPlus              |  45.46 ms |  1.762 ms |  4.794 ms |  44.07 ms |    2 |         - |         - |  4582.69 KB |
| EFCoreZzzProjectsCreate |  46.71 ms |  1.879 ms |  5.142 ms |  44.89 ms |    2 |         - |         - |  1287.46 KB |
| OrmLiteBulkInsert       |  61.31 ms |  2.177 ms |  5.961 ms |  58.70 ms |    3 | 1000.0000 |         - |   8192.9 KB |
| EFBorisDjCreate         |  75.32 ms |  3.621 ms | 10.273 ms |  70.90 ms |    4 | 2000.0000 | 1000.0000 | 14560.96 KB |
| PetaPocoExecute         | 192.20 ms |  3.813 ms |  5.345 ms | 189.62 ms |    5 |         - |         - |  5037.04 KB |
| NormNetExecute          | 200.70 ms |  3.963 ms | 10.015 ms | 199.28 ms |    6 |         - |         - |  5032.64 KB |
| DapperExecute           | 204.18 ms |  3.999 ms |  6.107 ms | 204.11 ms |    6 |         - |         - |  5034.07 KB |
| EFCoreExecuteSqlRaw     | 204.37 ms |  3.983 ms |  4.090 ms | 204.73 ms |    6 |         - |         - |  5039.16 KB |
| NHibernateBatchRaw      | 206.31 ms |  3.986 ms |  6.548 ms | 206.81 ms |    6 |         - |         - |  5056.95 KB |
| EFCoreExecuteSql        | 209.41 ms |  4.151 ms |  5.953 ms | 208.53 ms |    6 |         - |         - |  5039.47 KB |
| LinqToDbExecute         | 209.69 ms |  4.106 ms |  6.747 ms | 208.01 ms |    6 |         - |         - |  5030.35 KB |
| OrmLiteBulkInsertRaw    | 209.71 ms |  3.927 ms |  3.673 ms | 209.44 ms |    6 |         - |         - | 17603.38 KB |
| RepoDbInsertAll         | 582.63 ms |  9.283 ms |  8.683 ms | 582.77 ms |    7 | 8000.0000 |         - | 49856.09 KB |
| RepoDbBulkInsert        | 621.31 ms | 12.387 ms | 21.034 ms | 618.14 ms |    8 | 8000.0000 |         - | 49856.91 KB |
