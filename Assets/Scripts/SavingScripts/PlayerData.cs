using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int score;

    public PlayerData (Movement player)
    {
        score = player.score;
        level = SceneManager.GetActiveScene().buildIndex + 1;
    }
}
