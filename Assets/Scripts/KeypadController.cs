using UnityEngine;
using VRTK;
using System.Collections;

public class KeypadController : MonoBehaviour
{

    private string curPassword = "2628";
    private string input;
    private bool doorOpen = false;
    private bool keypadScreen;
 
    //public Transform doorHinge;
    public GameObject screen;
    public GameObject door;
    public ElightController eLight;

    void OnTriggerEnter(Collider other)
    {
        TextMesh tm = screen.GetComponent<TextMesh>();
        if (eLight.powerOn) {
            if (!doorOpen)
            {
                if (other.name.Equals("Cube_0"))
                {
                    input += "0";
                    tm.text = input;
                }
                else if (other.name.Equals("Cube_1"))
                {
                    input += "1";
                    tm.text = input;
                }
                else if (other.name.Equals("Cube_2"))
                {
                    input += "2";
                    tm.text = input;
                }
                else if (other.name.Equals("Cube_3"))
                {
                    input += "3";
                    tm.text = input;
                }
                else if (other.name.Equals("Cube_4"))
                {
                    input += "4";
                    tm.text = input;
                }
                else if (other.name.Equals("Cube_5"))
                {
                    input += "5";
                    tm.text = input;
                }
                else if (other.name.Equals("Cube_6"))
                {
                    input += "6";
                    tm.text = input;
                }
                else if (other.name.Equals("Cube_7"))
                {
                    input += "7";
                    tm.text = input;
                }
                else if (other.name.Equals("Cube_8"))
                {
                    input += "8";
                    tm.text = input;
                }
                else if (other.name.Equals("Cube_9"))
                {
                    input += "9";
                    tm.text = input;
                }
                else if (other.name.Equals("Cube_cancel"))
                {
                    input = "";
                    tm.text = input;
                }
                else if (other.name.Equals("Cube_enter"))
                {
                    if (input.Equals(curPassword))
                    {
                        doorOpen = true;
                        input = "";
                        tm.text = "Congraduation!";
                    }
                    else
                    {
                        input = "";
                        tm.text = "Password Wrong! ";
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
