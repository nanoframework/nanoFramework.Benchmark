# nanoFramework.Benchmark

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=nanoframework_nanoFramework.Benchmark&metric=alert_status)](https://sonarcloud.io/dashboard?id=nanoframework_nanoFramework.Benchmark) [![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=nanoframework_nanoFramework.Benchmark&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=nanoframework_nanoFramework.Benchmark) [![#yourfirstpr](https://img.shields.io/badge/first--timers--only-friendly-blue.svg)](https://github.com/nanoframework/Home/blob/main/CONTRIBUTING.md) [![Discord](https://img.shields.io/discord/478725473862549535.svg?logo=discord&logoColor=white&label=Discord&color=7289DA)](https://discord.gg/gCyBu8T)

![nanoFramework logo](https://raw.githubusercontent.com/nanoframework/Home/main/resources/logo/nanoFramework-repo-logo.png)

-----

## Welcome to the .NET **nanoFramework** Benchmark repository

## Build status

| Component | Build Status | NuGet Package |
|:-|---|---|
| nanoFramework.Benchmark | [![Build Status](https://dev.azure.com/nanoframework/nanoFramework.Benchmark/_apis/build/status/nanoFramework.Benchmark?repoName=nanoframework%2FnanoFramework.Benchmark&branchName=main)](https://dev.azure.com/nanoframework/nanoFramework.Benchmark/_build/latest?definitionId=97&repoName=nanoframework%2FnanoFramework.Benchmark&branchName=main) | [![NuGet](https://img.shields.io/nuget/v/nanoFramework.Benchmark.svg?label=NuGet&style=flat&logo=nuget)](https://www.nuget.org/packages/nanoFramework.Benchmark/) |

## What is the .NET **nanoFramework** Benchmark

The nanoFramework.Benchmark tool helps you to measure and track performance of the nanoFramework code.
You can easily turn normal method into benchmark by just adding one attribute!

Heavily inspired by [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet).

Example bellow will:

1. Run Setup method once before running any benchmark method.
2. Run each benchmark method 10 time.
3. Prepare data to be passed into each parses.
4. Invoke ConsoleParser (prints data in console as table).

```csharp
public class CompareObjectTypesBenchmark
{
    object[] array;

    [Setup]
    public void Setup()
    {
        array = new object[] {
                    (int)42,
                    (byte)42,
                    "This is a super string",
                    (ulong)42,
                    new Version(4, 2)
                };
    }

    [Benchmark]
    public void CompareByString()
    {
        for (int i = 0; i < array.Length; i++)
        {
            object obja = array.GetValue(i);
            var typea = obja.GetType();
            CompareUsingString(typea);
        }
    }

    [Benchmark]
    public void CompareUsingTypeofIf()
    {
        for (int i = 0; i < array.Length; i++)
        {
            object obja = array.GetValue(i);
            var typea = obja.GetType();
            CompareUsingTypeofIf(typea);
        }
    }

    [Benchmark]
    public void CompareUsingTypeofIfReturn()
    {
        for (int i = 0; i < array.Length; i++)
        {
            object obja = array.GetValue(i);
            var typea = obja.GetType();
            CompareUsingTypeofIfReturn(typea);
        }
    }
}
```

Output:

```text
Console export: CompareObjectTypesBenchmark benchmark class.
| MethodName                 | ItterationCount | Mean  | Min   | Max   |
| -------------------------------------------------------------------- |
| CompareByString            | 10              | 10 ms | 10 ms | 10 ms |
| CompareUsingTypeofIf       | 10              | 3 ms  | 0 ms  | 10 ms |
| CompareUsingTypeofIfReturn | 10              | 5 ms  | 0 ms  | 10 ms |
```

## Attributes

### Class

#### IterationCount

Specify how many times each benchmark method needs to be invoked when running benchmark methods. Default is 10.

### Logger

Sometimes you can try something that benchmark library does not support. In such situation, instead of debugging code, you may inject logger object. 

#### DebugLogger

Wrapper around nanoFramework.Logging.Debug. Prints logs to console.

### Methods

#### Setup

SetupAttribute is used to specify which method should be invoked only once before running benchmark methods.
It can be used to initialize collections/objects etc.
The execution time of setup method is not taken into account when calculating benchmark results.

Note, that setup method must be public and without parameters.

#### Benchmark

BenchmarkAttribute is used to specify which method should be invoked as benchmark.

Note, that benchmark method must be public and without parameters.

#### Baseline

BaselineAttribute is used to specify which method should be considered as baseline for calculation. Add new colum "Ratio" to output.

### Parsers

You can specify parsers as attributes on class. Every parsers is invoked after benchmark run, so you can get results in multiple formats.  

By default only ConsoleParser is applied.

New parses can be easily implement by creating new class and implementing IResultParses interface. Also new attribute needs to be  

#### ConsoleParser

You can use **CsvParserAttribute** to add parser which prints data in console in table format.

Output example

```text
Console export: CompareObjectTypesBenchmark benchmark class.
| MethodName                 | ItterationCount | Mean   | Min  | Max   |
| -------------------------------------------------------------------- |
| CompareByString            | 100             | 8.9 ms | 0 ms | 10 ms |
| CompareUsingTypeofIf       | 100             | 4.1 ms | 0 ms | 10 ms |
| CompareUsingTypeofIfReturn | 100             | 4.2 ms | 0 ms | 10 ms |
```

#### CsvParser

You can use **CsvParserAttribute** to add parser which prints data in console in CSV format.

Output example

```text
CSV export: CompareObjectTypesBenchmark benchmark class.
MethodName;ItterationCount;Mean;Min;Max
CompareByString;100;8.9 ms;0 ms;10 ms
CompareUsingTypeofIf;100;4.1 ms;0 ms;10 ms
CompareUsingTypeofIfReturn;100;4.2 ms;0 ms;10 ms
```

## Feedback and documentation

For documentation, providing feedback, issues and finding out how to contribute please refer to the [Home repo](https://github.com/nanoframework/Home).

Join our Discord community [here](https://discord.gg/gCyBu8T).

## Credits

The list of contributors to this project can be found at [CONTRIBUTORS](https://github.com/nanoframework/Home/blob/main/CONTRIBUTORS.md).

## License

The **nanoFramework** Class Libraries are licensed under the [MIT license](LICENSE.md).

## Code of Conduct

This project has adopted the code of conduct defined by the Contributor Covenant to clarify expected behaviour in our community.
For more information see the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

### .NET Foundation

This project is supported by the [.NET Foundation](https://dotnetfoundation.org).
