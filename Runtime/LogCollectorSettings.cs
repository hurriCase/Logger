using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#endif

namespace Logger.Runtime
{
    /// <summary>
    /// ScriptableObject that stores configuration settings for the LogCollector.
    /// </summary>
    internal sealed class LogCollectorSettings : ScriptableObject
    {
        private static LogCollectorSettings _instance;
        private const string ResourcesPath = "Assets/Logger/Resources";
        private const string SettingsFileName = "LogCollectorSettings";

        internal static LogCollectorSettings Instance
        {
            get
            {
                if (_instance)
                    return _instance;

                _instance = Resources.Load<LogCollectorSettings>(SettingsFileName);

                if (_instance)
                    return _instance;

                _instance = CreateInstance<LogCollectorSettings>();

#if UNITY_EDITOR

                if (Directory.Exists(ResourcesPath) is false)
                {
                    Directory.CreateDirectory(ResourcesPath);
                    AssetDatabase.Refresh();
                }

                AssetDatabase.CreateAsset(_instance, $"{ResourcesPath}/{SettingsFileName}.asset");
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                Debug.Log($"[LogCollector] Created settings asset at {ResourcesPath}/{SettingsFileName}.asset");
#endif

                return _instance;
            }
        }

        [field: SerializeField] internal int MaxLogEntries { get; private set; } = 500;
        [field: SerializeField] internal bool CaptureStackTrace { get; private set; } = true;
        [field: SerializeField] internal bool AutoStartCollect { get; private set; } = true;
        [field: SerializeField] internal LogType MinimumLogLevel { get; private set; } = LogType.Warning;
    }
}