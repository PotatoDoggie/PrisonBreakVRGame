using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour {

	private int cur;
	private int destination;
	void Start() {
		cur = SceneManager.GetActiveScene ().buildIndex;
		destination = cur + 1;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("r")) {
			SceneManager.LoadScene (cur);
		} 
		if (Input.GetKeyDown ("n")) {
			SceneManager.LoadScene (destination);
		}
	}
}
