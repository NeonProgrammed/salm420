using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

/// <summary>
/// A python runtime environment.
/// Please see README.txt for more details, especially if this class doesn't compile.
/// </summary>
public class PythonEnvironment
{
    public struct CommandResult
    {
        public string output;
        public object returnValue;
        public string returnValueStr;
        public System.Exception exception;
    }

    private ScriptEngine m_pythonEngine;
    private ScriptScope m_scriptScope;

    public PythonEnvironment()
    {
        m_pythonEngine = Python.CreateEngine();
        m_scriptScope = m_pythonEngine.CreateScope();
    }

    public CommandResult RunCommand(string command)
    {
        CommandResult result = new CommandResult();

        MemoryStream ms = new MemoryStream();
        try
        {
            m_pythonEngine.Runtime.IO.SetOutput(ms, new StreamWriter(ms, Encoding.UTF8));
            object o = m_pythonEngine.Execute(command, m_scriptScope);
            result.output = ReadStream(ms);
            if (o != null)
            {
                result.returnValue = o;
                m_scriptScope.SetVariable("_", o);
                try
                {
                    string objectStr = m_pythonEngine.Execute("repr(_)", m_scriptScope).ToString();
                    result.returnValueStr = objectStr;
                }
                catch
                {
                    result.returnValueStr = o.ToString();
                }
            }
        }
        catch (System.Exception e)
        {
            result.output = ReadStream(ms);
            result.exception = e;
        }
        ms.Dispose();

        return result;
    }

	public void ExposeVariable(string name, object obj)
	{
		m_scriptScope.SetVariable(name, obj);
	}
	
    private string ReadStream(MemoryStream ms)
    {
        if (ms.Length > 0)
        {
            int length = (int)ms.Length;
            byte[] bytes = new byte[length];

            ms.Seek(0, SeekOrigin.Begin);
            ms.Read(bytes, 0, (int)ms.Length);

            return Encoding.UTF8.GetString(bytes, 0, (int)ms.Length);
        }
        else
        {
            return null;
        }
    }

}

