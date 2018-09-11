using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationUI : MonoBehaviour {

    // Switching canvases
    public GameObject setupUI;
    public Text setupUI_info;
    public GameObject attributesUI;
    public Text attribUI_info;
    public GameObject backstoryUI;
    public Text backstoryUI_info;

    public GameObject infoTab;

    // Vairbales for tab UI
    public bool open = false;
    Animator anim;

    private void Start()

    {
        setupUI_info.enabled = true;
        attribUI_info.enabled = false;
        backstoryUI_info.enabled = false;

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
        setupUI_info.enabled = true;
        attributesUI.SetActive(false);
        attribUI_info.enabled = false;
        backstoryUI.SetActive(false);
        backstoryUI_info.enabled = false;
    }

    public void attributesPressed()
    {
        setupUI.SetActive(false);
        setupUI_info.enabled = false;
        attributesUI.SetActive(true);
        attribUI_info.enabled = true;
        backstoryUI.SetActive(false);
        backstoryUI_info.enabled = false;
    }

    public void backstoryPressed()
    {
        setupUI.SetActive(false);
        setupUI_info.enabled = false;
        attributesUI.SetActive(false);
        attribUI_info.enabled = false;
        backstoryUI.SetActive(true);
        backstoryUI_info.enabled = true;
    }

}
