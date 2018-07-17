using UnityEngine;

public class ChangeMouseIcon : MonoBehaviour {

    public Texture2D dragon_Icon;

    //Unity lets you set a default mouse curor in the build settings
    //but I will keep this script just incase we ever wanna change the cursor for gui

	// Use this for initialization
	void Start () {
        Cursor.SetCursor(dragon_Icon, Vector2.zero, CursorMode.Auto);
    }

}
