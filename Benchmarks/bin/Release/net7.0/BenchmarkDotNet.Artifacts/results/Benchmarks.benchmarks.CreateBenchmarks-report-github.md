```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-OFGKJY : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  MaxIterationCount=50  UnrollFactor=1  

```
| Method                  | Mean        | Error     | StdDev    | Median      | Rank | Gen0      | Gen1      | Gen2      | Allocated   |
|------------------------ |------------:|----------:|----------:|------------:|-----:|----------:|----------:|----------:|------------:|
| LinqToDbBulkCopy        |    41.31 ms |  3.478 ms |  6.532 ms |    38.65 ms |    1 |         - |         - |         - |   752.01 KB |
| EFCoreZzzProjectsCreate |    53.40 ms |  5.017 ms |  9.174 ms |    51.32 ms |    2 |         - |         - |         - |  1166.98 KB |
| DapperPlus              |    58.11 ms |  2.030 ms |  3.862 ms |    56.95 ms |    3 |         - |         - |         - |  4473.23 KB |
| OrmLiteBulkInsert       |    65.88 ms |  2.142 ms |  3.916 ms |    64.43 ms |    4 | 1000.0000 |         - |         - |  7331.39 KB |
| EFBorisDjCreate         |    75.29 ms |  3.374 ms |  6.083 ms |    72.35 ms |    5 | 2000.0000 | 1000.0000 |         - |  14675.4 KB |
| EFCoreExecuteSql        |   201.60 ms |  3.929 ms |  4.035 ms |   201.22 ms |    6 |         - |         - |         - |  6163.53 KB |
| NormNetExecute          |   215.26 ms |  4.560 ms |  8.565 ms |   214.08 ms |    7 |         - |         - |         - |  14331.6 KB |
| DapperExecute           |   215.34 ms |  4.242 ms |  3.968 ms |   215.00 ms |    7 |         - |         - |         - |   6155.8 KB |
| NHibernateBatchRaw      |   217.46 ms |  6.091 ms | 10.982 ms |   216.17 ms |    7 |         - |         - |         - | 14356.14 KB |
| LinqToDbExecute         |   219.56 ms |  7.335 ms | 13.777 ms |   221.16 ms |    7 |         - |         - |         - | 14328.96 KB |
| PetaPocoExecute         |   226.44 ms |  7.578 ms | 14.600 ms |   223.82 ms |    7 |         - |         - |         - | 14341.55 KB |
| EFCoreExecuteSqlRaw     |   226.51 ms |  6.225 ms | 12.287 ms |   224.63 ms |    7 |         - |         - |         - |  6163.42 KB |
| OrmLiteBulkInsertRaw    |   238.56 ms |  6.092 ms | 11.881 ms |   237.79 ms |    8 | 1000.0000 | 1000.0000 | 1000.0000 | 29710.66 KB |
| RepoDbInsertAll         | 2,406.91 ms |  9.293 ms |  8.238 ms | 2,406.15 ms |    9 | 6000.0000 | 3000.0000 |         - |  48897.8 KB |
| RepoDbBulkInsert        | 2,451.35 ms | 21.591 ms | 18.029 ms | 2,449.23 ms |   10 | 6000.0000 | 3000.0000 |         - | 48898.05 KB |
