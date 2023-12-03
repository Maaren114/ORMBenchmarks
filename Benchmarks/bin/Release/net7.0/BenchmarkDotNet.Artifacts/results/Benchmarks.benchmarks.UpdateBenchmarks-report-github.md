```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-LJKQUG : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

MaxIterationCount=100  

```
| Method                  | Mean       | Error    | StdDev   | Median     | Rank | Gen0       | Gen1      | Gen2      | Allocated |
|------------------------ |-----------:|---------:|---------:|-----------:|-----:|-----------:|----------:|----------:|----------:|
| ZZZProjectsBulkUpdate   |   141.7 ms |  3.92 ms | 11.30 ms |   138.5 ms |    1 |          - |         - |         - |   1.99 MB |
| RepoDbBulkUpdate        |   154.7 ms |  3.02 ms |  3.59 ms |   154.5 ms |    2 |          - |         - |         - |   1.23 MB |
| DapperPlus              |   162.7 ms |  3.23 ms |  3.72 ms |   162.4 ms |    3 |   750.0000 |         - |         - |   5.69 MB |
| NHibernateBatchRaw      |   195.5 ms |  3.78 ms |  5.55 ms |   194.6 ms |    4 |          - |         - |         - |   7.48 MB |
| PetaPocoExecute         |   197.2 ms |  3.58 ms |  3.35 ms |   196.9 ms |    4 |          - |         - |         - |   7.46 MB |
| DapperExecute           |   198.2 ms |  3.90 ms |  4.79 ms |   197.3 ms |    4 |          - |         - |         - |   7.45 MB |
| EFCoreExecuteSql        |   199.5 ms |  3.91 ms |  3.65 ms |   200.3 ms |    4 |          - |         - |         - |   7.45 MB |
| EFCoreExecuteRaw        |   201.7 ms |  4.01 ms |  4.62 ms |   201.0 ms |    4 |          - |         - |         - |   7.45 MB |
| NormNetUpdateExecute    |   213.9 ms |  3.98 ms |  8.39 ms |   212.6 ms |    5 |          - |         - |         - |   7.45 MB |
| LinqToDbExecute         |   218.6 ms |  4.27 ms |  4.75 ms |   218.6 ms |    6 |          - |         - |         - |   7.44 MB |
| ormliteexecuteupdateraw |   231.4 ms |  4.62 ms |  8.68 ms |   229.6 ms |    7 |   500.0000 |  500.0000 |  500.0000 |  24.75 MB |
| EFCoreBorisDjUpdate     |   822.3 ms | 16.44 ms | 38.10 ms |   823.4 ms |    8 |  2000.0000 | 1000.0000 |         - |  15.33 MB |
| EFCoreUpdateRange       | 1,112.3 ms | 10.91 ms |  9.11 ms | 1,110.9 ms |    9 | 29000.0000 | 7000.0000 |         - | 178.04 MB |
| NHibernateBatch         | 2,273.9 ms | 27.52 ms | 25.75 ms | 2,271.9 ms |   10 | 19000.0000 | 7000.0000 | 1000.0000 | 123.65 MB |
| RepoDbUpdateAll         | 2,783.3 ms | 55.16 ms | 69.77 ms | 2,793.6 ms |   11 |  4000.0000 | 2000.0000 |         - |  33.04 MB |
