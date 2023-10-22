using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeColliderManager : MonoBehaviour
{
    public int initSpikeAmount;
    public int constantSpikeAmount;
    public bool isOnSpikes = false;
    private float spikeDamageAt = 0.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerHUD.health > 0)
            {
                PlayerHUD.health -= initSpikeAmount;
                isOnSpikes = true;
            }
            else return;
        }
    }
    
    void OnTriggerStay(Collider other)
    {
        if(isOnSpikes && Time.time >= spikeDamageAt)
        {
            if (PlayerHUD.health > 0)
            {
                PlayerHUD.health -= constantSpikeAmount;
                spikeDamageAt = Time.time + 1.0f;
            }
            else return;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        isOnSpikes = false;
    }
}
