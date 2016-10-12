using UnityEngine;
using System.Collections;

public class LightningBolt : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{		
		Renderer rd = GetComponent<Renderer> ();
		Material newMat = rd.material;
		newMat.SetFloat("_StartSeed",Random.value*1000);
		rd.material = newMat;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

