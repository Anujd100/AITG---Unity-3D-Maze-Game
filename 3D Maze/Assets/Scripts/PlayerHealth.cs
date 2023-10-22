using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public static event Action OnPlayerDeath;
    public Transform[] enemies;
    public Transform player;
    public bool alreadyDead = false;

    private void Start() 
    {
        PlayerHUD.health = 100;
        enemies = new Transform[3];
    }

    public void Update(){
        if (PlayerHUD.health <= 0 && !alreadyDead) {

            PlayerHUD.totalScore -= PlayerHUD.levelScore;

            PlayerHUD.health = 0;

            Time.timeScale = 0;

            PlayerHUD.totalDeaths++;

            OnPlayerDeath?.Invoke();

            Debug.Log(PlayerHUD.totalDeaths);

            alreadyDead = true;
        }
    }
}