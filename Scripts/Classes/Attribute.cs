using UnityEngine;

[CreateAssetMenu(fileName = "New Attribute", menuName = "Campaign/Attrubute", order = 1)]

public class Attribute : ScriptableObject {

    new public string name = "New Attribute";

    public enum DiceType
    {
        None,
        D20,
        D12,
        D10,
        D8,
        D6,
        D4
    }

    public int diceAmt = 0;

}
