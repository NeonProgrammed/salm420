using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationUI : MonoBehaviour {

    // Switching canvases
    public GameObject setupUI;
    public GameObject attributesUI;
    public GameObject backstoryUI;
    public GameObject infoTab;

    // Vairbales for tab UI
    public bool open = false;
    Animator anim;

    private void Start()
    {

        // For tab UI
        anim = infoTab.GetComponent<Animator>(); // Gets the animator component in all children components
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

    public void setupPressed()
    {
        setupUI.SetActive(true);
        attributesUI.SetActive(false);
        backstoryUI.SetActive(false);
    }

    public void attributesPressed()
    {
        setupUI.SetActive(false);
        attributesUI.SetActive(true);
        backstoryUI.SetActive(false);
    }

    public void backstoryPressed()
    {
        setupUI.SetActive(false);
        attributesUI.SetActive(false);
        backstoryUI.SetActive(true);
    }

}
