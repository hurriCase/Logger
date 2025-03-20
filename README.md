# Unity Log Collector

A lightweight, easy-to-use logging solution for Unity projects that enables capturing and accessing logs in builds where the standard Unity console is not available.

## Overview

Unity Log Collector provides a simple way to capture, display, and share logs from your Unity application. This is particularly useful for:

- Debugging issues in release builds
- Collecting logs on mobile devices
- Retrieving logs from testers or users experiencing problems
- Monitoring application behavior in environments where the Unity console isn't accessible

## Features

- Capture Unity logs with configurable buffer size
- Optional stack trace capture
- Configurable minimum log level filtering
- Copy all logs to clipboard with device information
- UI components for displaying and controlling log collection
- Editor window for easy configuration

## Installation

1. Copy the `Logger` folder into your Unity project's Assets directory
2. Create a `LogCollectorSettings` asset in a Resources folder:
    - Right-click in your Project window
    - Select Create > ScriptableObject
    - Search for and select "LogCollectorSettings"
    - Name it "LogCollectorSettings"
    - Move it to a Resources folder (create one if needed)

## Usage

### Basic Setup

Initialize the log collector in your startup script:

```csharp
using Logger.Runtime;

void Start() {
    LogCollector.Init();
}
```

### Log Collection Control

Control log collection with these methods:

```csharp
// Start collecting logs
LogCollector.StartCollection();

// Stop collecting logs
LogCollector.StopCollection();

// Copy logs to clipboard
LogCollector.CopyLogs();

// Clear collected logs
LogCollector.ClearLogs();
```

### UI Integration

The package includes a `LogDisplay` component that can be attached to a UI canvas to provide user controls:

1. Add the `LogDisplay` component to a GameObject in your UI canvas
2. Assign UI buttons for each function (collect, start, stop, clear)
3. Optionally assign a TextMeshPro text component to display status messages

### Configuration

Configure the log collector through the `LogCollectorSettings` asset:

- **Max Log Entries**: Maximum number of log entries to keep in the buffer (default: 500)
- **Capture Stack Trace**: Whether to include stack traces with log entries (default: true)
- **Auto Start Collect**: Automatically start collecting logs on initialization (default: true)
- **Minimum Log Level**: Lowest log level to capture (default: Warning)

Access the settings editor window via `Tools > Log Collector Settings` in the Unity menu.

## Example

```csharp
// In your app startup script
void Awake() {
    LogCollector.Init();
    
    // Logs will be collected automatically if AutoStartCollect is enabled
    // Otherwise, call LogCollector.StartCollection() when needed
}

// Add a simple button to your UI to let users copy logs
public void OnSendLogsButtonPressed() {
    LogCollector.CopyLogs();
    // Now the logs are in the clipboard and can be pasted elsewhere
}
```

## Notes

- Log collection can be started and stopped at any time to preserve performance
- System information is automatically included when copying logs
- Buffer uses a circular array to maintain fixed memory usage

## License

This package is available for free use in both personal and commercial projects.