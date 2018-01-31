using System;
using System.Net.Sockets;
using System.Text;
using System.Net;

/// <summary>
/// A class that listens to commands that come from a socket (MonoDevelop or other app)
/// and injects python code 
/// </summary>
public class PythonCommandListenerThread
{
    private int m_port;
    private PythonInterpreterWindow m_targetWindow;
    private TcpListener m_tcpListener;

    public PythonCommandListenerThread(int port, PythonInterpreterWindow targetWindow)
    {
        m_port = port;
        m_targetWindow = targetWindow;
    }

    public void Start()
    {
        m_tcpListener = new TcpListener(IPAddress.Loopback, m_port);
        m_tcpListener.Start();
        UnityEngine.Debug.Log("Listening for python interpreter commands on port " + m_port);
        m_tcpListener.BeginAcceptTcpClient(HandleClientComm, null);
    }

    public void Stop()
    {
        if (m_tcpListener != null)
        {
            UnityEngine.Debug.Log("Stopped listening for python interpreter commands");
            m_tcpListener.Stop();
            m_tcpListener = null;
        }
    }

    private void HandleClientComm(IAsyncResult asyncResult)
    {
        //Get the received client
        TcpClient tcpClient = m_tcpListener.EndAcceptTcpClient(asyncResult);
        NetworkStream clientStream = tcpClient.GetStream();

        //Immediately start another listen operation
        m_tcpListener.BeginAcceptTcpClient(HandleClientComm, null);

        StringBuilder sb = new StringBuilder();
        byte[] message = new byte[4096];
        int bytesRead;

        while (true)
        {
            bytesRead = 0;

            try
            {
                //blocks until a client sends a message
                bytesRead = clientStream.Read(message, 0, 4096);
            }
            catch
            {
                //a socket error has occured
                break;
            }

            if (bytesRead == 0)
            {
                //the client has disconnected from the server
                break;
            }

            //message has successfully been received
            sb.Append(Encoding.UTF8.GetString(message, 0, bytesRead));
        }

        tcpClient.Close();

        if (sb.Length > 0)
        {
            m_targetWindow.AddCommandToQueue(sb.ToString());
        }
    }

    
}
