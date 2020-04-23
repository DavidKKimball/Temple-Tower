using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerArchwayLevelTwo : MonoBehaviour
{
    public Animator animPlay;
    public boulderSpawner boulder;
    public rotator boulderRotator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hitArchway()
    {
            animPlay.Play("doorCrumble");
            boulder.spawnBoulderSoundRumbleOnly();
            boulderRotator.stopBallRotation();
    }
}
