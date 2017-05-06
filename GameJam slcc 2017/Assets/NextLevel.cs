using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	private static int level;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			SceneManager.LoadScene (level++);
	}
}
