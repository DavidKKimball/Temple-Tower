﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.AI;

public class Qte2 : MonoBehaviour
{
    public Image qteBar;
    public ParticleSystem system;
    public ParticleSystem system2;
    public ParticleSystem system3;
    public GameObject[] buttonSpawn;
    public GameObject pumaSpawn;
    public int addValue;
    public float originalPosition;
    public float zoomInLength = 10f;
    public float zoomInSpeed = 45f;
    public float zoomInPosition;
    private GameObject buttonGraphic;
    private string pumaName;
    private bool qteOver;
    private bool isSafe;
    private float startBarHealth = 100;
    private int buttonPresses;
    private float barHealth;
    private int buttonNumber;
    //private Vector3 pumaCords;
    public GameObject playerHealth;
    public GameObject[] buttonPrefabs;
    public GameObject vcam;
    public GameObject miles;
    public GameObject cameraFollow;
    public GameObject puma;
    public GameObject sleepingPuma;
    public GameObject mover;
    public CinemachineVirtualCamera zoomer;
    public GameObject animHolder;
    public Animator anim;
    private AudioSource audioData;
    public AudioClip[] audioClipArray;
    public PumaController pumaController;
    public voiceOverManagerLevelBoss boss;
    public GameObject bossHolder;
    //private AudioSource pumaZaps;
    //public AudioClip pumaZapSound;
    public Animator animBossMusicStop;
    public GameObject animBossMusicHolder;
    // Start is called before the first frame update
    void Start()
    {
        //pumaZaps = GetComponent<AudioSource>();
        bossHolder = GameObject.Find("Voice Over Manager");
        boss = bossHolder.GetComponent<voiceOverManagerLevelBoss>();
        animBossMusicHolder = GameObject.Find("Music Manager");
        animBossMusicStop = animBossMusicHolder.GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
        miles = GameObject.Find("MilesNewWorking");
        cameraFollow = GameObject.Find("CameraFollowsThisObject");
        playerHealth = GameObject.Find("RedHealth");
        barHealth = startBarHealth;
        buttonNumber = Random.Range(0, 3);
        vcam = GameObject.Find("CM vcam1");
        animHolder = GameObject.Find("Puma Master");
        anim = animHolder.GetComponent<Animator>();
        zoomer =  vcam.GetComponent<CinemachineVirtualCamera>();        
        pumaName = miles.GetComponent<Movement>().pumaName;
        puma = GameObject.Find(pumaName);
        pumaController = puma.GetComponent<PumaController>();
        vcam.GetComponent<CinemachineVirtualCamera>().Follow = gameObject.transform;
        StartCoroutine(ButtonSpawnDelay());
        originalPosition = zoomer.m_Lens.FieldOfView;
        zoomInPosition = originalPosition - zoomInLength;
        Zoom();
        //zoomer.m_Lens.FieldOfView = 25f;
    }

    // Update is called once per frame
    void Update()
    {
        qteBar.fillAmount = barHealth / startBarHealth;

        barHealth -= Time.deltaTime * 80;

        ButtonMash(buttonNumber);
        StartCoroutine(QteEnd());

        if (buttonPresses == 10)
        {
            buttonNumber = Random.Range(0, 3);
            Destroy(buttonGraphic);
            buttonGraphic = Instantiate(buttonPrefabs[buttonNumber], buttonSpawn[buttonNumber].transform);
            buttonPresses = 0;
        }

        if (barHealth < 70)
            qteBar.color = Color.red;
        else
            qteBar.color = Color.green;

        if (barHealth > 100)
            barHealth = 100;
        else if (barHealth < 0)
            barHealth = 0;

        if (qteOver == true)
        {
            miles.transform.position = gameObject.transform.position;
            vcam.GetComponent<CinemachineVirtualCamera>().Follow = cameraFollow.transform;

            if (isSafe == true)
            {
                pumaController.pumaHealth--;
                puma.GetComponent<Rigidbody>().isKinematic = false;
                if (pumaController.pumaHealth <= 0)
                {
                    //Destroy(puma); destroying the puma makes his audio growl disapear which is used in an audioSource array to turn off all sound at the end of the level. If its destroyed mid-game, the tally screen script fails because the audioSource in one of the array slots is missing.
                    puma.gameObject.transform.position = new Vector3(0, -500,0);
                    //pumaZaps.Play();
                    Instantiate(sleepingPuma, miles.transform.position, Quaternion.identity);
                    animBossMusicStop.Play("bossLevelMusicBossOver");
                    boss.TriggerVoiceOver(10);
                }
                else
                    puma.transform.position = pumaSpawn.transform.position;
            }
            else if (isSafe == false)
            {
                puma.transform.position = pumaSpawn.transform.position;
                puma.GetComponent<PumaController>().speed = 2;
                puma.GetComponent<Rigidbody>().isKinematic = false;
                playerHealth.GetComponent<RedHealthBar>().AdjustCurrentHealth(20);
            }

            Destroy(gameObject);
        }
    }

