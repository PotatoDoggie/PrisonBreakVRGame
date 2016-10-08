﻿using UnityEngine;
using System.Collections;

public class DestoriableObj : MonoBehaviour {

    public GameObject dropWhenDestried;
    // Use this for initialization
    void Start()
    {
        if (dropWhenDestried != null) {
            dropInitial(dropWhenDestried);
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (dropWhenDestried != null)
        {
            dropItem(dropWhenDestried);
        }
        Destroy(this);
    }
    //initial obj for drop, setactive false
    void dropInitial(GameObject obj) {
        obj.transform.position = this.transform.position;
        obj.SetActive(false);
    }

    void dropItem(GameObject obj) {
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.velocity += new Vector3(0.0f, 0.0001f, 0.0f);
    }

}