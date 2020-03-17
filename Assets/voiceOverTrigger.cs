using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voiceOverTrigger : MonoBehaviour
{
    private GameObject voiceOverManager;
    private voiceOverManagerLevelOne managerLevelOne;
    public int voiceOverType;
    //private bool alreadyPlayed = false;
    public float manualDistance;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        voiceOverManager = GameObject.Find("Voice Over Manager");
        managerLevelOne = voiceOverManager.GetComponent<voiceOverManagerLevelOne>();
        player = GameObject.Find("MilesNewWorking");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter()
    {
    float playerDistance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (playerDistance < manualDistance)
        {
            managerLevelOne.TriggerVoiceOver(voiceOverType);
            Destroy(this);
        }
    }
}
