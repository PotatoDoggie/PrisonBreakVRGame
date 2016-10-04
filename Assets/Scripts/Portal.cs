using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public GameObject InDoor, OutDoor;
    void OnTriggerEnter(Collider other)
    {
        Vector3 in_position, out_position;
        in_position = InDoor.transform.position;
        out_position = OutDoor.transform.position;

        if (other.gameObject.CompareTag("Portal"))
        {
            if (other.gameObject.name == "InDoor")
            {
                transform.position = out_position;
            }
            if (other.gameObject.name == "OutDoor")
            {
                transform.position = in_position;
            }
        }
    }
}
