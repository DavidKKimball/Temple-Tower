using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuToCredits : MonoBehaviour
{
    public GameObject newGameCanvas;
    public GameObject loadGameCanvas;
    public MenuManager menuManager;
    public GameObject credits; 

    public GameObject firstObject;

    public void ChangeToCredits()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstObject, null);
        credits.GetComponent<Canvas>().enabled = true;
        if (menuManager.newGame == true)
            newGameCanvas.GetComponent<Canvas>().enabled = false;
        else
            loadGameCanvas.GetComponent<Canvas>().enabled = false;
    }
}
