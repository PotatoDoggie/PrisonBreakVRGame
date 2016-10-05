using UnityEngine;
using System.Collections;

public class KeypadController : MonoBehaviour {

	public string curPassword = "2628";
	public string input;
	public bool doorOpen = false; 
	public bool keypadScreen;
	//public Transform doorHinge;
	public GameObject screen = GameObject.Find("Screen");

	void OnTriggerEnter(Collider other) {
		TextMesh tm = screen.GetComponent<TextMesh> ();
		if (!doorOpen)
		if (other.Equals (GameObject.Find ("Cube_0"))) {
			input += "0";
			tm.text = "Input:\n" + input;
		} else if (other.Equals (GameObject.Find ("Cube_1"))) {
			input += "1";
			tm.text = "Input:\n" + input;
		}
		else if (other.Equals (GameObject.Find ("Cube_2"))) {
			input += "2";
			tm.text = "Input:\n" + input;
		} else if (other.Equals (GameObject.Find ("Cube_3"))) {
			input += "3";
			tm.text = "Input:\n" + input;
		} else if (other.Equals (GameObject.Find ("Cube_4"))) {
			input += "4";
			tm.text = "Input:\n" + input;
		} else if (other.Equals (GameObject.Find ("Cube_5"))) {
			input += "5";
			tm.text = "Input:\n" + input;
		} else if (other.Equals (GameObject.Find ("Cube_6"))) {
			input += "6";
			tm.text = "Input:\n" + input;
		} else if (other.Equals (GameObject.Find ("Cube_7"))) {
			input += "7";
			tm.text = "Input:\n" + input;
		} else if (other.Equals (GameObject.Find ("Cube_8"))) {
			input += "8";
			tm.text = "Input:\n" + input;
		} else if (other.Equals (GameObject.Find ("Cube_9"))) {
			input += "9";
			tm.text = "Input:\n" + input;
		} else if (other.Equals (GameObject.Find ("Cube_cancel"))) {
			input = "";
			tm.text = "Input:\n" + input;
		} else if (other.Equals (GameObject.Find ("Cube_enter"))) {
			if (input.Equals ("curPassword")) {
				doorOpen = true;
			} else {
				tm.text = "Password Error\n" + "Please try again!";
			}
		}

		if (doorOpen) {
			GameObject door = GameObject.Find ("PrisonCellDoorWayDoor");
			door.transform.Rotate (new Vector3 (0, -45, 0));
		}

	}


}

