using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChrClasses : MonoBehaviour
{

    public Text className;
    private string classTitle;

    public Dropdown hitDice;
    private int diceSelection;

    public Dropdown primaryAbility;
    private int abilitySelection;
    
    private List<string> attributeStrings;
    

    void Update()
    {
        classTitle = className.GetComponent<Text>().text;

        diceSelection = hitDice.value;

        abilitySelection = primaryAbility.value;

        hitDice.AddOptions(attributeStrings);

    }
}
