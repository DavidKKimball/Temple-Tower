using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ControlsMainMenu : MonoBehaviour
{
    public GameObject MainMenu1;
    public GameObject newGameButton;
    public GameObject MainMenu2;
    public GameObject resumeGameButton;
    public GameObject menuHolder;
    public MenuManager menuManager;
    public GameObject Controls;
    public GameObject backButton;
    // Start is called before the first frame update
    void Start()
    {
        menuHolder = GameObject.Find("EventSystem");
        menuManager = menuHolder.GetComponent<MenuManager>();
    }

    public void ControlsButton()
    {
        MainMenu1.GetComponent<Canvas>().enabled = false;
        MainMenu2.GetComponent<Canvas>().enabled = false;

        Controls.GetComponent<Canvas>().enabled = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backButton);        
    }

    public void BackButton()
    {
        Controls.GetComponent<Canvas>().enabled = false;

        if (menuManager.newGame)
        {
            MainMenu1.GetComponent<Canvas>().enabled = true;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(newGameButton);  
        }
        else
        {
            MainMenu2.GetComponent<Canvas>().enabled = true;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(resumeGameButton);
        }
    }
}
