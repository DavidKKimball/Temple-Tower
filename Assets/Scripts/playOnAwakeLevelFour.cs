using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOnAwakeLevelFour : MonoBehaviour
{
    public Animator letterbox;
    public Animator hud;
    public Animator boulder;
    private Animator cameraSwitch;
    private GameObject milesCameraController;
    // Start is called before the first frame update
    void Start()
    {
        letterbox.Play("FadeIn");
        hud.Play("HUDSlideInIdleForVoiceOver");
        boulder.Play("BoulderLevel4");
        milesCameraController = GameObject.Find("MilesAndCameraController");
        cameraSwitch = milesCameraController.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void levelFourCheckpoint()
    {
        boulder.SetTrigger("checkpoint4");
        cameraSwitch.Play("FrontViewIdle");
    }
}
