using System;
using System.Collections.Generic;
using Anlog.Entries;
using Xunit.Abstractions;

namespace Anlog.Sinks.XUnit
{
    /// <summary>
    /// Writes the output to a xUnit test runner.
    /// </summary>
    public class TestOutputSink : ILogSink
    {
        /// <inheritdoc />
        public LogLevel? MinimumLevel { get; set; }

        /// <inheritdoc />
        public ILogFormatter Formatter { get; }

        /// <summary>
        /// xUnit output helper.
        /// </summary>
        private readonly ITestOutputHelper output;

        /// <summary>
        /// Renderer factory method.
        /// </summary>
        private readonly Func<IDataRenderer> renderer;

        /// <summary>
        /// Initializes a new instance of <see cref="TestOutputSink"/>.
        /// </summary>
        /// <param name="output">xUnit output helper.</param>
        /// <param name="formatter">Log formatter.</param>
        /// <param name="renderer">Renderer factory method.</param>
        /// <param name="minimumLevel">Minimum log level. The default is the logger minimum level.</param>
        public TestOutputSink(ITestOutputHelper output, ILogFormatter formatter, Func<IDataRenderer> renderer, 
            LogLevel? minimumLevel = null)
        {
            Formatter = formatter;
            MinimumLevel = minimumLevel;
            this.renderer = renderer;
            this.output = output;
        }

        /// <inheritdoc />
        public void Write(LogLevelName level, List<ILogEntry> entries)
        {
            if (MinimumLevel.HasValue && MinimumLevel > level.Level)
            {
                return;
            }

            output.WriteLine(Formatter.Format(level, entries, renderer()));
        }
    }
}