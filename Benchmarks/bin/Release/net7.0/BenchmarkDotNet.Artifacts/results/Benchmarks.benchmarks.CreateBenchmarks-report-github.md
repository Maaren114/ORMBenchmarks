```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-HWFZOU : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                        | Mean        | Error     | StdDev    | Median      | Rank | Gen0       | Gen1      | Gen2      | Allocated    |
|------------------------------ |------------:|----------:|----------:|------------:|-----:|-----------:|----------:|----------:|-------------:|
| RepoDb_BulkInsert             |    50.71 ms |  5.885 ms | 15.910 ms |    46.64 ms |    1 |          - |         - |         - |    726.66 KB |
| LinqToDb_BulkCopy             |    56.36 ms |  8.200 ms | 22.170 ms |    49.83 ms |    1 |          - |         - |         - |     725.9 KB |
| EFCore_BulkInsert_ZZZProjects |    60.96 ms |  4.783 ms | 12.683 ms |    55.59 ms |    2 |          - |         - |         - |   1136.52 KB |
| Dapper_BulkInsert_DapperPlus  |    63.51 ms |  6.636 ms | 18.054 ms |    54.95 ms |    2 |          - |         - |         - |    4325.1 KB |
| OrmLite_BulkInsert            |    70.55 ms |  5.889 ms | 15.719 ms |    63.83 ms |    3 |  1000.0000 |         - |         - |   7116.97 KB |
| EFCore_BulkInsert_BorisDj     |    89.26 ms |  7.276 ms | 20.039 ms |    81.34 ms |    4 |  2000.0000 | 1000.0000 |         - |  14198.98 KB |
| LinqToDb_Execute              |   198.55 ms |  2.777 ms |  2.319 ms |   197.64 ms |    5 |          - |         - |         - |  13886.55 KB |
| PetaPocoExecute               |   201.41 ms |  4.019 ms |  7.647 ms |   201.11 ms |    5 |          - |         - |         - |  13897.51 KB |
| Dapper_Execute                |   202.33 ms |  5.118 ms | 13.836 ms |   196.52 ms |    5 |          - |         - |         - |  13890.55 KB |
| RepoDb_ExecuteNonQuery        |   204.49 ms |  4.069 ms | 10.721 ms |   199.57 ms |    5 |          - |         - |         - |  13888.71 KB |
| EFCore_ExecuteSqlRaw          |   204.79 ms |  3.847 ms |  9.722 ms |   202.81 ms |    5 |          - |         - |         - |  13897.54 KB |
| NormNetExecute                |   208.56 ms |  6.175 ms | 17.007 ms |   204.63 ms |    5 |          - |         - |         - |  13889.34 KB |
| NHibernate_CreateSqlQuery     |   210.84 ms |  4.125 ms |  6.777 ms |   210.48 ms |    6 |          - |         - |         - |  13913.71 KB |
| OrmLite_ExecuteNonQuery       |   224.88 ms |  4.465 ms |  9.612 ms |   222.20 ms |    7 |  2000.0000 | 2000.0000 |         - |     28161 KB |
| NHibernate_Save               | 1,681.26 ms | 32.489 ms | 39.899 ms | 1,673.58 ms |    8 | 20000.0000 | 6000.0000 | 1000.0000 | 120673.52 KB |
| EFCore_AddRange               | 2,189.30 ms | 21.256 ms | 17.750 ms | 2,195.24 ms |    9 | 27000.0000 | 9000.0000 | 2000.0000 | 163862.48 KB |
| EFCore_Add                    | 2,210.80 ms | 13.791 ms | 12.225 ms | 2,210.41 ms |    9 | 27000.0000 | 9000.0000 | 2000.0000 | 164339.02 KB |
| RepoDb_InsertAll              | 2,377.68 ms | 19.831 ms | 16.560 ms | 2,375.35 ms |   10 |  6000.0000 | 3000.0000 |         - |  47150.77 KB |
