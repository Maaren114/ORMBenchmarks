```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-MTWWLH : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

MaxIterationCount=100  

```
| Method                   | Mean       | Error    | StdDev    | Rank | Gen0       | Gen1      | Gen2      | Allocated |
|------------------------- |-----------:|---------:|----------:|-----:|-----------:|----------:|----------:|----------:|
| OrmLiteSqlList           |         NA |       NA |        NA |    ? |         NA |        NA |        NA |        NA |
| RepoDbExecuteQuery       |   300.7 ms |  3.34 ms |   2.96 ms |    1 |   500.0000 |         - |         - |   5.56 MB |
| PetaPocoFetch            |   303.9 ms |  5.92 ms |   7.05 ms |    1 |   500.0000 |         - |         - |   5.44 MB |
| EFCoreFromSql            |   329.7 ms |  6.53 ms |  13.19 ms |    2 |          - |         - |         - |   6.05 MB |
| EFCoreFromSqlRaw         |   334.4 ms |  6.50 ms |  11.21 ms |    2 |   500.0000 |         - |         - |   6.05 MB |
| NormNetRead              |   335.7 ms |  6.78 ms |  19.56 ms |    2 |  1000.0000 |  500.0000 |         - |   8.77 MB |
| NHibernateRawSql         |   341.5 ms |  6.59 ms |  18.14 ms |    2 |  2000.0000 | 1000.0000 |         - |  19.14 MB |
| DapperExecute            |   342.1 ms |  8.46 ms |  23.73 ms |    2 |          - |         - |         - |   6.63 MB |
| EFCoreSelect             | 1,347.0 ms | 17.69 ms |  14.77 ms |    3 |  2000.0000 | 1000.0000 |         - |  16.25 MB |
| LinqToDbSelect           | 1,382.0 ms | 27.01 ms |  32.15 ms |    4 |          - |         - |         - |   4.09 MB |
| OrmLiteSelect            | 2,286.0 ms | 20.04 ms |  15.65 ms |    5 |  2000.0000 | 1000.0000 |         - |  17.19 MB |
| NHibernateCreateCriteria | 2,359.4 ms | 41.20 ms |  34.41 ms |    6 | 16000.0000 | 7000.0000 | 1000.0000 |  98.23 MB |
| RepoDbQuery              | 2,368.0 ms | 32.93 ms |  27.50 ms |    6 | 26000.0000 | 4000.0000 |         - | 159.16 MB |
| NHibernateCreateQueryHql | 2,558.5 ms | 58.35 ms | 171.12 ms |    7 | 13000.0000 | 5000.0000 | 1000.0000 |  82.56 MB |
| NHibernateQueryLinq      | 2,609.4 ms | 51.00 ms | 109.77 ms |    7 | 14000.0000 | 6000.0000 | 1000.0000 |  86.42 MB |

Benchmarks with issues:
  SelectBenchmarks.OrmLiteSqlList: Job-MTWWLH(MaxIterationCount=100)
