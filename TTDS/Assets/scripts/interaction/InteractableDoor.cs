using UnityEngine;

public class InteractableDoor : Interactable
{
    public GameObject Door;
    public GameObject DoorPrefab;

    protected override void Interact(Collider player)
    {
        if (Door == null)
            Door = Instantiate(DoorPrefab, transform);
        else Destroy(Door);
    }
}
