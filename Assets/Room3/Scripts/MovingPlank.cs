using UnityEngine;
using System.Collections;

public class MovingPlank : MonoBehaviour 
{
	private float speed = 2.0f;
    void Update() 
	{   //moveposition includes fiction
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.MovePosition (new Vector3(Mathf.PingPong(Time.time, 2.5f), transform.position.y, transform.position.z));
	}
    /*
     void FixedUpdate() {
         Rigidbody rigidbody = GetComponent<Rigidbody>();
         rigidbody.position -= transform.forward * speed * Time.deltaTime;
         rigidbody.MovePosition(rigidbody.position + transform.forward * speed * Time.deltaTime);
     }
      */
}