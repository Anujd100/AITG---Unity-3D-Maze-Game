using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource menuMusic;
    public AudioSource mainGameMusic;
    public AudioSource winScreenMusic;

    public static BackgroundMusic instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Start Screen" || SceneManager.GetActiveScene().name == "Tutorial Screen" || SceneManager.GetActiveScene().name == "Settings Screen")
        {
            menuMusic.enabled = true;
            mainGameMusic.enabled = false;
            winScreenMusic.enabled = false;
        }
        if (SceneManager.GetActiveScene().name == "3D Maze Level 1" || SceneManager.GetActiveScene().name == "3D Maze Level 2" || SceneManager.GetActiveScene().name == "3D Maze Level 3")
        {
            menuMusic.enabled = false;
            mainGameMusic.enabled = true;
            winScreenMusic.enabled = false;
        }
        if (SceneManager.GetActiveScene().name == "Win Screen")
        {
            menuMusic.enabled = false;
            mainGameMusic.enabled = false;
            winScreenMusic.enabled = true;
        }
    }
}
