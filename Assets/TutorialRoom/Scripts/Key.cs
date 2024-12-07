using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	private Rigidbody rb;
	GameObject door;

	//This value is used to control that the top can only rotate one time.
	private bool hasBoxTopRotated = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		door = GameObject.Find ("Door");
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Key_Hole") && hasBoxTopRotated == false)
		{
			GameObject boxTop = GameObject.Find ("box_top");
			boxTop.transform.Rotate (new Vector3(-45, 0, 0));
			hasBoxTopRotated = true;
		}
		if (other.gameObject.name.Equals ("Door") || other.gameObject.name.Equals ("DoorHandle")) {
			door.transform.Rotate (new Vector3 (0, 45, 0));
		}
	}
}
