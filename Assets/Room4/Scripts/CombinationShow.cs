using UnityEngine;
using System.Collections;
using System.Linq;

public class CombinationShow : MonoBehaviour {
	/**
	 * Time line
	 * 0 -> 49: every color
	 * 0 -> 9: every interval
	 * -150 -> -21: last color (the window to input password, expires after it)
	 * -20 -> -1: ready text, generate new combination
	 */
	public GameObject combinationText;
	public GameObject readyText;
	public int combinationLength;
	public Material fontMaterial;
	public GameObject door;

	private Animator doorAnimator;

	private int timer;
	private int[] combination;

	private int[] current;
	private int currentCodeLen;

	private bool complete;

	private string[] colorTexts;
	private Color[] colors;
	private System.Random random;
	private int currentColor;

	// Use this for initialization
	void Start () {
		doorAnimator = door.GetComponent<Animator> ();
		timer = 0;
		combinationText.SetActive (false);
		colorTexts = new string[] {"Red", "Yellow", "Blue", "Green"};
		random = new System.Random ();
		//red, yellow, blue, green
		colors = new Color[] {Color.red, Color.yellow, new Color(0, .22f, 1), new Color(.35f, .65f, .35f)};
		//the generated combination
		combination = new int[combinationLength];
		generateCombination ();
		complete = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (complete) {
			return;
		}
		if (currentCodeLen == combinationLength) {
			Debug.Log ("Code complete, comparing...");
			if (current.SequenceEqual (combination)) {
				Debug.Log ("Correct, open the door");
				doorAnimator.SetTrigger ("DoorOpen");
				gameObject.SetActive (false);
				complete = true;
				return;
			} else {
				Debug.Log ("Wrong");
				timer = -20;
			}

		}

		if (timer == -20) {
			//Set ready text
			TextMesh combTextMesh = combinationText.GetComponent<TextMesh> ();
			combTextMesh.text = "Ready!";
			generateCombination ();
		}
		if (timer < 0) {
			++timer;
			return;
		}
		if (combinationText.activeSelf) {
			timer = (timer + 1) % 150;
		} else {
			timer = (timer + 1) % 30;
		}
		if (timer == 0) {
			combinationText.SetActive(!combinationText.activeSelf);
			if (combinationText.activeSelf) {
				TextMesh combTextMesh = combinationText.GetComponent<TextMesh> ();
				combTextMesh.text = colorTexts[random.Next (0, colorTexts.Length)];
				fontMaterial.color = colors[combination[currentColor]];
				++currentColor;
				if (currentColor == combinationLength) {
					timer = -170;
				}
			}
		}
	}

	void generateCombination() {
		//Wipe the current input codes
		current = new int[combinationLength];
		currentCodeLen = 0;

		currentColor = 0;
		string s = "";
		for (int i = 0; i < combinationLength; ++i) {
			combination [i] = random.Next (0, 4);
			s += colorTexts[combination[i]];
		}
		Debug.Log (s);
	}

	public int[] getCombination() {
		return combination;
	}

	public void inputCode(int color) {
		if (!complete && currentCodeLen < combinationLength) {
			current [currentCodeLen++] = color;
		}
	}
}
