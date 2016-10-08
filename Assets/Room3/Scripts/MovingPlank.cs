using UnityEngine;
using System.Collections;

public class MovingPlank : MonoBehaviour 
{
	
	void Update() 
	{
		transform.position = new Vector3(Mathf.PingPong(Time.time, 2.5f), transform.position.y, transform.position.z);
	}
}