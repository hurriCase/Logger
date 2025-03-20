using UnityEngine;

namespace Logger.Runtime
{
    /// <summary>
    /// ScriptableObject that stores configuration settings for the LogCollector.
    /// </summary>
    internal sealed class LogCollectorSettings : ScriptableObject
    {
        private static LogCollectorSettings _instance;

        internal static LogCollectorSettings Instance
            => _instance ?? (_instance = Resources.Load<LogCollectorSettings>(nameof(LogCollectorSettings)));

        [field: SerializeField] internal int MaxLogEntries { get; private set; } = 500;
        [field: SerializeField] internal bool CaptureStackTrace { get; private set; } = true;
        [field: SerializeField] internal bool AutoStartCollect { get; private set; } = true;
        [field: SerializeField] internal LogType MinimumLogLevel { get; private set; } = LogType.Warning;
    }
}