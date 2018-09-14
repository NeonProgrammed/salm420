using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour {

    public int counter;
    public Text rollReturn;
    public int range;

    private void Update()
    {
        GetComponent<Text>().text = counter.ToString();
    }

    public void increasePressed()
    {
        counter++;
    }

    public void decreasePressed()
    {
        if (counter > 0)
            counter--;
    }

    public void rollPressed()
    {
        int total = 0;

        for (int i = 0; i < counter; i++)
        {
            total += Random.Range(1, range + 1);
        }
        print(total);
        rollReturn.text = total.ToString();
    }
}