    void ButtonMash(int buttonNumber)
    {
    audioData.clip=audioClipArray[Random.Range(0,audioClipArray.Length)];
        switch (buttonNumber)
        {
            case 0:
                if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("s"))
                {
                    //system.Stop();
                    //Debug.Log("pressed");
                    barHealth += addValue;
                    buttonPresses++;
                    audioData.PlayOneShot(audioData.clip);
                    //system.Play();
                    StartCoroutine(particleReplay());
                    StartCoroutine(SpeedUpQTE());
                }
                break;
            case 1:
                if (Input.GetButtonDown("Fire5") || Input.GetKeyDown("d"))
                {
                    //system.Stop();
                    barHealth += addValue;
                    buttonPresses++;
                    audioData.PlayOneShot(audioData.clip);
                    StartCoroutine(particleReplay());
                    StartCoroutine(SpeedUpQTE());
                }
                break;
            case 2:
                if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("a"))
                {
                    //system.Stop();
                    barHealth += addValue;
                    buttonPresses++;
                    audioData.PlayOneShot(audioData.clip);
                    StartCoroutine(particleReplay());
                    StartCoroutine(SpeedUpQTE());
                }
                break;
            case 3:
                if (Input.GetButtonDown("Fire6") || Input.GetKeyDown("w"))
                {
                    //system.Stop();
                    barHealth += addValue;
                    buttonPresses++;
                    audioData.PlayOneShot(audioData.clip);
                    StartCoroutine(particleReplay());
                    StartCoroutine(SpeedUpQTE());
                }
                break;
            default:
                break;
        }
    }

    IEnumerator SpeedUpQTE()
    {
        //anim.speed = 1.6f;
        anim.Play("WrestlingPhaseOnePunch");
        yield return new WaitForSeconds(0.07f);
        //anim.speed = 1.0f;
    }
    IEnumerator QteEnd()
    {
        yield return new WaitForSeconds(8);

        qteOver = true;
        ZoomBack();

        if (barHealth <= 70)
            isSafe = false;
        else
            isSafe = true;
    }
    IEnumerator ButtonSpawnDelay()
    {
        yield return new WaitForSeconds(0.5f);
        buttonGraphic = Instantiate(buttonPrefabs[buttonNumber], buttonSpawn[buttonNumber].transform);
    }
    public void Zoom()
    { 
        if (zoomer.m_Lens.FieldOfView >= zoomInPosition)
            zoomer.m_Lens.FieldOfView += (-zoomInSpeed * Time.deltaTime);
           
    }

    public void ZoomBack()
    { 
        if (zoomer.m_Lens.FieldOfView <= originalPosition)
            zoomer.m_Lens.FieldOfView += (zoomInSpeed * Time.deltaTime);
    }
    IEnumerator particleReplay()
    {
        system.Play();
        system2.Play();
        system3.Play();
        yield return new WaitForSeconds(0.3f);
        //system.Stop();
        //system2.Stop();
        //system3.Stop();
    }
}
