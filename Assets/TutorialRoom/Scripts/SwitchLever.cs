using UnityEngine;
using System.Collections;
using VRTK;
public class SwitchLever : MonoBehaviour {
	private bool powerOn;
	private Vector3 oldPosition;
	private GameObject obj;

	// Use this for initialization
	void Start () {
		obj = GameObject.Find ("PrisonGateSingleDoor");
		oldPosition = obj.transform.position;
		GetComponent<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChange);
		HandleChange(GetComponent<VRTK_Control>().GetValue(), GetComponent<VRTK_Control>().GetNormalizedValue());
	}
	
	private void HandleChange(float value, float normalizedValue)
	{
		if (normalizedValue > 60)
		{
			powerOn = false;
			obj.transform.position = oldPosition;
		}
		else {
			powerOn = true;
			obj.transform.position = new Vector3 (oldPosition.x, oldPosition.y + 3, oldPosition.z);
		}
	}
}

