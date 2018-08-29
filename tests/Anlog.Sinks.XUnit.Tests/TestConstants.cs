using System.Collections.Generic;
using Anlog.Entries;
using Anlog.Formatters.LogLevelNames;

namespace Anlog.Sinks.XUnit.Tests
{
    /// <summary>
    /// Constants used in tests.
    /// </summary>
    public class TestConstants
    {
        /// <summary>
        /// Generic log level names.
        /// </summary>
        public static readonly ILogLevelName GenericLogLevelName = new ThreeLetterLogLevelName();

        /// <summary>
        /// Generic log entries.
        /// </summary>
        public static readonly List<ILogEntry> GenericLogEntries = new List<ILogEntry>()
        {
            new LogEntry("key1", "value1"),
            new LogEntry("key2", "value2")
        };

        /// <summary>
        /// Generic log text.
        /// </summary>
        public const string GenericLogText = "key1=value1 key2=value2";
    }
}