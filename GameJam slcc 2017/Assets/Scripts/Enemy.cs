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

    private Transform player;
    public float viewDistance = 2f;
    public float viewAngle = 20f;
	public float rotationSpeed = 3.0f;
    private Vector3 lastKnown;

    int counter = 0;

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

		if(EnemyState == State.Chasing)
			agent.SetDestination(lastKnown);
    }

	void OnTriggerEnter(Collider other) { // Collide with destinations
		if (other.tag == "AI Destination" && EnemyState == State.Patrolling) {
				if (counter >= targets.Length - 1) {
					counter = 0;
//					print ("set to 0");
				} else {
					counter++;
//					print ("counter++");
				}
				agent.SetDestination (targets [counter].position);	
		}

	}

	//private void Rotate () {
	//	Quaternion newRotation = Quaternion.AngleAxis (90, Vector3.up);
	//	transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, .05f);
	//}

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
                    }

                    else
                    {
                        if(EnemyState == State.Chasing) EnemyState = State.Alerted;
                    }
                }
                else
                    EnemyState = State.Alerted;


            }
        }

//		if (transform.position.x == lastKnown.x && transform.position.z == lastKnown.z) {
//			agent.SetDestination (targets [counter++].position);
//			EnemyState = State.Patrolling;
//			print ("I lost him boss :(");
//		}

		if (PointInsideSphere(new Vector2 (transform.position.x, transform.position.z), 
			new Vector2(lastKnown.x, lastKnown.z), 0.3f)) {

			agent.SetDestination (targets [counter].position);
			EnemyState = State.Patrolling;
			print ("I lost him boss :(");

		}
    }

	bool PointInsideSphere(Vector2 point, Vector2 center, float radius) {
		return (Vector2.Distance(point, center) < radius);
	}

}
