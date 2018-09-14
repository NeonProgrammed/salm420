using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leftTabGuiScript : MonoBehaviour {
    public List<Attributes> attributes;

    public RectTransform parent;

    public Transform attributePrefab;

    void Start()
    {

    }

    public void addAttributes()
    {
        Attributes attrib = new Attributes(attributePrefab);
        attributes.Add(attrib);
        attrib.createAttribute(parent);
    }

}
