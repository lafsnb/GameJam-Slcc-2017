using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{ 
	Patrolling,
	Alerted,
	Chasing
}

public class Enemy : MonoBehaviour {
	

	public State EnemyState = State.Patrolling;

	public Transform target;
	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (EnemyState);
		agent.SetDestination(target.position);
	}



}
