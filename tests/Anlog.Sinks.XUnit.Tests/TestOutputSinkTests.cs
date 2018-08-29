using Anlog.Formatters.CompactKeyValue;
using Anlog.Renderers;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Anlog.Sinks.XUnit.Tests
{
    /// <summary>
    /// Tests for <see cref="TestOutputSink"/>.
    /// </summary>
    public sealed class TestOutputSinkTests
    {
        /// <summary>
        /// Mock of the xUnit log output.
        /// </summary>
        private Mock<ITestOutputHelper> outputMock;

        /// <summary>
        /// Object being tested.
        /// </summary>
        private TestOutputSink sink;

        public TestOutputSinkTests()
        {
            outputMock = new Mock<ITestOutputHelper>();
            sink = new TestOutputSink(outputMock.Object, new CompactKeyValueFormatter(), 
                () => new DefaultDataRenderer(), LogLevel.Info);
        }

        [Fact]
        public void WhenWritingLogsAboveMinimumLevel_WriteToOutput()
        {
            sink.Write(TestConstants.GenericLogLevelName.Info, TestConstants.GenericLogEntries);
            
            outputMock.Verify(m => m.WriteLine(It.Is<string>(s => s.EndsWith(TestConstants.GenericLogText))), Times.Once());
        }

        [Fact]
        public void WhenWritingLogsBelowMinimumLevel_DoNotWriteToOutput()
        {
            sink.Write(TestConstants.GenericLogLevelName.Debug, TestConstants.GenericLogEntries);
            
            outputMock.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Never);
        }
    }
}