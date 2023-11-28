```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-QYLAGE : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  MaxIterationCount=100  UnrollFactor=1  

```
| Method                  | Mean      | Error    | StdDev   | Median    | Rank | Gen0      | Gen1      | Allocated   |
|------------------------ |----------:|---------:|---------:|----------:|-----:|----------:|----------:|------------:|
| LinqToDbBulkCopy        |  26.76 ms | 1.408 ms | 3.948 ms |  24.82 ms |    1 |         - |         - |    381.1 KB |
| DapperPlus              |  44.39 ms | 1.776 ms | 4.891 ms |  42.03 ms |    2 |         - |         - |   4661.3 KB |
| EFCoreZzzProjectsCreate |  46.66 ms | 3.075 ms | 8.521 ms |  41.51 ms |    2 |         - |         - |  1372.45 KB |
| EFBorisDjCreate         |  69.01 ms | 2.961 ms | 8.304 ms |  64.17 ms |    3 | 2000.0000 | 1000.0000 | 14538.98 KB |
| EFCoreExecuteSql        | 180.80 ms | 2.057 ms | 1.606 ms | 180.91 ms |    4 |         - |         - |  5008.41 KB |
| DapperExecute           | 182.44 ms | 3.627 ms | 8.689 ms | 179.25 ms |    4 |         - |         - |  5003.18 KB |
| LinqToDbExecute         | 185.68 ms | 3.671 ms | 5.266 ms | 184.10 ms |    5 |         - |         - |  4996.88 KB |
| EFCoreExecuteSqlRaw     | 189.13 ms | 3.716 ms | 6.209 ms | 187.85 ms |    5 |         - |         - |  5005.57 KB |
