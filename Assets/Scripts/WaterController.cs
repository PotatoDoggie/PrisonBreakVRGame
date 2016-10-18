using UnityEngine;
using System.Collections;
using VRTK;

public class WaterController : MonoBehaviour {
	public VRTK_InteractableObject keyInteractor;
	public ElectricalLeverReactor electricReactor;
	public TapeController tape;

	private TextMesh tm;

	void Start(){
		keyInteractor = GetComponent<VRTK_InteractableObject>();
		tm = GameObject.Find ("Attention").GetComponent<TextMesh> ();
	}

	void OnTriggerEnter(Collider other) {
		//Only when the key is in the water it can be changed to un grabbable
		if (other.gameObject.name.Equals ("key_silver")) {
			if (electricReactor.ElectricOn == true && tape.wireFixed == false) {
				tm.text = "Electricity in! Dangerous! \nCannot pick up the key now!";
				keyInteractor.isGrabbable = false;
			}
		}
	}
}
