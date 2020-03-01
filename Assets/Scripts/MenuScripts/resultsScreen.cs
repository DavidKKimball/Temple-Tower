using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class resultsScreen : MonoBehaviour
{
    public transitionController blackOut;
    public Canvas resultsObject;
    public musicManager musicMan;
    public Animator hud;
    public GameObject endGameTarget;
    public Animator transitionPanel;
    private MoveSegment cameraUnlock;
    private GameObject scriptHolderForCamera;
    public CinemachineVirtualCamera vcam;
    //private GameObject milesCameraMasterAnimator;

    public void Start()
        {
            scriptHolderForCamera = GameObject.Find("ColliderToMechanism");
            cameraUnlock = scriptHolderForCamera.GetComponent<MoveSegment>();
            //milesCameraMasterAnimator = GameObject.Find("MilesAndCameraController");
            //cameraMain = GameObject.FindGameObjectWithTag("MainCamera");
        }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "end")
        {
            //StartCoroutine(blackOut.toggleFadein());
            blackOut.triggerMask();
            //cameraMain.transform.position = new Vector3(0, 0, -28f);
            StartCoroutine(Pause());
            hud.Play("HUDSlideOut");
            transitionPanel.Play("TallyScreenFadeIn");
            //trigger transition panel outro animation
        }
    }

    IEnumerator Pause()
    {
        musicMan.levelComplete();
        yield return new WaitForSeconds(0.3f);
        //cameraFollower.Play("ZoomOut");
        //cameraUnlock.vcam.Follow = endGameTarget;
        vcam.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        resultsObject.enabled = true;
        //Time.timeScale = 0; moved to musicManager so it can change songs while the tally screen loads
    }
}
