using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroSkipper : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene("MenuPostIntro");
        }
    }
}
