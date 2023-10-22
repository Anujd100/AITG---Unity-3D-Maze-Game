using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCollectionDetector : MonoBehaviour
{
    public static bool ARUnlocked = false;
    public bool collectedAR = false;

    public GameObject ARExplosionEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (collectedAR == false)
            {
                WeaponSwitching.selectedWeapon = 1;
                DestroyItem();
            }
            collectedAR = true;
            ARUnlocked = true;
        }
    }

    void DestroyItem()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(ARExplosionEffect, transform.position, transform.rotation);
        Destroy(explosion, 1f);
    }
}
