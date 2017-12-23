using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCS : MonoBehaviour
{
    private GameObject m_weapon, r_weapon;

    public void SetWeapon(Item item)
    {
        if (item is R_WeaponItem)
        {
            var _item = item as R_WeaponItem;
            r_weapon = _item.equipable;
        }
        else if (item is M_WeaponItem)
        {
            var _item = item as R_WeaponItem;
            m_weapon = _item.equipable;
        }
    }
}
