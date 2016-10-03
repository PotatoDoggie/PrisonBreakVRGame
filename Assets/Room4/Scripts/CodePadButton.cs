using UnityEngine;
using System.Collections;

public class CodePadButton : MonoBehaviour {
	public CombinationShow combinationShow;
	public GameObject[] buttons;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Arrow") {
			int color = System.Array.IndexOf (buttons, gameObject);
			combinationShow.inputCode (color);
			Debug.Log (color);
		}
	}
}
