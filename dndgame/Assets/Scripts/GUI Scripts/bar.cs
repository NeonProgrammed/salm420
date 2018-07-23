using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bar : MonoBehaviour {

	[SerializeField]
	private float width;

	[SerializeField]
	private Image content;

	public int MaxValue { get; set; }

	public float Value {
		set {
        // width = Map(value, 0, MaxValue, 0, 1);
        }

	}

	// Use this for initialization
	void Start () {
		Value = 500;
	}
	
	// Update is called once per frame
	void Update () {
		// HandleBar();
	}
    /**
	private void HandleBar() {
		if (width != content.width) {
			content.width = width;
		}
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax) {
		return value(value - inMin) * (outMax) / (inMax - inMin) + outMin;
		//(80 health - 0) * (1 - 0) / (100 - 0) + 0;
	} **/
}
