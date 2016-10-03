using UnityEngine;
using System.Collections;

public class RTSCamera : MonoBehaviour {

	public float PanSpeed = 10;
		

	
	
	void Start () {
		      
	
	}
		
	void Update () {

			if ( Input.GetKey("d") ) {             
				transform.Translate(Vector3.right * Time.deltaTime * PanSpeed, Space.Self );   
			}
			else if ( Input.GetKey("a") ) {            
				transform.Translate(Vector3.right * Time.deltaTime * -PanSpeed, Space.Self );              
			}
			
			if ( Input.GetKey("s")  ){            
				transform.Translate(Vector3.forward * Time.deltaTime * PanSpeed, Space.World );             
			}
			else if ( Input.GetKey("w"))          
				transform.Translate(Vector3.forward * Time.deltaTime * -PanSpeed, Space.World );            
			  
	
		}
		

	}

