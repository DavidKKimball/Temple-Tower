using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderKillTriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerCamTarget;
    public GameObject OriginalParent;
    //private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        //rotation = playerCamTarget.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        //playerCamTarget.transform.rotation = rotation;    
    }
 void OnTriggerEnter (Collider other)
  {
      if(other.gameObject.tag == "Player")
      {
        playerCamTarget.transform.parent = this.gameObject.transform;
        //player.transform.rotation = Quaternion.identity;
        //gameObject.transform.parent = player.transform;
        //Debug.Log("Player Attached");
      }
  }

}


