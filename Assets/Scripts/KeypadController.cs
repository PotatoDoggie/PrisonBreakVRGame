﻿using UnityEngine;
using VRTK;
using UnityEngine.SceneManagement;
using System.Collections;

public class KeypadController : VRTK_InteractableObject
{
    private string curPassword = "2826";
    private string input;
    private bool doorOpen;
    private ElectricalLeverReactor lever;
    private TapeController tape;
    private GameObject screen;
    private GameObject door;

    //private ElightController eLight;
	private TextMesh tm;
    private int timer = 100;
    private int delta = 3;

	protected override void Start() {
		base.Start ();
		screen = GameObject.Find ("Screen");
		door = GameObject.Find ("PrisonCellDoorWayDoor");
		//eLight = GameObject.Find ("ElecticLight").GetComponent<ElightController> ();
        lever = GameObject.Find("Lever").GetComponent<ElectricalLeverReactor>();
        tape = GameObject.Find("Tape").GetComponent<TapeController>();
        tm = screen.GetComponent<TextMesh>();
	}
    protected override void Update()
    {
        base.Update();
        if (doorOpen) {
            timer = timer - delta;
            if(timer < 0)
            {
                SteamVR_Fade.Start(Color.black, 0);
                SteamVR_Fade.Start(Color.clear, 5);
                SceneManager.LoadScene(3);
            }
        }
    }
    public override void StartUsing(GameObject usingObject)
	{
		base.StartUsing(usingObject);
		pressButtons(this.gameObject.name);
	}

	void pressButtons(string name)
    {
        if (tm.text.Equals("Password Wrong!"))
        {
            tm.text = "";
        }
        input = tm.text;
		doorOpen = door.GetComponent<DoorController> ().doorOpen;
        if (lever.ElectricOn && tape.wireFixed)
        {
            if (!doorOpen)
            {
				GameObject.Find ("Keypad").GetComponents<AudioSource> () [2].Play ();
                if (name.Equals("Cube_0"))
                {
                    input += "0";
                    tm.text = input;
                }
                else if (name.Equals("Cube_1"))
                {
                    input += "1";
                    tm.text = input;
                }
                else if (name.Equals("Cube_2"))
                {
                    input += "2";
                    tm.text = input;
                }
                else if (name.Equals("Cube_3"))
                {
                    input += "3";
                    tm.text = input;
                }
                else if (name.Equals("Cube_4"))
                {
                    input += "4";
                    tm.text = input;
                }
                else if (name.Equals("Cube_5"))
                {
                    input += "5";
                    tm.text = input;
                }
                else if (name.Equals("Cube_6"))
                {
                    input += "6";
                    tm.text = input;
                }
                else if (name.Equals("Cube_7"))
                {
                    input += "7";
                    tm.text = input;
                }
                else if (name.Equals("Cube_8"))
                {
                    input += "8";
                    tm.text = input;
                }
                else if (name.Equals("Cube_9"))
                {
                    input += "9";
                    tm.text = input;
                }
                else if (name.Equals("Cube_cancel") && !input.Equals(""))
                {
                    int length = input.Length;
                    input = input.Remove(length - 1, 1);
                    tm.text = input;
                }
                else if (name.Equals("Cube_enter"))
                {
                    if (input.Equals(curPassword))
                    {
						GameObject.Find ("Keypad").GetComponents<AudioSource> () [1].Play ();
                        doorOpen = true;
                        door.GetComponent<DoorController>().doorOpen = doorOpen;
                        input = "";
                        tm.text = "Congratuations!";
                    }
                    else
                    {
						GameObject.Find ("Keypad").GetComponents<AudioSource> () [0].Play ();
                        input = "";
                        tm.text = "Password Wrong!";
                    }
                }
                if (doorOpen)
                {
                    door.transform.Rotate(new Vector3(0, -45, 0));

                }
            }
        }
        else {
            tm.text = "";
        }

    }
}
