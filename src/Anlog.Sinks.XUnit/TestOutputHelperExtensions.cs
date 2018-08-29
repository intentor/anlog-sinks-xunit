using Anlog.Factories;
using Xunit.Abstractions;

namespace Anlog.Sinks.XUnit
{
    /// <summary>
    /// Extensions for <see cref="ITestOutputHelper"/>.
    /// </summary>
    public static class TestOutputHelperExtensions
    {
        /// <summary>
        /// Writes logs from Anlog to xUnit test output helper.
        /// </summary>
        /// <param name="output">xUnit test output.</param>
        public static void WriteAnlog(this ITestOutputHelper output)
        {
            Log.Logger = new LoggerFactory()
                .WriteTo.TestOutput(output)
                .CreateLogger();
        }
    }
}