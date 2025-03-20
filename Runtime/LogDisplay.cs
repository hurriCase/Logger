using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logger.Runtime
{
    /// <summary>
    /// MonoBehaviour component that provides UI controls for the LogCollector.
    /// </summary>
    public sealed class LogDisplay : MonoBehaviour
    {
        [SerializeField] private Button _collectLogsButton;
        [SerializeField] private Button _startCollectButton;
        [SerializeField] private Button _stopCollectButton;
        [SerializeField] private Button _clearLogsButton;
        [SerializeField] private TMP_Text _statusText;

        private void Awake()
        {
            _collectLogsButton?.onClick.AddListener(CopyLogs);
            _startCollectButton?.onClick.AddListener(StartCollect);
            _stopCollectButton?.onClick.AddListener(StopCollect);
            _clearLogsButton?.onClick.AddListener(ClearLogs);
        }

        private void CopyLogs()
        {
            LogCollector.CopyLogs();

            if (_statusText is null)
                return;

            _statusText.text = "Logs copied to clipboard";
            CancelInvoke(nameof(ResetStatusText));
            Invoke(nameof(ResetStatusText), 5f);
        }

        private void StartCollect() => LogCollector.StartCollection();

        private void StopCollect() => LogCollector.StopCollection();

        private void ClearLogs() => LogCollector.ClearLogs();

        private void ResetStatusText()
        {
            if (_statusText)
                _statusText.text = string.Empty;
        }

        private void OnDestroy()
        {
            _collectLogsButton?.onClick.RemoveListener(CopyLogs);
            _startCollectButton?.onClick.RemoveListener(StartCollect);
            _stopCollectButton?.onClick.RemoveListener(StopCollect);
            _clearLogsButton?.onClick.RemoveListener(ClearLogs);
        }
    }
}