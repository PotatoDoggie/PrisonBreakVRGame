using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using VRTK;

public class SceneSwitch : VRTK_InteractableObject {
    public int destination = 0;

	protected override void Start() {
		base.Start();
	}

	protected override void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
        if (Input.GetKeyDown("e"))
        {
            SceneManager.LoadScene(destination);
        }
    }
	public override void StartUsing(GameObject usingObject) {
		SceneManager.LoadScene(destination);
	}
}
