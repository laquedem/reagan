using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcticMonkeyWeaponScript : R_Weapon
{
    public int clipSize, clip, bullets;


    private WaitForSeconds reload, fire;

    protected override void Awake() 
    {
        base.Awake();
        reload = new WaitForSeconds(reloadTime);
        fire = new WaitForSeconds(fireRate);
    }

    protected override void Fire()
    {
        if (clip > 0 && ready)
        {
            Instantiate(projectile, muzzle.position, muzzle.rotation);
            clip--;
            StartCoroutine(Unready(fire));
        }
    }

    protected override void Inp()
    {
        if (Input.GetButtonDown("r"))
        {
            Reload();
            return;
        }

        if (Input.GetButtonDown("lmb"))
        {
            Fire();
        }
    }

    protected override void Reload()
    {
        if (clip < clipSize && bullets != 0)
        {
            if (clipSize - clip > bullets)
            {
                clip += bullets;
                bullets = 0;
            }
            else
            {
                bullets -= (clipSize - clip);
                clip = clipSize;
            }

            StartCoroutine(Unready(reload));
        }
    }

    IEnumerator Unready(WaitForSeconds wait)
    {
        Debug.Log("WAIT CALLED");

        ready = false;

        yield return wait;

        ready = true;

        yield break;
    }
}