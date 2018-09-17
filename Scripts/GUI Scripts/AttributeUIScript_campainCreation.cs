using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeUIScript_campainCreation : MonoBehaviour {
    public static List<Attributes> attributes;

    public RectTransform parent;

    public Transform attributePrefab;

    public void addAttributes()
    {
        Instantiate(attributePrefab, parent);
        Attributes attrib = attributePrefab.GetComponent<Attributes>();
        attributes.Add(attrib);
    }

}
