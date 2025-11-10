using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPlaying { get; private set; }
    //private bool isPaused = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //            DontDestroyOnLoad(this);
        }
        isPlaying = false;
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
        isPlaying = true;
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
        isPlaying = false;
    }
}
