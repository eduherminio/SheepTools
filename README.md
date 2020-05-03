# SheepTools

[![Azure DevOps][azuredevopslogo]][azuredevopslink]
[![GitHub Actions][githubactionslogo]][githubactionslink]

[![Code coverage][coveragelogo]][coveragelink]
[![Sonar Quality][sonarqualitylogo]][sonarqubelink]
[![Sonar vulnerabilities][sonarvulnerabilitieslogo]][sonarqubelink]
[![Sonar bugs][sonarbugslogo]][sonarqubelink]
[![Sonar code smells][sonarcodesmellslogo]][sonarqubelink]

[![Nuget][nugetlogo]][nugetlink]
[![Nuget][nugetlogo-moq]][nugetlink-moq]
[![Nuget][nugetlogo-xunit]][nugetlink-xunit]

Sheeptools is (yet another) toolbox library which contains handy classes, extension methods, etc.

It's dividided in different libraries so that using the general purpose, main one doesn't imply adding any transitive dependencies to your project.

I'm more than happy to accept suggestions, comments, or addition proposals.

## Content

- [SheepTools](#sheeptools)

  - [Point](#point)
  - [Line](#line)
  - [Point3D](#point3d)
  - [TreeNode](#tree-node)
  - [Node](#node)
  - [Ensure](#ensure)
  - [RangeHelpers](#rangehelpers)
  - [LinearInterpolation](#lerp)
  - [AssemblyExtensions](#collection-extensions)
  - [CollectionExtensions](#datetime-extensions)
  - [DateTimeExtensions](#assembly-extensions)
  - [DoubleExtensions](#double-extensions)
  - [EnumerableExtensions](#enumerable-extensions)
  - [IntExtensions](#int-extensions)
  - [NumericExtensions](#numeric-extensions)
  - [StringExtensions](#string-extensions)

- [SheepTools.Moq](#sheeptools-moq)

  - [MoqLoggerExtensions](#moq-logger-extensions)
  - [MoqGenericLoggerExtensions](#moq-genericlogger-extensions)

- [SheepTools.XUnit](#paragraph2)

  - [Asssert](#asssert)

---

<a name="sheeptools"></a>

## SheepTools

[![Nuget][nugetlogo]][nugetlink]

[nugetlogo]: https://img.shields.io/nuget/v/SheepTools.svg?style=flat-square&label=nuget
[nugetlink]: https://www.nuget.org/packages/SheepTools

<a name="point"></a>

### Point

2D Point class.

<a name="line"></a>

### Line

2D (straight) line class.

<a name="point3d"></a>

### Point3D

3D point class.

<a name="tree-node"></a>

### TreeNode

[Tree](<https://en.wikipedia.org/wiki/Tree_(data_structure)>) node class with a generic key.

<a name="node"></a>

### Node

[Tree](<https://en.wikipedia.org/wiki/Tree_(data_structure)>) node class with a `string` key.

Essentially, `TreeNode<string>`.

<a name="ensure"></a>

### Ensure

Assert-style class that throws exceptions when things don't go as expected.

- `Equal()` / `NotEqual()`
- `True()` / `False()`
- `Null()` / `NotNull()`
- `Empty()` / `NotEmpty()`
- `NullOrEmpty()` / `NotNullOrEmpty()`
- `NullOrWhiteSpace()` / `NotNullOrWhiteSpace()`
- `Count<T>(int, IEnumerable<T>, Func<T, bool>)`

<a name="rangehelpers"></a>

### RangeHelpers

Helper class to generate ranges of numbers before having to check if it was (a, b), [a, b] or (a, b] in Microsoft documentation every time I use `Enumberable.Range`.

- `GenerateRange(int, int)` -> [a, b]

<a name="lerp"></a>

### LinearInterpolation

Helper methods to interpolate 2D points

- `InterpolateLinearly(double, double, double, double, double)`
- `InterpolateYLinearly(double, Point, point)`
- `InterpolateXLinearly(double, Point, point)`

<a name="assembly-extensions"></a>

### AssemblyExtensions

- `GetTypes<TAttribute>()`
- `GetTypesAndAttributes<TAttribute>()`
- `GetAssemblies<TInterface>()`

<a name="collection-extensions"></a>

### CollectionExtensions

- `AddRange()`
- `RemoveAll()`

<a name="datetime-extensions"></a>

### DateTimeExtensions

- `IsAfterNow()`
- `IsAfter(DateTime)`
- `MillisecondsFromEpoch()`

<a name="double-extensions"></a>

### DoubleExtensions

- `DoubleEquals(double, precision)`

<a name="enumerable-extensions"></a>

### EnumerableExtensions

- `ForEach()`
- `IsNullOrEmpty()`

<a name="int-extensions"></a>

### IntExtensions

- `Factorial()`
- `Clamp(int, int)`

<a name="numeric-extensions"></a>

### NumericExtensions

- `Clamp<T>(T, T)`

<a name="string-extensions"></a>

### StringExtensions

- `IsEmpty()`
- `HasWhiteSpaces()`
- `Truncate(int)`

<a name="sheeptools-moq"></a>

## SheepTools.Moq

[![Nuget][nugetlogo]][nugetlink]

Depends on [Moq](https://github.com/moq/moq4) and [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging/).

<a name="moq-logger-extensions"></a>

### MoqLoggerExtensions

Helps verifying `ILogger` invocations.

- `VerifyLog(LogLevel, Message, Times)`

- `VerifyLog<TException>(LogLevel, Exception, Message, Times)`

<a name="moq-genericlogger-extensions"></a>

### MoqGenericLoggerExtensions

Helps verifying `ILogger<T>` invocations.

- `VerifyLog<T>(LogLevel, Message, Times)`

- `VerifyLog<T, TException>(LogLevel, Exception, Message, Times)`

<a name="sheeptools-xunit"></a>

## SheepTools.XUnit

[![Nuget][nugetlogo]][nugetlink]

<a name="asssert"></a>

Depends on [XUnit](https://xunit.net/).

### Asssert

- `DoesNotThrow(Action)`
- `DoesNotThrow(Func<object)`
- `DoesNotThrow(Func<Task>)`

[azuredevopslogo]: https://dev.azure.com/eduherminio/SheepTools/_apis/build/status/eduherminio.SheepTools?branchName=master
[azuredevopslink]: https://dev.azure.com/eduherminio/SheepTools/_build/latest?definitionId=1&branchName=master
[githubactionslogo]: https://github.com/eduherminio/SheepTools/workflows/CI%20GitHub%20Actions/badge.svg
[githubactionslink]: https://github.com/eduherminio/SheepTools/actions
[nugetlogo]: https://img.shields.io/nuget/v/SheepTools.svg?style=flat-square&label=nuget
[nugetlink]: https://www.nuget.org/packages/SheepTools
[nugetlogo-moq]: https://img.shields.io/nuget/v/SheepTools.Moq.svg?style=flat-square&label=nuget
[nugetlink-moq]: https://www.nuget.org/packages/SheepTools.Moq
[nugetlogo-xunit]: https://img.shields.io/nuget/v/SheepTools.XUnit.svg?style=flat-square&label=nuget
[nugetlink-xunit]: https://www.nuget.org/packages/SheepTools.XUnit
[coveragelogo]: https://img.shields.io/azure-devops/coverage/eduherminio/Sheeptools/8/master
[coveragelink]: https://dev.azure.com/eduherminio/SheepTools/_build/latest?definitionId=8&branchName=master
[sonarqubelink]: https://sonarcloud.io/dashboard?id=SheepTools
[sonarqualitylogo]: https://sonarcloud.io/api/project_badges/measure?project=SheepTools&metric=alert_status
[sonarvulnerabilitieslogo]: https://sonarcloud.io/api/project_badges/measure?project=SheepTools&metric=vulnerabilities
[sonarbugslogo]: https://sonarcloud.io/api/project_badges/measure?project=SheepTools&metric=bugs
[sonarcodesmellslogo]: https://sonarcloud.io/api/project_badges/measure?project=SheepTools&metric=code_smells
