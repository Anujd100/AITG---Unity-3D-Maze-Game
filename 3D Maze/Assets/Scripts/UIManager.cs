using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject endLevelMenu;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += EnableGameOverMenu;
        EndLevelManager.OnLevelCompleted += EnableEndLevelMenu;
        EndGameManager.OnGameCompleted += EnableEndGameMenu;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= EnableGameOverMenu;
        EndLevelManager.OnLevelCompleted -= EnableEndLevelMenu;
        EndGameManager.OnGameCompleted -= EnableEndGameMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EnableEndLevelMenu()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("3D Maze Level 3")) return;
        endLevelMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void EnableEndGameMenu()
    {
        SceneManager.LoadScene("Win Screen");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void NextLevel()
    {
        PlayerHUD.health = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuLoader()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
