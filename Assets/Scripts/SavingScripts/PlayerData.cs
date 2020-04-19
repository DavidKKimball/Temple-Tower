using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private int i;
    public int level;
    public int score;
    public bool[] treasureCollected;
    public int playerLocation;
    public float playerTime;

    public PlayerData (Movement player)
    {
        score = player.score;
        level = SceneManager.GetActiveScene().buildIndex;
        treasureCollected = new bool[player.treasureCounter.objects.Length];
        playerLocation = player.checkpointMarker;
        for (i = 0; i < player.treasureCollected.Length; i++)
            treasureCollected[i] = player.treasureCollected[i];
    }
}
