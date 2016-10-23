using UnityEngine;
using System.Collections;

public class fader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void Awake() {
        SteamVR_Fade.Start(Color.black, 0);
        SteamVR_Fade.Start(Color.clear, 15);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
