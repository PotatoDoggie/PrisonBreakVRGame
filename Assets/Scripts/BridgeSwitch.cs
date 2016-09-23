using UnityEngine;
using System.Collections;
using VRTK;



public class BridgeSwitch : VRTK_InteractableObject {
    public GameObject bridge;

    protected override void Start()
    {
        base.Start();
        Debug.Log(this.name + " is used in OnInteractableObjUsed");
        Vector3 newPosition = bridge.transform.position;
        bridge.transform.position = new Vector3(0, newPosition.y, newPosition.z);
    }


}
