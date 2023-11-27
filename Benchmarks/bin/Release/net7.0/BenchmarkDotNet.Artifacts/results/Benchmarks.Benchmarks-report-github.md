```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
| Method        | Mean        | Error      | StdDev      | Median      | Rank | Gen0      | Gen1      | Gen2     | Allocated |
|-------------- |------------:|-----------:|------------:|------------:|-----:|----------:|----------:|---------:|----------:|
| EFCoreCreate1 |    83.84 ms |   4.821 ms |    12.36 ms |    82.25 ms |    1 | 2500.0000 | 1000.0000 | 250.0000 |  14.93 MB |
| EFCoreCreate2 |   302.93 ms |  68.551 ms |   199.97 ms |   180.70 ms |    2 | 2333.3333 | 1000.0000 |        - |  14.94 MB |
| EFCoreCreate3 | 2,482.11 ms | 521.087 ms | 1,511.77 ms | 2,101.06 ms |    3 | 2000.0000 | 1000.0000 |        - |     15 MB |
