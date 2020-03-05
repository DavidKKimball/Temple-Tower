using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumaSpawner : MonoBehaviour
{
    public doorArchway door;
    public Transform[] waypoints;
    public GameObject pumaPrefab;
    public transitionController transitionController;
    public GameObject miles;
    public GameObject currentPuma;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentPuma == null && door.isShut == false)
        {
            currentPuma = Instantiate(pumaPrefab, gameObject.transform);
            System.Array.Resize(ref currentPuma.GetComponent<PumaController>().waypoints, 2);
            currentPuma.GetComponent<PumaController>().waypoints = waypoints;
            currentPuma.GetComponent<PumaController>().transition = transitionController;
            currentPuma.GetComponent<PumaController>().playerTarget = miles.transform;
        }
    }
}

