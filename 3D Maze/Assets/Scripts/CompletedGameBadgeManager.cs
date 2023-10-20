using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedGameBadgeManager : MonoBehaviour
{
    //Commemorative badge for completing the game
    public GameObject completedGameBadge;

    void Update()
    {
        if(WinScreenManager.completedGame == true)
        {
            completedGameBadge.SetActive(true);
        }
        else completedGameBadge.SetActive(false);
    }
}
