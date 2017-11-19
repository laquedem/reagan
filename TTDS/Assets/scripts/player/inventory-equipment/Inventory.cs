using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    private Item gear;
    private Item[] weapons;

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
}
