using UnityEngine;
using System.Collections;

public class BrokenLine : MonoBehaviour {
    public GameObject repairedLine;

	// Use this for initialization
	void Start () {
        repairedLine.SetActive(false);
        GameObject[] rend = this.GetComponentsInChildren<GameObject>();
        foreach (GameObject i in rend) {
            i.SetActive(true);
        }  
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Tape"))
        {
            repairedLine.SetActive(true);
            GameObject[] rend = this.GetComponentsInChildren<GameObject>();
            foreach (GameObject i in rend)
            {
                i.SetActive(false);
            }
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
