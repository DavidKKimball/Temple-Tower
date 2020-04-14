using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using TMPro;

public class treasureCounter : MonoBehaviour
{
    public GameObject[] objects;
    public TextMeshProUGUI treasureTextMesh;
    private Animator anim;
    public int treasureCollectedAmount = 0;
    public bool triggerVoiceOver;
    public int voiceOverNumber;
    private voiceOverManagerLevelOne voice;
    private voiceOverManagerLevelFive voice2;
    private GameObject voiceHolder;
    public bool levelOne =true;
    public bool levelFive;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        objects = GameObject.FindGameObjectsWithTag("Treasure");
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
    }

    public void collectTreasure()
    {
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
