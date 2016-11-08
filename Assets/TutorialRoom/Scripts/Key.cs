using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	private Rigidbody rb;

	//This value is used to control that the top can only rotate one time.
	private bool hasBoxTopRotated = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Key_Hole") && hasBoxTopRotated == false)
		{
			GameObject boxTop = GameObject.Find ("box_top");
			boxTop.transform.Rotate (new Vector3(-45, 0, 0));
			hasBoxTopRotated = true;
		}
	}
}
