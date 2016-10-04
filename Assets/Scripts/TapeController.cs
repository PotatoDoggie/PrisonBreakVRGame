using UnityEngine;
using System.Collections;

public class TapeController : MonoBehaviour {

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void OnTriggerEnter(Collider other) {
		GameObject brokenwire = GameObject.Find ("Broken wire");
		if (other.Equals(brokenwire)) {
			other.gameObject.SetActive (false);
			GameObject healthywire = GameObject.Find ("healthy wire");
			MeshRenderer mr = healthywire.GetComponent<MeshRenderer>();
			mr.enabled = true;
		}
	}
}
