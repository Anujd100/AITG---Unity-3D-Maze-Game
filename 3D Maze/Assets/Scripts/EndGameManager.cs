using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static event Action OnGameCompleted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CompleteGame();
        }
    }

    private void CompleteGame()
    {
        PlayerHUD.totalScore += 1000;

        OnGameCompleted?.Invoke();
    }
}
