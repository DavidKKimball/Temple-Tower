﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelFiveSwitchHandler : MonoBehaviour
{
    public Animator animGears;
    public ParticleSystem rubble;
    public cameraShake shake;
    private bool playedOnce = false;
    public GameObject highlight;
    public bool isShut = false;
    public segmentManagerLevelFive triggerDoorGears;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Whip" && playedOnce == false)
        {
            triggerDoorGears.gearCounterAdder();
            isShut = true;
            shake.triggerShakeMedium();
            animGears.Play("newFloorMechanismLevelOneConfigurationanim");
            playedOnce = true;
            rubble.Play();
            highlight.SetActive(false);
        }
    }
}
