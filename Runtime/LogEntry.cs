using UnityEngine;

namespace Logger.Runtime
{
    internal struct LogEntry
    {
        internal string Message { get; set; }
        internal LogType Type { get; set; }
        internal string Timestamp { get; set; }
        internal string StackTrace { get; set; }
    }
}