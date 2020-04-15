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
    public bool playedOnce0 = false;
    public bool playedOnce3 = false;
    public bool playedOnceSet2 = false;
    public Animator gear1;
    public Animator gear2;
    public Animator gear3;
    public Animator gear4;
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
        if (gearCounter == 1 && playedOnce0 == false)
        {
            playedOnce0 = true;
            gear1.Play("gearsLevelFiveTurningOn");
        }
        if (gearCounter == 2 && playedOnce == false)
        {
            playedOnce = true;
            gear2.Play("gearsLevelFiveTurningOn");
            StartCoroutine(firstSetOpen());
        }
        if (gearCounter == 3 && playedOnce3 == false)
        {
            playedOnce3 = true;
            gear3.Play("gearsLevelFiveTurningOn");
        }
        if (gearCounter == 4 && playedOnceSet2 == false)
        {
            playedOnceSet2 = true;
            gear4.Play("gearsLevelFiveTurningOn");
            StartCoroutine(secondSetOpen());
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
        triggerDoorsLevelFive.TriggerVoiceOver(3);
        yield return new WaitForSeconds(1f);  
        doorGears.Play("doorOpenSecondSet");
        playedOnceSet2 = true;   
        Debug.Log("second");   
    }
    public void gearCounterAdder()
    {
        gearCounter++;
        Debug.Log(gearCounter);
    }
}