using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //private bool isPaused = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
//            DontDestroyOnLoad(this);
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1f;
    }
    public void LoadGamePlayScene()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
