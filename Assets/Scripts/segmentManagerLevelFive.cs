using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segmentManagerLevelFive : MonoBehaviour
{
    public GameObject triggerOld;
    public GameObject triggerNew;
    public ParticleSystem rockslide;
    public int gearCounter;
    public Animator doorGears;
    public bool playedOnce = false;
    public bool playedOnceSet2 = false;
    public voiceOverManagerLevelFive triggerDoorsLevelFive;
    //private Animator anim;
    //private GameObject gears;
    //private Animator anim2;
    //private GameObject gearBox;
    //public GameObject waterfall;
    //public GameObject platformTrigger;
    //public GameObject setPieceTarget;
    // Start is called before the first frame update
    /*void Start()
    {
        gears = GameObject.Find("GearHandler");
        anim = gears.GetComponent<Animator>();
        gearBox = GameObject.Find("GearBoxAndGearHolder");
        anim2 = gearBox.GetComponent<Animator>();
    }

    */
    void Update()
    {
        if (gearCounter == 2 && playedOnce == false)
        {
            playedOnce = true;
            StartCoroutine(firstSetOpen());
        }
        if (gearCounter == 4 && playedOnceSet2 == false)
        {
            playedOnceSet2 = true;
            secondSetOpen();
        }
    }
    /*
    public void enableGears()
    {
        anim.Play("GearsWindUp");
        platformTrigger.SetActive(true);
        StartCoroutine(waterFallDelay());
    }
    public void disableGears()
    {
        anim.Play("GearsWindDown");
        waterfall.SetActive(false);
        platformTrigger.SetActive(false);
    }
    public void enableGearsNoWater()
    {
        anim2.Play("gearBoxLevelOneDrop");
        anim.Play("GearsWindUp");
        platformTrigger.SetActive(true);
    }
    public void disableGearsAndGearBox()
    {
        anim.Play("GearsWindDown");
        anim2.Play("gearBoxLevelOneRaiseUp");
        platformTrigger.SetActive(false);
    }
    IEnumerator waterFallDelay()
    {
        yield return new WaitForSeconds(7.4f);
        waterfall.SetActive(true);
    }*/
    public void switchTriggers()
    {
        triggerOld.SetActive(false);
        triggerNew.SetActive(true);
    }
    public void switchTriggersBack()
    {
        triggerOld.SetActive(true);
        triggerNew.SetActive(false);
    }
    IEnumerator firstSetOpen()
    {
        triggerDoorsLevelFive.TriggerVoiceOver(2);
        yield return new WaitForSeconds(1.5f);
        doorGears.Play("doorOpenFirstSet");
        playedOnce = true;
        Debug.Log("first");
    }
   IEnumerator secondSetOpen()
    {
        //triggerDoorsLevelFive.TriggerVoiceOver(2);
        yield return new WaitForSeconds(1.5f);  
        doorGears.Play("doorOpenSecondSet");
        playedOnceSet2 = true;   
        Debug.Log("second");   
    }
    public void gearCounterAdder()
    {
        gearCounter++;
    }
}