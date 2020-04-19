using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreData : MonoBehaviour
{
    public string[] names;
    public int[] scores;

    public HighScoreData (HighScoreMenuManager highScore)
    {
        names = highScore.nameArray;
        scores = highScore.scoreArray;
    }
}
