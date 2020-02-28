using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segmentManagerLevelOne : MonoBehaviour
{
    private Animator anim;
    private GameObject gears;
    private Animator anim2;
    private GameObject gearBox;
    public GameObject waterfall;
    public GameObject platformTrigger;
    public GameObject setPieceTarget;
    // Start is called before the first frame update
    void Start()
    {
        gears = GameObject.Find("GearHandler");
        anim = gears.GetComponent<Animator>();
        gearBox = GameObject.Find("GearBoxAndGearHolder");
        anim2 = gearBox.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void enableGears()
    {
        anim.Play("GearsWindUp");
        waterfall.SetActive(true);
        platformTrigger.SetActive(true);
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
}