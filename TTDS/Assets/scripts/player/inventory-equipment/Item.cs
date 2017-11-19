using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public new string name;
    public ItemType type;
    public int cost;
    public float mass;
    public GameObject phys;
}

public enum ItemType
{
    gear,
    weapon,
    consumable,
    trash
}

[CreateAssetMenu(fileName = "New Equipable Item", menuName = "Inventory/Equipable Item")]
public class EquipableItem : Item
{
    public GameObject Equipable;
}