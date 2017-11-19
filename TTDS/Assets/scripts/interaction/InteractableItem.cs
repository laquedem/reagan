using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : Interactable
{
    public Item item;

    protected override void Interact(Collider player)
    {
        Inventory inventory = player.GetComponent<Inventory>();

        if (inventory != null && inventory.AddItem(item))
        {
            Destroy(gameObject);
        }
    }
}
