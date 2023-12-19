```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-HNIJCO : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                        | Mean        | Error      | StdDev     | Median      | Rank | Gen0       | Gen1      | Gen2      | Allocated |
|------------------------------ |------------:|-----------:|-----------:|------------:|-----:|-----------:|----------:|----------:|----------:|
| EFCore_BulkDelete_ZZZProjects |    96.11 ms |   7.804 ms |  20.284 ms |    97.14 ms |    1 |          - |         - |         - |   1.12 MB |
| Dapper_BulkDelete_DapperPlus  |    97.34 ms |   9.278 ms |  24.280 ms |    91.07 ms |    1 |          - |         - |         - |   1.48 MB |
| RepoDb_BulkDelete             |   127.67 ms |  10.082 ms |  25.663 ms |   117.22 ms |    2 |          - |         - |         - |   1.06 MB |
| NHibernate_CreateSqlQuery     |   143.16 ms |   6.491 ms |  17.213 ms |   139.40 ms |    3 |          - |         - |         - |  14.13 MB |
| NormNetExecute                |   143.26 ms |   4.664 ms |  12.369 ms |   140.67 ms |    3 |          - |         - |         - |  14.01 MB |
| Dapper_Execute                |   150.39 ms |   8.948 ms |  23.257 ms |   145.54 ms |    3 |          - |         - |         - |   6.04 MB |
| EFCore_BulkDelete_BorisDj     |   160.12 ms |  14.964 ms |  39.157 ms |   148.01 ms |    3 |  1000.0000 |         - |         - |  10.08 MB |
| LinqToDb_Execute              |   161.10 ms |   6.027 ms |  15.559 ms |   159.71 ms |    4 |          - |         - |         - |  14.01 MB |
| RepoDb_ExecuteNonQuery        |   166.71 ms |   7.909 ms |  20.555 ms |   160.86 ms |    4 |          - |         - |         - |  14.03 MB |
| PetaPocoExecute               |   186.51 ms |   5.918 ms |  15.275 ms |   183.26 ms |    5 |          - |         - |         - |  14.03 MB |
| EFCore_ExecuteSqlRaw          |   189.95 ms |  35.972 ms |  96.636 ms |   151.51 ms |    6 |          - |         - |         - |  14.11 MB |
| OrmLite_ExecuteNonQuery       |   206.09 ms |   7.401 ms |  19.237 ms |   200.47 ms |    7 |  1000.0000 | 1000.0000 | 1000.0000 |  29.06 MB |
| OrmLite_DeleteAll             |   475.00 ms | 136.189 ms | 370.511 ms |   300.34 ms |    8 |          - |         - |         - |   5.97 MB |
| NHibernate_Delete             |   489.99 ms |  71.017 ms | 184.582 ms |   420.69 ms |    9 |  5000.0000 | 2000.0000 |         - |  41.23 MB |
| EFCore_Remove                 |   665.56 ms | 132.270 ms | 359.851 ms |   464.78 ms |   10 | 14000.0000 | 4000.0000 |         - |  92.57 MB |
| EFCore_RemoveRange            |   713.71 ms | 160.907 ms | 443.186 ms |   467.46 ms |   10 | 14000.0000 | 4000.0000 |         - |  92.11 MB |
| RepoDb_DeleteAll              |   733.64 ms |   7.485 ms |   6.250 ms |   730.92 ms |   11 | 24000.0000 | 1000.0000 |         - |  148.2 MB |
| LinqToDb_Delete               | 1,282.55 ms |  26.717 ms |  72.230 ms | 1,261.57 ms |   12 |          - |         - |         - |   5.13 MB |
