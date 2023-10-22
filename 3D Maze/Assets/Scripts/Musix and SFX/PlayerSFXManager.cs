using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXManager : MonoBehaviour
{
    public AudioSource WalkingSFX;
    public AudioSource RunningSFX;
    public AudioSource HandgunSFX;
    public AudioSource ARSFX;
    public AudioSource bulletExplosionSFX;
    public AudioSource itemExplosionSFX;


    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                WalkingSFX.enabled = false;
                RunningSFX.enabled = true;
            }
            else
            {
                WalkingSFX.enabled = true;
                RunningSFX.enabled = false;
            }
        }
        else
        {
            WalkingSFX.enabled = false;
            RunningSFX.enabled = false;
        }

        if(Input.GetKey("space"))
        {
            WalkingSFX.enabled = false;
            RunningSFX.enabled = false;
        }

        if (ProjectileGun.shot == true)
        {
            if (WeaponSwitching.selectedWeapon == 0)
            {
                HandgunSFX.enabled = true;
                ARSFX.enabled = false;
            }
            else if (WeaponSwitching.selectedWeapon == 1)
            {
                HandgunSFX.enabled = false;
                ARSFX.enabled = true;
            }
        }
        else
        {
            HandgunSFX.enabled = false;
            ARSFX.enabled = false;
        }

        if(CustomBullet.bulletExploded == true)
        {
            bulletExplosionSFX.enabled = true;
        }
        else bulletExplosionSFX.enabled = false;
    }
}