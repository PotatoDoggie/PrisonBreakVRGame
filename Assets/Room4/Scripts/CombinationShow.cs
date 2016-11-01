﻿using UnityEngine;
using System.Collections;
using System.Linq;

public class CombinationShow : MonoBehaviour {

	/**
	 * State:
	 * 0 -- Ready
	 * 1 -- Show text on the wall
	 * 2 -- Hide text on the wall (interval)
	 * 3 -- Wait for the next ready state
	 * -1 -- Start
	 * 0 -> 1 -> 2 -> 1 -> 2 -> ... -> 1 -> 3 (do not change anything) -> 0 ...
	 * -1 -> 0
	 */

	public float readyTime = 1.5f;
	public float showTextTime = 1.5f;
	public float intervalTime = 0.5f;
	public float endTime = 0.5f;


	public GameObject combinationText;
	public GameObject readyText;
	public int combinationLength;
	public Material fontMaterial;
	public GameObject door;
	public SceneSwitchDoor sceneSwitchDoor;


	private Animator doorAnimator;

	private float currentTimer;

	private int[] combination;

	private int[] current;
	private int currentCodeLen;

	private int currentState;

	private bool complete;

	private string[] colorTexts;
	private Color[] colors;
	private System.Random random;
	private int currentColor;

	// Use this for initialization
	void Start () {
		doorAnimator = door.GetComponent<Animator> ();
		currentState = -1;
		currentTimer = 0;

		colorTexts = new string[] {"Red", "Yellow", "Blue", "Green"};
		random = new System.Random ();
		//red, yellow, blue, green
		colors = new Color[] {Color.red, Color.yellow, new Color(0, .22f, 1), new Color(.35f, .65f, .35f)};

		//the generated combination
		combination = new int[combinationLength];

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
				sceneSwitchDoor.isUsable = true;

				//sceneSwitchDoor.highlightOnTouch = true;
				complete = true;
				return;
			} else {
				Debug.Log ("Wrong");
				currentTimer = -1;
				currentState = -1;
			}
		}

		currentTimer -= Time.deltaTime;

		if (currentTimer < 0) {
			switch (currentState) {
				case 0:
					currentState = 1;
					break;
				case 1:
					if (currentColor == combinationLength) {
						currentState = 3;
					} else {
						currentState = 2;
					}
					break;
				case 2:
					currentState = 1;
					break;
				case 3:
					currentState = 0;
					break;
				case -1:
					currentState = 0;
					break;
			}
			//After state update
			switch (currentState) {
				case 0:
					currentTimer = readyTime;
					//Set ready text
					combinationText.SetActive (true);
					fontMaterial.color = Color.black;
					combinationText.GetComponent<TextMesh> ().text = "Ready!";
					generateCombination ();
					break;
				case 1:
					currentTimer = showTextTime;
					combinationText.SetActive (true);
					TextMesh combTextMesh = combinationText.GetComponent<TextMesh> ();
					combTextMesh.text = colorTexts [random.Next (0, colorTexts.Length)];
					fontMaterial.color = colors [combination [currentColor]];
					++currentColor;
					break;
				case 2:
					combinationText.SetActive (false);
					currentTimer = intervalTime;
					break;
				case 3:
					currentTimer = endTime;
					break;
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
