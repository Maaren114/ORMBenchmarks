```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-PUHSPS : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

MaxIterationCount=1000  

```
| Method                     | Mean       | Error    | StdDev   | Rank | Gen0       | Gen1      | Allocated |
|--------------------------- |-----------:|---------:|---------:|-----:|-----------:|----------:|----------:|
| EFCore_FromSqlRaw          |   291.4 ms |  3.08 ms |  2.73 ms |    1 |   500.0000 |         - |   6.84 MB |
| PetaPoco_Fetch             |   293.6 ms |  5.81 ms |  6.22 ms |    1 |   500.0000 |         - |   5.26 MB |
| RepoDb_ExecuteQuery        |   296.3 ms |  5.68 ms |  6.07 ms |    1 |   500.0000 |         - |   5.37 MB |
| Dapper_Query               |   303.1 ms |  5.49 ms |  5.14 ms |    2 |   500.0000 |         - |   7.39 MB |
| NormNet_Read               |   306.3 ms |  6.05 ms | 10.28 ms |    2 |  1000.0000 |  500.0000 |   8.46 MB |
| NHibernate_CreateSqlQuery  |   320.9 ms |  6.39 ms | 11.53 ms |    3 |  2000.0000 | 1000.0000 |  17.59 MB |
| LinqToDb_Where             | 1,329.3 ms | 16.15 ms | 15.11 ms |    4 |          - |         - |   5.32 MB |
| EFCore_Where               | 1,341.2 ms | 12.08 ms | 10.71 ms |    4 |  2000.0000 | 1000.0000 |  15.69 MB |
| OrmLite_Select             | 2,222.0 ms | 43.00 ms | 42.23 ms |    5 |  2000.0000 | 1000.0000 |  16.62 MB |
| NHibernate_CreateCriteria  | 2,276.0 ms | 24.62 ms | 21.82 ms |    6 | 14000.0000 | 6000.0000 |  94.98 MB |
| NHibernate_Query_Linq      | 2,283.2 ms | 29.47 ms | 26.13 ms |    6 | 13000.0000 | 6000.0000 |  83.46 MB |
| NHibernate_CreateQuery_Hql | 2,290.3 ms | 21.92 ms | 19.43 ms |    6 | 12000.0000 | 5000.0000 |   79.7 MB |
| RepoDb_Query               | 2,350.9 ms | 25.21 ms | 21.05 ms |    7 | 25000.0000 | 4000.0000 | 155.51 MB |
| RepoDb_BatchQuery          | 2,369.6 ms | 34.09 ms | 30.22 ms |    7 | 25000.0000 | 4000.0000 | 155.52 MB |
