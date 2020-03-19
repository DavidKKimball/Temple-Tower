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
    public CinemachineVirtualCamera vcam4;
    public GameObject disableWhip1;
    public GameObject disableWhip2;
    public GameObject disableWhip3;
    public GameObject disableWhip4;
    //private GameObject regularCamera;
    private Movement movementScript;
    private Animator animPlayer;
    private GameObject animatorHolder;
    public Animator animTransitionController;
    private GameObject textHolder;
    public TMP_Text voiceOverDialogue;
    public VolumeChanger levelMusic;
    private AudioSource audioData;
    public AudioSource waterfallAudio;
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
                levelMusic.musicVolume = 0.25f;
                //turnOffWalkieTalkieWhileTalking.enabled = false;
                //animPlayer.Play("MilesDrinkHealth");
                audioData.clip=audioClipArray[3];//dead guy spiel
                audioData.PlayOneShot(audioData.clip);
                animTransitionController.Play("LetterboxVoiceOverFadeIn");
                hudAnim.Play("HUDSlideOutForVoiceOver");                
                //freezeDuration = 6f;                
                voiceOverDialogue.text = "Miles: Drat! I thought I'd be the first explorer down here!";
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
                levelMusic.musicVolume = 0.25f;
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
                StartCoroutine(phoneConvoDelay());
                break;
            case 2:
            //miles sees the puma
                movementScript.stayStill = true;
                movementScript.isHealing = true;
                movementScript.playAnim("MilesIdle");
                animTransitionController.Play("LetterboxVoiceOverFadeIn");
                hudAnim.Play("HUDSlideOutForVoiceOver"); 
                levelMusic.musicVolume = 0.25f;
                waterfallAudio.volume = 0.25f;
                vcam4.gameObject.SetActive(true);
                voiceOverDialogue.text = "Miles: A Puma! I've fought a few of these in my day! They'll only slow me down!";
            // animPlayer.Play("ShortNarrowVaseWobble");
                StartCoroutine(PumaReset());
                break;
            case 1:
            //miles comes up to the phone from below
                animName = "MilesLookUp";
                levelMusic.musicVolume = 0.25f;
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
    IEnumerator PumaReset()    {
        yield return new WaitForSeconds(0.2f);
        audioData.clip=audioClipArray[9];
        audioData.PlayOneShot(audioData.clip);
        yield return new WaitForSeconds(4.7f);
        movementScript.stayStill = false;   
        movementScript.isHealing = false;  
        vcam4.gameObject.SetActive(false);
        hudAnim.Play("HUDSlideInForVoiceOver");
        animTransitionController.Play("LetterboxVoiceOverFadeOut");  
        waterfallAudio.volume = 0.65f;     
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
        if (!fireSecondCoroutine)
        {
            VolumeReset();
        }
    }
    IEnumerator phoneConvoDelay()
    {
        //levelMusic.musicVolume = 0.25f;
        yield return new WaitForSeconds(3.3f);
        voiceOverDialogue.text = "Shelly: Oh thank goodness! I thought you were dead!";
        audioData.clip=audioClipArray[2];
        audioData.PlayOneShot(audioData.clip); 
        yield return new WaitForSeconds(1.9f);
        //VolumeReset();
        StartCoroutine(DelayedConvo());
    }
    IEnumerator HealthTalk()
    {
        yield return new WaitForSeconds(3.75f);
        voiceOverDialogue.text = "Miles: Looks like there's some mustache tonic! How fortunate! I can use that if I need to heal myself";
        audioData.clip=audioClipArray[4];
        audioData.PlayOneShot(audioData.clip); 
        vcam2.gameObject.SetActive(true);
        yield return new WaitForSeconds(4.5f);   
        vcam2.gameObject.SetActive(false);
        vcam3.gameObject.SetActive(false);
        animTransitionController.Play("LetterboxVoiceOverFadeOut"); 
        movementScript.stayStill = false;   
        movementScript.isHealing = false;
        hudAnim.Play("HUDSlideInForVoiceOver");
        VolumeReset();
    }
    IEnumerator DelayedConvo()
    {
        yield return new WaitForSeconds(1.5f);
                //animName = "MilesAnswersPhone";
                //levelMusic.musicVolume = 0.25f;
                audioData.clip=audioClipArray[5];//fall
                audioData.PlayOneShot(audioData.clip);
                //animTransitionController.Play("LetterboxVoiceOverFadeIn");
                //hudAnim.Play("HUDSlideOutForVoiceOver");                               
                voiceOverDialogue.text = "Miles: It Takes more than a fall to maim Miles McKracken!";
                movementScript.stayStill = true;
                movementScript.isHealing = true;
                //movementScript.playAnim(animName);
        yield return new WaitForSeconds(3.2f);
                audioData.clip=audioClipArray[6];//not sure
                audioData.PlayOneShot(audioData.clip);
                voiceOverDialogue.text = "Miles: Although, I'm not sure how I'm going to get out of here.";
        yield return new WaitForSeconds(3.3f);
                audioData.clip=audioClipArray[7];//look around
                audioData.PlayOneShot(audioData.clip);
                voiceOverDialogue.text = "Shelly: Look Around the temple and see what you can find to help you escape.";
        yield return new WaitForSeconds(3.4f);
                audioData.clip=audioClipArray[8];//right my whip
                audioData.PlayOneShot(audioData.clip);
                voiceOverDialogue.text = "Miles: Right, maybe my whip can be of help!";
        yield return new WaitForSeconds(3.25f);
                animTransitionController.Play("LetterboxVoiceOverFadeOut");
                movementScript.stayStill = false;   
                movementScript.isHealing = false;
                disableWhip1.SetActive(true);
                disableWhip2.SetActive(true);
                disableWhip3.SetActive(true);
                disableWhip4.SetActive(true);
                hudAnim.Play("HUDSlideInForVoiceOver");
                movementScript.playAnim("MilesPutsAwayPhone");  
                VolumeReset();
    }
    public void VolumeReset()
    {
        levelMusic.musicVolume = 0.85f;
    }
}
