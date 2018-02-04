using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMouseIcon : MonoBehaviour {

    public Texture2D dragon_Icon;

	// Use this for initialization
	void Start () {
        Cursor.SetCursor(dragon_Icon, Vector2.zero, CursorMode.Auto);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
