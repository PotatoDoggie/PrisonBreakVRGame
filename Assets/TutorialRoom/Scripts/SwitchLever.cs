using UnityEngine;
using System.Collections;
using VRTK;
public class SwitchLever : MonoBehaviour {
	public bool prisondoorOpen;
	private Vector3 oldPosition;
	private GameObject obj;

	// Use this for initialization
	void Start () {
		prisondoorOpen = false;
		obj = GameObject.Find ("PrisonGateSingleDoor");
		//oldPosition = new Vector3(0.25f, 0, -0.025f);
		oldPosition = obj.transform.position;
		Debug.Log (oldPosition.x + " " + oldPosition.y + " " + oldPosition.z);
		GetComponent<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChange);
		HandleChange(GetComponent<VRTK_Control>().GetValue(), GetComponent<VRTK_Control>().GetNormalizedValue());
	}
	
	private void HandleChange(float value, float normalizedValue)
	{
		if (normalizedValue > 60)
		{
			prisondoorOpen = true;
			obj.transform.position = new Vector3 (oldPosition.x, oldPosition.y + 2.0f, oldPosition.z);
		}
		else {
			prisondoorOpen = false;
			obj.transform.position = oldPosition;
		}
	}
}

