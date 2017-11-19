using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float fireRate;
    public float reloadTime;
    public WeaponState state;

    public abstract IEnumerator Reload();

    public abstract IEnumerator Fire();
}

public enum WeaponState
{
ready = 1, notready = 0
}