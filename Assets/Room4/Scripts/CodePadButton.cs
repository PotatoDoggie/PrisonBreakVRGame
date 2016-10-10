using UnityEngine;
using System.Collections;

public class CodePadButton : MonoBehaviour {
	public CombinationShow combinationShow;
	public GameObject[] buttons;
	private Animator targetAnimator;
    void Start() {
		targetAnimator = GetComponent<Animator> ();
    }
    

	void OnTriggerEnter(Collider other) {
		Debug.Log (gameObject);
		if (other.gameObject.tag == "Arrow") {
			targetAnimator.SetTrigger ("ShootingTargetDown");
			int color = System.Array.IndexOf (buttons, gameObject);
			combinationShow.inputCode (color);
			Debug.Log (color);
		}
	}

	void Update() {
		/*if (Input.GetKeyDown ("t")) {
			targetAnimator.SetTrigger ("ShootingTargetDown");
		}*/
	}

}
