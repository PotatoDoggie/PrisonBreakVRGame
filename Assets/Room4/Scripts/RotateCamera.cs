using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {
	private float ticks;
	public float rotateAmount;
	public float rotateSpeed;
	private float currentSpeed;
	// Use this for initialization
	void Start () {
		float angle = transform.eulerAngles.y;
		if (angle > 180) {
			angle -= 360;
		}
		ticks = Mathf.Asin(angle / rotateAmount);
		currentSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (transform.eulerAngles.x, (Mathf.Sin (ticks) * rotateAmount), transform.eulerAngles.z);
		ticks += currentSpeed;
	}

	public void startRotate() {
		currentSpeed = rotateSpeed;
	}
	public void stopRotate() {
		currentSpeed = 0;
	}
	public void changeRotationStatus() {
		if (currentSpeed == 0) {
			currentSpeed = rotateSpeed;
		} else {
			currentSpeed = 0;
		}
	}
}
