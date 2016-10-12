using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitch : MonoBehaviour {
    public int destination = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e"))
        {
            SceneManager.LoadScene(destination);
        }


    }
}
