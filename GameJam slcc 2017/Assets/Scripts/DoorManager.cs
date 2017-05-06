using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {

	public static Door[] blueDoors = new Door[6];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void unlockDoors(List<DoorType> keys) {
		if (keys.Contains (DoorType.Blue)) {
			foreach (Door door in blueDoors) {
				door.gameObject.GetComponent<BoxCollider> ().enabled = false;
			}
		}
	}
}
