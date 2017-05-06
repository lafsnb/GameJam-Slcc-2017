using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{ 
	Patrolling,
	Alerted,
	Chasing
}

public class Enemy : MonoBehaviour {
	

	public State EnemyState = State.Patrolling;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (EnemyState);
	}
}
