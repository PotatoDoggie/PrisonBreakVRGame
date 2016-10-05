﻿namespace VRTK
{
    using UnityEngine;

    public class ElightController : MonoBehaviour
    {
        public ElectricalLeverReactor eReactor;
        public TapeController tape;

        private bool ePowerOn;
        private bool wireFixed;
        private Renderer render;

        void Start() {
            render = GetComponent<Renderer>();
        }
        // Update is called once per frame
        void Update()
        {
            ePowerOn = eReactor.ElectricOn;
            wireFixed = tape.wireFixed;
            if (ePowerOn && wireFixed)
            {
                render.material.color = Color.green;
            }
            else {
                render.material.color = Color.red;
            }
        }
    }
}
