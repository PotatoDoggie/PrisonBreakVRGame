using UnityEngine;
using VRTK;
using System.Collections;

public class KeypadController : VRTK_InteractableObject
{
    private string curPassword = "2628";
    private string input;
    private bool doorOpen;
    //private bool keypadScreen;
 
    //public Transform doorHinge;
    private GameObject screen;
    private GameObject door;
    private ElightController eLight;
	private TextMesh tm;

	protected override void Start() {
		base.Start ();
		screen = GameObject.Find ("Screen");
		door = GameObject.Find ("PrisonCellDoorWayDoor");
		eLight = GameObject.Find ("ElecticLight").GetComponent<ElightController> ();
		tm = screen.GetComponent<TextMesh>();
	}

	public override void StartUsing(GameObject usingObject)
	{
		base.StartUsing(usingObject);
		pressButtons(usingObject.name);
	}

	void pressButtons(string name)
    {
		input = tm.text;
		doorOpen = door.GetComponent<DoorController> ().doorOpen;
        if (eLight.powerOn) {
            if (!doorOpen)
            {
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
                else if (name.Equals("Cube_cancel"))
                {
                    input = "";
                    tm.text = input;
                }
                else if (name.Equals("Cube_enter"))
                {
                    if (input.Equals(curPassword))
                    {
                        doorOpen = true;
						door.GetComponent<DoorController> ().doorOpen = doorOpen;
                        input = "";
                        tm.text = "Congratuations!";
                    }
                    else
                    {
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

    }
}
