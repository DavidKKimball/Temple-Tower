using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObjectOnEnter : MonoBehaviour
{
    public GameObject toBeDestroyed;
    public float manualDistance;
    //private Transform targetPos;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
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
            if(toBeDestroyed)
            {
            Destroy(toBeDestroyed);
            }
        }
    }
}