using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOnAwakeLevelFour : MonoBehaviour
{
    public Animator letterbox;
    public Animator hud;
    public Animator boulder;
    private Animator cameraSwitch;
    private GameObject MilesCameraController;
    // Start is called before the first frame update
    void Start()
    {
        letterbox.Play("FadeIn");
        hud.Play("HUDSlideInIdleForVoiceOver");
        boulder.Play("BoulderLevel4");
        MilesCameraController = GameObject.Find("MilesAndCameraController");
        cameraSwitch = MilesCameraController.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void levelFourCheckpoint()
    {
        boulder.Play("BoulderLevel4Checkpoint");
        cameraSwitch.Play("FrontViewIdle");
    }
}
