using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {

	private static BGM instance;
	public static BGM Instance
	{
		get{ return instance; }
	}
	// Use this for initialization
	void Start () {
		if (instance != null)
			Destroy (gameObject);
		else
			instance = this;
		DontDestroyOnLoad(gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
