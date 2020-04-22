using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuManager : MonoBehaviour
{
    private int i;
    public Canvas newGameCanvas;
    public Canvas loadGameCanvas;
    public GameObject newGameButton;
    public GameObject loadGameButton;
    public GameObject yesButton;
    public GameObject backButton;
    public GameObject audioOptionsButton;
    public GameObject controlBackButton;
    public GameObject creditBackButton;
    public GameObject gammaSlider;
    public GameObject highScoreBackButton;
    public bool newGame;
    public Canvas creditsCanvas;
    public Canvas settingsCanvas;
    public Canvas audioOptionsCanvas;
    public Canvas highScoreCanvas;
    public Canvas controlCanvas;
    public Canvas areYouSureCanvas;
    public Canvas noSaveDataCanvas;

    // high score stuff
    private bool hasHighScoreData;
    private List<HighScoreEntry> highScoreEntries;
    public GameObject[] nameObjectArray; // assign in engine
    public GameObject[] scoreObjectArray; // assign in engine
    public TextMeshProUGUI[] nameTMPArray;
    public string[] nameArray;
    public int[] scoreArray;
    // Start is called before the first frame update
    void Start()
    {
        SaveChecker();

        if (hasHighScoreData)
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

            LoadHighScore();

            for (i = 0; i < highScoreEntries.Count; i++)
            {
                nameArray[i] = highScoreEntries[i].entryName;
                nameObjectArray[i].GetComponent<TextMeshProUGUI>().text = nameArray[i];
                int entryScore = highScoreEntries[i].entryScore;
                scoreArray[i] = entryScore;
                scoreObjectArray[i].GetComponent<TextMeshProUGUI>().text = scoreArray[i].ToString();
            }
        }
    }

    public void SaveChecker()
    {
        string path1 = Application.persistentDataPath + "/player.snootysobyouare";
        string path2 = Application.persistentDataPath + "/player.verysnooty";
        string path3 = Application.persistentDataPath + "/player.wow";
        if (File.Exists(path1) || File.Exists(path2))
        {
            loadGameCanvas.enabled = true;
            newGameCanvas.enabled = false;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(loadGameButton);
            newGame = false;
        }
        else
        {
            newGameCanvas.enabled = true;
            loadGameCanvas.enabled = false;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(newGameButton);
            newGame = true;
        }

        if (File.Exists(path3))
        {
            hasHighScoreData = true;
        }
    }

    public void ResumeButton()
    {
        string path1 = Application.persistentDataPath + "/player.snootysobyouare";
        string path2 = Application.persistentDataPath + "/player.verysnooty";
        if (File.Exists(path2))
        {
            PlayerData data = SaveScript.LoadFromCheckPoint();

            SceneManager.LoadScene(data.level);
        }
        else if (File.Exists(path1))
        {
            PlayerData data = SaveScript.LoadPlayer();

            SceneManager.LoadScene(data.level);
        }
    }

    public void CreditsButton()
    {
        loadGameCanvas.enabled = false;
        newGameCanvas.enabled = false;
        creditsCanvas.enabled = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditBackButton);
    }

    public void SettingsButton()
    {
        loadGameCanvas.enabled = false;
        newGameCanvas.enabled = false;
        settingsCanvas.enabled = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(audioOptionsButton);       
    }

    public void SettingsBackButton()
    {
        settingsCanvas.enabled = false;
        SaveChecker();
    }

    public void CreditsBackButton()
    {
        creditsCanvas.enabled = false;
        SaveChecker();
    }
    public void AudioOptions()
    {
        settingsCanvas.enabled = false;
        audioOptionsCanvas.enabled = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(gammaSlider);
    }

    public void ControlsButton()
    {
        settingsCanvas.enabled = false;
        controlCanvas.enabled = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controlBackButton);
    }

    public void ControlsBackButton()
    {
        settingsCanvas.enabled = true;
        controlCanvas.enabled = false;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(audioOptionsButton);
    }

    public void HighScoreButton()
    {
        settingsCanvas.enabled = false;
        highScoreCanvas.enabled = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(highScoreBackButton);
    }

    public void BackToSettingsButtons()
    {
        audioOptionsCanvas.enabled = false;
        highScoreCanvas.enabled = false;
        settingsCanvas.enabled = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(audioOptionsButton);
    }

    public void AreYouSure()
    {
        loadGameCanvas.enabled = false;
        newGameCanvas.enabled = false;
        areYouSureCanvas.enabled = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(yesButton);
    }

    public void DeleteButton()
    {
        string path1 = Application.persistentDataPath + "/player.snootysobyouare";
        string path2 = Application.persistentDataPath + "/player.verysnooty";
        if (File.Exists(path1) || File.Exists(path2))
        {
            File.Delete(path1);
            File.Delete(path2);
            SceneManager.LoadScene("MenuPostIntro");
        }
        else
        {
            areYouSureCanvas.enabled = false;
            noSaveDataCanvas.enabled = true;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(backButton);
        }
    }

    public void BackorNo()
    {
        areYouSureCanvas.enabled = false;
        noSaveDataCanvas.enabled = false;
        string path1 = Application.persistentDataPath + "/player.snootysobyouare";
        string path2 = Application.persistentDataPath + "/player.verysnooty";
        if (File.Exists(path1) || File.Exists(path2))
        {
            loadGameCanvas.enabled = true;        

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(loadGameButton);
        }
        else
        {
            newGameCanvas.enabled = true;        

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(newGameButton);
        }

    }

    // highscore stuff
    private class HighScoreEntry
    {
        public int entryScore;
        public string entryName;
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
}
