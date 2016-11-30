using UnityEngine;
using System.Collections;

public class DestoriableObj : MonoBehaviour {

    public GameObject dropWhenDestried;
	public AudioClip balloonPop;

	private AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        if (dropWhenDestried != null) {
            dropInitial(dropWhenDestried);
        }
		//audioSource = GameObject.Find("/MainAudioSource").GetComponent<AudioSource> ();
    }
//	void Update() {
//		if (Input.GetKeyDown ("a")) {
//			audioSource.PlayOneShot (balloonPop, 1.0f);
//		}
//	}
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow")) {
			GameObject.Find ("Balloons").GetComponent<AudioSource> ().Play ();
			//audioSource.PlayOneShot (balloonPop, 1.0f);
            if (dropWhenDestried != null)
            {
                dropItem(dropWhenDestried);
            }
            Destroy(this.gameObject);
        }
    }
    //initial obj for drop, setactive false
    void dropInitial(GameObject obj) {
        obj.transform.position = this.transform.position;
        obj.SetActive(false);
    }

    void dropItem(GameObject obj) {
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.velocity += new Vector3(0.0f, 0.0001f, 0.0f);
    }

}
