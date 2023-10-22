using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCollectionDetector : MonoBehaviour
{
    public static bool ARUnlocked = false;
    public bool collectedAR = false;

    public GameObject ARExplosionEffect;
    public GameObject AR;
    public GameObject Handgun;

    //Audio
    public AudioSource ARFXHolder;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (collectedAR == false)
            {
                WeaponSwitching.selectedWeapon = 1;
                AR.SetActive(true);
                Handgun.SetActive(false);

                //Play SFX
                ARFXHolder.enabled = true;

                Invoke("DestroyItem", 0.2f);
            }

            collectedAR = true;
            ARUnlocked = true;
        }
    }

    void DestroyItem()
    {
        //Destroy AR Holder
        Destroy(gameObject);

        //Instantiate Explosion
        GameObject explosion = Instantiate(ARExplosionEffect, transform.position, transform.rotation);

        //Destroy Explosion
        Destroy(explosion, 1f);
    }
}
