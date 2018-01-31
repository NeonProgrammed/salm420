using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Text;
using System.IO;

/// <summary>
/// An editor window that introduces a python interpreter for interactive
/// editing of the scene.
/// Can also receive commands via socket (see MonoDevelop addin)
/// </summary>
public class PythonInterpreterWindow : EditorWindow 
{
    private enum HistoryItemType
    {
        COMMAND,
        RETURN_VALUE,
        ERROR,
        OUTPUT
    }
    private List<KeyValuePair<HistoryItemType, string>> m_historyItems 
        = new List<KeyValuePair<HistoryItemType,string>>();

    private PythonCommandListenerThread m_listenerThread = null;

    private Vector2 m_historyScrollPosition = Vector2.zero;
    private string m_commandBuffer = string.Empty;
    private string m_currentCommand = string.Empty;
    private bool m_initialized = false;
    private PythonEnvironment m_pythonEnvironment = new PythonEnvironment();
    private bool m_focusInputText = false;
    private const string INITIALIZATION_CODE =
@"
import clr
clr.AddReference('UnityEngine')
clr.AddReference('UnityEditor')
import UnityEngine as Unity
import UnityEditor as Editor
print 'Welcome to Unity Python Interpreter'
print 'UnityEngine classes are available via Unity.___'
print 'UnityEditor classes are avialable via Editor.___'
print 'You can add all unity classes to the global namespace via the command : '
print 'from UnityEngine import *'
print 'Good luck and have fun!'
";
    private Queue<string> m_commandQueue = new Queue<string>();

    [MenuItem("Window/Python Interpreter")]
    static void CreateWindow()
    {
        // Get existing open window or if none, make a new one:
        PythonInterpreterWindow window = (PythonInterpreterWindow)EditorWindow.GetWindow(typeof(PythonInterpreterWindow));
        window.title = "Python";
        
        window.InitializeWindow();
    }

    private void InitializeWindow()
    {
        if (!m_initialized)
        {
            m_listenerThread = new PythonCommandListenerThread(50001, this);
            m_listenerThread.Start();
            ExecuteCode(INITIALIZATION_CODE);
            m_initialized = true;
        }
    }

    public void AddCommandToQueue(string command)
    {
        lock (m_commandQueue)
        {
            m_commandQueue.Enqueue(command);
        }
    }

    public void Update()
    {
        InitializeWindow();
        bool executedCode = false;
        lock (m_commandQueue)
        {
            while (m_commandQueue.Count != 0)
            {
                string nextCommand = m_commandQueue.Dequeue();
                m_historyItems.Add(new KeyValuePair<HistoryItemType, string>(HistoryItemType.COMMAND, nextCommand));
                ExecuteCode(nextCommand);
                executedCode = true;
            }
        }
        if (executedCode)
        {
            Repaint();
            m_historyScrollPosition.y = Mathf.Infinity;
        }
    }

    void OnDisable()
    {
        if (m_listenerThread != null)
        {
            m_listenerThread.Stop();
            m_listenerThread = null;
        }
        m_initialized = false;
    }

    private void HandleInputLine(string newLine)
    {
        //Scroll to bottom of view
        m_historyScrollPosition.y = float.PositiveInfinity;

        bool shouldExecute = true;
        if (newLine.Trim().Length == 0)
        {
            //Debug.Log("Empty line!");
        }
        else
        {
            m_historyItems.Add(new KeyValuePair<HistoryItemType, string>(HistoryItemType.COMMAND, newLine));
            m_commandBuffer += newLine;
            if (newLine.Trim().EndsWith(":") || char.IsWhiteSpace(newLine, 0))
            {
                shouldExecute = false;
            }
        }
        if (shouldExecute && m_commandBuffer.Length > 0)
        {
            ExecuteCode(m_commandBuffer);
            m_commandBuffer = string.Empty;
        }
        m_focusInputText = true;
    }

    internal void ExecuteCode(string command)
    {
        PythonEnvironment.CommandResult result = m_pythonEnvironment.RunCommand(command.TrimEnd());
        if (!string.IsNullOrEmpty(result.output))
        {
            m_historyItems.Add(new KeyValuePair<HistoryItemType, string>(HistoryItemType.OUTPUT, result.output));
        }
        if (!string.IsNullOrEmpty(result.returnValueStr))
        {
            m_historyItems.Add(new KeyValuePair<HistoryItemType, string>(HistoryItemType.RETURN_VALUE, result.returnValueStr));
        }
        if (result.exception != null)
        {
            m_historyItems.Add(new KeyValuePair<HistoryItemType, string>(HistoryItemType.ERROR, result.exception.ToString()));
        }
    }

    void OnGUI()
    {
        InitializeWindow();
        if (m_currentCommand.EndsWith("\n"))
        {
            //Debug.Log("Newline!" + Event.current.type.ToString());
            if (Event.current.type == EventType.Layout)
            {   
                HandleInputLine(m_currentCommand);
                m_currentCommand = string.Empty;
            }
        }

        GUILayout.Label("Command history : ");
        m_historyScrollPosition = GUILayout.BeginScrollView(m_historyScrollPosition, GUILayout.Height(position.height-50));
        foreach (KeyValuePair<HistoryItemType, string> historyItem in m_historyItems)
        {
            
            Color targetColor = Color.black;
            switch (historyItem.Key)
            {
                case HistoryItemType.COMMAND:
                    targetColor = new Color(34f / 255, 177f / 255, 76f / 255);
                    break;
                case HistoryItemType.ERROR:
                    targetColor = Color.red;
                    break;
                case HistoryItemType.RETURN_VALUE:
                    targetColor = Color.blue;
                    break;
                case HistoryItemType.OUTPUT:
                    targetColor = Color.black;
                    break;
            }
            GUI.skin.label.normal.textColor = targetColor;
            GUI.skin.label.wordWrap = true;
            GUILayout.TextArea(historyItem.Value.TrimEnd(), GUI.skin.label, GUILayout.Width(position.width-40));
        }
        GUILayout.EndScrollView();
        
        GUI.skin.label.normal.textColor = Color.black;

        GUILayout.BeginHorizontal();
        GUILayout.Label(">>> ", GUILayout.Width(40));
        GUI.SetNextControlName("TextInput");
        m_currentCommand = GUILayout.TextArea(m_currentCommand);
        GUILayout.EndHorizontal();
        if (m_focusInputText)
        {
            GUI.FocusControl("TextInput");
            if (Event.current.type == EventType.Repaint)
            {
                m_focusInputText = false;
            }
        }
        
    }

}
