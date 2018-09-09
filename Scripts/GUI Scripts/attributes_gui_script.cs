﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script will take in a list read from the lnl file and display the attributes according to the list
 */

public class attributes_gui_script : MonoBehaviour {

    public Transform template;
    public RectTransform parent;
    public List<string> attributesList;

    int i = 0;

    // Use this for initialization
    void Start () {


        for (int i = 0; i < attributesList.Count; i++)
        {
            string str = attributesList[i];
            Instantiate(template, parent);

            template.GetComponentInChildren<Text>().text = attributesList[i];

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
