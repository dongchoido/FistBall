using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PausePanel pausePanel;
    public SettingPanel settingPanel;
    public RatioPanel ratioPanel;
    [SerializeField] Button pauseButton;
    public  Slider musicSlider;
    public Slider sfxSlider;
    [SerializeField] AudioClip clickSFX;
    public static UIManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;  
    }
    void Start()
    {
        musicSlider.value = SoundManager.Instance.MusicVolume;
        sfxSlider.value = SoundManager.Instance.SFXVolume;

        musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        ratioPanel.Popup(true);
    }
    public void ShowPausePanel()
    {
        pausePanel.gameObject.SetActive(true);
        ratioPanel.gameObject.SetActive(false);
        GameManager.instance.PauseGame();
        pausePanel.Popup(true);
        pauseButton.interactable = false;
    }
    public void HidePausePanel()
    {
        GameManager.instance.UnPauseGame();
        ratioPanel.gameObject.SetActive(true);
        pausePanel.Popup(false);
        pauseButton.interactable = true;
        ratioPanel.Popup(true);
    }
    public void ShowSettingPanel()
    {
        settingPanel.gameObject.SetActive(true);
        pausePanel.gameObject.SetActive(false);
        settingPanel.Popup(true);
    }
    public void HideSettingPanel()
    {
        settingPanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(true);
        pausePanel.Popup(true);
    }
     void OnMusicVolumeChanged(float value)
    {
        SoundManager.Instance.SetMusicVolume(value);
    }

    void OnSFXVolumeChanged(float value)
    {
        SoundManager.Instance.SetSFXVolume(value);
    }
    public void Click()
    {
        SoundManager.Instance.PlaySFX(clickSFX);
    }
    public void UpdateRatio()
    {
        ratioPanel.UpdateRatio();
    }
    public void PlayGame()
    {
        GameManager.instance.LoadGamePlayScene();
    }
    public void BackToMenu()
    {
        GameManager.instance.LoadMainMenuScene();
    }
}
