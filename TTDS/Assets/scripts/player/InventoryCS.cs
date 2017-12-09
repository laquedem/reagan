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
            InventorySorter.Sort(ref inventory, SortingType.mass);
            return true;
        }
        else return false;
    }

    public void DeleteItem(Item item)
    {
        Instantiate(item.physical, transform.position + transform.forward * 0.5f, transform.rotation);
        inventory.Remove(item);
    }

    public void SortInventory()
    {
        // sorts inventory in alphabet order
        inventory.Sort();
    }
}

// next there is a special sorting class

public static class InventorySorter
{
    public static void Sort(ref List<Item> list, SortingType type)
    {
        if ((int)type == 0)
        {
            list.Sort();
            return;
        }   // sorting by name

        if ((int)type == 1) 
        {
            list.Sort(delegate (Item item_1, Item item_2)
            { return item_1.mass.CompareTo(item_2.mass); });
        }   // sorting by mass

        if ((int)type == 2) 
        {
            List<Item> rarity_1 = new List<Item>();
            List<Item> rarity_2 = new List<Item>();
            List<Item> rarity_3 = new List<Item>();
            List<Item> rarity_4 = new List<Item>();
            List<Item> rarity_5 = new List<Item>();

            // dividing by rarity

            foreach (Item item in list)
            {
                switch ((int)item.rarity)
                {
                    case 0:
                        rarity_1.Add(item);
                        break;
                    case 1:
                        rarity_2.Add(item);
                        break;
                    case 2:
                        rarity_3.Add(item);
                        break;
                    case 3:
                        rarity_4.Add(item);
                        break;
                    case 4:
                        rarity_5.Add(item);
                        break;
                }
            } 

            rarity_1.Sort();
            rarity_2.Sort();
            rarity_3.Sort();
            rarity_4.Sort();
            rarity_5.Sort();

            list.AddRange(rarity_5);
            list.AddRange(rarity_4);
            list.AddRange(rarity_3);
            list.AddRange(rarity_2);
            list.AddRange(rarity_1);
            return;
        }   // sorting by rarity
    }

    public static List<Item> SortInGroup(List<Item> list, SortingType type)
    {
        List<Item> sorted = new List<Item>();

        if ((int)type == 3)
        {
            foreach (Item item in list)
            {
                if (item.type == ItemType.weapon)
                    sorted.Add(item);
            }

            sorted.Sort();
            return sorted;
        }   // weapon only sort

        if ((int)type == 4)
        {
            foreach (Item item in list)
            {
                if (item.type == ItemType.gear)
                    sorted.Add(item);
            }

            sorted.Sort();
            return sorted;
        }   // gear only sort

        if ((int)type == 5)
        {
            foreach (Item item in list)
            {
                if (item.type == ItemType.cumsumable)
                    sorted.Add(item);

                sorted.Sort();
                return sorted;
            }
        }   // consumables only sort

        if ((int)type == 6)
        {
            foreach (Item item in list)
            {
                R_WeaponItem test = new R_WeaponItem();
                if (item.GetType() == test.GetType())
                    sorted.Add(item);
            }

            sorted.Sort();
            return sorted;
        }   // ranged weapons only

        if ((int)type == 7)
        {
            foreach (Item item in list)
            {
                M_WeaponItem test = new M_WeaponItem();
                if (item.GetType() == test.GetType())
                    sorted.Add(item);
            }

            sorted.Sort();
            return sorted;
        }   // meele weapons only

        return sorted;
    }
}


public enum SortingType
{
    name = 0,
    mass = 1,
    rarity = 2,
    weapons_only = 3,
    gear_only = 4,
    consumables_only = 5,
    r_weapons_only = 6,
    m_weapons_only = 7,
}