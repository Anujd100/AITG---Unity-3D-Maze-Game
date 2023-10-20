using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreenManager : MonoBehaviour
{
    //Static bool (changes gameState to won game, to run code now that the player has beaten the game)
    public static bool completedGame = false;
    
    //Stats Text
    public TMP_Text totalScoreText;
    public TMP_Text totalDeathsText;

    //Audio
    public AudioSource winScreenFX;

    void Start()
    {
        winScreenFX.enabled = true;
    }

    void Update()
    {
        completedGame = true;
        totalScoreText.text = "TOTAL SCORE: " + PlayerHUD.totalScore.ToString();
        totalDeathsText.text = "TOTAL DEATHS: " + PlayerHUD.totalDeaths.ToString();
    }
    
}
