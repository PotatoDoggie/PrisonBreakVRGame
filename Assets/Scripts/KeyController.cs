namespace VRTK
{
    using UnityEngine;
    using System.Collections;

    public class KeyController : MonoBehaviour
    {
        public ElectricalLeverReactor electricReactor;
        public TapeController tape;

        private Rigidbody rb;
        private VRTK_InteractableObject keyInteractor;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            keyInteractor = GetComponent<VRTK_InteractableObject>();
        }

        void Update()
        {
            if (electricReactor.ElectricOn == false || tape.wireFixed == true)
            {
                keyInteractor.isGrabbable = true;
                //keyInteractor.touchHighlightColor = Color.clear;
                //keyInteractor.highlightOnTouch = true;
                keyInteractor.holdButtonToGrab = false;
                keyInteractor.grabAttachMechanic = VRTK_InteractableObject.GrabAttachType.Child_Of_Controller;
            }
            else {
                keyInteractor.isGrabbable = false;
                //keyInteractor.highlightOnTouch = false;
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

