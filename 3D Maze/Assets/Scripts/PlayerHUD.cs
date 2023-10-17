using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text scoreText;

    public static int health = 100;
    public static int levelScore = 0;
    public static int totalScore = 0;
    public static int damage = 5;
    public static int totalDeaths = 0;

    public Transform enemy;
    public Transform player;

    void Update()
    {
        // Update health and score values
        healthText.text = "Health: " + health.ToString();
        scoreText.text = "Score: " + levelScore.ToString();
    }
}
