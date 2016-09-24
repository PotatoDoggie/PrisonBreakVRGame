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
        Vector3 newPosition = exit.transform.position;
        usingObject.transform.position = newPosition;
    }

    protected override void Start()
    {
        base.Start();

    }

}
