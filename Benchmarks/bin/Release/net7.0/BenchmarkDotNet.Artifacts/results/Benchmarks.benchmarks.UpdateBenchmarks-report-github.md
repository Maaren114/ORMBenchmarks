```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-FPZEAI : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

MaxIterationCount=100  

```
| Method                  | Mean       | Error    | StdDev   | Median     | Rank | Gen0       | Gen1      | Gen2      | Allocated |
|------------------------ |-----------:|---------:|---------:|-----------:|-----:|-----------:|----------:|----------:|----------:|
| DapperPlus              |   131.0 ms |  2.34 ms |  2.60 ms |   130.1 ms |    1 |   750.0000 |         - |         - |   5.57 MB |
| ZZZProjectsBulkUpdate   |   132.4 ms |  1.93 ms |  1.72 ms |   132.1 ms |    1 |          - |         - |         - |   1.88 MB |
| RepoDbBulkUpdate        |   141.5 ms |  2.35 ms |  2.31 ms |   141.3 ms |    2 |          - |         - |         - |   1.11 MB |
| PetaPocoExecute         |   191.8 ms |  1.70 ms |  1.42 ms |   192.0 ms |    3 |          - |         - |         - |   8.45 MB |
| NormNetUpdateExecute    |   193.1 ms |  0.96 ms |  0.90 ms |   193.1 ms |    3 |          - |         - |         - |   8.45 MB |
| DapperExecute           |   193.9 ms |  2.61 ms |  2.31 ms |   193.6 ms |    3 |          - |         - |         - |   8.45 MB |
| NHibernateBatchRaw      |   197.1 ms |  1.82 ms |  1.70 ms |   196.2 ms |    3 |          - |         - |         - |   8.47 MB |
| LinqToDbExecute         |   198.8 ms |  2.51 ms |  2.10 ms |   198.8 ms |    3 |          - |         - |         - |   8.44 MB |
| EFCoreExecuteSql        |   202.2 ms |  3.80 ms |  3.55 ms |   201.7 ms |    3 |          - |         - |         - |   5.79 MB |
| EFCoreExecuteRaw        |   202.9 ms |  4.05 ms |  7.81 ms |   199.6 ms |    3 |          - |         - |         - |   5.79 MB |
| EFCoreBorisDjUpdate     |   207.7 ms |  3.78 ms |  5.04 ms |   206.5 ms |    4 |  2000.0000 | 1000.0000 |         - |  15.09 MB |
| ormliteexecuteupdateraw |   213.3 ms |  2.17 ms |  1.81 ms |   213.2 ms |    5 |   333.3333 |  333.3333 |  333.3333 |  25.56 MB |
| EFCoreUpdateRange       |   986.4 ms | 17.64 ms | 16.50 ms |   986.7 ms |    6 | 29000.0000 | 7000.0000 |         - | 177.78 MB |
| NHibernateBatch         | 2,044.9 ms | 10.59 ms |  9.91 ms | 2,049.4 ms |    7 | 19000.0000 | 6000.0000 | 1000.0000 | 123.62 MB |
| RepoDbUpdateAll         | 2,375.5 ms | 18.37 ms | 15.34 ms | 2,373.1 ms |    8 |  4000.0000 | 3000.0000 |         - |  33.21 MB |
