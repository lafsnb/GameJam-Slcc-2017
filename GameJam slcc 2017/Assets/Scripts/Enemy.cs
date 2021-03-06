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
	public float rotationSpeed = 3.0f;
	public float lastKnownRadius = 0.3f;
    private Vector3 lastKnown;
	private Light light;


    int counter = 0;

	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(targets[counter].position);
        player = GameObject.Find("Player").transform;
		light = transform.GetChild (0).gameObject.GetComponent<Light> ();
		light.color = Color.yellow;
    }

    // Update is called once per frame
    void Update () {
		Debug.Log (EnemyState);
        view();

		if (EnemyState == State.Chasing) {
			agent.SetDestination (lastKnown);
		}
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

    private void view()
    {
        Vector3 fromEnemyToPlayer = player.position - transform.position;

        if (fromEnemyToPlayer.magnitude < viewDistance && Vector3.Angle(transform.forward, fromEnemyToPlayer) < viewAngle)
        {
            if (EnemyState == State.Patrolling || EnemyState == State.Chasing)
            {
                RaycastHit hitInfo;
                if (Physics.Raycast(transform.position, fromEnemyToPlayer, out hitInfo))
                {
                    if (hitInfo.collider.tag == "Player")
                    {
                        EnemyState = State.Chasing;
						lastKnown = player.position;
						light.color = Color.red;
                    }

                    else
                    {
                        if(EnemyState == State.Chasing) EnemyState = State.Alerted;
						light.color = Color.yellow;

                    }
                }
                else
                    EnemyState = State.Alerted;


            }
        }

		if (PointInsideSphere(new Vector2 (transform.position.x, transform.position.z), 
			new Vector2(lastKnown.x, lastKnown.z), lastKnownRadius)) {

			agent.SetDestination (targets [counter].position);
			EnemyState = State.Patrolling;
			light.color = Color.yellow;
			print ("I lost him boss :(");

		}
    }

	bool PointInsideSphere(Vector2 point, Vector2 center, float radius) {
		return (Vector2.Distance(point, center) < radius);
	}

}
