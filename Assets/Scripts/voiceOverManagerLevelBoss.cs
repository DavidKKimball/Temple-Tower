using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class voiceOverManagerLevelBoss : MonoBehaviour
{
    private GameObject scriptHolder;
    public Animator hudAnim;
    public CinemachineVirtualCamera vcam;
    public CinemachineVirtualCamera vcam2;
    public CinemachineVirtualCamera vcam3;
    public CinemachineVirtualCamera vcam4;
    //public CinemachineVirtualCamera vcam5;
    //public CinemachineVirtualCamera vcam6;
    //public CinemachineVirtualCamera vcam7;
    //public CinemachineVirtualCamera vcam8;
    private Movement movementScript;
    private Animator animPlayer;
    private GameObject animatorHolder;
    public Animator animTransitionController;
    private GameObject textHolder;
    public TMP_Text voiceOverDialogue;
    public VolumeChanger levelMusic;
    private AudioSource audioData;
    public GameObject treasure;
    private Animator treasureAnim;
    public Animator musicAnim;
    public string animName;
    //public boulderSpawner boulderEffector;
    public AudioClip[] audioClipArray;
    public Animator musicChange;
    
        void Awake()
    {
        treasure.SetActive(true);
    }
       void Start()
    {
        treasureAnim = treasure.GetComponent<Animator>();
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
        treasure.SetActive(false);
    }
    void Update()
    {

    }
public void TriggerVoiceOver(int voiceOverType)
    {
    switch (voiceOverType)
            {
            case 9:
                StartCoroutine(pumaBoss());
            break;
            case 8:
                musicChange.Play("bossLevelMusicShift");
            break;
            case 7:
            StartCoroutine(chains());
                break;
            case 6:
            //camera pans area
            StartCoroutine(bossLevelStart());
                //animName = "MilesIdle";
                //levelMusic.musicVolume = 0.25f;
                //audioData.clip=audioClipArray[12];//dead guy spiel
                //audioData.PlayOneShot(audioData.clip);
                //animTransitionController.Play("LetterboxVoiceOverFadeIn");
                //hudAnim.Play("HUDSlideOutForVoiceOver");                ;                
                //voiceOverDialogue.text = "Well that's a strange looking statue.";
                //movementScript.playAnim(animName);
               //movementScript.stayStill = true;
                //movementScript.isHealing = true;
                //vcam5.gameObject.SetActive(true);//turn on health vcam
                //StartCoroutine(NormalVoiceOverReset(2.2f));
                break;
            case 5:
            //camera pans area
            StartCoroutine(levelFiveStart());
                //animName = "MilesIdle";
                //levelMusic.musicVolume = 0.25f;
                //audioData.clip=audioClipArray[12];//dead guy spiel
                //audioData.PlayOneShot(audioData.clip);
                //animTransitionController.Play("LetterboxVoiceOverFadeIn");
                //hudAnim.Play("HUDSlideOutForVoiceOver");                ;                
                //voiceOverDialogue.text = "Well that's a strange looking statue.";
                //movementScript.playAnim(animName);
               //movementScript.stayStill = true;
                //movementScript.isHealing = true;
                //vcam5.gameObject.SetActive(true);//turn on health vcam
                //StartCoroutine(NormalVoiceOverReset(2.2f));
                break;
            case 4:
            //miles sees the dead guy
                StartCoroutine(deadExplorer());
               // animPlayer.Play("TallVaseWobble");
                //animName = "MilesIdle";
                //levelMusic.musicVolume = 0.25f;
                //turnOffWalkieTalkieWhileTalking.enabled = false;
                //animPlayer.Play("MilesDrinkHealth");
                //audioData.clip=audioClipArray[3];//dead guy spiel
                //audioData.PlayOneShot(audioData.clip);
                //animTransitionController.Play("LetterboxVoiceOverFadeIn");
                //hudAnim.Play("HUDSlideOutForVoiceOver");                
                //freezeDuration = 6f;                
                //voiceOverDialogue.text = "Miles: Drat! I thought I'd be the first explorer down here!";
                //movementScript.stayStill = true;
                //movementScript.isHealing = true;
                //animPlayer.Play("MilesLookUp");
                //movementScript.playAnim(animName);
                //vcam.gameObject.SetActive(true);
                //regularCamera.SetActive(false);
                //walkieTalkie.SetActive(false);
                //fireSecondCoroutine = true;
                //vcam3.gameObject.SetActive(true);//turn on health vcam
                //StartCoroutine(HealthTalk());
                break;
            case 3:
                //miles picks up the phone
                StartCoroutine(doorsSecondSetOpen());
                //animName = "MilesAnswersPhone";
                //levelMusic.musicVolume = 0.25f;
                //turnOffWalkieTalkieWhileTalking.enabled = false;
                //animPlayer.Play("MilesDrinkHealth");
                //audioData.clip=audioClipArray[1];
                //audioData.PlayOneShot(audioData.clip);
                //animTransitionController.Play("LetterboxVoiceOverFadeIn");
                //hudAnim.Play("HUDSlideOutForVoiceOver");                
                //freezeDuration = 6f;                
                //voiceOverDialogue.text = "Miles: Shelly! Can you hear me? It's Miles. I'm Alright";
                //movementScript.stayStill = true;
                //movementScript.isHealing = true;
                //animPlayer.Play("MilesLookUp");
                //movementScript.playAnim(animName);
                //vcam.gameObject.SetActive(true);
                //regularCamera.SetActive(false);
                //walkieTalkie.SetActive(false);
                //fireSecondCoroutine = true;
                //StartCoroutine(FreezeReset());
                //StartCoroutine(phoneConvoDelay());
                break;
            case 2:
            //doors first set opens
            Debug.Log("case 2");
                StartCoroutine(doorsFirstSetOpen());
                //movementScript.stayStill = true;
                //movementScript.isHealing = true;
                //movementScript.playAnim("MilesIdle");
                //animTransitionController.Play("LetterboxVoiceOverFadeIn");
                //hudAnim.Play("HUDSlideOutForVoiceOver"); 
                //levelMusic.musicVolume = 0.25f;
                //waterfallAudio.volume = 0.15f;
                //vcam4.gameObject.SetActive(true);
                //voiceOverDialogue.text = "Miles: A Puma! I've fought a few of these in my day! They'll only slow me down!";
            // animPlayer.Play("ShortNarrowVaseWobble");
                //StartCoroutine(PumaReset());
                break;
            case 1:
            //miles gets a call from shelly
                StartCoroutine(boulderRumbleLevelStart());
                //animName = "MilesLookUp";
                //levelMusic.musicVolume = 0.25f;
                //turnOffWalkieTalkieWhileTalking.enabled = false;
                //animPlayer.Play("MilesDrinkHealth");
                //audioData.clip=audioClipArray[0];
                //audioData.PlayOneShot(audioData.clip);
                //animTransitionController.Play("LetterboxVoiceOverFadeIn");
                //hudAnim.Play("HUDSlideOutForVoiceOver");                
                //freezeDuration = 3.2f;                
                //voiceOverDialogue.text = "Miles: I can't reach that from here, I'll have to find another way";
                //movementScript.stayStill = true;
                //movementScript.isHealing = true;
                //animPlayer.Play("MilesLookUp");
                //movementScript.playAnim(animName);
                //vcam.gameObject.SetActive(true);
                //regularCamera.SetActive(false);
                //StartCoroutine(FreezeReset());
                break;
            default:
                print ("");
                break;
        }    

    IEnumerator pumaBoss()
    {
        vcam3.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        movementScript.stayStill = true;
        movementScript.isHealing = true;
        animPlayer.Play("MilesIdle");
        audioData.clip=audioClipArray[2];
        levelMusic.musicVolume = 0.25f;
        musicAnim.Play("bossLevelMusicVoiceOverCarn");
        hudAnim.Play("HUDSlideOutIdleForVoiceOver");
        animTransitionController.Play("LetterboxVoiceOverFadeIn");
        audioData.PlayOneShot(audioData.clip);        
        voiceOverDialogue.text = "Miles: I can see the ultimate Artifact from here!"; 
        yield return new WaitForSeconds(4.6f);       
        voiceOverDialogue.text = "Miles: Hmm another big cat in my way, he seems stronger than your typical puma too.";
        vcam4.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.2f);
        voiceOverDialogue.text = "Miles: I 'ought to be careful.";
        yield return new WaitForSeconds(1.5f);
        vcam3.gameObject.SetActive(false);
        vcam4.gameObject.SetActive(false);
        levelMusic.musicVolume = 0.85f;
        musicAnim.Play("bossLevelMusicBoss");
        animTransitionController.Play("LetterboxVoiceOverFadeOut"); 
        movementScript.stayStill = false;   
        movementScript.isHealing = false;
        hudAnim.Play("HUDSlideInForVoiceOver");  


    }
    IEnumerator bossLevelStart()
    {
        yield return new WaitForSeconds(2f);
        //treasure.SetActive(false);
        movementScript.stayStill = true;
        movementScript.isHealing = true;
        animPlayer.Play("MilesAnswersPhone");
        voiceOverDialogue.text = "Miles: I'm beginning to see daylight! Shelly! I’m close to the ultimate artifact I can feel it!";
        audioData.clip=audioClipArray[0];
        hudAnim.Play("HUDSlideOutIdleForVoiceOver");
        levelMusic.musicVolume = 0.25f;
        musicAnim.Play("bossLevelMusicVoiceOver");
        animTransitionController.Play("LetterboxVoiceOverFadeIn");
        yield return new WaitForSeconds(1f);
        audioData.PlayOneShot(audioData.clip);
        yield return new WaitForSeconds(1.5f);
        vcam2.gameObject.SetActive(false); 
        yield return new WaitForSeconds(4f); 
        movementScript.playAnim("MilesPutsAwayPhone");
        levelMusic.musicVolume = 0.85f;
        musicAnim.Play("bossLevelMusicIdleBeforeChange");
        animTransitionController.Play("LetterboxVoiceOverFadeOut"); 
        movementScript.stayStill = false;   
        movementScript.isHealing = false;
        hudAnim.Play("HUDSlideInForVoiceOver");   
        treasure.SetActive(true);   
        treasureAnim.Play("TreasureHudSlideIn");       
    }   

    IEnumerator chains()
    {
        yield return new WaitForSeconds(0.8f);
        levelMusic.musicVolume = 0.25f;
        musicAnim.Play("bossLevelMusicVoiceOver");
        yield return new WaitForSeconds(0.5f);
        //treasure.SetActive(false);
        movementScript.stayStill = true;
        movementScript.isHealing = true;
        animPlayer.Play("MilesIdle");
        voiceOverDialogue.text = "Miles: I can't seem to cross these very modern looking chains...";
        audioData.clip=audioClipArray[1];
        hudAnim.Play("HUDSlideOutIdleForVoiceOver");
        animTransitionController.Play("LetterboxVoiceOverFadeIn");
        audioData.PlayOneShot(audioData.clip);
        yield return new WaitForSeconds(3.5f);
        voiceOverDialogue.text = "Miles: It's like there's some sort of cursed placed on it.";
        yield return new WaitForSeconds(3f); 
        levelMusic.musicVolume = 0.85f;
        musicAnim.Play("bossLevelMusicIdleBeforeChange");
        animTransitionController.Play("LetterboxVoiceOverFadeOut"); 
        movementScript.stayStill = false;   
        movementScript.isHealing = false;
        hudAnim.Play("HUDSlideInForVoiceOver");         
    }  

    IEnumerator levelFiveStart()  
    {
        //vcam5.gameObject.SetActive(true); 
        yield return new WaitForSeconds(1f);
        audioData.clip=audioClipArray[4];
        movementScript.stayStill = true;
        movementScript.isHealing = true;
        animPlayer.Play("MilesIdle");
        voiceOverDialogue.text = "Miles: Hmm seems I need to find a way to move those barriers, they may be connected to this gear system.";
        hudAnim.Play("HUDSlideOutForVoiceOver");
        levelMusic.musicVolume = 0.25f;
        audioData.PlayOneShot(audioData.clip);
        animTransitionController.Play("LetterboxVoiceOverFadeIn"); 
        yield return new WaitForSeconds(4f);
        //vcam6.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);  
        levelMusic.musicVolume = 0.85f;
        animTransitionController.Play("LetterboxVoiceOverFadeOut"); 
        movementScript.stayStill = false;   
        movementScript.isHealing = false;
        hudAnim.Play("HUDSlideInForVoiceOver");  
        //vcam5.gameObject.SetActive(false);  
        //vcam6.gameObject.SetActive(false); 
    }

    IEnumerator phoneConvoLevelStart()
    {

        //yield return new WaitForSeconds(3.3f);
        //voiceOverDialogue.text = "Shelly: Oh thank goodness! I thought you were dead!";
        //audioData.clip=audioClipArray[2];
        //audioData.PlayOneShot(audioData.clip); 
        yield return new WaitForSeconds(4.5f);
        levelMusic.musicVolume = 0.85f;
        animTransitionController.Play("LetterboxVoiceOverFadeOut"); 
        movementScript.stayStill = false;   
        movementScript.isHealing = false;
        hudAnim.Play("HUDSlideInForVoiceOver");
        movementScript.playAnim("MilesPutsAwayPhone");
        //vcam5.gameObject.SetActive(false);

    }
    IEnumerator boulderRumbleLevelStart()
    {
        //boulderEffector.GetComponent<boulderSpawner>().spawnBoulderSoundRumbleOnly();
        Debug.Log("it fired");
        yield return new WaitForSeconds(2.3f);
        audioData.clip=audioClipArray[0];
        movementScript.stayStill = true;
        movementScript.isHealing = true;
        animPlayer.Play("MilesAnswersPhone");
        animTransitionController.Play("LetterboxVoiceOverFadeIn");
        hudAnim.Play("HUDSlideOutForVoiceOver");
        levelMusic.musicVolume = 0.25f;
        audioData.PlayOneShot(audioData.clip);
        voiceOverDialogue.text = "Shelly: Miles did you feel that?... Are you alright?... Watch out for the falling rocks down there.";
        StartCoroutine(phoneConvoLevelStart());
    }

    IEnumerator doorsFirstSetOpen()
    {
        //vcam3.gameObject.SetActive(true); 
        yield return new WaitForSeconds(1f);
        audioData.clip=audioClipArray[1];
        movementScript.stayStill = true;
        movementScript.isHealing = true;
        animPlayer.Play("MilesIdle");
        voiceOverDialogue.text = "Miles: Looks like I'm making progress.";
        hudAnim.Play("HUDSlideOutForVoiceOver");
        levelMusic.musicVolume = 0.25f;
        audioData.PlayOneShot(audioData.clip);
        animTransitionController.Play("LetterboxVoiceOverFadeIn"); 
        yield return new WaitForSeconds(5.4f); 
        levelMusic.musicVolume = 0.85f;
        animTransitionController.Play("LetterboxVoiceOverFadeOut"); 
        movementScript.stayStill = false;   
        movementScript.isHealing = false;
        hudAnim.Play("HUDSlideInForVoiceOver");  
        //vcam3.gameObject.SetActive(false);   
    }

    IEnumerator doorsSecondSetOpen()
    {
        //vcam3.gameObject.SetActive(true); 
        yield return new WaitForSeconds(1f);
        audioData.clip=audioClipArray[2];
        movementScript.stayStill = true;
        movementScript.isHealing = true;
        animPlayer.Play("MilesIdle");
        voiceOverDialogue.text = "Miles: Aha! It's finally open! I hope this leads back to the Ultimate Artifact.";
        hudAnim.Play("HUDSlideOutForVoiceOver");
        levelMusic.musicVolume = 0.25f;
        audioData.PlayOneShot(audioData.clip);
        animTransitionController.Play("LetterboxVoiceOverFadeIn"); 
        yield return new WaitForSeconds(5.4f); 
        levelMusic.musicVolume = 0.85f;
        animTransitionController.Play("LetterboxVoiceOverFadeOut"); 
        movementScript.stayStill = false;   
        movementScript.isHealing = false;
        hudAnim.Play("HUDSlideInForVoiceOver");  
        //vcam3.gameObject.SetActive(false);   
    }
    IEnumerator deadExplorer()
    {
        //vcam4.gameObject.SetActive(true); 
        yield return new WaitForSeconds(1f);
        audioData.clip=audioClipArray[3];
        movementScript.stayStill = true;
        movementScript.isHealing = true;
        animPlayer.Play("MilesIdle");
        voiceOverDialogue.text = "Miles: Really?! Another explorer beat me down here?! I can't stand this!";
        hudAnim.Play("HUDSlideOutForVoiceOver");
        levelMusic.musicVolume = 0.25f;
        audioData.PlayOneShot(audioData.clip);
        animTransitionController.Play("LetterboxVoiceOverFadeIn"); 
        yield return new WaitForSeconds(3.6f); 
        levelMusic.musicVolume = 0.85f;
        animTransitionController.Play("LetterboxVoiceOverFadeOut"); 
        movementScript.stayStill = false;   
        movementScript.isHealing = false;
        hudAnim.Play("HUDSlideInForVoiceOver");  
        //vcam4.gameObject.SetActive(false);   
    }
    /*

    public Animator hudAnim;
    public Animator turnOffWalkieTalkieWhileTalking;
    public CinemachineVirtualCamera vcam;
    public CinemachineVirtualCamera vcam2;
    public CinemachineVirtualCamera vcam3;
    public CinemachineVirtualCamera vcam4;
    public CinemachineVirtualCamera vcam5;
    public GameObject disableWhip1;
    public GameObject disableWhip2;
    public GameObject disableWhip3;
    public GameObject disableWhip4;
    private Collider highLightChecker;
    public GameObject highLightCheckerHolder;
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
        highLightChecker = highLightCheckerHolder.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TriggerVoiceOver(int voiceOverType)
    {
    switch (voiceOverType)
            {
            case 5:
            //miles sees puma go round
                animName = "MilesIdle";
                levelMusic.musicVolume = 0.25f;
                audioData.clip=audioClipArray[12];//dead guy spiel
                audioData.PlayOneShot(audioData.clip);
                animTransitionController.Play("LetterboxVoiceOverFadeIn");
                hudAnim.Play("HUDSlideOutForVoiceOver");                ;                
                voiceOverDialogue.text = "Well that's a strange looking statue.";
                movementScript.playAnim(animName);
                movementScript.stayStill = true;
                movementScript.isHealing = true;
                vcam5.gameObject.SetActive(true);//turn on health vcam
                StartCoroutine(NormalVoiceOverReset(2.2f));
                break;
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
                waterfallAudio.volume = 0.15f;
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
        yield return new WaitForSeconds(3.76f);
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
        yield return new WaitForSeconds(3.3f);
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
                highLightChecker.enabled = true;  
                VolumeReset();
    }
    public void VolumeReset()
    {
        levelMusic.musicVolume = 0.85f;
    }
    IEnumerator NormalVoiceOverReset(float number)
    {
        yield return new WaitForSeconds(number);
        levelMusic.musicVolume = 0.85f;
        animTransitionController.Play("LetterboxVoiceOverFadeOut"); 
        movementScript.stayStill = false;   
        movementScript.isHealing = false;
        hudAnim.Play("HUDSlideInForVoiceOver");
        vcam5.gameObject.SetActive(false);
    }
    public void audioOneShot(int number)
    {
        levelMusic.musicVolume = 0.25f;
        StartCoroutine(DelayedVolumeReset(number));
    }
    IEnumerator DelayedVolumeReset(int number)
    {
        yield return new WaitForSeconds(1.3f);
        audioData.clip=audioClipArray[number];
        audioData.PlayOneShot(audioData.clip);
        yield return new WaitForSeconds(1.3f);
        levelMusic.musicVolume = 0.85f;
    }*/
    }
}
