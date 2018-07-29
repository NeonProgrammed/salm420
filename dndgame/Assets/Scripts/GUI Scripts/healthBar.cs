using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    public Slider hBar;
    int currentHealth;
    int maxHealth = 50;


    float calculateHealth()
    {
        return currentHealth / maxHealth;
    }

    void start()
    {
        //will be set by each individual character sheet, 50 is for test
        int currentHealth = maxHealth;
        //start with full hp
        hBar.value = calculateHealth();
    }

    void update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            dmg(6);
        }
    }
    void dmg(int dmgDealt)
    {

        currentHealth -= dmgDealt;
    }
}
