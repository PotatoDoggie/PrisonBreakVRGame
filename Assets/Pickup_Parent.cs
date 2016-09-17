using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Pickup_Parent : MonoBehaviour {
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;
    //bind trackedObj 
    void Awake() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    //bind device
    void FixedUpdate() {
        device = SteamVR_Controller.Input((int)trackedObj.index);

    }
    void OnTriggerStay(Collider other) {
        Debug.Log("Collied with " + other.name + "on OnTriggerStay");
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            Debug.Log("Collied with " + other.name + "on Touch Trigger");
            if (other.CompareTag("Pickable")) {
                Debug.Log("is Pickable");
                other.attachedRigidbody.isKinematic = true;
                other.gameObject.transform.SetParent(this.gameObject.transform);
            }
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("release touch while Collied with " + other.name);
            if (other.CompareTag("Pickable"))
            {
                Debug.Log("is Pickable");
                other.attachedRigidbody.isKinematic = false;
                other.gameObject.transform.SetParent(null);
            }
        }
    }
    

}
