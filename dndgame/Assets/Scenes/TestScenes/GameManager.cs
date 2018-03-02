using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

    [SyncVar]
    public float timeLeft = 180;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isServer == false)
        {
            return;
        }
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {

        }
	}
}
