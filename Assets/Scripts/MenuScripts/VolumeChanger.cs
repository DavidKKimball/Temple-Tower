using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    public AudioSource audioSrc;
    public float musicVolume = 8.5f;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }


    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
