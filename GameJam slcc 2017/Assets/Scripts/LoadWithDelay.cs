using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWithDelay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Load());
	}

	IEnumerator Load()
	{
		yield return new WaitForSeconds (5f);
		if (LevelManagement.CurrentLevel != null)
			SceneManager.LoadScene (LevelManagement.CurrentLevel);
	}
}
