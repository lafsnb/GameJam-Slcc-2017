using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour {

	public static List<DoorType> keys = new List<DoorType> ();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void AddKey(DoorType type) {
		if (!keys.Contains (type)) {
			keys.Add (type);
			DoorManager.unlockDoors (keys);
		}
		print("key added");
	}

	public static void ResetKeys() {
		keys.Clear ();
	}
}
