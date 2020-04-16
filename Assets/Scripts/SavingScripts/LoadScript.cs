using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{

    public void LoadPlayerLevel()
    {
        PlayerData data = SaveScript.LoadPlayer();

        if (data != null)
            SceneManager.LoadScene(data.level + 1);
        else
            SceneManager.LoadScene(3);
    }

    public void LoadPlayerLevelFromCheckpoint()
    {
        PlayerData data = SaveScript.LoadFromCheckPoint();

        if (data != null)
            SceneManager.LoadScene(data.level);
        else
            LoadPlayerLevel();
    }
}
