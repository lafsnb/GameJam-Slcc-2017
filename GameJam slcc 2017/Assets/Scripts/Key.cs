using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	public DoorType type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
            GameObject parentDoor = null;
            switch(type)
            {
                case (DoorType.Blue):
                    parentDoor = GameObject.Find("blueDoors");
                    break;
                case (DoorType.Red):
                    parentDoor = GameObject.Find("redDoors");
                    break;
                case (DoorType.Yellow):
                    parentDoor = GameObject.Find("yellowDoors");
                    break;
                case (DoorType.Green):
                    parentDoor = GameObject.Find("greenDoors");
                    break;
            }
            if (parentDoor != null)
            {
                foreach(Transform child in parentDoor.transform) {
                    child.gameObject.layer = 8;
                }
            }
            Destroy(gameObject);
		}
	}
}
