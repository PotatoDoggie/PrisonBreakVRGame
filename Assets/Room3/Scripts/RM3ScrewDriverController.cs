using UnityEngine;
using System.Collections;

public class RM3ScrewDriverController : MonoBehaviour {

	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("ScrewHead")) {
			other.gameObject.SetActive (false);
			count++;
            Debug.Log("Count" + count);
			if (count >= 4) {
				GameObject electricPanelDoor = GameObject.Find ("ElectricalPanelDoor");
				Rigidbody rb1 = electricPanelDoor.GetComponent<Rigidbody>();
				rb1.isKinematic = false;
			}
		}
	}
}
