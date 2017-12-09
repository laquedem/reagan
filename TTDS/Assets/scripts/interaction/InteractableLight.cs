using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLight : Interactable
{
    public GameObject[] Lights;

    protected override void Interact(Collider player)
    {
        foreach (GameObject light in Lights)
        {
            light.SetActive(!(light.active));
        }
    }


}
