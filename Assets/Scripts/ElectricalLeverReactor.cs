namespace VRTK
{
    using UnityEngine;

    public class    ElectricalLeverReactor : MonoBehaviour
    {
        //public Renderer eLight;
        public bool ElectricOn;

        private void Start()
        {
            GetComponent<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChange);
            HandleChange(GetComponent<VRTK_Control>().GetValue(), GetComponent<VRTK_Control>().GetNormalizedValue());
        }
			
        private void HandleChange(float value, float normalizedValue)
        {
			GameObject[] objs = GameObject.FindGameObjectsWithTag ("Light");
            if (normalizedValue > 60)
            {
				GameObject.Find ("PrisonElectricalPanel").GetComponents<AudioSource> () [0].Play ();
                ElectricOn = false;
				for (int i = 0; i < objs.Length; i++) {
					objs [i].GetComponent<Light> ().enabled = false;
				}
            }
            else {
				GameObject.Find ("PrisonElectricalPanel").GetComponents<AudioSource> () [0].Play ();
                ElectricOn = true;
				for (int i = 0; i < objs.Length; i++) {
					objs [i].GetComponent<Light> ().enabled = true;
				}
            }
        }
    }
}