using UnityEngine;
using System.Collections;

public class fader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SteamVR_Fade.Start(Color.black, 0);
		SteamVR_Fade.Start(Color.clear, 15);
	}
    void Awake() {

    }
	// Update is called once per frame
	void Update () {
	
	}
}
