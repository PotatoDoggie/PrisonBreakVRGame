using UnityEngine;
using System.Collections;
using VRTK;

public class CameraControl : VRTK_InteractableObject {
	public RotateCamera rotateCamera;
	public AudioClip switchsound;
	private AudioSource audioSource;
	// Update is called once per frame
	protected override void Update () {
		if (Input.GetKeyDown ("c")) {
			audioSource.PlayOneShot (switchsound, 1.0f);
			rotateCamera.changeRotationStatus ();
		}
	}

	protected override void Start() {
		base.Start();
		audioSource = GameObject.Find("/MainAudioSource").GetComponent<AudioSource> ();
	}
	public override void StartUsing(GameObject usingObject) {
		audioSource.PlayOneShot (switchsound, 1.0f);
		rotateCamera.changeRotationStatus ();
	}
}
