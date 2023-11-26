```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  Job-PBQBRR : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

MaxIterationCount=10000  

```
| Method        | Mean | Error | Rank |
|-------------- |-----:|------:|-----:|
| EFCoreCreate1 |   NA |    NA |    ? |
| EFCoreCreate2 |   NA |    NA |    ? |
| EFCoreCreate3 |   NA |    NA |    ? |

Benchmarks with issues:
  Benchmarks.EFCoreCreate1: Job-PBQBRR(MaxIterationCount=10000)
  Benchmarks.EFCoreCreate2: Job-PBQBRR(MaxIterationCount=10000)
  Benchmarks.EFCoreCreate3: Job-PBQBRR(MaxIterationCount=10000)
