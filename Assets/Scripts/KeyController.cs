namespace VRTK
{
    using UnityEngine;
    using System.Collections;

    public class KeyController : MonoBehaviour
    {
        public ElectricalLeverReactor electricReactor;
        public TapeController tape;

		private GameObject[] objs;
        private Rigidbody rb;
        private VRTK_InteractableObject keyInteractor;
		private TextMesh tm;
        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            keyInteractor = GetComponent<VRTK_InteractableObject>();
			tm = GameObject.Find ("Attention").GetComponent<TextMesh> ();
			objs = GameObject.FindGameObjectsWithTag ("ElectricSpark");
        }

        void Update()
        {
			if(electricReactor.ElectricOn == false || tape.wireFixed == true)
			{
				tm.text = "";
				keyInteractor.isGrabbable = true;
				keyInteractor.holdButtonToGrab = false;
				keyInteractor.grabAttachMechanic = VRTK_InteractableObject.GrabAttachType.Child_Of_Controller;
				//Disable the electric sparks 
				for (int i = 0; i < objs.Length; i++) {
					objs [i].GetComponent<MeshRenderer> ().enabled = false;
				}
			}

        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("KeyHole"))
            {
                GameObject doorLeft = GameObject.FindGameObjectWithTag("DoorLeft");
                GameObject doorRight = GameObject.FindGameObjectWithTag("DoorRight");
                doorLeft.transform.Rotate(new Vector3(0, 90, 0));
                doorRight.transform.Rotate(new Vector3(0, -90, 0));
            }
        }
    }
}

