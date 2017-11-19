using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoWeapon : Weapon
{
    public int clip_size;
    public int clip;
    public int ammo;
    public GameObject bullet;
    public Transform muzzle;

    private WaitForSeconds reload;
    private WaitForSeconds fire;

    private void Awake()
    {
        state = WeaponState.ready;
        reload = new WaitForSeconds(reloadTime);
        fire = new WaitForSeconds(fireRate);
    }

    public override IEnumerator Fire()
    {
        Notready();

        if (clip != 0)
        {
            Instantiate(bullet, muzzle.position, muzzle.rotation);

            clip--;

            yield return fire;
        }

        Ready();

        yield break;
    }

    public override IEnumerator Reload()
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        if (Input.GetButton("lmb") && state == (WeaponState)1)
            StartCoroutine(Fire());
    }

    private void Ready()
    {
        state = (WeaponState)1;
    }

    private void Notready()
    {
        state = 0;
    }
}
