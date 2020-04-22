using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {
    public bool stopBall = false;

    void Update () 
    {
        if (stopBall == true)
        {
            return;
        }
        if (stopBall == false )
        {
        transform.Rotate (new Vector3 (0, 0, -120) * Time.deltaTime);
        }
    }
    public void stopBallRotation()
    {
        stopBall = true;
    }
}