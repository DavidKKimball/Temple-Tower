using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorArchway : MonoBehaviour
{
    public Animator animGears;
    public ParticleSystem rubble;
    public cameraShake shake;
    private bool playedOnce = false;
    public GameObject highlight;
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
            shake.triggerShakeMedium();
            animGears.Play("DoorMechanismTurn");
            playedOnce = true;
            highlight.SetActive(false);
        }
    }
}
