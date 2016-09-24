using UnityEngine;
using System.Collections;
using VRTK;



public class PortalUsable : VRTK_InteractableObject
{
    public GameObject exit;
    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        Debug.Log(this.name + " is used in OnInteractableObjUsed");
        Debug.Log(usingObject.name+"is using");
        Vector3 newPosition = exit.transform.position;
        usingObject.transform.parent.position = newPosition;
        Debug.Log(usingObject.transform.parent.name);
    }

    protected override void Start()
    {
        base.Start();

    }

}
