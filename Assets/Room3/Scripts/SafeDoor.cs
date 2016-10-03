using UnityEngine;
using System.Collections;
using VRTK;

public class SafeDoor: VRTK_InteractableObject {
	
	private bool isTouched;

	public override void StartUsing(GameObject usingObject) 
	{
		base.StartUsing(usingObject);
		if (!isTouched) 
		{
			Vector3 oldPosition = this.transform.position;
			this.transform.position = new Vector3 (oldPosition.x + 0.75f, oldPosition.y, oldPosition.z);
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
		this.transform.position = new Vector3(-0.675f, 1.5f, 1.2f);
		isTouched = false;

	}

}
