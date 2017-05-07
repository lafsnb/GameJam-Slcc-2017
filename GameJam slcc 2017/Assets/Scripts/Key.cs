using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Key : MonoBehaviour {

	public DoorType type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		var HUD = GameObject.Find ("Key Hud");
		if (other.tag == "Player") {
            GameObject parentDoor = null;
            switch(type)
            {
			case (DoorType.Blue):
				parentDoor = GameObject.Find ("blueDoors");
				if (HUD != null)
					HUD.transform.Find ("Blue").GetComponent<Image> ().enabled = true;
                    break;
                case (DoorType.Red):
                    parentDoor = GameObject.Find("redDoors");
					if (HUD != null)
						HUD.transform.Find ("Red").GetComponent<Image> ().enabled = true;
                    break;
                case (DoorType.Yellow):
                    parentDoor = GameObject.Find("yellowDoors");
					if (HUD != null)
						HUD.transform.Find ("Yellow").GetComponent<Image> ().enabled = true;
                    break;
                case (DoorType.Green):
                    parentDoor = GameObject.Find("greenDoors");
					if (HUD != null)
						HUD.transform.Find ("Green").GetComponent<Image> ().enabled = true;
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
