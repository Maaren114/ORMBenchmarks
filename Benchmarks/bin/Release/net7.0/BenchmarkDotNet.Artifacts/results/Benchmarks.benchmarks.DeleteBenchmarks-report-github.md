```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2 [AttachedDebugger]
  Job-HZIYGO : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

MaxIterationCount=100  

```
| Method                  | Mean             | Error           | StdDev          | Rank | Gen0      | Gen1   | Allocated  |
|------------------------ |-----------------:|----------------:|----------------:|-----:|----------:|-------:|-----------:|
| DapperPlus              |         504.7 ns |         9.51 ns |         8.43 ns |    1 |    0.1221 |      - |      768 B |
| RepoDbBulkDelete        |       9,433.4 ns |        59.85 ns |        49.98 ns |    2 |    0.1678 |      - |     1096 B |
| RepoDbDeleteAll         |      86,070.8 ns |       892.85 ns |       745.57 ns |    3 |    0.8545 | 0.7324 |     5958 B |
| LinqToDbExecute         |     114,005.3 ns |     2,253.30 ns |     3,573.97 ns |    4 |         - |      - |      788 B |
| NormNetExecute          |     124,724.7 ns |     1,240.84 ns |     1,099.97 ns |    5 |    0.2441 |      - |     2083 B |
| DapperExecute           |     126,735.1 ns |     1,952.13 ns |     1,730.51 ns |    5 |    0.2441 |      - |     2612 B |
| OrmLiteBulkDelete       |     136,507.3 ns |     2,701.04 ns |     5,871.83 ns |    6 |    0.4883 |      - |     3332 B |
| PetaPocoExecute         |     144,544.2 ns |     1,169.72 ns |       913.24 ns |    7 |    0.4883 |      - |     3830 B |
| NHibernateBatchRaw      |     278,586.4 ns |     5,364.22 ns |     5,739.65 ns |    8 |    2.9297 |      - |    21306 B |
| EFCoreZzzProjectsCreate |   7,483,210.1 ns |   147,061.69 ns |   241,626.58 ns |    9 |         - |      - |    66502 B |
| EFBorisDjCreate         |  92,439,765.3 ns | 2,455,819.15 ns | 7,046,205.50 ns |   10 | 1000.0000 |      - | 10967504 B |
| EFCoreExecuteSqlRaw     | 131,387,317.6 ns | 2,481,312.29 ns | 2,548,125.03 ns |   11 |         - |      - | 14779440 B |
| EFCoreExecuteSql        | 132,422,953.8 ns | 1,853,875.71 ns | 1,548,070.18 ns |   11 |         - |      - | 10612096 B |
