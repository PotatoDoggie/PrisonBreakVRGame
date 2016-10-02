using UnityEngine;
using System.Collections;

public class BrokenLine : MonoBehaviour {
    public GameObject repairedLine;

	// Use this for initialization
	void Start () {
        repairedLine.SetActive(false);
        Renderer rend = this.GetComponent<Renderer>();
        rend.enabled = true;
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Tape"))
        {
            repairedLine.SetActive(true);
            Renderer rend = this.GetComponent<Renderer>();
            rend.enabled = false;
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
