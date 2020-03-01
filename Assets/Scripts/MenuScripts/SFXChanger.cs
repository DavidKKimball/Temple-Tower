using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXChanger : MonoBehaviour
{
    public AudioSource sfx1;
    private float sfxVolume;

    void Start()
    {
        sfx1 = GetComponent<AudioSource>();
    }


    void Update()
    {
        sfx1.volume = sfxVolume;
    }

    public void SetVolume(float vol)
    {
        sfxVolume = vol;
    }
}
