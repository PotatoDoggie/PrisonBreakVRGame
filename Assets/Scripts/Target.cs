using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
    public GameObject bridge;

    private bool isUsed;
    private int factor = 2;

    // Use this for initialization
    void Start () {
        isUsed = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Grabbable")) {
            Debug.Log(this.name + " is triggered");
            if (!isUsed)
            {
                Debug.Log("first trigger! this obj grow");
                Vector3 oldPosition = bridge.transform.position;
                bridge.transform.position = new Vector3(oldPosition.x + 1, oldPosition.y, oldPosition.z);
                isUsed = !isUsed;
                Vector3 oldScale = this.transform.localScale;
                this.transform.localScale = oldScale * factor;
            }
            else
            {
                Debug.Log("second trigger!");
                Vector3 oldPosition = bridge.transform.position;
                bridge.transform.position = new Vector3(oldPosition.x - 1, oldPosition.y, oldPosition.z);
                isUsed = !isUsed;
                Vector3 oldScale = this.transform.localScale;
                this.transform.localScale = oldScale / factor;
            }
        }
    }
}
