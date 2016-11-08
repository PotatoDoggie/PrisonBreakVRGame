using UnityEngine;
using System.Collections;

public class Axe : MonoBehaviour {
	private int collisionTimes = 3;
	GameObject door;
	GameObject doorHandle;
	// Use this for initialization
	void Start () {
		door = GameObject.Find ("Door");
		doorHandle = GameObject.Find ("DoorHandle");
	}
	
	void onTriggerEnter(Collider other) {
		if (other.gameObject.Equals (door) || other.gameObject.Equals (doorHandle)) {
			collisionTimes--;
			if (collisionTimes == 0) {
				door.transform.Rotate (new Vector3 (0, 45, 0));
			}
		}
	}
}
