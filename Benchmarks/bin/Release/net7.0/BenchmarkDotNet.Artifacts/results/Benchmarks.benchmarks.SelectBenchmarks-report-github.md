```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-YQDIIE : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                     | Mean       | Error    | StdDev   | Rank | Gen0       | Gen1      | Gen2      | Allocated |
|--------------------------- |-----------:|---------:|---------:|-----:|-----------:|----------:|----------:|----------:|
| Dapper_Query               |   318.7 ms |  6.21 ms |  6.38 ms |    1 |          - |         - |         - |   6.55 MB |
| RepoDb_ExecuteQuery        |   319.8 ms |  4.40 ms |  4.32 ms |    1 |          - |         - |         - |   5.52 MB |
| PetaPoco_Fetch             |   321.4 ms |  5.87 ms |  5.49 ms |    1 |          - |         - |         - |   5.41 MB |
| NormNet_Read               |   323.2 ms |  5.07 ms |  4.49 ms |    1 |  1000.0000 |         - |         - |   8.61 MB |
| EFCore_FromSqlRaw          |   327.0 ms |  4.22 ms |  3.30 ms |    1 |  2000.0000 | 1000.0000 |         - |   18.1 MB |
| NHibernate_CreateSqlQuery  |   344.5 ms |  5.91 ms |  5.24 ms |    2 |  2000.0000 | 1000.0000 |         - |  17.74 MB |
| OrmLite_Select             | 2,293.9 ms | 41.71 ms | 39.01 ms |    3 |  2000.0000 | 1000.0000 |         - |  16.77 MB |
| NHibernate_CreateQuery_Hql | 2,308.3 ms |  9.92 ms |  8.79 ms |    3 | 13000.0000 | 5000.0000 | 1000.0000 |  79.85 MB |
| NHibernate_Query_Linq      | 2,313.9 ms | 10.86 ms |  9.62 ms |    3 | 14000.0000 | 6000.0000 | 1000.0000 |  83.61 MB |
| NHibernate_CreateCriteria  | 2,322.9 ms | 12.34 ms | 11.54 ms |    3 | 15000.0000 | 7000.0000 | 1000.0000 |  95.13 MB |
| RepoDb_Query               | 2,350.3 ms | 19.10 ms | 17.87 ms |    3 | 25000.0000 | 4000.0000 |         - | 155.66 MB |
| RepoDb_BatchQuery          | 2,357.9 ms |  6.65 ms |  5.89 ms |    3 | 25000.0000 | 4000.0000 |         - | 155.67 MB |
| LinqToDb_Where             | 2,526.0 ms | 24.53 ms | 22.94 ms |    4 |          - |         - |         - |   5.47 MB |
| EFCore_Where               | 2,544.8 ms | 30.50 ms | 28.53 ms |    4 |  4000.0000 | 1000.0000 |         - |  27.73 MB |
