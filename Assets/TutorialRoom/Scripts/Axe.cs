using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Axe : MonoBehaviour {
	private int collisionTimes = 1;
	GameObject door;
	GameObject doorHandle;
	// Use this for initialization
	void Start () {
		door = GameObject.Find ("Door");
		doorHandle = GameObject.Find ("DoorHandle");
	}
	void Update() {
		if (Input.GetKeyDown ("o")) {
			this.gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name.Equals ("DoorHandle") || other.gameObject.name.Equals("Door")) {
			this.gameObject.GetComponent<AudioSource> ().Play ();
			collisionTimes--;
			if (collisionTimes == 0) {
				door.transform.Rotate (new Vector3 (0, 45, 0));
				SteamVR_Fade.Start(Color.black, 0);
				SteamVR_Fade.Start(Color.clear, 5);
				SceneManager.LoadScene(1);
			}
		}
	}
}
