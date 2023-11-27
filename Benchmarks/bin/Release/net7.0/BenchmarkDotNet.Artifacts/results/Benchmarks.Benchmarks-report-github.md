```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
| Method                  | Mean     | Error     | StdDev   | Median   | Rank | Gen0      | Gen1      | Allocated |
|------------------------ |---------:|----------:|---------:|---------:|-----:|----------:|----------:|----------:|
| EFBorisDjCreate         | 80.69 ms |  6.141 ms | 16.71 ms | 75.94 ms |    1 | 2000.0000 | 1000.0000 |  14.93 MB |
| EFCoreZzzProjectsCreate | 86.19 ms | 19.057 ms | 54.06 ms | 60.58 ms |    2 |  200.0000 |         - |   1.49 MB |
