namespace VRTK
{
    using UnityEngine;
    using System.Collections;

    public class KeyController : MonoBehaviour
    {

        private Rigidbody rb;
        private ElectricalLeverReactor electricOn;
        private bool wireFixed;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            electricOn = GetComponent<ElectricalLeverReactor>();
        }

        void Update()
        {

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

