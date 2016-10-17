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

        void Start() {
            //render = GetComponent<Renderer>();
			wallLightOn = GameObject.Find("Lamp_ON");
			wallLightOff = GameObject.Find ("Lamp_OFF");
        }
        // Update is called once per frame
        void Update()
        {
            ePowerOn = eReactor.ElectricOn;
            wireFixed = tape.wireFixed;
            if (ePowerOn && wireFixed)
            {
                //render.material.color = Color.green;
				wallLightOn.SetActive(true);
				wallLightOff.SetActive (false);
                powerOn = true;
            }
            else {
                //render.material.color = Color.red;
				wallLightOn.SetActive(false);
				wallLightOff.SetActive (true);
                powerOn = false;
            }
        }
    }
}
