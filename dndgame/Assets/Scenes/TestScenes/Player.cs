using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    public GameObject PlayerPrefab;

	void Start () {

        if (isServer == true)
        {
        SpawnObj();
        }
	}
	
	
	void Update () {
		
	}

    public GameObject PlrPrefab()
    {
        return new GameObject();
    }

    public void SpawnObj()
    {
        if (isServer == false)
        {
            return;
        }

        GameObject ob = Instantiate(PlayerPrefab);

        NetworkServer.Spawn(ob);
    }
}

//Based off of tutorial from https://www.youtube.com/watch?v=NCT-kQZ8WFY