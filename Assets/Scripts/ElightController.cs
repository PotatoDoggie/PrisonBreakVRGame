namespace VRTK
{
    using UnityEngine;

    public class ElightController : MonoBehaviour
    {
        public ElectricalLeverReactor eReactor;
        public TapeController tape;
        public bool powerOn;

        private bool ePowerOn;
        private bool wireFixed; 
		private GameObject wallLightOff;
		private GameObject wallLightOn;
        //private Renderer render;
		private GameObject[] keypadTexts;
		private Color mycolor;

        void Start() {
            //render = GetComponent<Renderer>();
			wallLightOn = GameObject.Find("Lamp_ON");
			wallLightOff = GameObject.Find ("Lamp_OFF");
			keypadTexts = GameObject.FindGameObjectsWithTag ("KeypadText");
			mycolor = keypadTexts [0].GetComponent<TextMesh> ().color;
        }
        // Update is called once per frame
        void Update()
        {
            ePowerOn = eReactor.ElectricOn;
            wireFixed = tape.wireFixed;
            if (ePowerOn && wireFixed)
            {
				powerOn = true;

                //render.material.color = Color.green;
				wallLightOn.SetActive(true);
				wallLightOff.SetActive (false);

				//Set color for keypad text -- power on
				for (int i = 0; i < keypadTexts.Length; i++) {
					keypadTexts [i].GetComponent<TextMesh> ().color = Color.white;
				}
            }
            else {
				powerOn = false;

                //render.material.color = Color.red;
				wallLightOn.SetActive(false);
				wallLightOff.SetActive (true);

                //Set color for keypad text -- power off
				//Color newColor = new Color(0x8, 0x3, 0x3, 0x255);
				for (int i = 0; i < keypadTexts.Length; i++) {
					keypadTexts [i].GetComponent<TextMesh> ().color = mycolor;
				}
            }
        }
    }
}
