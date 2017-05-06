using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other)
	{
		var enemy = transform.parent.gameObject.GetComponent<Enemy> ();
		if (other.tag == "Player" && enemy.EnemyState == State.Patrolling)
		{
			RaycastHit hitInfo;
			if (Physics.Raycast (transform.position, other.transform.position - transform.position, out hitInfo)) {
				if (hitInfo.collider.tag == "Player")
					transform.parent.gameObject.GetComponent<Enemy> ().EnemyState = State.Alerted;
			}
			
		}
	}
}
