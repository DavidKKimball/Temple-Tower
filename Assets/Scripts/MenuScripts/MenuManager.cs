using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public GameObject newGameCanvas;
    public GameObject loadGameCanvas;
    public GameObject newGameButton;
    public GameObject loadGameButton;
    public GameObject yesButton;
    public GameObject backButton;
    public GameObject controlBackButton;
    public bool newGame;
    public GameObject controlCanvas;
    public GameObject areYouSureCanvas;
    public GameObject noSaveDataCanvas;
    // Start is called before the first frame update
    void Start()
    {
        SaveChecker();
    }

    public void SaveChecker()
    {
        string path1 = Application.persistentDataPath + "/player.snootysobyouare";
        string path2 = Application.persistentDataPath + "/player.verysnooty";
        if (File.Exists(path1) || File.Exists(path2))
        {
            loadGameCanvas.GetComponent<Canvas>().enabled = true;
            newGameCanvas.GetComponent<Canvas>().enabled = false;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(loadGameButton);
            newGame = false;
        }
        else
        {
            newGameCanvas.GetComponent<Canvas>().enabled = true;
            loadGameCanvas.GetComponent<Canvas>().enabled = false;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(newGameButton);
            newGame = true;
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

    public void ControlsButton()
    {
        loadGameCanvas.GetComponent<Canvas>().enabled = false;
        newGameCanvas.GetComponent<Canvas>().enabled = false;
        controlCanvas.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controlBackButton);
    }

    public void AreYouSure()
    {
        loadGameCanvas.GetComponent<Canvas>().enabled = false;
        newGameCanvas.GetComponent<Canvas>().enabled = false;
        areYouSureCanvas.GetComponent<Canvas>().enabled = true;

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
            areYouSureCanvas.GetComponent<Canvas>().enabled = false;
            noSaveDataCanvas.GetComponent<Canvas>().enabled = true;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(backButton);
        }
    }

    public void BackorNo()
    {
        areYouSureCanvas.GetComponent<Canvas>().enabled = false;
        noSaveDataCanvas.GetComponent<Canvas>().enabled = false;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(loadGameButton);
    }
}
