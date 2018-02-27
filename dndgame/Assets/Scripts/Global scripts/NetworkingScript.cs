using UnityEngine;
using UnityEngine.Networking;

public class NetworkingScript : MonoBehaviour {

    /* 
     Layout:
        void CreateServer()/CreateClient
        void connectServer()
        void disconnect()
        void eventHandling()
     */

    NetworkClient myClient;

    public void CreateServer()
    {
        NetworkServer.Listen(4444);
    }

    public void CreateClient()
    {
        myClient = new NetworkClient();
    }

}
