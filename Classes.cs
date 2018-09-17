using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Classes : MonoBehaviour {

    public Text className;
    private string classTitle;

    public Dropdown hitDice;
    private int diceSelection;

    public Dropdown primaryAbility;
    private int abilitySelection;
	

	void Update () {
        classTitle = className.GetComponent<Text>().text;
	}
}
