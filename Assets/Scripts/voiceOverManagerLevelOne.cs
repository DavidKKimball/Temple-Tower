using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class voiceOverManagerLevelOne : MonoBehaviour
{
    private GameObject scriptHolder;
    public Animator hudAnim;
    public Animator turnOffWalkieTalkieWhileTalking;
    public CinemachineVirtualCamera vcam;
    public CinemachineVirtualCamera vcam2;
    public CinemachineVirtualCamera vcam3;

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

    private bool fireSecondCoroutine;
    public string animName;
    public GameObject walkieTalkie;
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
            //miles sees the dead guy
               // animPlayer.Play("TallVaseWobble");
                animName = "MilesIdle";
                //turnOffWalkieTalkieWhileTalking.enabled = false;
                //animPlayer.Play("MilesDrinkHealth");
                audioData.clip=audioClipArray[3];//dead guy spiel
                audioData.PlayOneShot(audioData.clip);
                animTransitionController.Play("LetterboxVoiceOverFadeIn");
                hudAnim.Play("HUDSlideOutForVoiceOver");                
                //freezeDuration = 6f;                
                voiceOverDialogue.text = "Miles: Dang! I thought I'd be the first explorer down here!";
                movementScript.stayStill = true;
                movementScript.isHealing = true;
                //animPlayer.Play("MilesLookUp");
                movementScript.playAnim(animName);
                //vcam.gameObject.SetActive(true);
                //regularCamera.SetActive(false);
                //walkieTalkie.SetActive(false);
                //fireSecondCoroutine = true;
                vcam3.gameObject.SetActive(true);//turn on health vcam
                StartCoroutine(HealthTalk());
                break;
            case 3:
            //miles picks up the phone
                animName = "MilesAnswersPhone";
                //turnOffWalkieTalkieWhileTalking.enabled = false;
                //animPlayer.Play("MilesDrinkHealth");
                audioData.clip=audioClipArray[1];
                audioData.PlayOneShot(audioData.clip);
                animTransitionController.Play("LetterboxVoiceOverFadeIn");
                hudAnim.Play("HUDSlideOutForVoiceOver");                
                freezeDuration = 6f;                
                voiceOverDialogue.text = "Miles: Shelly! Can you hear me? It's Miles. I'm Alright";
                movementScript.stayStill = true;
                movementScript.isHealing = true;
                //animPlayer.Play("MilesLookUp");
                movementScript.playAnim(animName);
                //vcam.gameObject.SetActive(true);
                //regularCamera.SetActive(false);
                walkieTalkie.SetActive(false);
                fireSecondCoroutine = true;
                //StartCoroutine(FreezeReset());
                StartCoroutine(FreezeReset());
                break;
            case 2:
            //miles sees the puma
               // animPlayer.Play("ShortNarrowVaseWobble");
                break;
            case 1:
            //miles comes up to the phone from below
                animName = "MilesLookUp";
                turnOffWalkieTalkieWhileTalking.enabled = false;
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
        if (fireSecondCoroutine)
        {
            StartCoroutine(phoneConvoDelay());
        }
        yield return new WaitForSeconds(freezeDuration);
        animTransitionController.Play("LetterboxVoiceOverFadeOut"); 
        movementScript.stayStill = false;   
        movementScript.isHealing = false;
        if (vcam)
        {
            vcam.gameObject.SetActive(false);
            movementScript.playAnim("MilesIdle");
        }    
        if (fireSecondCoroutine)
        {
            movementScript.playAnim("MilesPutsAwayPhone");
        }
        hudAnim.Play("HUDSlideInForVoiceOver");
        turnOffWalkieTalkieWhileTalking.enabled = true;
    }
    IEnumerator phoneConvoDelay()
    {
        yield return new WaitForSeconds(3.3f);
        voiceOverDialogue.text = "Shelly: Oh thank goodness! I thought you were dead!";
        audioData.clip=audioClipArray[2];
        audioData.PlayOneShot(audioData.clip); 
    }
    IEnumerator HealthTalk()
    {
        yield return new WaitForSeconds(3.0f);
        voiceOverDialogue.text = "Miles: Looks likes some mustache tonic! How fortunate! I can use that to heal myself";
        audioData.clip=audioClipArray[4];
        audioData.PlayOneShot(audioData.clip); 
        vcam2.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);   
        vcam2.gameObject.SetActive(false);
        vcam3.gameObject.SetActive(false);
        animTransitionController.Play("LetterboxVoiceOverFadeOut"); 
        movementScript.stayStill = false;   
        movementScript.isHealing = false;
        hudAnim.Play("HUDSlideInForVoiceOver");
    }
}
