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
    public bool newGame;
    public GameObject areYouSureCanvas;
    public GameObject noSaveDataCanvas;
    // Start is called before the first frame update
    void Start()
    {
        SaveChecker();
    }

    public void SaveChecker()
    {
        string path = Application.persistentDataPath + "/player.snootysobyouare";
        if (File.Exists(path))
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
        string path = Application.persistentDataPath + "/player.snootysobyouare";
        if (File.Exists(path))
        {
            File.Delete(path);
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
}
