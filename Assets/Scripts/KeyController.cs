using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("KeyHole")) {
			GameObject doorLeft = GameObject.FindGameObjectWithTag ("DoorLeft");
			GameObject doorRight = GameObject.FindGameObjectsWithTag ("DoorRight");
			doorLeft.transform.Rotate (new Vector3(0, 90, 0));
			doorRight.transform.Rotate (new Vector3 (0, -90, 0));
		}
	}
}
