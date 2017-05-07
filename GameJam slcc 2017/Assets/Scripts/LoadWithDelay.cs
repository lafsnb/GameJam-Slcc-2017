using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWithDelay : MonoBehaviour {
	public float delay;
	public string SceneName;
	public bool loadLast;
	// Use this for initialization
	void Start () {
		StartCoroutine (Load());
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (loadLast)
				LoadLast ();
			else
				SceneManager.LoadScene (SceneName);
		}
	}
	IEnumerator Load()
	{
		yield return new WaitForSeconds (delay);
		if (loadLast)
			LoadLast ();
		else
			SceneManager.LoadScene (SceneName);
	}

	void LoadLast()
	{
		if (LevelManagement.CurrentLevel != null)
			SceneManager.LoadScene (LevelManagement.CurrentLevel);
	}
}
