using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healerDetector : MonoBehaviour
{
    public int healAmount;
    public int explosionDuration;
    public bool collectedHealer = false;

    //Graphics
    public GameObject healerExplosionEffect;

    //SFX
    public AudioSource healerFXHolder;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!collectedHealer) 
            {
                if (PlayerHUD.health < 100 - healAmount)
                {
                    PlayerHUD.health += healAmount;

                    //Play SFX
                    healerFXHolder.enabled = true;

                    Invoke("destroyItem", 0.2f);
                }
                else
                {
                    PlayerHUD.health = 100;

                    //Play SFX
                    healerFXHolder.enabled = true;

                    Invoke("destroyItem", 0.2f);
                }
                collectedHealer = true;
            }
        }
    }

    void destroyItem()
    {
        //Destroy item
        Destroy(gameObject);

        //Instantiate Explosion
        GameObject explosion = Instantiate(healerExplosionEffect, transform.position, transform.rotation);

        //Destroy Explosion
        Destroy(explosion, 1f);
    }
}
