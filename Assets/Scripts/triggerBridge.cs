﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerBridge : MonoBehaviour
{
    private Animator anim;
    private int playedOnce = 0;
    public Transform cameraReset;
    public ParticleSystem rubbleSmoke;
    public GameObject playerScriptHolder;
    private Movement script;
    private AudioSource audioFile;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        audioFile = GetComponent<AudioSource>();
        playerScriptHolder = GameObject.Find("MilesNewWorking");
        script = playerScriptHolder.GetComponent<Movement>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playedOnce == 0)
        {
            cameraReset.localPosition = new Vector3(0,0,0);
            audioFile.Play();
            anim.Play("BridgePlatform");
            playedOnce += 1;
            //Debug.Log("Played");
            rubbleSmoke.Play();
            script.stayStill = false;
        }
    }
}
