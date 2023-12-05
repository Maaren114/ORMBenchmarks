```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-QPDSXW : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  MaxIterationCount=100  UnrollFactor=1  

```
| Method                  | Mean        | Error    | StdDev    | Median      | Rank | Gen0      | Gen1      | Gen2      | Allocated   |
|------------------------ |------------:|---------:|----------:|------------:|-----:|----------:|----------:|----------:|------------:|
| LinqToDbBulkCopy        |    25.43 ms | 0.258 ms |  0.201 ms |    25.42 ms |    1 |         - |         - |         - |    381.2 KB |
| EFCoreZzzProjectsCreate |    58.38 ms | 7.321 ms | 20.528 ms |    47.49 ms |    2 |         - |         - |         - |  1166.98 KB |
| EFBorisDjCreate         |    68.15 ms | 1.307 ms |  1.158 ms |    67.86 ms |    3 | 2000.0000 | 1000.0000 |         - | 14321.42 KB |
| OrmLiteBulkInsert       |    84.91 ms | 8.698 ms | 25.096 ms |    78.28 ms |    4 | 1000.0000 |         - |         - |  8314.95 KB |
| DapperPlus              |   141.00 ms | 3.691 ms | 10.884 ms |   143.53 ms |    5 |         - |         - |         - |   5706.8 KB |
| NHibernateBatchRaw      |   219.62 ms | 4.377 ms |  9.423 ms |   217.60 ms |    6 |         - |         - |         - |  14438.4 KB |
| DapperExecute           |   220.01 ms | 4.399 ms |  9.838 ms |   219.99 ms |    6 |         - |         - |         - |  14415.5 KB |
| PetaPocoExecute         |   222.08 ms | 4.320 ms |  5.913 ms |   221.28 ms |    6 |         - |         - |         - | 14422.82 KB |
| NormNetExecute          |   223.74 ms | 4.383 ms |  8.231 ms |   222.36 ms |    6 |         - |         - |         - |  14414.2 KB |
| EFCoreExecuteSqlRaw     |   223.98 ms | 4.388 ms |  4.506 ms |   224.08 ms |    6 |         - |         - |         - | 14457.57 KB |
| EFCoreExecuteSql        |   224.43 ms | 4.443 ms |  7.175 ms |   222.84 ms |    6 |         - |         - |         - | 14424.81 KB |
| LinqToDbExecute         |   230.27 ms | 4.570 ms | 10.408 ms |   229.45 ms |    6 |         - |         - |         - | 14411.75 KB |
| OrmLiteBulkInsertRaw    |   240.54 ms | 4.681 ms |  7.288 ms |   240.85 ms |    7 | 1000.0000 | 1000.0000 | 1000.0000 | 29999.66 KB |
| RepoDbInsertAll         | 2,379.83 ms | 8.834 ms |  8.263 ms | 2,379.66 ms |    8 | 6000.0000 | 3000.0000 |         - |  48898.1 KB |
| RepoDbBulkInsert        | 2,399.60 ms | 7.684 ms |  7.187 ms | 2,397.12 ms |    8 | 6000.0000 | 3000.0000 |         - |  48898.1 KB |
