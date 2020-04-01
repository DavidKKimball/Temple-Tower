using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{

    public void LoadPlayerLevel()
    {
        PlayerData data = SaveScript.LoadPlayer();

        SceneManager.LoadScene(data.level);
    }
}
