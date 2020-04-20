using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOnAwakeLevelBoss : MonoBehaviour
{
    public Animator letterbox;
    public Animator hud;
    //private voiceOverManagerLevelBoss managerLevelBoss;
    //private GameObject voiceOverManager;
    // Start is called before the first frame update
    void Awake()
    {
        //voiceOverManager = GameObject.Find("Voice Over Manager");
        //managerLevelBoss = voiceOverManager.GetComponent<voiceOverManagerLevelBoss>();
        letterbox.Play("FadeIn");
        hud.Play("HUDSlideOutIdleForVoiceOver");
        //managerLevelBoss.TriggerVoiceOver(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}