using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour {

	private Transform player;
	public float viewDistance = 2f;
	public float viewAngle = 20f;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player(Clone)").transform;
	}

	void Update()
	{
		Vector3 fromEnemyToPlayer = player.position - transform.position;

		if (fromEnemyToPlayer.magnitude < viewDistance && Vector3.Angle(transform.forward, fromEnemyToPlayer) < viewAngle) {
			var enemy = transform.gameObject.GetComponent<Enemy> ();
			if (enemy.EnemyState == State.Patrolling)
			{
				Debug.Log ("Got here");
				RaycastHit hitInfo;
				if (Physics.Raycast (transform.position, fromEnemyToPlayer, out hitInfo)) {
					if (hitInfo.collider.tag == "Player")
						transform.gameObject.GetComponent<Enemy> ().EnemyState = State.Alerted;
					else
						Debug.Log ("something's in the way");
				}
				else
					transform.gameObject.GetComponent<Enemy> ().EnemyState = State.Alerted;

			}
		}

	}

	void OnDrawGizmos()
	{
		Gizmos.DrawRay (transform.position, player.position - transform.position);
	}
}
