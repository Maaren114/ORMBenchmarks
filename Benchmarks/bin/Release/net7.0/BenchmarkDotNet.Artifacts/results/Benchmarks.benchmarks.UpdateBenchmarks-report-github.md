```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-TUNZUH : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                       | Mean       | Error    | StdDev    | Median     | Rank | Gen0       | Gen1      | Gen2      | Allocated |
|----------------------------- |-----------:|---------:|----------:|-----------:|-----:|-----------:|----------:|----------:|----------:|
| Dapper_BulkUpdate_DapperPlus |   160.2 ms |  2.55 ms |   2.13 ms |   159.7 ms |    1 |          - |         - |         - |   5.39 MB |
| ZZZProjectsBulkUpdate        |   170.8 ms |  3.21 ms |   7.94 ms |   168.4 ms |    2 |          - |         - |         - |   1.82 MB |
| RepoDb_BulkUpdate            |   174.5 ms |  3.32 ms |   4.20 ms |   174.5 ms |    3 |          - |         - |         - |   1.07 MB |
| Dapper_Execute               |   197.0 ms |  3.56 ms |   3.15 ms |   196.6 ms |    4 |          - |         - |         - |   5.67 MB |
| EFCore_ExecuteSqlRaw         |   201.0 ms |  1.27 ms |   0.99 ms |   201.2 ms |    5 |          - |         - |         - |   5.68 MB |
| LinqToDbExecute              |   204.7 ms |  3.95 ms |   4.06 ms |   203.2 ms |    5 |          - |         - |         - |   5.67 MB |
| PetaPocoExecute              |   234.3 ms |  4.45 ms |   4.76 ms |   232.6 ms |    6 |          - |         - |         - |   5.68 MB |
| NHibernate_CreateSqlQuery    |   236.1 ms |  4.46 ms |   5.14 ms |   236.2 ms |    6 |          - |         - |         - |    5.7 MB |
| NormNetUpdateExecute         |   238.2 ms |  4.60 ms |   5.81 ms |   238.4 ms |    6 |          - |         - |         - |  11.34 MB |
| OrmLite_ExecuteNonQuery      |   253.1 ms |  4.91 ms |   4.10 ms |   253.3 ms |    7 |          - |         - |         - |  19.84 MB |
| RepoDb_ExecuteNonQuery       |   257.6 ms |  5.00 ms |   6.33 ms |   258.5 ms |    7 |          - |         - |         - |   5.67 MB |
| EFCore_BulkUpdate_BorisDj    |   424.7 ms | 65.34 ms | 191.64 ms |   305.9 ms |    8 |  2000.0000 | 1000.0000 |         - |  14.61 MB |
| NHibernate_Update            | 2,021.5 ms | 10.93 ms |   9.12 ms | 2,020.8 ms |    9 | 18000.0000 | 7000.0000 | 1000.0000 |  118.3 MB |
| RepoDb_UpdateAll             | 2,393.4 ms | 38.34 ms |  33.99 ms | 2,387.3 ms |   10 |  4000.0000 | 3000.0000 |         - |  32.02 MB |
| EFCore_UpdateRange           | 2,506.8 ms | 20.03 ms |  17.76 ms | 2,502.2 ms |   11 | 24000.0000 | 6000.0000 |         - |  173.1 MB |
| EFCore_Update                | 2,510.2 ms | 12.88 ms |  11.41 ms | 2,509.3 ms |   11 | 24000.0000 | 6000.0000 |         - | 173.56 MB |
