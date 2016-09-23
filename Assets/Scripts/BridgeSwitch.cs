using UnityEngine;
using System.Collections;
using VRTK;



public class BridgeSwitch : VRTK_InteractableObject {
    public GameObject bridge;
    public override void StartUsing(GameObject usingObject) 
    {
        base.StartUsing(usingObject);
        Debug.Log(this.name + " is used in OnInteractableObjUsed");
        Vector3 newPosition = bridge.transform.position;
        bridge.transform.position = new Vector3(0, newPosition.y, newPosition.z);
    }

    protected override void Start()
    {
        base.Start();
        bridge.transform.position = new Vector3((float)-6.84, (float)6.9, (float)0.01);

    }

}
