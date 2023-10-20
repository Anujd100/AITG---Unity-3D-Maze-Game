using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSFX : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip hoverFX;
    public AudioClip clickFX;

    public Slider mySlider;

    Color color = new Color(12.0f / 255.0f, 79.0f / 255.0f, 9.0f / 255.0f, 1);

    public void HoverFX()
    {
        mySlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color;
        myFX.PlayOneShot(hoverFX);
    }

    public void ClickFX()
    {
        myFX.PlayOneShot(clickFX);
    }
}
