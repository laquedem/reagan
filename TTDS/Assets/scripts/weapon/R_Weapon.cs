using UnityEngine;

public abstract class R_Weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform muzzle;
    public float fireRate;
    public float reloadTime;
    public bool ready;

    protected virtual void Awake()
    {
        ready = true;
    }

    protected abstract void Fire();

    protected abstract void Reload();

    protected abstract void Inp();

    protected void Update()
    {
        Inp();
    }
}
