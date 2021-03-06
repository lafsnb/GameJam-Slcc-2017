﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	public AudioClip clip;
	public string level = "Game Over";
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			SceneManager.LoadScene (level);
		BGM.Instance.transform.GetComponent<AudioSource> ().PlayOneShot (clip);
	}
}
