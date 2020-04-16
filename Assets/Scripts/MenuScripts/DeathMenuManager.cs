using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;

public class DeathMenuManager : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject areYouSureRestart;
    public GameObject areYouSureMainMenu;
    public GameObject lastCheckPoint;
    public GameObject restartLevelYes;
    public GameObject mainMenuYes;
    public LoadScript loadScript;

    public void RestartButton()
    {
        canvas1.GetComponent<Canvas>().enabled = false;
        areYouSureRestart.GetComponent<Canvas>().enabled = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(restartLevelYes);
    }
    public void MainMenuButton()
    {
        canvas1.GetComponent<Canvas>().enabled = false;
        areYouSureMainMenu.GetComponent<Canvas>().enabled = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainMenuYes);
    }

    public void No()
    {
        areYouSureRestart.GetComponent<Canvas>().enabled = false;
        areYouSureMainMenu.GetComponent<Canvas>().enabled = false;
        canvas1.GetComponent<Canvas>().enabled = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(lastCheckPoint);        
    }

    public void JumpToMainMenu()
    {
        string path = Application.persistentDataPath + "/player.verysnooty";
        File.Delete(path);
        SceneManager.LoadScene("MenuPostIntro");
    }
    
    public void RestartLevel()
    {
        string path = Application.persistentDataPath + "/player.verysnooty";
        File.Delete(path);
    }
}
