﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathToMenu : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuPostIntro");
    }
}
