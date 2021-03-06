﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PumaController : MonoBehaviour { 

    public float lookRadius;
    public float speed;
    public float lockPos = 0;
    public Transform puma;

    public GameObject spriteLeft;
    public GameObject spriteRight;
    public Transform[] waypoints;
    public AudioSource pumaGrowl;
    public Transform startingPosition;

    public Transform playerTarget;
    public Transform waypointTarget;
    public GameObject dustCloud;
    public transitionController transition;//attaches the transition controller which has the UI QTE intro animation function in it
    NavMeshAgent agent;

    private bool playerDetect = false;
    private int current = 0;
    private float Wpradius = 1;

    public bool isBoss;

    public int pumaHealth;

    private void Start()
    {
        startingPosition = gameObject.transform;

        if (isBoss)
            pumaHealth = 3;
        else
            pumaHealth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerTarget.position, transform.position);
        waypointTarget = waypoints[current];

        if (distance <= lookRadius)
        {
            FacePlayer();
            playerDetect = true;
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, Time.deltaTime * speed * 2f);
        }
        else
        {
            playerDetect = false;
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
            FaceWaypoint();
        }

        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < Wpradius && playerDetect == false)
        {
            current++;
            SpriteFlip();
            FaceWaypoint();
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        /*float distance2 = Vector3.Distance(waypoints[current].transform.position, transform.position);
        if (distance2 > 25)
        {
            transform.position = waypoints[current].transform.position;
        }*/
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos); //prevents puma from turning awkwardly

    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(dustCloud, gameObject.transform.position, gameObject.transform.rotation);
            playerTarget.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 750, other.gameObject.transform.position.z);
            gameObject.transform.position = new Vector3(startingPosition.position.x, startingPosition.position.y + 500, startingPosition.position.z);
            pumaGrowl.Play();
            transition.QTEtrigger(); //triggers the into animation, can also put this in a coroutine to have the dust cloud instantiate after the animation plays.
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            speed = 0;
        }
    }


    void FaceWaypoint()
    {
        Vector3 direction = (waypointTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z + 90));
        puma.transform.rotation = Quaternion.Slerp(puma.transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void FacePlayer()
    {
        Vector3 direction = (playerTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z + 90));
        puma.transform.rotation = Quaternion.Lerp(puma.transform.rotation, lookRotation, Time.deltaTime * 30f);
    }

    void SpriteFlip()
    {
        /*if (puma.GetComponent<SpriteRenderer>().flipX == true) //changed to target sprite renderer in grandchildren, allows more control later on animation wise
            puma.GetComponent<SpriteRenderer>().flipX = false;
        else if (puma.GetComponent<SpriteRenderer>().flipX == false)
            puma.GetComponent<SpriteRenderer>().flipX = true;*/

        if (spriteLeft.activeSelf)
        {
            spriteRight.SetActive(true);
            spriteLeft.SetActive(false);
        }
        else if (spriteRight.activeSelf)
        {
            spriteLeft.SetActive(true);
            spriteRight.SetActive(false);
        }
    }
}

