using UnityEngine;
using System.Collections;
using VRTK;

public class Room3_ElectricSwitch : VRTK_InteractableObject
{
    public GameObject cagePillars;

    private bool isOn;

    //initial
    protected override void Start()
    {
        base.Start();
        isOn = false;
        //show cagePillars
        Renderer[] ChildRends = cagePillars.GetComponentsInChildren<Renderer>();
        foreach (Renderer i in ChildRends) {
            i.enabled = true;
        }
    }
    //when using
    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        Debug.Log(this.name + " is used in OnInteractableObjUsed");
        isOn = !isOn;
        //change color of ElectricLine tag
        var lines = GameObject.FindGameObjectsWithTag("ElectricLine");
        foreach (GameObject i in lines) {
            Renderer rend = i.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Standard");
            rend.material.color = Color.yellow;
        }
        //hide cagePillars
        Renderer[] ChildRends = cagePillars.GetComponentsInChildren<Renderer>();
        foreach (Renderer i in ChildRends)
        {
            i.enabled = false;
        }
    }

    protected override void Update()
    {
        base.Update();
        SwitchEffect();
    }

    //call for the stauts of the switch, return bool;
    public bool AskStatus() {
        return isOn;
    }

    //set the gameobj's transform to show the status of the switch
    private void SwitchEffect() {
        if (isOn)
        {
            //On status
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            //off status
            this.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }




}
