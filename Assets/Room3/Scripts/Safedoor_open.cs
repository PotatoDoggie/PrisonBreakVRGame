using UnityEngine;
using System.Collections;
using VRTK;

public class SafeDoor_open : VRTK_InteractableObject {
	public GameObject safedoor;
	private bool isTouched;

	public override void StartUsing(GameObject usingObject) 
	{
		base.StartUsing(usingObject);
		//Debug.Log(this.name + " is used in OnInteractableObjUsed");
		if (!isTouched) {
			//Debug.Log ("first use! this obj grow");
			Vector3 oldPosition = safedoor.transform.position;
			safedoor.transform.position = new Vector3 (oldPosition.x + 0.75, oldPosition.y, oldPosition.z);
			//isTouched = !isUsed;

		}
		/*else {
			Debug.Log ("second use!");
			Vector3 oldPosition = bridge.transform.position;
			bridge.transform.position = new Vector3 (oldPosition.x - 1, oldPosition.y, oldPosition.z);
			isUsed = !isUsed;
		}*/
	}

	protected override void Start()
	{
		base.Start();
		safedoor.transform.position = new Vector3((float)-0.675, (float)1.5, (float)1.2);
		isTouched = false;

	}

}
