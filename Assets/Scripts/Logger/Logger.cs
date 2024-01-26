/**
 * refs. https://bluebirdofoz.hatenablog.com/entry/2020/09/01/230303
 */

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Logger : MonoBehaviour
{

    [SerializeField]
    private TextMeshPro logText;

    [SerializeField, Tooltip("表示行数")]
    private int logLineNum = 30;

    private string[] linecodes = new string[] { "\n", "\r", "\r\n" };

    private void Awake()
    {
        Application.logMessageReceived += LogMessageOutput;

        logText.text = "";

        Debug.Log("Logger started.");
    }

    /// <summary>
    /// Logメッセージイベント処理
    /// </summary>
    private void LogMessageOutput(string condition, string stackTrace, LogType type)
    {
        switch (type)
        {
            case LogType.Error:
                // ログメッセージとスタックトレースを表示
                ShowMessage(logText.text, condition, stackTrace);
                break;
            case LogType.Assert:
                // ログメッセージとスタックトレースを表示
                ShowMessage(logText.text, condition, stackTrace);
                break;
            case LogType.Warning:
                // ログメッセージのみ表示
                ShowMessage(logText.text, condition, "");
                break;
            case LogType.Log:
                // ログメッセージを表示
                ShowMessage(logText.text, condition, "");
                break;
            case LogType.Exception:
                break;
        }
    }

    /// <summary>
    /// 指定行数でのメッセージ表示処理
    /// </summary>
    private void ShowMessage(string basetext, string message, string stacktrace)
    {
        string[] baselines = basetext.Split(linecodes, System.StringSplitOptions.RemoveEmptyEntries);
        string[] messagelines = message.Split(linecodes, System.StringSplitOptions.RemoveEmptyEntries);
        string[] tracelines = stacktrace.Split(linecodes, System.StringSplitOptions.RemoveEmptyEntries);

        List<string> lines = new List<string>();
        lines.AddRange(baselines);
        lines.AddRange(messagelines);
        foreach (string trace in tracelines)
        {
            lines.Add(" " + trace);
        }

        int linecount = 0;
        string textmessage = "";
        if (lines.Count > logLineNum)
        {
            linecount = lines.Count - logLineNum;
        }
        for (int num = linecount; num < lines.Count; num++)
        {
            if (lines[num].Length > 0)
            {
                textmessage += lines[num] + linecodes[0];
            }
        }

        logText.text = textmessage;
    }
}
