using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuToCredits : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject firstObject;

    public void ChangeToCredits()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstObject, null);
        credits.SetActive(true);
        mainMenu.SetActive(false);
    }
}
