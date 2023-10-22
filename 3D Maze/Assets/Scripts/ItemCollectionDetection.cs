using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionDetection : MonoBehaviour
{
    public int rewardAmount;
    public int animDuration;
    public int explosionDuration;
    public bool openedChest = false;
    //private int items;
    
    public Animator ChestAnimator;
    public string animName;
    public GameObject chestExplosionEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(openedChest == false)
            {
                PlayerHUD.totalScore += rewardAmount;
                PlayerHUD.levelScore += rewardAmount;
                //items++;

                ChestAnimator.Play(animName, 0, 0f);
                Invoke("destroyItem", 4f);
            }
            openedChest = true;
        }
    }

    void destroyItem()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(chestExplosionEffect, transform.position, transform.rotation);
        Destroy(explosion, 1f);
    }
}
