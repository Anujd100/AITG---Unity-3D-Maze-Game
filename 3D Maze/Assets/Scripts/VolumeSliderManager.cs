using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSliderManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    public TMP_Text volumeSliderText;
    public static float volume = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
    }

    void Update()
    {
        volume = 100*volumeSlider.value;

        //Display the current volume settings as a percentage of the full volume
        volumeSliderText.text = "VOLUME: " + volume.ToString("F0") + "%";
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        //Retrieve saved volume settings
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        //Save volume settings between runthroughs
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
