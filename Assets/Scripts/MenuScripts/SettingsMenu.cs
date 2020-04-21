using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SettingsMenu : MonoBehaviour
{

    public GameObject firstMenu;
    public GameObject settingsMenu;
    public GameObject controlsMenu;
    public GameObject resumeButton;
    public GameObject gammaSlider;
    public GameObject controlsBackButton;
    public AudioSource myFX;
    public AudioClip clickForwardFx;
    public AudioClip clickBackwardFx;
    public AudioClip hoverFx;
    public bool pressedOnce = false;

    void Update()
    {
        /*if (Input.GetAxis("Vertical") != 0 && pressedOnce == false)
        {
            myFX.PlayOneShot(hoverFx);
            pressedOnce = true;
        }
        else if (Input.GetAxis("Vertical") == 0)
            pressedOnce = false;

        if (Input.GetButtonDown("Fire1"))
            myFX.PlayOneShot(clickForwardFx);*/
    }


    public void OnSettingsPress()
    {
        firstMenu.SetActive(false);
        settingsMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(gammaSlider);
    }

    public void BackButton()
    {
        settingsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        firstMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeButton);
    }
    public void ControlsButton()
    {
        controlsMenu.SetActive(true);
        firstMenu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controlsBackButton);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Preload");
    }

    public void ClickForwardSound()
    {
        myFX.PlayOneShot(clickForwardFx);
    }

    public void ClickBackwardSound()
    {
        myFX.PlayOneShot(clickBackwardFx);
    }

    public void HoverButton()
    {
        myFX.PlayOneShot(hoverFx);
    }
}
