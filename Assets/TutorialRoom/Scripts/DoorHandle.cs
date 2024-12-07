using UnityEngine;
using System.Collections;
using VRTK;

public class DoorHandle : VRTK_InteractableObject {
	private SwitchLever switchLever;
	private bool leftDoorOpen;
	private bool rightDoorOpen;
	private GameObject leftDoor;
	private GameObject rightDoor;
	//private Vector3 oldPositionLeft;
	//private Vector3 oldPositionRight;

	protected override void Start() {
		base.Start ();
		//prisonDoorOpen = switchLever.prisondoorOpen;
		switchLever = GameObject.Find("Lever").GetComponent<SwitchLever>();
		leftDoorOpen = false;
		rightDoorOpen = false;
		leftDoor = GameObject.Find ("LeftDoor");
		rightDoor = GameObject.Find ("RightDoor");
		//oldPositionLeft = leftDoor.transform.rotation.eulerAngles;
		//oldPositionRight = rightDoor.transform.rotation.eulerAngles;
	}
		
	public override void StartUsing(GameObject usingObject)
	{
		base.StartUsing(usingObject);
		openDoor(this.gameObject);
	}

	public void openDoor(GameObject obj) {
		if (switchLever.prisondoorOpen) {
			if (obj.name.Equals ("leftDoorHandle")) {
				if (leftDoorOpen == false) {
					leftDoorOpen = true;
					leftDoor.transform.Rotate (new Vector3 (0, -90, 0));
				} else {
					leftDoorOpen = false;
					leftDoor.transform.Rotate (new Vector3(0, 90, 0));
				}

			}
			if (obj.name.Equals ("rightDoorHandle")) {
				if (rightDoorOpen == false) {
					rightDoorOpen = true;
					rightDoor.transform.Rotate (new Vector3 (0, 90, 0));
				} else {
					rightDoorOpen = false;
					rightDoor.transform.Rotate (new Vector3 (0, -90, 0));
				}
			}
		}
	}
}
