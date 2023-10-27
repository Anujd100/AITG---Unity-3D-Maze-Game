using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static event Action OnGameCompleted;

    public Transform player;
    public float fadeDistance = 15f;

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

    void Update()
    {
        Debug.Log(AudioListener.volume);
        AudioFader();
    }

    void AudioFader()
    {
        //Return if player is too far away from end of game object
        if (Vector3.Distance(player.position, transform.position) > fadeDistance) return;

        //Fade Audio when player gets near the end of game object
        if(Vector3.Distance(player.position, transform.position) <= fadeDistance)
        {
            float fadedVolume = Vector3.Distance(player.position, transform.position) / fadeDistance;
            AudioListener.volume = fadedVolume - 0.5f;
        }
    }
}