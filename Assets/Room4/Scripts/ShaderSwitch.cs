using UnityEngine;
using System.Collections;

public class ShaderSwitch : MonoBehaviour {

	public GameObject shader;
	private Animator shaderAnimator;

	// Use this for initialization
	void Start () {
		shaderAnimator = shader.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other) {
		Debug.Log ("trigger");
		shaderAnimator.SetTrigger ("ShaderDown");
	}
	void OnTriggerExit(Collider other) {
		shaderAnimator.SetTrigger ("ShaderUp");
	}
}
