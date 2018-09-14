using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour {

    /* 0 - nothing
     * D20 - 1
     * D12 - 2
     * D10 - 3
     * D8 - 4
     * D6 - 5
       D4 - 6 */

    public Transform attribute;

    private string attributeTitle;
    private int dice;
    private int counter;

    public Attributes(Transform attrib)
    {
        attribute = attrib;

        attributeTitle = "";
        dice = 0;
        counter = 0;
    }

    public Attributes(Transform attrib, string attributeName, int diceType, int diceCounter)
    {
        attribute = attrib;

        attributeTitle = attributeName;
        dice = diceType;
        counter = diceCounter;
    }

    public void setAttributeName(string attributeName) { attributeTitle = attributeName; }

    public void setDiceType(int diceType) { dice = diceType; }

    public void setDiceCounter(int diceCounter) { counter = diceCounter; }

    public string getAttributeName() { return attributeTitle; }

    public int getDiceType() { return dice; }

    public int getDiceCounter() { return counter; }

    public void createAttribute(RectTransform parent) { Instantiate(attribute, parent); }
	
}
