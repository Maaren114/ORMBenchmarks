```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-VFUWHG : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  MaxIterationCount=100  UnrollFactor=1  

```
| Method                  | Mean        | Error     | StdDev    | Median      | Rank | Gen0      | Gen1      | Allocated   |
|------------------------ |------------:|----------:|----------:|------------:|-----:|----------:|----------:|------------:|
| LinqToDbBulkCopy        |    32.76 ms |  4.190 ms | 11.749 ms |    25.50 ms |    1 |         - |         - |    381.2 KB |
| EFCoreZzzProjectsCreate |    51.54 ms |  3.745 ms | 10.314 ms |    46.32 ms |    2 |         - |         - |  1166.98 KB |
| EFBorisDjCreate         |    67.50 ms |  0.832 ms |  0.695 ms |    67.34 ms |    3 | 2000.0000 | 1000.0000 | 14321.42 KB |
| OrmLiteBulkInsert       |    75.26 ms |  6.976 ms | 19.675 ms |    67.16 ms |    3 | 1000.0000 |         - |  8314.95 KB |
| DapperPlus              |   125.06 ms |  2.129 ms |  1.888 ms |   124.76 ms |    4 |         - |         - |   5706.8 KB |
| NHibernateBatchRaw      |   216.82 ms |  4.311 ms | 11.506 ms |   217.31 ms |    5 |         - |         - | 14438.39 KB |
| DapperExecute           |   217.67 ms |  4.286 ms |  4.764 ms |   218.06 ms |    5 |         - |         - | 14415.49 KB |
| PetaPocoExecute         |   222.26 ms |  3.426 ms |  5.022 ms |   222.11 ms |    5 |         - |         - | 14422.69 KB |
| NormNetExecute          |   222.92 ms |  4.452 ms | 11.169 ms |   221.60 ms |    5 |         - |         - | 14414.33 KB |
| EFCoreExecuteSqlRaw     |   223.54 ms |  4.287 ms |  5.422 ms |   224.20 ms |    5 |         - |         - | 14457.77 KB |
| EFCoreExecuteSql        |   224.89 ms |  4.459 ms |  9.007 ms |   222.23 ms |    5 |         - |         - | 14424.88 KB |
| LinqToDbExecute         |   228.07 ms |  4.556 ms | 12.700 ms |   224.54 ms |    5 |         - |         - | 14411.67 KB |
| OrmLiteBulkInsertRaw    |   245.84 ms |  4.882 ms | 11.509 ms |   245.12 ms |    6 | 3000.0000 | 3000.0000 | 29998.85 KB |
| RepoDbInsertAll         | 2,375.88 ms |  9.564 ms |  8.478 ms | 2,378.82 ms |    7 | 6000.0000 | 3000.0000 |  48898.1 KB |
| RepoDbBulkInsert        | 2,378.50 ms | 15.071 ms | 13.360 ms | 2,374.24 ms |    7 | 6000.0000 | 3000.0000 | 48897.84 KB |
