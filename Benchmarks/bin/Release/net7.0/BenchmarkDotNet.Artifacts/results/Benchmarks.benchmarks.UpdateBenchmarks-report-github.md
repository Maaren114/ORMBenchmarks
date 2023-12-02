```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-ZPHAYP : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

MaxIterationCount=100  

```
| Method              | Mean       | Error    | StdDev   | Rank | Gen0       | Gen1       | Gen2      | Allocated |
|-------------------- |-----------:|---------:|---------:|-----:|-----------:|-----------:|----------:|----------:|
| EFCoreExecuteSql    |   186.0 ms |  2.20 ms |  1.95 ms |    1 |          - |          - |         - |   7.76 MB |
| EFCoreExecuteRaw    |   191.1 ms |  1.53 ms |  1.20 ms |    2 |          - |          - |         - |   7.79 MB |
| EFCoreBorisDjUpdate |   202.1 ms |  3.98 ms |  6.65 ms |    3 |  2666.6667 |  1000.0000 |  333.3333 |  15.33 MB |
| EFCoreUpdateRange   | 1,128.8 ms | 19.80 ms | 17.56 ms |    4 | 33000.0000 | 10000.0000 | 4000.0000 | 177.95 MB |
