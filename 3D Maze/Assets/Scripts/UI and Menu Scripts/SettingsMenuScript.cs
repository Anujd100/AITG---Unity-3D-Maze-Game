using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenuScript : MonoBehaviour
{
    public Slider MouseSensitivitySlider;
    public TMP_Text mouseSensitivityText;
    public static float mouseSensitivity = 2.0f;

    void Start()
    {
        MouseSensitivitySlider.value = 2.0f;

    }
    void Update()
    {
        mouseSensitivityText.text = "MOUSE SENSITIVITY: " + mouseSensitivity.ToString("F2");
    }

    public void MouseSensitivity()
    {
        mouseSensitivity = MouseSensitivitySlider.value;
    }
}
