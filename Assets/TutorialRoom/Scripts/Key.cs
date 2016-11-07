using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Key_Hole"))
		{
			GameObject boxTop = GameObject.Find ("box_top");
			boxTop.transform.Rotate (new Vector3(-45, 0, 0));
		}
	}
}
