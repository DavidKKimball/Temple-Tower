﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerBridge : MonoBehaviour
{
    private Animator anim;
    private int playedOnce = 0;
    public ParticleSystem rubbleSmoke;
    private AudioSource audioFile;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        audioFile = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && playedOnce == 0)
        {
            audioFile.Play();
            anim.Play("BridgePlatform");
            playedOnce += 1;
            Debug.Log("Played");
            rubbleSmoke.Play();
        }
    }
}
