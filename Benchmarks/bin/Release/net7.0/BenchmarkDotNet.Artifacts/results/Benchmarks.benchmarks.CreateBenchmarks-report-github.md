```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-QLFFJU : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                        | Mean        | Error     | StdDev   | Median      | Rank | Gen0       | Gen1      | Gen2      | Allocated    |
|------------------------------ |------------:|----------:|---------:|------------:|-----:|-----------:|----------:|----------:|-------------:|
| RepoDb_BulkInsert             |    48.38 ms |  5.602 ms | 14.86 ms |    43.42 ms |    1 |          - |         - |         - |    726.66 KB |
| LinqToDb_BulkCopy             |    49.68 ms |  5.593 ms | 15.12 ms |    49.02 ms |    1 |          - |         - |         - |     725.9 KB |
| Dapper_BulkInsert_DapperPlus  |    60.69 ms |  6.848 ms | 18.28 ms |    53.15 ms |    2 |          - |         - |         - |    4325.1 KB |
| EFCore_BulkInsert_ZZZProjects |    64.89 ms |  8.262 ms | 22.48 ms |    55.42 ms |    2 |          - |         - |         - |   1136.52 KB |
| OrmLite_BulkInsert            |    67.45 ms |  4.118 ms | 10.78 ms |    61.93 ms |    3 |  1000.0000 |         - |         - |   7116.97 KB |
| EFCore_BulkInsert_BorisDj     |    92.70 ms |  9.113 ms | 25.40 ms |    82.08 ms |    4 |  2000.0000 | 1000.0000 |         - |  14199.02 KB |
| LinqToDb_Execute              |   215.37 ms |  4.292 ms | 10.53 ms |   215.04 ms |    5 |          - |         - |         - |  13886.23 KB |
| Dapper_Execute                |   215.92 ms |  4.396 ms | 11.81 ms |   214.93 ms |    5 |          - |         - |         - |  13889.95 KB |
| RepoDb_ExecuteNonQuery        |   217.79 ms |  4.355 ms | 11.24 ms |   216.37 ms |    5 |          - |         - |         - |  13888.32 KB |
| NHibernate_CreateSqlQuery     |   218.41 ms |  6.105 ms | 16.71 ms |   212.65 ms |    5 |          - |         - |         - |  13913.93 KB |
| NormNetExecute                |   218.46 ms |  5.379 ms | 14.82 ms |   214.73 ms |    5 |          - |         - |         - |  13889.27 KB |
| PetaPocoExecute               |   218.57 ms |  4.690 ms | 12.60 ms |   215.92 ms |    5 |          - |         - |         - |  13897.77 KB |
| EFCore_ExecuteSqlRaw          |   227.75 ms |  6.915 ms | 18.81 ms |   221.94 ms |    6 |          - |         - |         - |  13898.13 KB |
| OrmLite_ExecuteNonQuery       |   241.18 ms |  5.095 ms | 14.03 ms |   238.05 ms |    7 |  1000.0000 | 1000.0000 | 1000.0000 |  28162.98 KB |
| NHibernate_Save               | 1,740.24 ms | 31.845 ms | 28.23 ms | 1,735.62 ms |    8 | 20000.0000 | 6000.0000 |         - | 128867.49 KB |
| EFCore_AddRange               | 2,141.51 ms | 31.226 ms | 24.38 ms | 2,135.37 ms |    9 | 25000.0000 | 8000.0000 |         - | 163851.97 KB |
| EFCore_Add                    | 2,172.67 ms | 42.998 ms | 35.90 ms | 2,191.42 ms |    9 | 25000.0000 | 8000.0000 |         - | 164320.73 KB |
| RepoDb_InsertAll              | 2,330.73 ms | 17.353 ms | 14.49 ms | 2,332.17 ms |   10 |  6000.0000 | 3000.0000 |         - |  47150.77 KB |
