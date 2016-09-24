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
        GameObject player = GameObject.Find("[CameraRig]");
        player.transform.position = newPosition;
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.velocity += new Vector3(0.0f, 0.0001f,0.0f);
        Debug.Log(player.name);
    }

    protected override void Start()
    {
        base.Start();

    }

}
