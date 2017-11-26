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
        // Aim();

        if (Input.GetButton("lmb") && state == (WeaponState)1)
            StartCoroutine(Fire());
    }

    // [Range(0f, 20f)] public float rotSpeed;
    // public float MinAimDistance;

    void FixedUpdate()
    {
        /*
        Vector3 normalized = new Vector3(transform.position.x, 0, transform.position.z);

        if (Vector3.Distance(normalized, MousePointerController.MPCinst.transform.position) > MinAimDistance)
            transform.rotation = Quaternion.Slerp(
            transform.rotation, Quaternion.LookRotation(new Vector3(MousePointerController.MPCinst.transform.position.x - transform.position.x,
            /*MousePointer.instance.transform.position.y - transform.position.y// 0,
            MousePointerController.MPCinst.transform.position.z - transform.position.z)),
            rotSpeed * Time.fixedDeltaTime
            );
        */

        // transform.LookAt(MousePointerController.MPCinst.transform.position);
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
