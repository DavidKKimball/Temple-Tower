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
    public float[] playerLocation;
    public float playerTime;

    public PlayerData (Movement player)
    {
        score = player.score;
        level = SceneManager.GetActiveScene().buildIndex;
        playerLocation = new float[3];
        treasureCollected = new bool[player.treasureCounter.objects.Length];
        playerLocation[0] = player.transform.position.x;
        playerLocation[1] = player.transform.position.y;
        playerLocation[2] = player.transform.position.z;
        for (i = 0; i < player.treasureCollected.Length; i++)
            treasureCollected[i] = player.treasureCollected[i];
    }
}
