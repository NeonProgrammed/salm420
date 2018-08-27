using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationUI : MonoBehaviour {

    public bool open = false;
    Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>(); // Gets the animator component in all children components
    }

    private void Update()
    {
    }

    // If the info tab button is pressed
    public void PressedTab ()
    {
        if (! open)
        {
            open = true;
            anim.SetTrigger("OpenTab");
        } else if (open) {
            open = false;
            anim.SetTrigger("CloseTab");
        }
    }

}
