using UnityEngine;
#region enums
public enum Rarity
{
    rarity_1 = 0,
    rarity_2,
    rarity_3,
    rarity_4,
    rarity_5
}

public enum ItemType
{
    weapon = 1,
    gear = 2,
    cumsumable = 3,
    other = 0
}

public enum RangedWeaponType
{
pistol,
assault_rifle,
sniper_rifle,
lasergun
        // etc
}

public enum MeeleWeaponType
{

}
#endregion

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public new string name;
    public float mass;
    public Rarity rarity;
    public ItemType type;           
    public GameObject physical;     // game object that presents item in real world while it's not equiped
}

public abstract class WeaponItem : Item
{
    public GameObject equipable;        // reference to game object that player equips
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Ranged Weapon")]
public class R_WeaponItem : WeaponItem {
    public RangedWeaponType weaponType;
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Meele Weapon")]
public class M_WeaponItem : WeaponItem {
    public MeeleWeaponType weaponType;
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Gear")]
public class GearItem : Item {
    public GameObject equipable;        // reference to game object that player equips
}
