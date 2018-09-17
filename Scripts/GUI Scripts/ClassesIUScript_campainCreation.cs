using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassesIUScript_campainCreation : MonoBehaviour {

    public RectTransform classesPrefab;

    public RectTransform parent;

	public void createClass()
    {
        Instantiate(classesPrefab, parent);
    }
}
