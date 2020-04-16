using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;

    // Update is called once per frame
    public void RunGame()
    {
        //SceneManager.LoadScene("Loading");
        anim1.Play("newGameStart");
        anim2.Play("menuFadeOut");
    }
}
