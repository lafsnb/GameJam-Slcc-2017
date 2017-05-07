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

	public Transform playerTarget = null;
	public Transform[] targets = new Transform[2];

	int counter = 1;

	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(targets[counter].position);
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (EnemyState);
	}

	void OnTriggerEnter(Collider other) { // Collide with destinations
		if (other.tag == "AI Destination") {
			if (counter >= targets.Length - 1) {
				counter = 0;
			} else {
				counter++;
			}
			agent.SetDestination (targets [counter].position);	
		}
	}

	void ReachDestination() {

	}
}
