# ![Anlog](https://user-images.githubusercontent.com/5340818/38121535-4b734df8-33a6-11e8-98aa-e9b8d7234de0.png)

**(Yet) Another .NET Logger - xUnit Sink**

[![NuGet Version](http://img.shields.io/nuget/v/Anlog.Sinks.xUnit.svg?style=flat)](https://www.nuget.org/packages/Anlog.Sinks.xUnit/)

Allows writing of logs to the xUnit test console using *[Anlog](https://github.com/intentor/anlog)*.

## Contents

1. [Quick start](#quick-start)
1. [License](#license)

## Quick start

Install *Anlog.Sinks.xUnit* from the NuGet Gallery in the test project:

```
Install-Package Anlog.Sinks.xUnit
```

In a xUnit test, receive the `ITestOutputHelper` through constructor and call the `WriteAnlog()` method:

```cs
using Xunit;
using Xunit.Abstractions;
using Anlog.Sinks.XUnit;

namespace MyProject.Tests
{
    public sealed class MyTest
    {
        public MyTest(ITestOutputHelper output)
        {
            output.WriteAnlog();
        }
        
        [Fact]
        public void WhenSomething_ThenTest()
        {
            ...
        }
    }
}
```

Any logs written to *Anlog* will then be forwarded to the xUnit test output console.

## License

Licensed under the [The MIT License (MIT)](http://opensource.org/licenses/MIT). Please see [LICENSE](https://raw.githubusercontent.com/intentor/anlog-sinks-xunit/master/LICENSE) for more information.