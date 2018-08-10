using System.Collections;
using UnityEngine;

/**
 * ____NOTES_______
 * Use this script when moving sprites on the screen.
 * When wanting to move a sprite you MUST add a BOX COLLIDER to the attributes
 * Box Collider is located under the physics tab.
 **/



public class ClickAndDrag : MonoBehaviour {
    void OnMouseDrag(){
        Vector2 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }


}
