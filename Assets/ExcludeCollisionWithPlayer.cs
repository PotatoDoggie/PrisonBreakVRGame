using UnityEngine;
using System.Collections;

public class ExcludeCollisionWithPlayer : MonoBehaviour {
	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("VRPlayerNoTeleport");
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
