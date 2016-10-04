using UnityEngine;
using System.Collections;
using VRTK;

public class CameraControl : VRTK_InteractableObject {
	public RotateCamera rotateCamera;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("c")) {
			rotateCamera.changeRotationStatus ();
		}
	}

	protected override void Start() {
		base.Start();
	}
	public override void StartUsing(GameObject usingObject) {
		rotateCamera.changeRotationStatus ();
	}
}
