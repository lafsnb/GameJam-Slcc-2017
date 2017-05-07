﻿using System.Collections;
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

    private Transform player;
    public float viewDistance = 2f;
    public float viewAngle = 20f;
    private Vector3 lastKnown;

    int counter = 1;

	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(targets[counter].position);
        player = GameObject.Find("Player(Clone)").transform;
    }

    // Update is called once per frame
    void Update () {
		Debug.Log (EnemyState);

        view();
    }

	void OnTriggerEnter(Collider other) { // Collide with destinations
		if (other.tag == "AI Destination" && EnemyState == State.Patrolling) {
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

    private void view()
    {
        Vector3 fromEnemyToPlayer = player.position - transform.position;

        if (fromEnemyToPlayer.magnitude < viewDistance && Vector3.Angle(transform.forward, fromEnemyToPlayer) < viewAngle)
        {
            if (EnemyState == State.Patrolling || EnemyState == State.Chasing)
            {
                Debug.Log("Got here");
                RaycastHit hitInfo;
                if (Physics.Raycast(transform.position, fromEnemyToPlayer, out hitInfo))
                {
                    if (hitInfo.collider.tag == "Player")
                    {
                        EnemyState = State.Chasing;
                        lastKnown = player.position;
                        print(lastKnown);
                    }

                    else
                    {
                        if(EnemyState == State.Chasing) EnemyState = State.Alerted;
                        Debug.Log("something's in the way");
                    }
                }
                else
                    EnemyState = State.Alerted;


            }
        }
        if(EnemyState == State.Chasing)agent.SetDestination(lastKnown);
    }
}
