using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownUI : MonoBehaviour {

    GameManager gameManager;
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager == null)
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();

            if(gameManager == null)
            {
                return;
            }
        }

        text.text = gameManager.timeLeft.ToString("#.##") ;
	}
}
