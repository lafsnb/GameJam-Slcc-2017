using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	private float t;
	void Update () {
		GetComponent<Text> ().color = new Color (1, 1, 1, Mathf.Sin (t) / 2 + .5f);
		t += Time.deltaTime;
	}
}
