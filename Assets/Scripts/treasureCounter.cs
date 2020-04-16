using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using TMPro;

public class treasureCounter : MonoBehaviour
{
    private int i;
    public GameObject[] objects;
    public TextMeshProUGUI treasureTextMesh;
    public Animator anim;
    public int treasureCollectedAmount = 0;
    public bool triggerVoiceOver;
    public int voiceOverNumber;
    private voiceOverManagerLevelOne voice;
    private voiceOverManagerLevelFive voice2;
    private GameObject voiceHolder;
    public bool levelOne =true;
    public bool levelFive;
    public GameObject miles;
    public Movement player;

    public ChestController[] chestControllers;
    // Start is called before the first frame update

    void Awake()
    {
        objects = GameObject.FindGameObjectsWithTag("Treasure");
        chestControllers = new ChestController[objects.Length];
    }
    void Start()
    {
        anim = GetComponent<Animator>();

        miles = GameObject.Find("MilesNewWorking");
        player = miles.GetComponent<Movement>();
        
        for (i = 0; i < objects.Length; i++)
        {
            chestControllers[i] = objects[i].GetComponent<ChestController>();
        }

        treasureTextMesh  = treasureTextMesh.gameObject.GetComponent<TextMeshProUGUI>();
        voiceHolder = GameObject.Find("Voice Over Manager");
        if (levelOne)
        {
            voice = voiceHolder.GetComponent<voiceOverManagerLevelOne>();
        }
        if (levelFive)
        {
            voice2 = voiceHolder.GetComponent<voiceOverManagerLevelFive>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(objects.Length);
        treasureTextMesh.text = treasureCollectedAmount.ToString() + "/" + objects.Length.ToString();
        if (Input.GetKeyDown("l"))
        {
            Debug.Log(chestControllers[0].hasPlayed);
            Debug.Log(chestControllers[1].hasPlayed);
            Debug.Log(chestControllers[2].hasPlayed);
            Debug.Log(chestControllers[3].hasPlayed);
            Debug.Log(chestControllers[4].hasPlayed);
            Debug.Log(chestControllers[5].hasPlayed);
            Debug.Log(chestControllers[6].hasPlayed);
        }
    }

    public void collectTreasure()
    {
        for (i = 0; i < chestControllers.Length; i++)
        {
            if (chestControllers[i].hasPlayed)
            {
                player.treasureCollected[i] = true;
            }
        }
        Debug.Log("yo");
        if (triggerVoiceOver)
        {
            if (levelOne)
            {
                if (treasureCollectedAmount == 1)
                {
                    voice.audioOneShot(voiceOverNumber);
                    voiceOverNumber++;
                }
                if (treasureCollectedAmount == 4)
                {
                    voice.audioOneShot(voiceOverNumber);
                }
            }
        }
        anim.Play("TreasureHudSlideIn");
        StartCoroutine(treasureDelay());
    }

    IEnumerator treasureDelay()
    {
        yield return new WaitForSeconds(1.8f);
        treasureCollectedAmount++;
    }
}
