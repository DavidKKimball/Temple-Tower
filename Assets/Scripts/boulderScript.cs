using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderScript : MonoBehaviour
{
    public GameObject player;
    public Animator boulderanim;
    public GameObject target;
    public int manualDistance = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = Vector3.Distance(target.transform.position, player.transform.position);
        Debug.Log(playerDistance);
        if (playerDistance > 13 && manualDistance < 25)
        {
            boulderanim.speed = 1.2f;
            Debug.Log("miles too far catching up...");
        }
        if (playerDistance >= 25)
        {
            boulderanim.speed = 2.0f;
            Debug.Log("miles way too far catching up...");
        }
        if (playerDistance < 13 && playerDistance >=5)
        {
            boulderanim.speed = 0.5f;
            Debug.Log("miles too close slowing down...");
        }
        if (playerDistance >= 2 && playerDistance <= 5)
        {
            boulderanim.speed = 1f;
            Debug.Log("good distance");
        }             
    }        
}
