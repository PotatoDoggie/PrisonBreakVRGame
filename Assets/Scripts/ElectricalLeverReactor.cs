namespace VRTK
{
    using UnityEngine;

    public class    ElectricalLeverReactor : MonoBehaviour
    {
        public Renderer eLight;
        public bool ElectricOn;

        public TextMesh go;

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
                go.text = "Electric OFF!";
                ElectricOn = false;
				for (int i = 0; i < objs.Length; i++) {
					objs [i].GetComponent<Light> ().enabled = false;
				}
            }
            else {
                go.text = "Electric ON!";
                ElectricOn = true;
				for (int i = 0; i < objs.Length; i++) {
					objs [i].GetComponent<Light> ().enabled = true;
				}
            }
        }
    }
}