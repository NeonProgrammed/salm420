using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour {

    /* 0 - nothing
     * D20 - 1
     * D12 - 2
     * D10 - 3
     * D8 - 4
     * D6 - 5
       D4 - 6 */

    // holds data for attribute
    public Text attributeName;
    private string attributeString;

    public Dropdown diceSelection;
    private int diceType;

    public Text counterText;
    private int diceCounter = 0;

    public enum diceType
    {
        None,
        D20,
        D12,
        D10,
        D8,
        D6,
        D4
    }

    void Update()
    {
        attributeString = attributeName.text; // updates the atribute name

        diceType = diceSelection.value; // updates the dice being used

        counterText.text = diceCounter.ToString(); // updates the counter script
    }


    // Controls counter
    public void increaseCount()
    {
        diceCounter++;
    }
    public void decreaseCount()
    {
        if (diceCounter > 0)
            diceCounter--;
    }

    // Returns all values for attribute
    public string getAttributeName () { return attributeString; }
    public int getDiceType() { return diceType; }
    public int getDiceCounter() { return diceCounter; }

}
