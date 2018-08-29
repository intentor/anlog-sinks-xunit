using Xunit;
using Xunit.Abstractions;

namespace Anlog.Sinks.XUnit.Tests
{
    /// <summary>
    /// Tests for <see cref="TestOutputHelperExtensions"/>.
    /// </summary>
    public sealed class TestOutputHelperExtensionsTests
    {
        public TestOutputHelperExtensionsTests(ITestOutputHelper output)
        {
            output.WriteLogs();
        }

        [Fact]
        public void WhenWritingLogsToTestOutput_SinkIsCreated()
        {
            Assert.NotNull(Log.Logger);
            Assert.Single(Log.Logger.Sinks);
            Assert.Equal(typeof(TestOutputSink), Log.Logger.Sinks[0].GetType());
        }
    }
}