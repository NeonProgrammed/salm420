using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollTabAnimationHandler : MonoBehaviour {

    public bool open = false;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    public void PressedTab()
    {
        if (!open)
        {
            open = true;
            anim.SetTrigger("openTab");
        }
        else if (open)
        {
            open = false;
            anim.SetTrigger("closeTab");
        }
    }
}
