using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voiceOverTrigger : MonoBehaviour
{
    private GameObject voiceOverManager;
    private voiceOverManagerLevelOne managerLevelOne;
    public int voiceOverType;
    private bool alreadyPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        voiceOverManager = GameObject.Find("Voice Over Manager");
        managerLevelOne = voiceOverManager.GetComponent<voiceOverManagerLevelOne>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter()
    {
        if (alreadyPlayed)
        {
            managerLevelOne.TriggerVoiceOver(voiceOverType);
            Destroy(this);
        }
        alreadyPlayed = true;

    }
}
