using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollision : MonoBehaviour {

	public Transform target;
	NavMeshAgent agent;

	void Start() {
		agent = GetComponent<NavMeshAgent>();
	}

	void Update() {
		agent.SetDestination(target.position);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			print ("Player Died");
		}
	}
}
