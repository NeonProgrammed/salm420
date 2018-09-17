using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script will take in a list read from the lnl file and display the attributes according to the list
 */

public class attributes_gui_script : MonoBehaviour {

    public Transform template;
    public RectTransform parent;
    public List<Attributes> attributesList;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < attributesList.Count; i++)
        {
            string str = attributesList[i].getAttributeName();
            Instantiate(template, parent);

            template.GetComponentInChildren<Text>().text = str;

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
