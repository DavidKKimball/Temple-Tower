using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsToMenu : MonoBehaviour
{
    public GameObject newGameCanvas;
    public GameObject loadGameCanvas;
    public GameObject newGameButton;
    public GameObject loadGameButton;
    public MenuManager menuManager;
    public GameObject credits;
    public GameObject firstObject;

    public void ChangeToCredits()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstObject, null);
        if (menuManager.newGame == true)
        {
            newGameCanvas.GetComponent<Canvas>().enabled = true;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(newGameButton);
        }
        else
        {
            loadGameCanvas.GetComponent<Canvas>().enabled = true;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(loadGameButton);
        }
        credits.GetComponent<Canvas>().enabled = false;
        gameObject.GetComponent<Canvas>().enabled = false;
    }
}
