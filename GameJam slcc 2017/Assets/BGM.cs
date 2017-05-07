using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {

	private static BGM Instance;
	// Use this for initialization
	void Start () {
		if (Instance != null)
			Destroy (gameObject);
		else
			Instance = this;
		DontDestroyOnLoad(gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
