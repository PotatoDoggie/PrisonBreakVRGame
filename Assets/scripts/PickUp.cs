using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickUp : MonoBehaviour {
	//public Rigidbody rigidAttachedPoint;
	public GameObject sphere;

	private SteamVR_TrackedObject trackedobj;
	private SteamVR_Controller.Device device;

	private FixedJoint fixedJoint;

	void Awake () {
		trackedobj = GetComponent<SteamVR_TrackedObject> ();
	}

	void FixedUpdate () {
		device = SteamVR_Controller.Input ((int)trackedobj.index);

		if (device.GetPressUp (SteamVR_Controller.ButtonMask.Touchpad)) {
			sphere.transform.position = Vector3.zero;
			sphere.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			sphere.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		}
	}

	void OnTriggerStay(Collider col){
		if (fixedJoint == null && device.GetTouch (SteamVR_Controller.ButtonMask.Trigger) && col.GetComponent<FixedJoint>() == null) {
			Debug.Log ("Get Touched!\n");
			fixedJoint = col.gameObject.AddComponent<FixedJoint> ();
			fixedJoint.connectedBody = this.GetComponent<Rigidbody> ();
		} else if(fixedJoint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)){
            Debug.Log("Detected!\n");
			GameObject go = fixedJoint.gameObject;
			Rigidbody rigidBody = go.GetComponent<Rigidbody> ();
			Object.Destroy (fixedJoint);
			fixedJoint = null;
			Debug.Log ("Get Touch Up!\n");
			tossObject (rigidBody);
		} else if(fixedJoint != null && !device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject go = fixedJoint.gameObject;
            Rigidbody rigidBody = go.GetComponent<Rigidbody>();
            Object.Destroy(fixedJoint);
            fixedJoint = null;
            Debug.Log("UnTouched!\n");
            tossObject(rigidBody);
            Debug.Log("UnTouched and tossed!\n");
        }
	}

	void tossObject(Rigidbody rigidbody){
		Transform origin = trackedobj.origin ? trackedobj.origin : trackedobj.transform.parent;

		if (origin != null) {
			rigidbody.velocity = origin.TransformVector (device.velocity);
			rigidbody.angularVelocity = origin.TransformVector (device.angularVelocity);
		} else {
			rigidbody.velocity = device.velocity;
			rigidbody.angularVelocity = device.angularVelocity;
		}
	}
}
