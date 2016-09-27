using UnityEngine;
using System.Collections;
using VRTK;



public class BridgeSwitch : VRTK_InteractableObject {
    public GameObject bridge;
    private bool isUsed;
    private int factor = 2;
    public override void StartUsing(GameObject usingObject) 
    {
        base.StartUsing(usingObject);
        Debug.Log(this.name + " is used in OnInteractableObjUsed");
        if (!isUsed)
        {
            Debug.Log("first use! this obj grow");
            Vector3 oldPosition = bridge.transform.position;
            bridge.transform.position = new Vector3(oldPosition.x + 1, oldPosition.y, oldPosition.z);
            isUsed = !isUsed;
            Vector3 oldScale = this.transform.localScale;
            this.transform.localScale = oldScale * factor;
        }
        else
        {
            Debug.Log("second use!");
            Vector3 oldPosition = bridge.transform.position;
            bridge.transform.position = new Vector3(oldPosition.x - 1, oldPosition.y, oldPosition.z);
            isUsed = !isUsed;
            Vector3 oldScale = this.transform.localScale;
            this.transform.localScale = oldScale / factor;
        }
    }

    protected override void Start()
    {
        base.Start();
        bridge.transform.position = new Vector3((float)-6.0, (float)6.9, (float)0.01);
        isUsed = false;

    }

}
