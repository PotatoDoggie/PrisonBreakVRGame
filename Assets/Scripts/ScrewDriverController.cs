using UnityEngine;
using System.Collections;

public class ScrewDriverController : MonoBehaviour {

	private int count;

	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("ScrewHead")) {
			other.gameObject.SetActive (false);
			count++;
			GameObject.Find ("PrisonElectricalPanel").GetComponents<AudioSource> () [1].Play ();
            Debug.Log("Count" + count);
			if (count >= 4) {
				GameObject.Find ("PrisonElectricalPanel").GetComponents<AudioSource> () [1].Play ();
				GameObject electricPanelDoor = GameObject.Find ("ElectricalPanelDoor");
				Rigidbody rb1 = electricPanelDoor.GetComponent<Rigidbody>();
				rb1.isKinematic = false;
			}
		}
	}
}
