```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-TGBMRU : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

InvocationCount=1  MaxIterationCount=100  UnrollFactor=1  

```
| Method                  | Mean      | Error    | StdDev    | Median    | Rank | Gen0      | Gen1      | Allocated   |
|------------------------ |----------:|---------:|----------:|----------:|-----:|----------:|----------:|------------:|
| LinqToDbBulkCopy        |  38.32 ms | 4.172 ms | 11.903 ms |  34.49 ms |    1 |         - |         - |   380.77 KB |
| EFCoreZzzProjectsCreate |  48.30 ms | 0.958 ms |  1.652 ms |  48.08 ms |    2 |         - |         - |  1491.23 KB |
| DapperPlus              |  49.58 ms | 4.180 ms | 11.513 ms |  47.18 ms |    2 |         - |         - |  3114.96 KB |
| EFBorisDjCreate         |  71.23 ms | 3.721 ms | 10.555 ms |  65.71 ms |    3 | 2000.0000 | 1000.0000 | 14377.82 KB |
| DapperExecute           | 169.47 ms | 3.370 ms |  8.140 ms | 168.50 ms |    4 |         - |         - |  8161.88 KB |
| LinqToDbExecute         | 179.62 ms | 3.472 ms |  3.999 ms | 180.22 ms |    5 |         - |         - |  12553.4 KB |
| EFCoreExecuteSql        | 183.76 ms | 2.362 ms |  1.844 ms | 183.47 ms |    6 |         - |         - | 13214.45 KB |
| EFCoreExecuteSqlRaw     | 188.03 ms | 3.758 ms |  6.483 ms | 186.19 ms |    6 |         - |         - | 13213.98 KB |
