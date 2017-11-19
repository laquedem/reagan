using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private SphereCollider interZone;
    public float interactionRadius;

    protected virtual void Awake()
    {
        interZone = GetComponent<SphereCollider>();
        interZone.radius = interactionRadius;
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("e"))
        {
            Debug.Log("Player tried to interact");
            Interact(other);
        }
    }

    protected abstract void Interact(Collider player);
}
