using UnityEngine;
using System.Collections;
using VRTK;

public class LeverReactor : MonoBehaviour {

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

        if (normalizedValue > 60)
        {
            go.text = "Electric OFF!";
            MovingPlank.Instance.changeActive();
        }
        else
        {
            go.text = "Electric ON!";
            MovingPlank.Instance.changeActive();

        }
    }
}
