using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSoundFX : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverAudio;
    public AudioClip backwardAudio;
    public AudioClip forwardAudio;
    //public GameObject pauseMenu;
    public bool pressedOnce = false;

    private void Start()
    {
        // = GameObject.Find("Pause Menu");
    }

    void Update()
    {
        /*if (pauseMenu.gameObject.activeInHierarchy == true)
        {
            if (Input.GetAxis("Vertical") != 0 && pressedOnce == false)
            {
                myFx.PlayOneShot(hoverAudio);
                pressedOnce = true;
            }
            else if (Input.GetAxis("Vertical") == 0)
                pressedOnce = false;

            if (Input.GetButtonDown("Fire1"))
                myFx.PlayOneShot(forwardAudio);
        }*/
    }

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverAudio);
    }

    public void ForwardAudio()
    {
        myFx.PlayOneShot(forwardAudio);
    }

    public void BackwardAudio()
    {
        myFx.PlayOneShot(backwardAudio);
    }

}
