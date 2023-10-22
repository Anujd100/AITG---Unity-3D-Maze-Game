using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public int bulletDamage;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHUD.health -= bulletDamage;
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Maze")
        {
            Destroy(gameObject);
        }
    }
}
