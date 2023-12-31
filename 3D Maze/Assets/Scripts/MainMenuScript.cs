using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public Slider MouseSensitivitySlider;

    public void PlayGame()
    {
        SceneManager.LoadScene("3D Maze Level 1");
    }

    public void SettingsLoader()
    {
        SceneManager.LoadScene("Settings Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void MouseSensitivity()
    {
        PlayerController.mouseSensitivity = MouseSensitivitySlider.value;
    }

    public void MainMenuLoader()
    {
        SceneManager.LoadScene("Start Screen");
    }
}