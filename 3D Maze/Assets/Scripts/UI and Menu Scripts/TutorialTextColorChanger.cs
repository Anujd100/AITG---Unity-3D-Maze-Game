using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTextColorChanger : MonoBehaviour
{
    public TMP_Text movementText;
    public TMP_Text sprintingText;
    public TMP_Text jumpingText;
    public TMP_Text shootingText;
    public TMP_Text reloadText;
    public TMP_Text switchWeaponsText;

    public AudioSource buttonSFX;
    public AudioClip selectedSFX;

    public bool playedButtonSFX = false;

    public Color g = new Color(12.0f / 255.0f, 79.0f / 255.0f, 9.0f / 255.0f, 1);

   void Update()
    {
        MovementInputChecker();
        SprintingInputChecker();
        JumpingInputChecker();
        ShootingInputChecker();
        ReloadInputChecker();
        SwitchWeaponsInputChecker();
    }

    //Make movement text green and play SFX upon recieving player input
    public void MovementInputChecker()
    {
        //Change color
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            movementText.color = g;
        }
        else
        {
            movementText.color = Color.white;
        }

        //Play SFX
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            buttonSFX.PlayOneShot(selectedSFX);
        }
    }

    //Make sprinting text green and play SFX upon recieving player input
    public void SprintingInputChecker()
    {
        //Change color
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintingText.color = g;

        }
        else
        {
            sprintingText.color = Color.white;
        }

        //Play SFX
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            buttonSFX.PlayOneShot(selectedSFX);
        }
    }

    //Make jumping text green and play SFX upon recieving player input
    public void JumpingInputChecker()
    {
        //Change color
        if (Input.GetKey(KeyCode.Space))
        {
            jumpingText.color = g;
        }
        else
        {
            jumpingText.color = Color.white;
        }

        //Play SFX
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttonSFX.PlayOneShot(selectedSFX);
        }
    }

    //Make shooting text green and play SFX upon recieving player input
    public void ShootingInputChecker()
    {
        //Change color
        if (Input.GetKey(KeyCode.Mouse0))
        {
            shootingText.color = g;
        }
        else
        {
            shootingText.color = Color.white;
        }

        //Play SFX
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            buttonSFX.PlayOneShot(selectedSFX);
        }
    }

    //Make reload text green and play SFX upon recieving player input
    public void ReloadInputChecker()
    {
        //Change color
        if (Input.GetKey(KeyCode.R))
        {
            reloadText.color = g;
        }
        else
        {
            reloadText.color = Color.white;
        }

        //Play SFX
        if (Input.GetKeyDown(KeyCode.R))
        {
            buttonSFX.PlayOneShot(selectedSFX);
        }
    }

    //Make switch weapons text green and play SFX upon recieving player input (when any number key is pressed
    public void SwitchWeaponsInputChecker()
    {
        //Change color
        if (Input.GetKey(KeyCode.Alpha0) || Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3)
                                         || Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Alpha5) || Input.GetKey(KeyCode.Alpha6)
                                         || Input.GetKey(KeyCode.Alpha7) || Input.GetKey(KeyCode.Alpha8) || Input.GetKey(KeyCode.Alpha9))
        {
            switchWeaponsText.color = g;
        }
        else
        {
            switchWeaponsText.color = Color.white;
        }

        //Play SFX
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)
                                        || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6)
                                        || Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            buttonSFX.PlayOneShot(selectedSFX);
        }
    }
}
