namespace VRTK
{
    using UnityEngine;

    public class TapeController : MonoBehaviour
    {

        private Rigidbody rb;

        public bool wireFixed;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            wireFixed = false;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("BrokenWire"))
            {
                GameObject[] brokenWires = GameObject.FindGameObjectsWithTag("BrokenWire");
                for (int i = 0; i < brokenWires.Length; i++)
                {
                    brokenWires[i].SetActive(false);
                }
                GameObject healthywire = GameObject.Find("healthy wire");
                MeshRenderer mr = healthywire.GetComponent<MeshRenderer>();
                mr.enabled = true;
                wireFixed = true;
            }
        }
    }
}
