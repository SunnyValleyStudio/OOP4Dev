using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public int mainMenuSceneIndex, level1SceneIndex;

    public void LoadMenu()
    {
        LoadScene(mainMenuSceneIndex);
    }

    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadLevel()
    {
        LoadScene(level1SceneIndex);
    }

    public void RestartLevel()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
