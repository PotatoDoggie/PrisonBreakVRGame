using UnityEngine;
using System.Collections;
using VRTK;

public class DoorHandle : VRTK_InteractableObject {
	private bool leftDoorOpen;
	private bool rightDoorOpen;
	private GameObject leftDoor;
	private GameObject rightDoor;

	protected override void Start() {
		base.Start ();
		leftDoorOpen = false;
		rightDoorOpen = false;
		leftDoor = GameObject.Find ("LeftDoor");
		rightDoor = GameObject.Find ("RightDoor");
	}
		
	public override void StartUsing(GameObject usingObject)
	{
		base.StartUsing(usingObject);
		openDoor(this.gameObject);
	}

	public void openDoor(GameObject obj) {
		if (obj.name.Equals ("leftDoorHandle")) {
			if (leftDoorOpen == false) {
				leftDoorOpen = true;
				leftDoor.transform.Rotate (new Vector3 (0, -90, 0));
			} else {
				leftDoorOpen = false;
				leftDoor.transform.Rotate (new Vector3 (0, 0, 0));
			}

		}
		if (obj.name.Equals ("rightDoorHandle")) {
			if (rightDoorOpen == false) {
				rightDoorOpen = true;
				rightDoor.transform.Rotate (new Vector3 (0, 90, 0));
			} else {
				rightDoorOpen = false;
				rightDoor.transform.Rotate (new Vector3(0, 0, 0));
			}

		}
	}
}
