using Anlog.Factories;
using Anlog.Formatters.CompactKeyValue;
using Anlog.Renderers;
using Xunit.Abstractions;

namespace Anlog.Sinks.XUnit
{
    /// <summary>
    /// Factory for the xUnit Test Output Sink.
    /// </summary>
    public static class TestOutputSinkFactory
    {
        /// <summary>
        /// Writes the output to a xUnit test runner.
        /// </summary>
        /// <param name="sinksFactory">Sinks factory.</param>
        /// <param name="output">xUnit output helper.</param>
        /// <param name="minimumLevel">Minimum log level. The default is the logger minimum level.</param>
        /// <param name="formatter">Log formatter to be used. The default is
        /// <see cref="CompactKeyValueFormatter"/>.</param>
        /// <returns>Logger factory.</returns>
        public static LoggerFactory TestOutput(this LogSinksFactory sinksFactory, ITestOutputHelper output, 
            LogLevel? minimumLevel = null, ILogFormatter formatter = null)
        {
            formatter = formatter ?? new CompactKeyValueFormatter();

            var sink = new TestOutputSink(output, formatter, () => new DefaultDataRenderer(), minimumLevel);
            sinksFactory.Sinks.Add(sink);
            
            return sinksFactory.Factory;
        }
    }
}