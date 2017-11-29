using System.Collections.Generic;
using UnityEngine;

public class InventoryCS : MonoBehaviour
{
    // list off all items
    public List<Item> inventory = new List<Item>();
    
    public float carry;
    public float m_mass;

    public bool AddItem(Item item)
    {
        if (item.mass + carry <= m_mass)
        {
            inventory.Add(item);
            carry += item.mass;
            return true;
        }
        else return false;
    }

    public void DeleteItem(Item item)
    {
        inventory.Remove(item);
    }
}
