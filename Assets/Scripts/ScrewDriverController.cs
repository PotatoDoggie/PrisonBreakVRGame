using UnityEngine;
using System.Collections;

public class ScrewDriverController : MonoBehaviour {

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
			if (count >= 4) {
				GameObject electricPanelDoor = GameObject.Find ("ElectricPanelDoor");
				float f = 1.5f;
				electricPanelDoor.transform.position = new Vector3(electricPanelDoor.transform.position.x, 
					electricPanelDoor.transform.position.y - f, 
					electricPanelDoor.transform.position.z);
			}
		}
	}
}
