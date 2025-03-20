using Logger.Runtime;
using UnityEditor;
using UnityEngine;

namespace Logger.Editor
{
    /// <summary>
    /// Custom editor window that allows configuring LogCollector settings.
    /// </summary>
    public sealed class LogCollectorEditorWindow : EditorWindow
    {
        [MenuItem("Tools/Log Collector Settings")]
        public static void ShowWindow()
        {
            GetWindow<LogCollectorEditorWindow>("Log Collector Settings");
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(10);
            GUILayout.Label("Log Collector Settings", EditorStyles.boldLabel);
            EditorGUILayout.Space(5);

            EditorGUI.BeginChangeCheck();

            var logCollectorSettings = LogCollectorSettings.Instance;

            var serializedObject = new SerializedObject(logCollectorSettings);

            var maxLogEntriesProp =
                serializedObject.FindProperty(ConvertToBackingField(nameof(logCollectorSettings.MaxLogEntries)));
            var captureStackTraceProp =
                serializedObject.FindProperty(ConvertToBackingField(nameof(logCollectorSettings.CaptureStackTrace)));
            var autoStartCollectProp =
                serializedObject.FindProperty(ConvertToBackingField(nameof(logCollectorSettings.AutoStartCollect)));
            var minimumLogLevelProp =
                serializedObject.FindProperty(ConvertToBackingField(nameof(logCollectorSettings.MinimumLogLevel)));

            EditorGUILayout.PropertyField(maxLogEntriesProp, new GUIContent("Max Log Entries"));
            EditorGUILayout.PropertyField(captureStackTraceProp, new GUIContent("Capture Stack Trace"));
            EditorGUILayout.PropertyField(autoStartCollectProp, new GUIContent("Auto Start Collect"));
            EditorGUILayout.PropertyField(minimumLogLevelProp, new GUIContent("Minimum Log Level"));

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(logCollectorSettings);
                AssetDatabase.SaveAssets();
            }

            EditorGUILayout.Space(15);

            EditorGUILayout.Space(10);
        }

        private static string ConvertToBackingField(string propertyName)
            => $"<{propertyName}>k__BackingField";
    }
}