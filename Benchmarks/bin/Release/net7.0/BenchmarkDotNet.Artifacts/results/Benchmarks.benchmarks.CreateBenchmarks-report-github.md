```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-GAWMSF : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  MaxIterationCount=100  UnrollFactor=1  

```
| Method                  | Mean      | Error     | StdDev    | Median    | Rank | Gen0      | Gen1      | Allocated   |
|------------------------ |----------:|----------:|----------:|----------:|-----:|----------:|----------:|------------:|
| LinqToDbBulkCopy        |  38.87 ms |  2.807 ms |  7.825 ms |  37.34 ms |    1 |         - |         - |    381.1 KB |
| EFCoreZzzProjectsCreate |  52.16 ms |  3.231 ms |  9.165 ms |  49.28 ms |    2 |         - |         - |  1288.66 KB |
| DapperPlus              |  64.61 ms |  1.397 ms |  4.032 ms |  63.85 ms |    3 |         - |         - |  5825.91 KB |
| OrmLiteBulkInsert       |  71.68 ms |  4.859 ms | 13.704 ms |  67.28 ms |    4 | 1000.0000 |         - |  8190.58 KB |
| EFBorisDjCreate         |  79.42 ms |  2.929 ms |  8.164 ms |  77.50 ms |    5 | 2000.0000 | 1000.0000 |    14563 KB |
| DapperExecute           | 209.60 ms |  4.155 ms |  9.378 ms | 209.02 ms |    6 |         - |         - |  5034.14 KB |
| PetaPocoExecute         | 210.29 ms |  4.198 ms |  9.127 ms | 209.53 ms |    6 |         - |         - |  5037.29 KB |
| NormNetExecute          | 212.40 ms |  4.242 ms | 11.468 ms | 209.33 ms |    6 |         - |         - |  5032.85 KB |
| LinqToDbExecute         | 212.92 ms |  4.248 ms |  7.327 ms | 212.99 ms |    6 |         - |         - |  5030.38 KB |
| EFCoreExecuteSql        | 217.25 ms |  4.344 ms | 10.407 ms | 214.55 ms |    6 |         - |         - |  5039.33 KB |
| EFCoreExecuteSqlRaw     | 218.94 ms |  4.191 ms |  8.840 ms | 218.58 ms |    6 |         - |         - |  5039.27 KB |
| NHibernateBatchRaw      | 219.46 ms |  5.755 ms | 16.512 ms | 215.29 ms |    6 |         - |         - |  5056.92 KB |
| OrmLiteBulkInsertRaw    | 228.07 ms |  4.522 ms | 11.092 ms | 225.92 ms |    7 |         - |         - | 17604.59 KB |
| RepoDbBulkInsert        | 673.04 ms | 13.397 ms | 16.943 ms | 672.64 ms |    8 | 8000.0000 |         - | 49854.83 KB |
| RepoDbInsertAll         | 676.69 ms | 13.240 ms | 15.247 ms | 672.23 ms |    8 | 8000.0000 |         - | 49856.33 KB |
