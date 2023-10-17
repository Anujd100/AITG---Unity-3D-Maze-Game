using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelManager : MonoBehaviour
{
    public static event Action OnLevelCompleted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        PlayerHUD.levelScore += 500;
        PlayerHUD.totalScore += 500;

        OnLevelCompleted?.Invoke();
    }
}
