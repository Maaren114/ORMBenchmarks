```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-DKNPRP : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

MaxIterationCount=100  

```
| Method                  | Mean       | Error    | StdDev   | Median     | Rank | Gen0       | Gen1      | Gen2      | Allocated |
|------------------------ |-----------:|---------:|---------:|-----------:|-----:|-----------:|----------:|----------:|----------:|
| RepoDbBulkUpdate        |         NA |       NA |       NA |         NA |    ? |         NA |        NA |        NA |        NA |
| DapperPlus              |   128.5 ms |  2.52 ms |  3.84 ms |   127.7 ms |    1 |   750.0000 |         - |         - |   5.58 MB |
| ZZZProjectsBulkUpdate   |   129.3 ms |  2.43 ms |  2.16 ms |   128.6 ms |    1 |   250.0000 |         - |         - |   1.88 MB |
| NormNetUpdateExecute    |   185.9 ms |  1.79 ms |  1.59 ms |   185.7 ms |    2 |          - |         - |         - |   8.45 MB |
| PetaPocoExecute         |   187.1 ms |  1.77 ms |  1.65 ms |   187.5 ms |    2 |          - |         - |         - |   8.45 MB |
| DapperExecute           |   187.5 ms |  2.31 ms |  2.17 ms |   188.1 ms |    2 |          - |         - |         - |   8.45 MB |
| NHibernateBatchRaw      |   193.0 ms |  2.66 ms |  2.49 ms |   193.0 ms |    3 |          - |         - |         - |   8.47 MB |
| EFCoreBorisDjUpdate     |   193.7 ms |  3.56 ms |  7.43 ms |   192.6 ms |    3 |  2000.0000 | 1000.0000 |         - |  15.09 MB |
| EFCoreExecuteSql        |   193.8 ms |  1.92 ms |  1.70 ms |   193.7 ms |    3 |          - |         - |         - |   8.45 MB |
| LinqToDbExecute         |   194.0 ms |  2.28 ms |  2.02 ms |   193.8 ms |    3 |          - |         - |         - |   8.44 MB |
| EFCoreExecuteRaw        |   198.1 ms |  3.89 ms |  8.04 ms |   193.9 ms |    3 |          - |         - |         - |   8.45 MB |
| ormliteexecuteupdateraw |   206.2 ms |  1.50 ms |  1.33 ms |   206.3 ms |    4 |   333.3333 |  333.3333 |  333.3333 |  25.56 MB |
| EFCoreUpdateRange       |   996.4 ms |  7.37 ms |  6.90 ms |   993.4 ms |    5 | 29000.0000 | 7000.0000 |         - | 177.78 MB |
| NHibernateBatch         | 2,036.8 ms | 20.17 ms | 17.88 ms | 2,033.6 ms |    6 | 19000.0000 | 6000.0000 | 1000.0000 | 123.62 MB |
| RepoDbUpdateAll         | 2,377.7 ms |  9.33 ms |  8.27 ms | 2,377.6 ms |    7 |  4000.0000 | 3000.0000 |         - |  33.21 MB |

Benchmarks with issues:
  UpdateBenchmarks.RepoDbBulkUpdate: Job-DKNPRP(MaxIterationCount=100)
