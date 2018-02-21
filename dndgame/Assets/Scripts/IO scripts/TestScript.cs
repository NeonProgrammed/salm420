using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{
    private void Start()
    {
        Example();
    }

    void Example()
    {
        print(Application.persistentDataPath + "\n" + Application.dataPath);
    }
}