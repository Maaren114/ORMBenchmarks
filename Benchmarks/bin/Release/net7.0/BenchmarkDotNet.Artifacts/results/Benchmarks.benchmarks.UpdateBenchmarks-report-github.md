```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2 [AttachedDebugger]
  Job-FPSATM : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

MaxIterationCount=100  

```
| Method                  | Mean       | Error    | StdDev    | Median     | Rank | Gen0       | Gen1      | Gen2      | Allocated |
|------------------------ |-----------:|---------:|----------:|-----------:|-----:|-----------:|----------:|----------:|----------:|
| DapperPlus              |   180.5 ms |  4.23 ms |  12.00 ms |   180.9 ms |    1 |   666.6667 |         - |         - |   5.57 MB |
| ZZZProjectsBulkUpdate   |   182.1 ms |  3.58 ms |   7.15 ms |   181.4 ms |    1 |          - |         - |         - |   1.88 MB |
| RepoDbBulkUpdate        |   208.7 ms |  6.92 ms |  19.29 ms |   204.3 ms |    2 |          - |         - |         - |   1.11 MB |
| EFCoreBorisDjUpdate     |   252.4 ms |  5.05 ms |  13.81 ms |   249.3 ms |    3 |  2000.0000 | 1000.0000 |         - |   15.1 MB |
| NormNetUpdateExecute    |   254.8 ms |  7.77 ms |  22.55 ms |   250.4 ms |    3 |          - |         - |         - |  13.77 MB |
| LinqToDbExecute         |   262.1 ms |  8.75 ms |  24.81 ms |   254.3 ms |    3 |          - |         - |         - |   9.77 MB |
| PetaPocoExecute         |   264.8 ms |  8.04 ms |  22.56 ms |   259.0 ms |    3 |          - |         - |         - |   9.78 MB |
| DapperExecute           |   306.1 ms | 19.17 ms |  55.93 ms |   294.1 ms |    4 |          - |         - |         - |  13.77 MB |
| NHibernateBatchRaw      |   310.4 ms | 15.99 ms |  46.66 ms |   296.0 ms |    4 |          - |         - |         - |  13.79 MB |
| ormliteexecuteupdateraw |   321.7 ms | 17.11 ms |  49.65 ms |   305.0 ms |    4 |   500.0000 |  500.0000 |  500.0000 |  28.22 MB |
| EFCoreExecuteRaw        |   449.6 ms | 19.99 ms |  58.00 ms |   446.9 ms |    5 |          - |         - |         - |  13.78 MB |
| EFCoreExecuteSql        |   454.5 ms | 31.61 ms |  91.19 ms |   446.6 ms |    5 |          - |         - |         - |  13.78 MB |
| EFCoreUpdateRange       | 1,340.5 ms | 26.70 ms |  33.76 ms | 1,343.3 ms |    6 | 29000.0000 | 7000.0000 |         - | 177.78 MB |
| NHibernateBatch         | 2,764.2 ms | 54.05 ms |  93.23 ms | 2,744.4 ms |    7 | 19000.0000 | 7000.0000 | 1000.0000 | 123.62 MB |
| RepoDbUpdateAll         | 3,088.4 ms | 59.82 ms | 156.55 ms | 3,086.2 ms |    8 |  4000.0000 | 3000.0000 |         - |  33.21 MB |
