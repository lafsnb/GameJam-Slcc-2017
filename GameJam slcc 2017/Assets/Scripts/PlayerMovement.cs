using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Vector3 velocity;
	Rigidbody rigidbody;
	public float speed = 2.0f;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		velocity = new Vector3 (Input.GetAxis ("Horizontal"),0,Input.GetAxis ("Vertical")) * speed;
		rigidbody.velocity = velocity;
	}

}
