using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairFixer : MonoBehaviour
{
    public PhysicMaterial originalPhys;
    public PhysicMaterial stairPhys;
    public Collider player;
    private GameObject playerMaster;
    private Movement scriptHolder;
    private Animator anim;

    void Awake()
    {
        playerMaster = GameObject.Find("MilesNewWorking");
        scriptHolder = playerMaster.GetComponent<Movement>();
        anim = playerMaster.GetComponent<Animator>();
    }
    void Update()
    {
        if (scriptHolder.speed < 2)
        {
            scriptHolder.speed = 3.7f;
        }
    }
    void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.tag == "Player")            
        {
            //Debug.Log("hit");
            player.material = stairPhys;
            if (scriptHolder.isRolling == false || scriptHolder.isJumping == false || scriptHolder.justJumped == false || scriptHolder.isStairs == false)
            {
                scriptHolder.speed = 2.0f;
                anim.speed = 0.7f;
            }
            
            if (scriptHolder.isRolling == true || scriptHolder.isJumping == true || scriptHolder.justJumped == true || scriptHolder.isStairs == true)
            {
                scriptHolder.speed = 5f;
                anim.speed = 1.0f;
            }
        }
    }
    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Player")            
        {
            player.material = originalPhys;
            scriptHolder.speed = 3.7f;
            anim.speed = 1.0f;
        }
    }
}
