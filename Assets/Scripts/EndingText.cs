using UnityEngine;
using System.Collections;

public class EndingText : MonoBehaviour {
	private float finalHeight = 3f;
	private float beginHeight = -2f;

	private GameObject memberText;
	private bool text1RiseTop = false;
	private bool text2RiseTop = false;
	private float speed = 0.5f;
	private Vector3 curPosition1;
	private Vector3 curPosition2;
	// Use this for initialization
	void Start () {
		memberText = GameObject.Find ("Text_2");
		curPosition1 = this.transform.position;
		curPosition2 = memberText.transform.position;
		memberText.transform.position = new Vector3(curPosition2.x, beginHeight, curPosition2.z);
		this.gameObject.transform.position = new Vector3 (curPosition1.x, beginHeight, curPosition1.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (!text1RiseTop && !text2RiseTop) {
			if (this.gameObject.transform.position.y - finalHeight > 0.001f) {
				text1RiseTop = true;
				this.transform.position = new Vector3 (curPosition1.x, finalHeight, curPosition1.z);
			} else {
				this.gameObject.transform.position = new Vector3 (
					curPosition1.x, 
					this.gameObject.transform.position.y + speed * Time.deltaTime, 
					curPosition1.z); 
			}
		} 
		if (text1RiseTop && !text2RiseTop) {
			if (memberText.transform.position.y - finalHeight > 0.001f) {
				text2RiseTop = true;
				memberText.transform.position = new Vector3 (curPosition2.x, finalHeight, curPosition2.z);
				return;
			} else {
				memberText.transform.position = new Vector3 (curPosition2.x, 
					memberText.transform.position.y + speed * Time.deltaTime,
					memberText.transform.position.z);
			}
		}
	}
}
