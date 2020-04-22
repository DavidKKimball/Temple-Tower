using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class HighScoreMenuManager : MonoBehaviour
{
    public int i, j;
    public int score;
    public GameObject inputCanvas;
    public GameObject highScoreCanvas;
    public TextMeshProUGUI inputField;
    private List<HighScoreEntry> highScoreEntries;
    public GameObject[] nameObjectArray; // assign in engine
    public GameObject[] scoreObjectArray; // assign in engine
    public TextMeshProUGUI[] nameTMPArray;
    public string[] nameArray;
    public int[] scoreArray;

    public bool playedOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        nameTMPArray = new TextMeshProUGUI[nameObjectArray.Length];
        nameArray = new string[nameTMPArray.Length];
        scoreArray = new int[scoreObjectArray.Length];
        for (i = 0; i < nameObjectArray.Length; i++)
        {
            nameTMPArray[i] = nameObjectArray[i].GetComponent<TextMeshProUGUI>();
            nameArray[i] = nameTMPArray[i].text;
            scoreArray[i] = int.Parse(scoreObjectArray[i].GetComponent<TextMeshProUGUI>().text);
        }
        //Save();
        LoadScore();
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputField.text.Length == 3 && playedOnce == false)
        {
            Continue();
            playedOnce = true;
        }
    }
    private class HighScoreEntry
    {
        public int entryScore;
        public string entryName;
    }

    public void LoadScore ()
    {
        PlayerData data = SaveScript.LoadPlayer();
        score = data.score;
    }

    public void Save ()
    {
        SaveScript.SaveHighScore(this);
    }

    public void LoadHighScore ()
    {
        HighScoreData highScoreData = SaveScript.LoadHighScore();

        highScoreEntries = new List<HighScoreEntry>()
        {
                new HighScoreEntry{ entryScore = highScoreData.scores[0], entryName = highScoreData.names[0] },
                new HighScoreEntry{ entryScore = highScoreData.scores[1], entryName = highScoreData.names[1] },
                new HighScoreEntry{ entryScore = highScoreData.scores[2], entryName = highScoreData.names[2] },
                new HighScoreEntry{ entryScore = highScoreData.scores[3], entryName = highScoreData.names[3] },
                new HighScoreEntry{ entryScore = highScoreData.scores[4], entryName = highScoreData.names[4] },
                new HighScoreEntry{ entryScore = highScoreData.scores[5], entryName = highScoreData.names[5] },
                new HighScoreEntry{ entryScore = highScoreData.scores[6], entryName = highScoreData.names[6] },
                new HighScoreEntry{ entryScore = highScoreData.scores[7], entryName = highScoreData.names[7] },
                new HighScoreEntry{ entryScore = highScoreData.scores[8], entryName = highScoreData.names[8] },
                new HighScoreEntry{ entryScore = highScoreData.scores[9], entryName = highScoreData.names[9] },   
        };
    }

    public void Continue ()
    {
        highScoreEntries.Add(new HighScoreEntry{ entryScore = score, entryName = inputField.text });

        // sort
        for (i = 0; i < highScoreEntries.Count; i++)
        {
            for (j = i + 1; j < highScoreEntries.Count; j++)
            {
                if (highScoreEntries[j].entryScore > highScoreEntries[i].entryScore)
                {
                    HighScoreEntry tmp = highScoreEntries[i];
                    highScoreEntries[i] = highScoreEntries[j];
                    highScoreEntries[j] = tmp;
                }
            }
        }

        highScoreEntries.RemoveAt(10);

        for (i = 0; i < highScoreEntries.Count; i++)
        {
            nameArray[i] = highScoreEntries[i].entryName;
            nameTMPArray[i].text = nameArray[i];
            scoreArray[i] = highScoreEntries[i].entryScore;
            scoreObjectArray[i].GetComponent<TextMeshProUGUI>().text = scoreArray[i].ToString();
        }
        
        Save();
        inputCanvas.GetComponent<Canvas>().enabled = false;
        highScoreCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MenuPostIntro");
    }
}
