using UnityEngine;
using System.Collections;
using VRTK;

public class CodePadButton : VRTK_InteractableObject {
	public CombinationShow combinationShow;
	public GameObject[] buttons;

    protected override void Start() {
        base.Start();
    }
    

	void OnTriggerEnter(Collider other) {
		/*int color = System.Array.IndexOf (buttons, gameObject);
		combinationShow.inputCode (color);
		Debug.Log (color);*/
	}


    public override void StartUsing(GameObject usingObject) {
        int color = System.Array.IndexOf(buttons, gameObject);
        combinationShow.inputCode(color);
        Debug.Log(color);
    }


}
