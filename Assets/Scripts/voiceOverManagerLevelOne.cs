using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class voiceOverManagerLevelOne : MonoBehaviour
{
    private GameObject scriptHolder;
    public Animator hudAnim;
    public CinemachineVirtualCamera vcam;
    //private GameObject regularCamera;
    private Movement movementScript;
    private Animator animPlayer;
    private GameObject animatorHolder;
    public Animator animTransitionController;
    private GameObject textHolder;
    public TMP_Text voiceOverDialogue;
    private AudioSource audioData;
    public AudioClip[] audioClipArray;
    private float freezeDuration;
    public string animName;
    // Start is called before the first frame update
    void Start()
    {
        //vcam = GameObject.Find("CM vcam4");
        //regularCamera = GameObject.Find("CM vcam1");
        textHolder = GameObject.Find("VoiceOverText");
        animatorHolder = GameObject.Find("Transition Controller");
        scriptHolder = GameObject.Find("MilesNewWorking");
        movementScript = scriptHolder.GetComponent<Movement>();
        animPlayer = scriptHolder.GetComponent<Animator>();
        animTransitionController = animatorHolder.GetComponent<Animator>();
        voiceOverDialogue = textHolder.GetComponent<TMP_Text>();
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TriggerVoiceOver(int voiceOverType)
    {
    switch (voiceOverType)
            {
            case 4:
               // animPlayer.Play("TallVaseWobble");
                break;
            case 3:
            //miles picks up the phone
                //animPlayer.Play("MediumVaseWobble");
                break;
            case 2:
            //miles sees the puma
               // animPlayer.Play("ShortNarrowVaseWobble");
                break;
            case 1:
            //miles comes up to the phone from below
                animName = "MilesLookUp";
                //animPlayer.Play("MilesDrinkHealth");
                audioData.clip=audioClipArray[0];
                audioData.PlayOneShot(audioData.clip);
                animTransitionController.Play("LetterboxVoiceOverFadeIn");
                hudAnim.Play("HUDSlideOutForVoiceOver");                
                freezeDuration = 3.2f;                
                voiceOverDialogue.text = "Miles: I can't reach that from here, I'll have to find another way";
                movementScript.stayStill = true;
                movementScript.isHealing = true;
                //animPlayer.Play("MilesLookUp");
                movementScript.playAnim(animName);
                vcam.gameObject.SetActive(true);
                //regularCamera.SetActive(false);
                StartCoroutine(FreezeReset());
                break;
            default:
                print ("");
                break;
        }        
    }
    IEnumerator FreezeReset()
    {
        //yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(freezeDuration);
        animTransitionController.Play("LetterboxVoiceOverFadeOut"); 
        movementScript.stayStill = false;   
        movementScript.isHealing = false;
        if (vcam)
        {
            vcam.gameObject.SetActive(false);
            movementScript.playAnim("MilesIdle");
            //regularCamera.SetActive(true);
        }    
        hudAnim.Play("HUDSlideInForVoiceOver"); 
    }
}
