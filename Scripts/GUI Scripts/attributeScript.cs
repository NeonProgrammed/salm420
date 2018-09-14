using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attributeScript : MonoBehaviour {
    public int counter = 0;
    public Text counterText;

    void Update()
    {
        counterText.text = counter.ToString();
    }

    public void increaseCount()
    {
        counter++;
    }
    public void decreaseCount()
    {
        if (counter > 0)
            counter--;
    }
}
