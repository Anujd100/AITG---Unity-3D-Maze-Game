using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionDetection : MonoBehaviour
{
    public int rewardAmount;
    public int animDuration;
    public int explosionDuration;
    public bool collectedItem = false;

    //Graphics
    public Animator ChestAnimator;
    public string animName;
    public GameObject chestExplosionEffect;

    //SFX
    public AudioSource itemFXHolder;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(collectedItem == false)
            {
                PlayerHUD.totalScore += rewardAmount;
                PlayerHUD.levelScore += rewardAmount;

                ChestAnimator.Play(animName, 0, 0f);
                
                //Play SFX
                itemFXHolder.enabled = true;

                Invoke("destroyItem", 4f);
            }
            collectedItem = true;
        }
    }

    void destroyItem()
    {
        //Destroy item
        Destroy(gameObject);

        //Instantiate Explosion
        GameObject explosion = Instantiate(chestExplosionEffect, transform.position, transform.rotation);
        
        //Destroy Explosion
        Destroy(explosion, 1f);
    }
}
